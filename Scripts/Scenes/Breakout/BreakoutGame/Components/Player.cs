using System.Diagnostics;
using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components;

public partial class Player : Node
{
	[Export]
	public Ball Ball;

	[Export]
	public PaddlePawn Paddle;

	[Export]
	public Augmentions Augmentions;

	public override void _Ready()
	{
		Debug.Assert(Ball != null);
		Debug.Assert(Paddle != null);
		Debug.Assert(Augmentions != null);
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("enter"))
		{
			Ball.StartBall(Paddle.GetRunningTime(), Paddle.IsGoingRight());
		}
		
		var inputValue = Vector2.Zero;
		inputValue.x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		Paddle.SetInput(inputValue);
	}

	public void Reinitialize(BreakoutRound breakoutRound)
	{
		Paddle = Paddle.Reinitialize();
		breakoutRound.AddChild(Paddle);
		
		Ball = Ball.Reinitialize(Paddle);
		breakoutRound.AddChild(Ball);

		Augmentions = Augmentions.Reinitialize();
		breakoutRound.AddChild(Augmentions);
	}
}