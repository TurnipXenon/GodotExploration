class_name PongMenu
extends Node

var meta: Resource = SimplePongMeta.get_resource()
var pong_player_resource: Resource = PongPlayer.get_resource()
var paddle_keyboard_input_resource: Resource = PaddleKeyboardInput.get_resource()


static func get_scene_path() -> String:
	return "res://scenes/simple_pong/menu/PongMenu.tscn"


func _on_SinglePlayerButton_pressed():
	var meta_obj = meta.new()
	meta_obj.pong_mode = GameConstants.PongMode.SINGLEPLAYER
	var paddle_simple_ai_resource = PaddleSimpleAI.get_resource()
	meta_obj.player_list = [
		pong_player_resource.new(paddle_keyboard_input_resource.new()),
		pong_player_resource.new(paddle_simple_ai_resource.new()),
	]
	SceneUtil.goto_scene(SimplePong.get_scene_path(), meta_obj.to_dictionary())


func _on_MultiplayerButton_pressed():
	var meta_obj = meta.new()
	meta_obj.pong_mode = GameConstants.PongMode.MULTIPLAYER
	meta_obj.player_list = [
		pong_player_resource.new(paddle_keyboard_input_resource.new()),
		pong_player_resource.new(paddle_keyboard_input_resource.new()),
	]
	SceneUtil.goto_scene(SimplePong.get_scene_path(), meta_obj.to_dictionary())
