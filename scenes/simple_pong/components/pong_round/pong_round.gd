class_name PongRound
extends Node

export(Array, Resource) var player_objects
export(NodePath) var ball_path

var pong_meta: SimplePongMeta
var ball: BallController


func _ready():
	assert(ball_path != null)
	ball = get_node(ball_path)


func initialize(pong_meta_: SimplePongMeta) -> void:
	assert(len(player_objects) == len(pong_meta_.player_list))
	pong_meta = pong_meta_
	var player_list = pong_meta.player_list
	var fn = funcref(self, "inform_done")

	for ind in player_objects.size():
		var paddle = get_node(player_objects[ind].paddle_controller)
		paddle.set_behavior(player_list[ind].behavior)
		get_node(player_objects[ind].wall).fn = fn


func inform_done():
	ball.should_stop = true
