class_name PongPlayer

var behavior = null
var score: int = 0


static func get_resource() -> Resource:
	return load("res://scenes/simple_pong/components/pong_player.gd")


func _init(behavior_):
	InterfacesUtil.implements_interface(behavior_, PaddleBehavior.get_interface_list())
	self.behavior = behavior_
