extends Node


func _on_PongButton_pressed():
	SceneUtil.goto_scene(GameConstants.PONG_MENU_SCENE_PATH)
