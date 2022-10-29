class_name InputUtil

const CONTROL_SCHEME_DICT = {
	GameConstants.ControlScheme.ENEMY: "enemy",
	GameConstants.ControlScheme.PLAYER: "ui",
}


# todo(reinhardluvr69): int to enum typing???
static func get_prefix(scheme: int) -> String:
	if not scheme in CONTROL_SCHEME_DICT:
		DebugUtil.log(
			"InputUtil: get_prefix: invalid scheme: %d. Defaulting to PLAYER" % scheme,
			{GameConstants.LOG_LEVEL_KEY: GameConstants.LogLevel.ERROR}
		)
		return CONTROL_SCHEME_DICT[GameConstants.ControlScheme.PLAYER]
	return CONTROL_SCHEME_DICT[scheme]
