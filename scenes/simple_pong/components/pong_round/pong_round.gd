class_name PongRound
extends Node

@export var score_delay_duration: float = 3.0
@export var player_objects: Array[Resource]  # (Array, Resource)
@export var ball_path: NodePath
@export var score_path: NodePath

var pong_meta: SimplePongMeta
var ball: BallController
var game
var score

@onready var timer = $Timer


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

	for ind in player_objects.size():
		var player_object: PongPlayerObject = player_objects[ind]
		var player_meta: PongPlayer = player_list[ind]
		var paddle = get_node(player_object.paddle_controller)
		paddle.set_behavior(player_meta.behavior)
		var wall = get_node(player_object.wall)
		wall.fn = inform_done
		wall.player = player_meta


func inform_done():
	ball.should_stop = true
	score.show_score(pong_meta)
	score.show()
	timer.wait_time = score_delay_duration
	timer.start()
	# gdlint:ignore = expression-not-assigned
	await timer.timeout
	score.hide()
	game.end_round()
