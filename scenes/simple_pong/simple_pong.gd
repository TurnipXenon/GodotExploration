class_name SimplePong
extends Node

@export var pong_round_scene: PackedScene

var pong_meta: SimplePongMeta
var pong_round: PongRound


static func get_scene_path() -> String:
	return "res://scenes/simple_pong/SimplePong.tscn"


func _ready() -> void:
	pong_meta = SceneUtil.current_args[SceneUtil.KEY_SIMPLE_PONG]

	assert(pong_round_scene != null)

	start_round()


func start_round() -> void:
	pong_round = pong_round_scene.instantiate()
	pong_round.initialize(pong_meta, self)
	add_child(pong_round)


func end_round() -> void:
	if pong_meta.is_done():
		SceneUtil.goto_scene(GameConstants.PONG_MENU_SCENE_PATH)
		return

	pong_round.queue_free()
	start_round()
