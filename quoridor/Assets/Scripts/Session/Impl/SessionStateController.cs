using System.Linq;
using UnityEngine;
using Zenject;

public class SessionStateController
{
    public PlayfieldConfiguration Configuration => new PlayfieldConfiguration();

    [Inject] public ISessionState SessionState { get; private set; }

    [Inject] public SignalBus SignalBus { get; set; }

    [Inject] public IPlayfieldController PlayfieldController { get; private set; }

    [Inject]
    public void SubscribleSignals()
    {
        SignalBus.Subscribe<SetPlayerPositionSignal>(x => SetPlayerPosition(x.PlayerId, x.CellPosition));
    }

    public void Initialize(int playerCount)
    {
        SessionState.Reset();

        CreatePlayers(playerCount);
    }

    private void CreatePlayers(int playerCount)
    {
        for (var i = 0; i < playerCount; i++)
        {
            var playerModel = new PlayerState(i, Configuration.WallsCount);

            var startPosition = Configuration.PlayersStartPositions[i];
            playerModel.Position = startPosition;

            var isCurrentTurn = i == 0;
            playerModel.IsCurrentTurn = isCurrentTurn;

            SessionState.Players.Add(playerModel);
        }

        SignalBus.Fire<PlayerPositionsChangedSignal>();
    }

    private void SetPlayerPosition(int playerId, Vector2Int newPosition)
    {
        if (PlayfieldController.CanSetPosition(playerId, newPosition) == false)
            return;

        var playerState = SessionState.Players.FirstOrDefault(p => p.Id == playerId);
        playerState.Position = newPosition;

        SignalBus.Fire<PlayerPositionsChangedSignal>();

        CompleteTurn(playerId);
    }

    private void CompleteTurn(int playerId)
    {
        var nextPlayerId = playerId++;
        if (nextPlayerId >= SessionState.Players.Count)
            nextPlayerId = 0;

        foreach(var player in SessionState.Players)
        {
            var isCurrentTurn = player.Id == nextPlayerId;
            player.IsCurrentTurn = isCurrentTurn;
        }

        SignalBus.Fire<PlayerTurnsChangedSignal>();
    }
}
