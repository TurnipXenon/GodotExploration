using System.Diagnostics;
using Godot;
using GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components.Augmentation;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components;

public partial class Target : StaticBody2D, IBallHittable
{
    [Export(PropertyHint.Range, "0,1")]
    public float AugmentationChance = 1 / 3f;

    [Export]
    public PackedScene AugmentationPrefab;

    [Signal]
    public delegate void KilledEventHandler();

    private const int MaxLives = 3;
    private int _currentLives = MaxLives;
    private Color _additionalColor;
    private Sprite2D _sprite2D;
    private AugmentationManager.ICallback _callback;
    private bool _isDone = false;

    public override void _Ready()
    {
        Debug.Assert(AugmentationPrefab != null);
    }

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
            if (_isDone)
            {
                return;
            }

            // todo(turnip): convert to AugmentationChance
            if (GD.Randf() < 1f)
            {
                var augmentation = (AugmentationShell)AugmentationPrefab.Instantiate();
                augmentation.SetAugmentationManager(_callback);
                GetTree().Root.AddChild(augmentation);
                augmentation.Position = Position;
                
                QueueFree();
                EmitSignal(SignalName.Killed);
            }

            _isDone = true;
            return;
        }

        UpdateColor();
        ball?.InfluenceHorizontalByMultiplication((float)GD.RandRange(.5f, 1.5f));
    }

    public void SetAugmentationManager(AugmentationManager.ICallback callback)
    {
        _callback = callback;
    }
}