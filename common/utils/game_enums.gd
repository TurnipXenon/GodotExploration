extends Node

enum ControlScheme {
	PLAYER,
	ENEMY,
}

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
