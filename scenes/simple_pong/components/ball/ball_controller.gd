class_name BallController
extends KinematicBody2D

export(int) var ball_speed = 500
export(Vector2) var min_velocity = Vector2.ONE
export(Vector2) var max_velocity = Vector2.ONE * 5

# we need this one to prevent a bug where delta is big due to slow start
export(float) var start_delay = 2.0

var should_stop: bool = false

var _current_velocity: Vector2 = Vector2.ZERO
var _rng: RandomNumberGenerator = RandomNumberGenerator.new()
var _start_process_time: int = 0
var _should_start_process: bool = false


func _ready():
	# validation
	assert(ball_speed > 0, "ball_speed should be a positive number")
	assert(min_velocity.x >= 0, "min_velocity.x must be greater than 0")
	assert(min_velocity.y > 0, "min_velocity.y must be greater than 0")
	assert(min_velocity.x <= max_velocity.x, "min_velocity.x cannot be bigger than max_velocity.x")
	assert(min_velocity.y <= max_velocity.y, "min_velocity.y cannot be bigger than max_velocity.y")

	# setup
	_current_velocity = _randomize_velocity()
	_start_process_time = OS.get_ticks_msec() + (1000 * start_delay)


func _process(delta):
	if not _should_start_process or should_stop:
		_should_start_process = OS.get_ticks_msec() > _start_process_time
		return

	# warning-ignore:return_value_discarded
	move_and_slide(_current_velocity * delta * ball_speed)
	if get_slide_count() > 0:
		var collision = get_slide_collision(0)
		if collision:
			_current_velocity = _current_velocity.bounce(collision.normal)
			if collision.collider.has_method("hit"):
				collision.collider.hit()


func _randomize_velocity() -> Vector2:
	return Vector2(
		_rng.randi_range(min_velocity.x, max_velocity.x),
		_rng.randi_range(min_velocity.y, max_velocity.y)
	)
