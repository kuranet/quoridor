using System.Linq;
using UnityEngine;
using Zenject;

public class SetDraggablePositionCommand
{
    [Inject] public ICellSpaceConverter CellSpaceConverter { get; private set; } 
    [Inject] public IPlayersHandler PlayersHandler { get; private set; }

    public void Execute(SetDraggablePositionSignal signal)
    {
        if (signal.Draggable is PlayerView player)
        {
            var handler = PlayersHandler.PlayerControllers.FirstOrDefault(p => p.Id == player.PlayerId);

            if (handler == null)
                return;

            var cellPosition = CellSpaceConverter.WorldToCell(signal.NewWorldPosition);
            handler.SetPlayerPosition(cellPosition);
        }
    }
}
