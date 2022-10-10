class_name SimplePongMeta

var pong_mode = GameConstants.PongMode.MULTIPLAYER
var player_list: Array = []  # array of PongPlayers


static func get_resource() -> Resource:
	return load("res://scenes/simple_pong/simple_pong_meta.gd")


func to_dictionary() -> Dictionary:
	return {SceneUtil.KEY_SIMPLE_PONG: self}
