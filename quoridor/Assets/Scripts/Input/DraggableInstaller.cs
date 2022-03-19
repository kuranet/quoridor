using Zenject;

public class DraggableInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<SetDraggablePositionSignal>();
        Container.BindSignal<SetDraggablePositionSignal>()
            .ToMethod<SetDraggablePositionCommand>(x => x.Execute).FromNew();

        Container.DeclareSignal<PlayerDragStateChangedSignal>();
    }
}
