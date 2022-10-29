using Godot;

public interface PaddleBehavior
{
	public void Initialize(Object paddle);
	public Vector2 Act(Object paddle, float delta);
}
