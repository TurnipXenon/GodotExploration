using System.Diagnostics;
using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components;

public partial class Player : Node
{
	[Export]
	public Ball Ball;

	[Export]
	public PaddlePawn Paddle;

	public override void _Ready()
	{
		Debug.Assert(Ball != null);
		Debug.Assert(Paddle != null);
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("enter"))
		{
			Ball.StartBall();
		}
		
		var inputValue = Vector2.Zero;
		inputValue.x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		Paddle.SetInput(inputValue);
	}
}