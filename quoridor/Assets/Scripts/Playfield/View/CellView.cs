using UnityEngine;

public class CellView : MonoBehaviour
{
    [SerializeField] private Color _interactableColor;
    [SerializeField] private Color _notInteractableColor;

    private bool _isInteractable;
    public Vector2Int Position { get; private set; }

    public bool IsInteractable
    {
        get => _isInteractable;
        set
        {
            if (_isInteractable == value)
                return;

            _isInteractable = value;

            var goColor = _isInteractable ? _interactableColor : _notInteractableColor;
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", goColor);
        }
    }

    public void Initialize(Vector2Int position)
    {
        Position = position;
    }
}
