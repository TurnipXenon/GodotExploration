class_name DebugUtil

const _debug_config: DebugConfig = preload("res://common/utils/debug/configs/default_debug_config.tres")


static func log(message: String, config: Dictionary = {}) -> void:
	if !(GameEnums.LOG_LEVEL_KEY in config):
		return

	if config[GameEnums.LOG_LEVEL_KEY] < _debug_config.log_level:
		return

	print(message)
