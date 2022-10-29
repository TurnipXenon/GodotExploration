using Godot;
using GodotExploration.Common;
using GodotExploration.Common.Utils;

namespace GodotExploration.Scenes.MainMenu;

public partial class MainMenu : Node
{
	private void OnButtonClicked()
	{
		SceneUtil.GetSingleton(this).GoToScene(Paths.PathPongMenu, null);
	}
}