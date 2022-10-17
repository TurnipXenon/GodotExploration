using Godot;

public interface PaddleBehavior {
  // todo(turnip): how to call gdscript
  public void initialize(Object paddle);
  public Vector2 act(Object paddle, float delta);
}
