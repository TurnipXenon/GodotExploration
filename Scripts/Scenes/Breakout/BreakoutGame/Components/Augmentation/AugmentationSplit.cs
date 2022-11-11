namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components.Augmentation;

public partial class AugmentationSplit : AugmentationBase
{
    public override bool IsDone()
    {
        return true;
    }

    public override void Initialize(Player.ICallback player)
    {
        base.Initialize(player);
        
        // todo(turnip): split ball
        
    }
}