using Godot;
using GodotExploration.Common.Utils;
using GodotExploration.Scripts.Common;

namespace GodotExploration.Scripts.Scenes.MainMenu;

public partial class MainMenu : Node
{
	private void OnButtonClicked()
	{
		SceneUtil.GetSingleton(this).GoToScene(ResourcePaths.SimplePong.Menu.PongMenuScene, null);
	}
}