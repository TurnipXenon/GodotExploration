class_name PaddleController
extends KinematicBody2D

export(float) var input_strength = 4.0
export(GameEnums.ControlScheme) var control_scheme = GameEnums.ControlScheme.PLAYER
export(Script) var behavior_script

var behavior = null


func _ready():
	assert(behavior_script != null)
	behavior = behavior_script.new()
	assert(behavior.has_method("initialize"))
	assert(behavior.has_method("act"))
	behavior.initialize(self)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	# warning-ignore:return_value_discarded
	move_and_collide(behavior.act(self, delta))
