using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components;

public partial class PaddlePawn : CharacterBody2D
{
    [Export]
    public float InputStrength = 4.0f;

    private Vector2 _currentInput;


    public override void _Process(double delta)
    {
        MoveAndCollide(_currentInput * (float)delta * InputStrength);
    }

    public void SetInput(Vector2 input)
    {
        _currentInput = input;
    }
}