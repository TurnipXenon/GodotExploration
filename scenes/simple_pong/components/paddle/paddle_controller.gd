class_name PaddleController
extends KinematicBody2D

enum BehaviorType { HUMAN, AI }

export(float) var input_strength = 4.0
export(BehaviorType) var behavior_type = BehaviorType.HUMAN
export(GameConstants.ControlScheme) var control_scheme = GameConstants.ControlScheme.PLAYER
export(Script) var behavior_script

var behavior = null


func set_behavior(behavior_):
	behavior = behavior_
	behavior.initialize(self)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	# warning-ignore:return_value_discarded
	move_and_collide(behavior.act(self, delta))
