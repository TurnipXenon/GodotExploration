using System.Collections.Generic;
using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components.Augmentation;

public partial class AugmentationManager : Node, AugmentationManager.ICallback
{
	private List<AugmentationBase> _augmentationList = new();
	private Player.ICallback _player;

	public interface ICallback
	{
		public void ActivateAugmentation(PackedScene augmentationShell);
	}

	public override void _Process(double delta)
	{
		for (int i = _augmentationList.Count - 1; i >= 0; i--)
		{
			if (_augmentationList[i].IsDone())
			{
				_augmentationList[i].Destroy();
				_augmentationList.RemoveAt(i);
			}
		}
	}

	public AugmentationManager Reinitialize()
	{
		var duplicate = (AugmentationManager)Duplicate();
		QueueFree();
		return duplicate;
	}

	public void ActivateAugmentation(PackedScene augmentationShell)
	{
		var newAugmentation = (AugmentationBase)augmentationShell.Instantiate();
		newAugmentation.Initialize(_player);
		_augmentationList.Add(newAugmentation);
		// todo: augmentations can merge
	}

	public void SetPlayerCallback(Player.ICallback player)
	{
		_player = player;
	}
}