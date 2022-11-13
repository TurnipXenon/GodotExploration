using System.Collections.Generic;
using System.Diagnostics;
using Godot;
using GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components.Augmentation;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components;

public partial class Player : Node, Player.ICallback
{
    public interface ICallback
    {
        public List<Ball> GetBallList();
        public PaddlePawn GetPaddle();
        public AugmentationManager.ICallback GetAugmentationManager();
        public Node2D GetNode2DRoot();
    }

    [Export]
    public Ball InitialBall;

    [Export]
    public PaddlePawn Paddle;

    [Export]
    public AugmentationManager AugmentationManager;

    private List<Ball> _ballList = new();
    private Node2D _node2dRoot;

    public override void _Ready()
    {
        Debug.Assert(InitialBall != null);
        Debug.Assert(Paddle != null);
        Debug.Assert(AugmentationManager != null);

        _ballList.Add(InitialBall);
        InitialBall = null;
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("enter"))
        {
            foreach (var ball in _ballList)
            {
                if (ball.StartBall(Paddle.GetRunningTime(), Paddle.IsGoingRight()))
                {
                    break;
                }
            }
        }

        var inputValue = Vector2.Zero;
        inputValue.x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
        Paddle.SetInput(inputValue);
    }

    public void Reinitialize(BreakoutRound breakoutRound)
    {
        // arrange by most dependent to least dependent
        AugmentationManager = AugmentationManager.Reinitialize();
        breakoutRound.AddChild(AugmentationManager);

        Paddle = Paddle.Reinitialize();
        breakoutRound.AddChild(Paddle);

        _ballList[0] = _ballList[0].Reinitialize(Paddle);
        breakoutRound.AddChild(_ballList[0]);
    }

    public List<Ball> GetBallList()
    {
        return _ballList;
    }

    public PaddlePawn GetPaddle()
    {
        return Paddle;
    }

    public AugmentationManager.ICallback GetAugmentationManager()
    {
        return AugmentationManager;
    }

    public Node2D GetNode2DRoot()
    {
        return _node2dRoot;
    }

    public void SetNode2DRoot(Node2D node2dRoot)
    {
        _node2dRoot = node2dRoot;
    }
}