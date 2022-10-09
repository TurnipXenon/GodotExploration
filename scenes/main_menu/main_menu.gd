extends Node


func _on_PongButton_pressed():
	SceneUtil.goto_scene(PongMenu.get_scene_path())
