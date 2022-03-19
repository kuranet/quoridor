public class PlayerDragStateChangedSignal 
{
    public int PlayerId { get; }
    public bool IsDragged { get; }

    public PlayerDragStateChangedSignal(int playerId, bool isDragged)
    {
        PlayerId = playerId;
        IsDragged = isDragged;
    }
}
