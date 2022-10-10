class_name PongPlayer

var behavior: PaddleBehavior = null
var score: int = 0


static func get_resource() -> Resource:
	return load("res://scenes/simple_pong/components/pong_player.gd")


func _init(behavior: PaddleBehavior):
	self.behavior = behavior
