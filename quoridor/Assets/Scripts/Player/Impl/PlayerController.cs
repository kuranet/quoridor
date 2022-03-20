using UnityEngine;
using Zenject;

public class PlayerController : IPlayerController
{
    private const int _turnDurationTicks = 100000;
    private int _ticksSinceTurnStart;

    private IPlayerState _playerState;

    public bool IsCurrentTurn { get; private set; }

    public int Id => _playerState.Id;

    public bool IsReady { get; set; }

    public void Initialize(IPlayerState playerState)
    {
        _playerState = playerState;
    }

    public void SimulationStep()
    {
        _ticksSinceTurnStart++;

        if (_ticksSinceTurnStart >= _turnDurationTicks)
            CompleteTurn();
    }

    public void StartTurn()
    {
        IsCurrentTurn = true;
        _ticksSinceTurnStart = 0;
    }

    public void CompleteTurn()
    {
        IsCurrentTurn = false;
    }
}
