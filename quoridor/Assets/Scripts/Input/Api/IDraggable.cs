using UnityEngine;

public interface IDraggable : IInteractable
{
    Vector3 DragPosition { get; set; }

    void StartDtag();
    void CancelDrag();
    void EndDrag();
}
