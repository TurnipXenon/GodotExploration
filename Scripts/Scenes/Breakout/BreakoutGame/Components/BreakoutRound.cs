using System.Diagnostics;
using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components;

public partial class BreakoutRound : Node
{
    // todo(turnip): section this properties
    [Export]
    public PackedScene TargetOriginal;

    [Export]
    public Player Player;

    [Export]
    public Augmentation.AugmentationManager AugmentationManager;

    private const int MaxLives = 3;

    private Node2D _initialTarget = null;
    private int _targetCount = 0;
    private int _currentLives = MaxLives;
    private Target _target;
    private RandomNumberGenerator _rng;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Debug.Assert(TargetOriginal != null);
        Debug.Assert(Player != null);
        Debug.Assert(AugmentationManager != null);

        AugmentationManager.SetPlayerCallback(Player);

        _rng = new RandomNumberGenerator();
        _rng.Randomize();
        GD.Randomize(); // idk lol

        Initialize();
    }

    private void Initialize()
    {
        _initialTarget = (Node2D)TargetOriginal.Instantiate();
        _initialTarget.Ready += OnTargetReady;
        AddChild(_initialTarget);
    }

    /**
     * Initialize all targets
     */
    private void OnTargetReady()
    {
        // Figure out the size of the target to fit our game
        var initialSprite = _initialTarget.GetNode<Node2D>("Sprite2D");
        var spacing = initialSprite.Transform.Scale;
        var startingPosition = spacing / 2;
        var verticalSpacing = new Vector2(0, spacing.y);
        var horizontalSpacing = new Vector2(spacing.x, 0);
        _initialTarget.QueueFree();
        _initialTarget = null;

        // Generate colors!
        for (int rows = 0; rows < 5; rows++)
        {
            for (int columns = 0; columns < 10; columns++)
            {
                var target = (Target)TargetOriginal.Instantiate();
                AddChild(target);
                target.Position = startingPosition + (horizontalSpacing * columns) + (verticalSpacing * rows);
                target.SetColor(_rng);
                target.SetAugmentationManager(AugmentationManager);
                target.Killed += TargetKilled;
                _targetCount++;
                this._target = target;
            }
        }
    }

    private void TargetKilled()
    {
        GD.Print("Target killed! TODO");
        _targetCount--;
        if (_targetCount <= 0)
        {
            // todo(turnip): done
        }
    }

    private void Test()
    {
        _target.OnBallHit(null);
    }

    private void InformBallWasDone()
    {
        _currentLives--;
        GD.Print("Done?");
        if (_currentLives <= 0)
        {
            GD.Print("TODO: Game ending! Inform someone about results");
            return;
        }

        Player.Reinitialize(this);
    }
}