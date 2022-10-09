class_name PongMenu
extends Node


static func get_scene_path() -> String:
	return "res://scenes/simple_pong/menu/PongMenu.tscn"


func _on_SinglePlayerButton_pressed():
	var meta = SimplePongMeta.get_resource()
	var meta_obj = meta.new()
	meta_obj.pong_mode = GameConstants.PongMode.SINGLEPLAYER
	SceneUtil.goto_scene(SimplePong.get_scene_path(), meta_obj.to_dictionary())


func _on_MultiplayerButton_pressed():
	var meta = SimplePongMeta.get_resource()
	var meta_obj = meta.new()
	meta_obj.pong_mode = GameConstants.PongMode.MULTIPLAYER
	SceneUtil.goto_scene(SimplePong.get_scene_path(), meta_obj.to_dictionary())
