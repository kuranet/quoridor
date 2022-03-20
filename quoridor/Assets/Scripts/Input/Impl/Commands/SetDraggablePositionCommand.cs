using System.Linq;
using Zenject;

public class SetDraggablePositionCommand
{
    [Inject] public ICellSpaceConverter CellSpaceConverter { get; private set; }
    [Inject] public SignalBus SignalBus { get; set; }

    public void Execute(SetDraggablePositionSignal signal)
    {
        if (signal.Draggable is PlayerView player)
        {
            var cellPosition = CellSpaceConverter.WorldToCell(signal.NewWorldPosition);
            SignalBus.Fire(new SetPlayerPositionSignal()
            {
                PlayerId = player.PlayerId,
                CellPosition = cellPosition,
            });
        }
    }
}
