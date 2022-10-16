class_name PongWall
extends Node

var fn: Callable
var player: PongPlayer


func hit():
	if fn:
		player.score += 1
		fn.call()
	else:
		assert("Func ref for wall %s not set" % name)
