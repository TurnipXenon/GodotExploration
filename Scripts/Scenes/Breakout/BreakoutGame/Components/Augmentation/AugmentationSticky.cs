using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components.Augmentation;

public partial class AugmentationSticky : AugmentationBase
{
    public override void Yell()
    {
        GD.Print("I am Sticky");
    }
}