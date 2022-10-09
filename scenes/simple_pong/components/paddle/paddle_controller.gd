class_name PaddleController
extends KinematicBody2D

enum BehaviorType { HUMAN, AI }

export(float) var input_strength = 4.0
export(BehaviorType) var behavior_type = BehaviorType.HUMAN
export(GameConstants.ControlScheme) var control_scheme = GameConstants.ControlScheme.PLAYER
export(Script) var behavior_script

var behavior = null


func _ready():
	if (
		control_scheme == GameConstants.ControlScheme.ENEMY
		and SceneUtil.KEY_PONG_MODE in SceneUtil.current_args
		and SceneUtil.current_args[SceneUtil.KEY_PONG_MODE] == GameConstants.PongMode.SINGLEPLAYER
	):
		behavior_script = load(
			"res://scenes/simple_pong/components/paddle/behavior/paddle_simple_ai.gd"
		)

	assert(behavior_script != null)
	behavior = behavior_script.new()
	assert(behavior.has_method("initialize"))
	assert(behavior.has_method("act"))
	behavior.initialize(self)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	# warning-ignore:return_value_discarded
	move_and_collide(behavior.act(self, delta))
