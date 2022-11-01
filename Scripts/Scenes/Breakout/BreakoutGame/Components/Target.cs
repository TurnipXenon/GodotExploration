using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components;

public partial class Target : StaticBody2D
{
    // todo(turnip): generate color depending on lives
    // todo(turnip): lives
    private const int maxLives = 3;
    private int currentLives = maxLives;
    private Color _additionalColor;
    private Sprite2D _sprite2D;
    
    [Signal]
    public delegate void KilledEventHandler();

    public void SetColor(RandomNumberGenerator rng)
    {
        _additionalColor = new Color(rng.Randf(), rng.Randf(), rng.Randf());

        UpdateColor();
    }

    public void UpdateColor()
    {
        var baseColorValue = (currentLives / (float)(maxLives + 1)) * .5f;
        var r = 2f +  _additionalColor.r*.7f;
        var g = baseColorValue + (1 - baseColorValue) * _additionalColor.g;
        var b = baseColorValue + (1 - baseColorValue) * _additionalColor.b;
        
        if (_sprite2D == null)
        {
            _sprite2D = GetNode<Sprite2D>("Sprite2D");
        }

        _sprite2D.Modulate = new Color(r, g, b);
    }


    public void Hit()
    {
        currentLives--;
        if (currentLives <= 0)
        {
            QueueFree();
            EmitSignal("Killed");
            return;
        }
        
        UpdateColor();
    }
}