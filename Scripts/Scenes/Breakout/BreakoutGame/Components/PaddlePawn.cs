using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components;

public partial class PaddlePawn : CharacterBody2D
{
    [Export]
    public float InputStrength = 4.0f;

    private Vector2 _currentPosition;
    private Vector2 _startingPosition;

    public override void _Ready()
    {
        _startingPosition = Position;
    }


    public override void _Process(double delta)
    {
        MoveAndCollide(_currentPosition * (float)delta * InputStrength);
    }

    public void SetInput(Vector2 input)
    {
        _currentPosition = input;
    }

    public PaddlePawn Reinitialize()
    {
        var duplicate = (PaddlePawn)Duplicate();
        duplicate.Position = _startingPosition;
        QueueFree();
        return duplicate;
    }
}