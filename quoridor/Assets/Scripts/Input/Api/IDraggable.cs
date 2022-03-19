using UnityEngine;

public interface IDraggable
{
    bool IsInteractable { get; }
    Vector3 DragPosition { get; set; }

    void StartDtag();
    void EndDrag();
}
