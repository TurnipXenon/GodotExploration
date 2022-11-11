using Godot;

namespace GodotExploration.Scripts.Scenes.Breakout.BreakoutGame.Components.Augmentation;

public partial class AugmentationLong : AugmentationBase
{
    private PaddlePawn _paddle;
    private const ulong TransformDuration = 1000;
    private const float NormalScale = 1f;
    private const float LargeScale = 2f;
    private float _startingX;
    private float _endingX;
    private ulong _transformStartTime;
    private ulong _transformEndTime;
    private State _state = State.Growing;

    private enum State
    {
        Growing,
        Long,
        Shrinking,
        Normal
    }

    public override bool IsDone()
    {
        return base.IsDone() && _state == State.Normal;
    }

    public override void Initialize(Player.ICallback player)
    {
        base.Initialize(player);

        _paddle = Player.GetPaddle();

        _startingX = _paddle.Scale.x;
        _endingX = LargeScale;
        _transformStartTime = Time.GetTicksMsec();
        _transformEndTime = Time.GetTicksMsec() + TransformDuration;
    }

    public override void _PhysicsProcess(double delta)
    {
        ModifyPaddleSize();

        if (_state == State.Long && base.IsDone())
        {
            _startingX = _paddle.Scale.x;
            _endingX = NormalScale;
            _transformStartTime = Time.GetTicksMsec();
            _transformEndTime = Time.GetTicksMsec() + TransformDuration;
            _state = State.Shrinking;
        }
    }

    private void ModifyPaddleSize()
    {
        if (_state != State.Growing && _state != State.Shrinking)
        {
            return;
        }

        var currentScale = _paddle.Scale;
        var currentTime = Time.GetTicksMsec();
        currentScale.x = Mathf.Lerp(_endingX, _startingX, (_transformEndTime - currentTime) / (float)TransformDuration);
        if (currentTime > _transformEndTime)
        {
            currentScale.x = _endingX;

            if (_state == State.Growing)
            {
                _state = State.Long;
            }
            else if (_state == State.Shrinking)
            {
                _state = State.Normal;
            }
        }

        _paddle.Scale = currentScale;
    }

    public override void Destroy()
    {
        var paddleScale = _paddle.Scale;
        paddleScale.x = NormalScale;
        _paddle.Scale = paddleScale;
        base.Destroy();
    }
}