using Zenject;

public class WallsInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<IWallsController>()
            .To<WallsController>()
            .AsSingle();
    }
}
