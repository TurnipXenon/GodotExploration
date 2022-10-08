class_name InputUtil

const CONTROL_SCHEME_DICT = {
    InputEnum.ControlScheme.ENEMY: "enemy",
    InputEnum.ControlScheme.PLAYER: "ui",
}


# todo(reinhardluvr69): int to enum typing???
static func get_prefix(scheme: int) -> String:
    if not scheme in CONTROL_SCHEME_DICT:
        print("InputUtil: get_prefix: invalid scheme: %d. Defaulting to PLAYER" % scheme)
        return InputEnum.ControlScheme.PLAYER
    return CONTROL_SCHEME_DICT[scheme]
