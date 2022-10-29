using Godot;
using Godot.Collections;

namespace GodotExploration.Scripts.Common.Utils;

public partial class SceneUtil : Node
{
	private Node _currentScene = null;
	private Dictionary<string, Object> _currentArgs = new();

	private static SceneUtil _singleton;
	/**
	 * We just need the caller to get the root
	 */
	public static SceneUtil GetSingleton(Node caller)
	{
		if (_singleton != null)
			return _singleton;

		_singleton = new SceneUtil();
		var root = caller.GetTree().Root;
		_singleton._currentScene = root.GetChild(root.GetChildCount() - 1);
		root.AddChild(_singleton);
		return _singleton;
	}

	/**
	 * This function will usually be called from a signal callback,
	 * or some other function in the current scene.
	 * Deleting the current scene at this point is
	 * a bad idea, because it may still be executing code.
	 * This will result in a crash or unexpected behavior.
	 */
	public void GoToScene(string path, Dictionary<string, Object> args)
	{
		_currentArgs = args;
		// The solution is to defer the load to a later time, when
		// we can be sure that no code from the current scene is running:
		CallDeferred("DeferredGoToScene", path);
	}

	// ReSharper disable once UnusedMember.Local
	private void DeferredGoToScene(string path)
	{
		_currentScene.Free();

		// Load the new scene
		// Ref: https://godotengine.org/qa/19380/how-to-instance-a-scene-in-c%23
		var s = (PackedScene)ResourceLoader.Load(path);

		// Instance the new scene
		_currentScene = s.Instantiate();

		// Add it to the active scene, as child of root
		GetTree().Root.AddChild(_currentScene);

		// Optionally, to make it compatible with the SceneTree.ChangeSceneToFile API
		GetTree().CurrentScene = _currentScene;
	}
}
