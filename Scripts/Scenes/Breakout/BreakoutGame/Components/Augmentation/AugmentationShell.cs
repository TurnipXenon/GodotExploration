using System.Diagnostics;
using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components.Augmentation;

public partial class AugmentationShell : Area2D
{
    [Export]
    public float KillZoneY = 370f;

    [Export]
    public float FallRate = 100f;

    [Export]
    public PackedScene[] Augmentations = System.Array.Empty<PackedScene>();

    private AugmentationManager.ICallback _callback;

    public override void _Ready()
    {
        Debug.Assert(Augmentations.Length > 0);

        BodyEntered += OnBodyEnter;
    }

    public override void _Process(double delta)
    {
        if (Position.y > KillZoneY)
        {
            QueueFree();
            return;
        }

        var position = Position;
        position.y += FallRate * (float)delta;
        Position = position;
    }

    private void OnBodyEnter(Node2D body)
    {
        if (body is not PaddlePawn)
        {
            return;
        }

        _callback.ActivateAugmentation(Augmentations[GD.RandRange(0, Augmentations.Length)]);
        QueueFree();
    }

    public void SetAugmentationManager(AugmentationManager.ICallback callback)
    {
        _callback = callback;
    }
}