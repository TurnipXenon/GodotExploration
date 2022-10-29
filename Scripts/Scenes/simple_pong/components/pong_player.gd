class_name PongPlayer

var behavior = null
var score: int = 0


func _init(behavior_):
	# todo(turnip): disable interface chacking for c# script
	# InterfacesUtil.implements_interface(behavior_, PaddleBehavior.get_interface_list())
	self.behavior = behavior_
