using Zenject;

public class ContextInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.Install<SessionInstaller>();
    }
}