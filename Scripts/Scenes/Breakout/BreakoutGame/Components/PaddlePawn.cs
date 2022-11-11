using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components;

public partial class PaddlePawn : CharacterBody2D, IBallHittable
{
    [Export]
    public float InputStrength = 4.0f;

    [Export]
    public float BallInfluence = 0.25f;

    [Export]
    public float PaddleMinX = 20f;

    [Export]
    public float PaddleMaxX = 400f;

    private const float widthMultiplier = 40f;
    private Vector2 _currentInput;
    private Vector2 _startingPosition;
    private double _runningTime;

    public override void _Ready()
    {
        _startingPosition = Position;
    }


    public override void _PhysicsProcess(double delta)
    {
        // clamp the value within a range based on the walls and the scale of the paddle
        var movementDelta = _currentInput.x * (float)delta * InputStrength;
        var newPosition = Position;
        var limit = Mathf.Max(0f, (Scale.x - 1f) / 2f) * widthMultiplier;
        newPosition.x = Mathf.Clamp(
            newPosition.x + movementDelta,
            PaddleMinX + limit,
            PaddleMaxX - limit);
        Position = newPosition;

        if (_currentInput != Vector2.Zero)
        {
            _runningTime += delta;
        }
        else
        {
            _runningTime = 0;
        }
    }

    public void SetInput(Vector2 input)
    {
        _currentInput = input;
    }

    public PaddlePawn Reinitialize()
    {
        var duplicate = (PaddlePawn)Duplicate();
        duplicate.Position = _startingPosition;
        QueueFree();
        return duplicate;
    }

    public void OnBallHit(Ball ball)
    {
        ball.InfluenceHorizontal(_currentInput.x * BallInfluence);
    }

    public float GetRunningTime()
    {
        return (float)_runningTime;
    }

    public bool IsGoingRight()
    {
        return _currentInput.x > 0f;
    }
}