class_name SimplePongMeta

var pong_mode = GameConstants.PongMode.MULTIPLAYER
var player_list: Array = []  # array of PongPlayers
var max_score = 3


static func get_resource() -> Resource:
	return load("res://Scenes/simple_pong/simple_pong_meta.gd")


func is_done() -> bool:
	for p in player_list:
		var player: PongPlayer = p
		if player.score >= max_score:
			return true
	return false


func to_dictionary() -> Dictionary:
	return {SceneUtil.KEY_SIMPLE_PONG: self}
