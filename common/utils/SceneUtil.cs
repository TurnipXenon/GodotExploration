using Godot;
using Godot.Collections;

namespace GodotExploration.Common.Utils;

public partial class SceneUtil : Node
{
	private Node currentScene = null;
	private Dictionary<string, Object> currentArgs = new();

	private static SceneUtil singleton;
	/**
	 * We just need the caller to get the root
	 */
	public static SceneUtil GetSingleton(Node caller)
	{
		if (singleton != null)
			return singleton;

		singleton = new SceneUtil();
		var root = caller.GetTree().Root;
		singleton.currentScene = root.GetChild(root.GetChildCount() - 1);
		root.AddChild(singleton);
		return singleton;
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
		currentArgs = args;
		// The solution is to defer the load to a later time, when
		// we can be sure that no code from the current scene is running:
		CallDeferred("DeferredGoToScene", path);
	}

	// ReSharper disable once UnusedMember.Local
	private void DeferredGoToScene(string path)
	{
		currentScene.Free();
		
		// Load the new scene
		// Ref: https://godotengine.org/qa/19380/how-to-instance-a-scene-in-c%23
		var s = (PackedScene)ResourceLoader.Load(path);
		
		// Instance the new scene
		currentScene = s.Instantiate();
		
		// Add it to the active scene, as child of root
		GetTree().Root.AddChild(currentScene);
		
		// Optionally, to make it compatible with the SceneTree.ChangeSceneToFile API
		GetTree().CurrentScene = currentScene;
	}
}
