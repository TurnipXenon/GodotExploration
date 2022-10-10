class_name PaddleBehavior
extends Node

# Serves as an interface


func initialize(_paddle: PaddleController) -> void:
	pass


func act(_paddle: PaddleController, _delta: float) -> Vector2:
	return Vector2.ZERO
