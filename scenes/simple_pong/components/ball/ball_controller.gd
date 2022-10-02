extends KinematicBody2D

const InputEnum = preload("res://common/scripts/input_enum.gd")

export var input_strength: float  = 4
export var control_scheme: int = InputEnum.ControlScheme.PLAYER

var up_key = "ui_up"
var down_key = "ui_down"
var test = true
var direction = Vector2.ZERO

func _ready():
   var prefix = InputUtil.get_prefix(control_scheme)
   up_key = "%s_up" % prefix
   down_key = "%s_down" % prefix
   direction = Vector2.ONE # todo(turnip): randomize

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
   var input_value = Vector2.ONE
   # input_value.y = Input.get_action_strength(down_key) - Input.get_action_strength(up_key)
   move_and_slide(direction * delta * input_strength)
   if get_slide_count() > 0:
      var collision = get_slide_collision(0)
      if collision:
         direction = direction.bounce(collision.normal)
         if test:
            test = false
            print("Hello")

