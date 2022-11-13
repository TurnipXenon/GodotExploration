using System.Collections.Generic;
using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components.Augmentation;

public partial class AugmentationSplit : AugmentationBase
{
    private class BallPair
    {
        public Ball Ball;
        public float RotateBy;
    }
    
    [Export]
    public float SplitRadian = Mathf.Pi / 6;

    private bool _isDone = false;
    private readonly List<BallPair> _newBallList = new();

    public override bool IsDone()
    {
        return _isDone;
    }

    public override void _Ready()
    {
        // get the ball facing up; get the ball closest at the top (least Y)
        var ballList = Player.GetBallList();
        var bestBall = ballList[0];
        foreach (var currentBall in ballList)
        {
            // replace best ball if it is going down
            if (bestBall.Velocity.y > 0 && currentBall.Velocity.y < 0)
            {
                bestBall = currentBall;
                continue;
            }

            if (bestBall.Position.y > currentBall.Position.y)
            {
                bestBall = currentBall;
            }
        }

        // could be improved but I lost braincells already lol
        var newBall1 = (Ball)bestBall.Duplicate();
        _newBallList.Add(new BallPair {Ball = newBall1, RotateBy = SplitRadian});
        var newBall2 = (Ball)bestBall.Duplicate();
        _newBallList.Add(new BallPair {Ball = newBall2, RotateBy = -SplitRadian});

        CallDeferred("DeferredSetting", bestBall);
    }

    private void DeferredSetting(Ball referenceBall)
    {
        // Lessons:
        // There are points in the lifecycle when we should modify the game tree.
        // We always want to defer it at the end of a "game frame"
        // We have stuff like QueueFree and CallDeferred to do this

        // Ahh so i was using velocity and not direction, it becomes normal once it collides

        foreach (var ballPair in _newBallList)
        {
            var newBall = ballPair.Ball;
            Player.GetBallList().Add(newBall);
            Player.GetNode2DRoot().AddChild(newBall);
            newBall.Position = referenceBall.Position;
            newBall.ForceDirection(referenceBall, ballPair.RotateBy);
            newBall.ForceStart();
        }

        _isDone = true;
    }
}