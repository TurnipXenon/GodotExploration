using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components;

public partial class Target : StaticBody2D, IBallHittable
{
    private const int MaxLives = 3;
    private int _currentLives = MaxLives;
    private Color _additionalColor;
    private Sprite2D _sprite2D;

    [Signal]
    public delegate void KilledEventHandler();

    public void SetColor(RandomNumberGenerator rng)
    {
        _additionalColor = new Color(rng.Randf(), rng.Randf(), rng.Randf());

        UpdateColor();
    }

    private void UpdateColor()
    {
        var baseColorValue = (_currentLives / (float)(MaxLives + 1)) * .5f;
        var r = 2f + _additionalColor.r * .7f;
        var g = baseColorValue + (1 - baseColorValue) * _additionalColor.g;
        var b = baseColorValue + (1 - baseColorValue) * _additionalColor.b;

        if (_sprite2D == null)
        {
            _sprite2D = GetNode<Sprite2D>("Sprite2D");
        }

        _sprite2D.Modulate = new Color(r, g, b);
    }

    public void OnBallHit(Ball ball)
    {
        _currentLives--;
        if (_currentLives <= 0)
        {
            QueueFree();
            EmitSignal(SignalName.Killed);
            return;
        }

        UpdateColor();
        ball.InfluenceHorizontalByMultiplication((float)GD.RandRange(.5f, 1.5f));
    }
}