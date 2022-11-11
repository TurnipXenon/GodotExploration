using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components.Augmentation;

public abstract partial class AugmentationBase : Node
{
    [Export]
    public double Duration = 6 * 1000;


    private double _endTime = 0;
    protected Player.ICallback Player;

    public virtual bool IsDone()
    {
        return Time.GetTicksMsec() > _endTime;
    }

    public virtual void Initialize(Player.ICallback player)
    {
        Player = player;
        _endTime = Time.GetTicksMsec() + Duration;
    }

    public virtual void Destroy()
    {
        QueueFree();
    }
}