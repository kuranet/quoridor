using UnityEngine;
using Zenject;

public class DragProcessor : MonoBehaviour
{
    private IDraggable _draggable;

    [Inject] public SignalBus SignalBus { get; set; }

    private IDraggable Draggable
    {
        get => _draggable;
        set
        {
            if (_draggable == value)
                return;

            if (_draggable != null)
                _draggable.EndDrag();

            _draggable = value;

            if (_draggable != null)
                _draggable.StartDtag();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Draggable = GetDraggable();
        }
        else if (Input.GetMouseButton(0))
        {
            if (Draggable == null)
                return;

            var worldPosition = GetDragPosition();
            Draggable.DragPosition = worldPosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (Draggable == null)
                return;

            var worldPosition = GetDragPosition();
            SignalBus.Fire(new SetDraggablePositionSignal(Draggable, worldPosition));

            Draggable = null;
        }
    }

    private IDraggable GetDraggable()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        var raycastAll = Physics.RaycastAll(ray);
        foreach (var raycasted in raycastAll)
        {
            if (raycasted.collider.gameObject.TryGetComponent(out IDraggable draggable) && draggable.IsInteractable)
                return draggable;
        }

        return null;
    }

    private Vector3 GetDragPosition()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 11;

        var worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        return worldPosition;
    }
}
