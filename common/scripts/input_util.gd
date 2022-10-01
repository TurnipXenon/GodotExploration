class_name InputUtil

const InputEnum = preload("res://assets/scripts/input_enum.gd")

const control_scheme_dict = {
    InputEnum.ControlScheme.PLAYER: "ui",
    InputEnum.ControlScheme.ENEMY: "enemy",
}

# todo(reinhardluvr69): int to enum typing???
static func get_prefix(scheme: int)-> String:
    if not scheme in control_scheme_dict:
        print("InputUtil: get_prefix: invalid scheme: %d. Defaulting to PLAYER" % scheme)
        return InputEnum.ControlScheme.PLAYER
    return control_scheme_dict[scheme]
