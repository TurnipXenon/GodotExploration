class_name PaddleKeyboardInput
extends Node

var up_key: String = "ui_up"
var down_key: String = "ui_down"


static func get_resource() -> Resource:
	return load("res://scenes/simple_pong/components/paddle/behavior/paddle_keyboard_input.gd")


func initialize(paddle: PaddleController) -> void:
	var prefix: String = InputUtil.get_prefix(paddle.control_scheme)
	up_key = "%s_up" % prefix
	down_key = "%s_down" % prefix


func act(paddle: PaddleController, delta: float) -> Vector2:
	var input_value: Vector2 = Vector2.ZERO
	input_value.y = Input.get_action_strength(down_key) - Input.get_action_strength(up_key)
	return input_value * delta * paddle.input_strength
