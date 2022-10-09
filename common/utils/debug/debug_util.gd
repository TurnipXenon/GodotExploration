class_name DebugUtil

# gdlint:ignore = max-line-length
const DEBUG_CONFIG: DebugConfig = preload("res://common/utils/debug/configs/default_debug_config.tres")


static func log(message: String, config: Dictionary = {}) -> void:
	if !(GameConstants.LOG_LEVEL_KEY in config):
		return

	if config[GameConstants.LOG_LEVEL_KEY] < DEBUG_CONFIG.log_level:
		return

	print(message)
