class_name PaddleSimpleAI
extends Node


static func get_resource() -> Resource:
	return load("res://scenes/simple_pong/components/paddle/behavior/paddle_simple_ai.gd")


func initialize(_paddle: PaddleController) -> void:
	pass


func act(_paddle: PaddleController, _delta: float) -> Vector2:
	return Vector2.ZERO
