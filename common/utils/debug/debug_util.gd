class_name DebugUtil

const CONFIG_LOCATION = "res://common/utils/debug/configs/default_debug_config.tres"
const DEBUG_CONFIG: DebugConfig = preload(CONFIG_LOCATION)


static func log(message: String, config: Dictionary = {}) -> void:
	if !(GameEnums.LOG_LEVEL_KEY in config):
		return

	if config[GameEnums.LOG_LEVEL_KEY] < DEBUG_CONFIG.log_level:
		return

	print(message)
