using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame;

public partial class BreakoutGame : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Port to C#
		// pong_meta = SceneUtil.current_args[SceneUtil.KEY_SIMPLE_PONG]
		// assert(pong_round_scene != null)
		// start_round()
	}
	
	// Port to C#
	// func start_round() -> void:
	// pong_round = pong_round_scene.instantiate()
	// 	pong_round.initialize(pong_meta, self)
	// add_child(pong_round)
	//
	//
	// func end_round() -> void:
	// if pong_meta.is_done():
	// SceneUtil.goto_scene(GameConstants.PONG_MENU_SCENE_PATH)
	// return
	//
	// pong_round.queue_free()
	// 	start_round()
}