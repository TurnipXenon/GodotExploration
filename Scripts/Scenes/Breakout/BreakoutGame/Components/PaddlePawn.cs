using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components;

public partial class PaddlePawn : CharacterBody2D
{
    [Export]
    public float InputStrength = 4.0f;


    public override void _Process(double delta)
    {
        var inputValue = Vector2.Zero;
        inputValue.x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
        MoveAndCollide(inputValue * (float)delta * InputStrength);
    }
}