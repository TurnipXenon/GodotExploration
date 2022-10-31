using System.Diagnostics;
using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components;

public partial class Ball : CharacterBody2D
{
    [Export]
    public float BallSpeed = 1000f;

    [Export]
    public Vector2 MinVelocity = Vector2.One;

    [Export]
    public Vector2 MaxVelocity = Vector2.One * 5f;

    [Export]
    public float KillZoneY = 360f;

    [Export]
    public Node2D Follow;

    private bool _shouldStop = true;
    private Vector2 _currentVelocity;
    private RandomNumberGenerator _rng = new();

    [Signal]
    public delegate void BallWasDoneEventHandler();

    public override void _Ready()
    {
        Debug.Assert(Follow != null);
    }

    public override void _Process(double delta)
    {
        if (_shouldStop)
        {
            Position = new Vector2(Follow.Position.x, Position.y);
            return;
        }

        // judge
        if (Position.y > KillZoneY)
        {
            EmitSignal("BallWasDone");
            Free();
        }

        // move
        Velocity = _currentVelocity * (float)delta * BallSpeed;
        MoveAndSlide();
        if (GetSlideCollisionCount() > 0)
        {
            KinematicCollision2D collision2D = GetSlideCollision(0);
            if (collision2D != null)
            {
                _currentVelocity = _currentVelocity.Bounce(collision2D.GetNormal());
                // var collider = collision2D.GetCollider();
                // todo(turnip): make things react when you hit them
                // collider.HasMethod("Hit")?
            }
        }
    }

    public void StartBall()
    {
        _shouldStop = false;
        _currentVelocity = RandomizeVelocity();
    }

    private Vector2 RandomizeVelocity()
    {
        return new Vector2(
            _rng.RandfRange(MinVelocity.x, MaxVelocity.x),
            _rng.RandfRange(MinVelocity.y, MaxVelocity.y)
        );
    }

    private void Split()
    {
        // todo(turnip)
    }

    public void Stop()
    {
        // todo(turnip)
    }
}