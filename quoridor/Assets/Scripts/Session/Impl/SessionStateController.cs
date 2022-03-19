using Zenject;

public class SessionStateController
{
    public PlayfieldConfiguration Configuration => new PlayfieldConfiguration();

    [Inject] public ISessionState SessionState { get; private set; }
    [Inject] public SignalBus SignalBus { get; set; }

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

            SessionState.Players.Add(playerModel);
        }

        SignalBus.Fire<PlayerPositionsChangedSignal>();
    }
}
