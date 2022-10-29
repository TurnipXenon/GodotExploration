using Godot;
using GodotExploration.Scripts.Common;
using GodotExploration.Scripts.Common.Utils;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutMenu;

public partial class BreakoutMenu: Node
{
	private void OnBackButtonPressed()
	{
		SceneUtil.GetSingleton(this).GoToScene(ResourcePaths.MainMenu.MainMenuScene, null);
	}
}
