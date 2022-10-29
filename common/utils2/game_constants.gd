extends Node

# gdlint: disable = class-definitions-order

# region Universal
enum LogLevel {
	INHERIT = -1,
	OFF = 0,
	VERBOSE = 100,
	DEBUG = 200,
	INFO = 300,
	WARN = 400,
	LASSERT = 500,
	ERROR = 600,
	FATAL = 700,
	FORCE_ON = 800
}

const LOG_LEVEL_KEY = "LogLevel"
# endregion Universal

# region General
enum ControlScheme {
	PLAYER,
	ENEMY,
}
# endregion General

# region Pong
enum PongMode { MULTIPLAYER, SINGLEPLAYER }

const PONG_MENU_SCENE_PATH = "res://Scenes/simple_pong/menu/PongMenu.tscn"
# endregion Pong

# gdlint: enable=class-definitions-order
