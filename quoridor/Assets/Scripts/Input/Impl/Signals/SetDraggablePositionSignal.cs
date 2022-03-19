using UnityEngine;

public class SetDraggablePositionSignal
{
    public Vector3 NewWorldPosition { get; private set; }
    public IDraggable Draggable { get; private set; }

    public SetDraggablePositionSignal(IDraggable draggable, Vector3 newWorldPosition)
    {
        Draggable = draggable;
        NewWorldPosition = newWorldPosition;
    }
}
