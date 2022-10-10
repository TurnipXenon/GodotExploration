extends Node

# gdlint:ignore = max-line-length
# taken from: https://docs.godotengine.org/en/3.1/getting_started/step_by_step/singletons_autoload.html#global-gd

const KEY_PONG_MODE = "pong_mode"
const KEY_PONG_PLAYERS = "pong_players"
const KEY_SIMPLE_PONG = "simple_pong"

var current_scene: Node = null
var current_args: Dictionary = {}


func _ready():
	var root = get_tree().get_root()
	current_scene = root.get_child(root.get_child_count() - 1)


func goto_scene(path: String, args: Dictionary = {}) -> void:
	# This function will usually be called from a signal callback,
	# or some other function in the current scene.
	# Deleting the current scene at this point is
	# a bad idea, because it may still be executing code.
	# This will result in a crash or unexpected behavior.

	current_args = args

	# The solution is to defer the load to a later time, when
	# we can be sure that no code from the current scene is running:
	call_deferred("_deferred_goto_scene", path)


func _deferred_goto_scene(path: String) -> void:
	# It is now safe to remove the current scene
	current_scene.free()

	# Load the new scene.
	var s = ResourceLoader.load(path)

	# Instance the new scene.
	current_scene = s.instance()

	# Add it to the active scene, as child of root.
	get_tree().get_root().add_child(current_scene)

	# Optionally, to make it compatible with the SceneTree.change_scene() API.
	get_tree().set_current_scene(current_scene)
