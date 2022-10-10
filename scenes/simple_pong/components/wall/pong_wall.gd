class_name PongWall
extends Node

var fn: FuncRef
var player: PongPlayer


func hit():
	if fn:
		player.score += 1
		fn.call_func()
	else:
		assert("Func ref for wall %s not set" % name)
