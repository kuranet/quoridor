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

        for (var i = 0; i < PlayersCount; i++)
        {
            var playerController = Container.Instantiate<PlayerController>();
            playerController.Initialize(i);
            PlayersHandler.AddController(playerController);
        }
    }
}
