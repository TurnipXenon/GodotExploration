class_name SimplePongMeta

# var PongPlayerResource = PongPlayer.get_resource()

var pong_mode = GameConstants.PongMode.MULTIPLAYER
var player_list: Array = []  # array of PongPlayers


static func get_resource() -> Resource:
	return load("res://scenes/simple_pong/simple_pong_meta.gd")


func to_dictionary() -> Dictionary:
	return {SceneUtil.KEY_PONG_MODE: pong_mode}
