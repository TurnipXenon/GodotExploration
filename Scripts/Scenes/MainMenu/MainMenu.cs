using Godot;
using GodotExploration.Scripts.Common;
using GodotExploration.Scripts.Common.Utils;

namespace GodotExploration.Scripts.Scenes.MainMenu;

public partial class MainMenu : Node
{
	private void OnPongButtonPressed()
	{
		SceneUtil.GetSingleton(this).GoToScene(ResourcePaths.SimplePong.Menu.PongMenuScene, null);
	}
	
	private void OnBreakoutButtonPressed()
	{
		SceneUtil.GetSingleton(this).GoToScene(ResourcePaths.Breakout.BreakoutMenu.BreakoutMenuScene, null);
	}
}