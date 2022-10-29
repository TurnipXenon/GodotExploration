using Godot;
using Object = Godot.Object;

public partial class PaddleKeyboardInput : Node, PaddleBehavior
{
	private string _upKey = "ui_up";
	private string _downKey = "ui_down";

	public void Initialize(Object paddle)
	{
		GDScript script = (GDScript)GD.Load("res://common/utils/input_util.gd");
		var prefix = (string)script.Call("get_prefix", paddle.Get("control_scheme"));
		_upKey = $"{prefix}_up";
		_downKey = $"{prefix}_down";
	}

	public Vector2 Act(Object paddle, float delta)
	{
		var inputValue = Vector2.Zero;
		inputValue.y = Input.GetActionStrength(_downKey) - Input.GetActionStrength(_upKey);
		return inputValue * delta * (float)paddle.Get("input_strength");
	}
}
