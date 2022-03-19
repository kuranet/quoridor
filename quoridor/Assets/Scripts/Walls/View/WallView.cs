using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallView : MonoBehaviour, IDraggable
{
    [SerializeField] private GameObject _bodyView;
    [SerializeField] private GameObject _ghostView;

    private bool _isDragger;

    public bool IsInteractable { get; set; }

    public Vector3 DragPosition
    {
        get => _bodyView.transform.position;
        set => _bodyView.transform.position = value;
    }

    public void StartDtag()
    {
        _isDragger = true;
        _ghostView.gameObject.SetActive(true);
    }

    public void EndDrag()
    {
        _isDragger = false;
        _ghostView.gameObject.SetActive(false);
    }

    public void CancelDrag()
    {
    }

    private void Update()
    {
        if (_isDragger == false)
            return;

        var isRotationKeyPressed = Input.GetKeyDown(KeyCode.Space);
    }
}
