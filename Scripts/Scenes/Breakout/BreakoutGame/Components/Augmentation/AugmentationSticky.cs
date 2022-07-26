﻿using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components.Augmentation;

public partial class AugmentationSticky : AugmentationBase
{
    private bool _isSticky;

    public override bool IsDone()
    {
        return base.IsDone() && !_isSticky;
    }

    public override void Initialize(Player.ICallback player)
    {
        base.Initialize(player);
        foreach (var ball in player.GetBallList())
        {
            ball.BallHitPaddle += OnPaddleHitBall;
            ball.BallStarted += OnBallStarted;
        }
    }

    private void OnBallStarted()
    {
        _isSticky = false;
    }

    private void OnPaddleHitBall(Ball ball)
    {
        if (IsDone())
        {
            return;
        }

        _isSticky = true;
        ball.Stop();
    }
}