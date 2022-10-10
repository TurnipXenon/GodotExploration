class_name PongWall
extends Node

var fn: FuncRef


func hit():
	if fn:
		fn.call_func()
	else:
		assert("Func ref for wall %s not set" % name)
