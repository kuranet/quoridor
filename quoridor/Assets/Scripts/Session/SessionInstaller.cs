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

        Container.Bind<SessionStateController>()
            .ToSelf()
            .AsSingle();

        Container.DeclareSignal<StartLocalSessionSignal>();
        Container.BindSignal<StartLocalSessionSignal>()
            .ToMethod<StartLocalSessionCommand>(x => x.Execute).FromNew();
    }
}
