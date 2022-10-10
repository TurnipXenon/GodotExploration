class_name PongRound
extends Node

export(float) var score_delay_duration = 3.0
export(Array, Resource) var player_objects
export(NodePath) var ball_path
export(NodePath) var score_path

var pong_meta: SimplePongMeta
var ball: BallController
var game
var score

onready var timer = $Timer


func _ready():
	assert(ball_path != null)
	assert(score_path != null)
	ball = get_node(ball_path)
	score = get_node(score_path)
	score.hide()


func initialize(pong_meta_: SimplePongMeta, game_) -> void:
	assert(len(player_objects) == len(pong_meta_.player_list))

	game = game_
	pong_meta = pong_meta_
	var player_list = pong_meta.player_list
	var fn = funcref(self, "inform_done")

	for ind in player_objects.size():
		var player_object: PongPlayerObject = player_objects[ind]
		var player_meta: PongPlayer = player_list[ind]
		var paddle = get_node(player_object.paddle_controller)
		paddle.set_behavior(player_meta.behavior)
		var wall = get_node(player_object.wall)
		wall.fn = fn
		wall.player = player_meta


func inform_done():
	ball.should_stop = true
	score.show_score(pong_meta)
	score.show()
	timer.wait_time = score_delay_duration
	timer.start()
	yield(timer, "timeout")
	score.hide()
	game.end_round()
