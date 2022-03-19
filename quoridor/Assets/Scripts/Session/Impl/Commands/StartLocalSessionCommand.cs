using Zenject;

public class StartLocalSessionCommand
{
    private const int PlayersCount = 2;

    [Inject] public SessionStateController SessionStateController { get; set; }
    [Inject] public IPlayersHandler PlayersHandler { get; set; }
    [Inject] public DiContainer Container { get; set; }

    public void Execute()
    {
        OverlayController.DisableOverlay(typeof(LobbyOverlay));

        UnityEngine.Debug.Log("start local player");

        SessionStateController.Initialize(PlayersCount);

        foreach(var state in SessionStateController.SessionState.Players)
        {
            var playerController = Container.Instantiate<PlayerController>();
            playerController.Initialize(state);
            PlayersHandler.AddController(playerController);
        }
    }
}
