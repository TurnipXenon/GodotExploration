using System;
using System.Diagnostics;
using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components;

public partial class Ball : CharacterBody2D
{
    [Export]
    public float BallSpeed = 1000f;

    [Export]
    public float KillZoneY = 360f;

    [Export]
    public float MinimumHorizontalRadian = Mathf.Pi / 7f;

    [Export]
    public float MinimumVerticalRadian = Mathf.Pi / 7f;

    [Export]
    public Node2D Follow;

    [Signal]
    public delegate void BallWasDoneEventHandler();

    private bool _shouldStop = true;
    private Vector2 _currentDirection;
    private RandomNumberGenerator _rng = new();
    private Vector2 _startingPosition;
    private bool _isDone = false;

    public override void _Ready()
    {
        Debug.Assert(Follow != null);
        _startingPosition = Position;
        _rng.Randomize();
    }

    public override void _Process(double delta)
    {
        if (_isDone)
        {
            return;
        }

        if (_shouldStop)
        {
            Position = new Vector2(Follow.Position.x, Position.y);
            return;
        }

        // judge
        if (Position.y > KillZoneY)
        {
            EmitSignal(SignalName.BallWasDone);
            _isDone = true;
            return;
        }

        // move
        Velocity = _currentDirection * (float)delta * BallSpeed;

        MoveAndSlide();
        if (GetSlideCollisionCount() > 0)
        {
            KinematicCollision2D collision2D = GetSlideCollision(0);
            if (collision2D != null)
            {
                _currentDirection = _currentDirection.Bounce(collision2D.GetNormal()).Normalized();
                var collider = collision2D.GetCollider();
                var ballHittable = collider as IBallHittable;
                ballHittable?.OnBallHit(this);
            }
        }
    }

    public void StartBall()
    {
        _shouldStop = false;
        _currentDirection = RandomizeInitialDirection();
    }

    private Vector2 RandomizeInitialDirection()
    {
        var baseRadian = MinimumHorizontalRadian;
        if (_rng.Randf() > 0.5f)
        {
            baseRadian = Mathf.Pi + MinimumVerticalRadian;
        }

        var radian = _rng.RandfRange(baseRadian, Mathf.Pi - (MinimumHorizontalRadian + MinimumVerticalRadian));

        return Vector2.Right.Rotated(radian).Normalized();
    }

    private void Split()
    {
        // todo(turnip)
    }

    public void Stop()
    {
        // todo(turnip)
    }

    public Ball Reinitialize(PaddlePawn paddlePawn)
    {
        var duplicate = (Ball)Duplicate();
        GD.Print(_startingPosition);
        duplicate.Position = _startingPosition;
        duplicate.Follow = paddlePawn;
        QueueFree();
        return duplicate;
    }
}