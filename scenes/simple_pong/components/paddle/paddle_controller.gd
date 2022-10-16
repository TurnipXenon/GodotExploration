class_name PaddleController
extends CharacterBody2D

enum BehaviorType { HUMAN, AI }

#gdlint:disable = class-definitions-order
@export var input_strength: float = 4.0
@export var behavior_type: BehaviorType = BehaviorType.HUMAN
@export var control_scheme = GameConstants.ControlScheme.PLAYER  # (GameConstants.ControlScheme)
@export var behavior_script: Script

var behavior = null
#gdlint:enable = class-definitions-order


func set_behavior(behavior_):
	behavior = behavior_
	behavior.initialize(self)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	# warning-ignore:return_value_discarded
	move_and_collide(behavior.act(self, delta))
