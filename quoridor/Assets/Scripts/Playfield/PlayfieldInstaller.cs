using Zenject;

public class PlayfieldInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<IPlayfieldController>()
            .To<PlayfieldController>()
            .AsSingle();

        Container.Bind<ICellSpaceConverter>()
            .To<CellsSpaceConverter>()
            .AsSingle();
    }
}
