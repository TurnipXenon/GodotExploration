class_name InputUtil

const CONTROL_SCHEME_DICT = {
	GameEnums.ControlScheme.ENEMY: "enemy",
	GameEnums.ControlScheme.PLAYER: "ui",
}


# todo(reinhardluvr69): int to enum typing???
static func get_prefix(scheme: int) -> String:
	if not scheme in CONTROL_SCHEME_DICT:
		DebugUtil.log(
			"InputUtil: get_prefix: invalid scheme: %d. Defaulting to PLAYER" % scheme,
			{GameEnums.LOG_LEVEL_KEY: GameEnums.LogLevel.ERROR}
		)
		return GameEnums.ControlScheme.PLAYER
	return CONTROL_SCHEME_DICT[scheme]
