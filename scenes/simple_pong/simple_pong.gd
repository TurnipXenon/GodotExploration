class_name SimplePong
extends Node

export(PackedScene) var pong_round_scene

var pong_meta: SimplePongMeta
var pong_round: PongRound


static func get_scene_path() -> String:
	return "res://scenes/simple_pong/SimplePong.tscn"


func _ready():
	pong_meta = SceneUtil.current_args[SceneUtil.KEY_SIMPLE_PONG]

	assert(pong_round_scene != null)

	start_round()

	# todo(turnip): show score

	# todo(turnip): countdown

	# todo(turnip): start ball


func start_round():
	pong_round = pong_round_scene.instance()
	pong_round.initialize(pong_meta, self)
	add_child(pong_round)


func end_round():
	# todo(turnip): add delay over here
	pong_round.queue_free()
	start_round()
