using UnityEngine;
using Zenject;

public class PlayerView : MonoBehaviour, IDraggable
{
    [SerializeField] private GameObject _bodyView;
    [SerializeField] private GameObject _ghostView;

    public int PlayerId { get; set; }

    public bool IsInteractable { get; set; } = true;

    public Vector3 WorldPosition
    {
        get => transform.position;
        set
        {
            transform.position = value;

            _ghostView.transform.position = value;
            _bodyView.transform.position = value;
        }
    }

    public Vector3 DragPosition
    {
        get => _bodyView.transform.position;
        set => _bodyView.transform.position = value;
    }

    [Inject] public SignalBus SignalBus { get; private set; }

    public void StartDtag()
    {
        Debug.Log("start drag");

        var isDragged = true;

        _ghostView.gameObject.SetActive(isDragged);

        SignalBus.Fire(new PlayerDragStateChangedSignal(PlayerId, isDragged));
    }

    public void CancelDrag()
    {
        WorldPosition = WorldPosition;
    }

    public void EndDrag()
    {
        Debug.Log("end drag");

        var isDragged = false;

        _ghostView.gameObject.SetActive(isDragged);

        SignalBus.Fire(new PlayerDragStateChangedSignal(PlayerId , isDragged));
    }
}
