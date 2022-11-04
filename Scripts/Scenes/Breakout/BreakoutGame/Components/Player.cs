using System.Diagnostics;
using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components;

public partial class Player : Node, Player.ICallback
{
	public interface ICallback
	{
		public Ball GetBall();
		public PaddlePawn GetPaddle();
	}
	
	[Export]
	public Ball Ball;

	[Export]
	public PaddlePawn Paddle;

	[Export]
	public Augmentation.AugmentationManager AugmentationManager;

	public override void _Ready()
	{
		Debug.Assert(Ball != null);
		Debug.Assert(Paddle != null);
		Debug.Assert(AugmentationManager != null);
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

		AugmentationManager = AugmentationManager.Reinitialize();
		breakoutRound.AddChild(AugmentationManager);
	}

	public Ball GetBall()
	{
		return Ball;
	}

	public PaddlePawn GetPaddle()
	{
		return Paddle;
	}
}