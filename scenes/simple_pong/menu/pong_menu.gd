class_name PongMenu
extends Node


static func get_scene_path() -> String:
	return "res://scenes/simple_pong/menu/PongMenu.tscn"


func _on_SinglePlayerButton_pressed():
	var meta_obj = SimplePongMeta.new()
	meta_obj.pong_mode = GameConstants.PongMode.SINGLEPLAYER
	meta_obj.player_list = [
		PongPlayer.new(PaddleKeyboardInput.new()),
		PongPlayer.new(PaddleSimpleAI.new()),
	]
	SceneUtil.goto_scene(SimplePong.get_scene_path(), meta_obj.to_dictionary())


func _on_MultiplayerButton_pressed():
	var meta_obj = SimplePongMeta.new()
	meta_obj.pong_mode = GameConstants.PongMode.MULTIPLAYER
	meta_obj.player_list = [
		PongPlayer.new(PaddleKeyboardInput.new()),
		PongPlayer.new(PaddleKeyboardInput.new()),
	]
	SceneUtil.goto_scene(SimplePong.get_scene_path(), meta_obj.to_dictionary())
