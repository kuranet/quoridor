using Zenject;

public class SessionInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<ISessionState>()
            .To<SessionState>()
            .AsSingle();

        Container.Bind<IPlayersHandler>()
            .To<PlayersHandler>()
            .AsSingle();
    }
}
