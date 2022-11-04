using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components.Augmentation;

public partial class AugmentationManager : Node, AugmentationManager.ICallback
{
	public interface ICallback
	{
		public void ActivateAugmentation(PackedScene augmentationShell);
	}

	public AugmentationManager Reinitialize()
	{
		var duplicate = (AugmentationManager)Duplicate();
		QueueFree();
		return duplicate;
	}

	public void ActivateAugmentation(PackedScene augmentationShell)
	{
		GD.Print("Activate augmentation: ", augmentationShell);
		var newAugmentation = (AugmentationBase)augmentationShell.Instantiate();
		newAugmentation.Yell();
	}
}