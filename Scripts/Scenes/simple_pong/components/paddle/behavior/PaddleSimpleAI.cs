using Godot;
using Object = Godot.Object;

public partial class PaddleSimpleAI : Node, PaddleBehavior
{
	public void Initialize(Object paddle) {}

	public Vector2 Act(Object paddle, float delta)
	{
		return Vector2.Zero;
	}
}
