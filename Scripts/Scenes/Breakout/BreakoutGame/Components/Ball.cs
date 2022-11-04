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

    [Signal]
    public delegate void BallHitPaddleEventHandler(Ball ball);

    [Signal]
    public delegate void BallStartedEventHandler();

    private bool _shouldStop = true;
    private Vector2 _currentDirection;
    private RandomNumberGenerator _rng = new();
    private Vector2 _startingPosition;
    private bool _isDone = false;
    private float _freezeXOffset;

    public override void _Ready()
    {
        Debug.Assert(Follow != null);
        _startingPosition = Position;
        _rng.Randomize();
    }

    public override void _PhysicsProcess(double delta)
    {
        if (_isDone)
        {
            return;
        }

        if (_shouldStop)
        {
            Position = new Vector2(Follow.Position.x + _freezeXOffset, Position.y);
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
                
                if (collider is PaddlePawn)
                {
                    GD.Print("Hit paddle!");
                    EmitSignal(SignalName.BallHitPaddle, this);
                }
            }
        }
    }

    public void StartBall(float runningTime, bool isGoingRight)
    {
        _shouldStop = false;
        EmitSignal(SignalName.BallStarted);
        _currentDirection = RandomizeInitialDirection(runningTime, isGoingRight);
    }

    private Vector2 RandomizeInitialDirection(float runningTime, bool isGoingRight)
    {
        var rad = Mathf.Clamp(runningTime,
            MinimumVerticalRadian,
            (Mathf.Pi / 2f) - MinimumHorizontalRadian);
        var newVector = Vector2.Up.Rotated(rad * (isGoingRight ? 1f : -1f));
        var newV = SnapDirection(newVector);
        return newV;
    }

    private void Split()
    {
        // todo(turnip)
    }

    public void Stop()
    {
        // stop at the x-axis
        _freezeXOffset = Position.x - Follow.Position.x;
        _shouldStop = true;
    }

    public Ball Reinitialize(PaddlePawn paddlePawn)
    {
        var duplicate = (Ball)Duplicate();
        duplicate.Position = _startingPosition;
        duplicate.Follow = paddlePawn;
        QueueFree();
        return duplicate;
    }

    public void InfluenceHorizontal(float influenceHorizontal)
    {
        if (influenceHorizontal == 0)
        {
            return;
        }

        var newDirection = _currentDirection;
        newDirection.x = influenceHorizontal;
        newDirection = newDirection.Normalized();
        _currentDirection = SnapDirection(newDirection);
    }

    public void InfluenceHorizontalByMultiplication(float mulitiplier)
    {
        _currentDirection.x *= mulitiplier;
        _currentDirection = _currentDirection.Normalized();
        _currentDirection = SnapDirection(_currentDirection);
    }

    private Vector2 SnapDirection(Vector2 direction)
    {
        // Prevent division by zero
        var processedDirection = direction;
        if (direction.x == 0)
        {
            processedDirection.x = 0.1f;
        }

        if (direction.y == 0)
        {
            processedDirection.y = 0.1f;
        }

        // Remember which Quadrant we were using the following matrix
        // | +/-1  0  |
        // |  0  +/-1 |
        var originalQuadrant = new Transform2D(
            processedDirection.x / Mathf.Abs(processedDirection.x), 0f,
            0f, processedDirection.y / Mathf.Abs(processedDirection.y),
            0f, 0f);

        // Force to Quadrant I
        var q1 = processedDirection * originalQuadrant;

        // Do snapping logic on Quadrant I
        // Clamp between minimum acute angle and maximum acute angle (90deg - MinimumVerticalRadian)
        var rad = Mathf.Clamp(q1.Angle(),
            MinimumHorizontalRadian,
            (Mathf.Pi / 2f) - MinimumVerticalRadian);
        q1 = Vector2.Right.Rotated(rad);

        // Convert back to original Quadrant
        return q1 * originalQuadrant;
    }
}