class_name SimplePongMeta

var pong_mode = GameConstants.PongMode.MULTIPLAYER


static func get_resource() -> Resource:
	return load("res://scenes/simple_pong/simple_pong_meta.gd")


func to_dictionary() -> Dictionary:
	return {SceneUtil.KEY_PONG_MODE: pong_mode}
