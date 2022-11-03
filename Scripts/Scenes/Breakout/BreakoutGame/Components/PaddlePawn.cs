using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components;

public partial class PaddlePawn : CharacterBody2D, IBallHittable
{
    [Export]
    public float InputStrength = 4.0f;

    [Export]
    public float BallInfluence = 0.25f;

    private Vector2 _currentInput;
    private Vector2 _startingPosition;
    private double _runningTime;

    public override void _Ready()
    {
        _startingPosition = Position;
    }


    public override void _Process(double delta)
    {
        MoveAndCollide(_currentInput * (float)delta * InputStrength);

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
        ball.InfluenceDirection(_currentInput.x * BallInfluence);
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