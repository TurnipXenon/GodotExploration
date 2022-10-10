class_name SimplePong
extends Node

export(PackedScene) var pong_round_scene

var pong_meta: SimplePongMeta


static func get_scene_path() -> String:
	return "res://scenes/simple_pong/SimplePong.tscn"


func _ready():
	pong_meta = SceneUtil.current_args[SceneUtil.KEY_SIMPLE_PONG]

	assert(pong_round_scene != null)
	var pong_round: PongRound = pong_round_scene.instance()
	pong_round.initialize(pong_meta)
	add_child(pong_round)

	# todo(turnip): prepare scene
	# todo(turnip): show score
	# todo(turnip): countdown
	# todo(turnip): start ball
	pass

# todo(turnip): receive signal that the ball touched the wall
# todo(turnip): increment score
