using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayfieldMediator : MonoBehaviour
{
    [SerializeField] private CellView _cellPrefab;
    [SerializeField] private Transform _cellsContainer;

    private List<CellView> _cells = new List<CellView>();

    [Inject] public IPlayfieldController PlayfieldController { get; set; }
    [Inject] public ICellSpaceConverter CellSpaceConverter { get; set; }
    [Inject] public SignalBus SignalBus { get; set; }

    private void Start()
    {
        SignalBus.Subscribe<PlayerDragStateChangedSignal>(x => OnPlayerDragChanged(x.PlayerId, x.IsDragged));

        CreateField();
    }

    public void CreateField()
    {
        var borderSize = PlayfieldController.Configuration.BoarderSize;
        CellSpaceConverter.Initialize(borderSize);

        foreach (var cellModel in PlayfieldController.Cells)
        {
            var cell = Instantiate(_cellPrefab, _cellsContainer);

            var cellPosition = cellModel.Position;

            cell.Initialize(cellModel.Position);

            var worldPosition = CellSpaceConverter.CellToWorld(cellPosition);
            cell.WorldPosition = worldPosition;

            cell.name = $"cell_({cellPosition.x},{cellPosition.y})";
            _cells.Add(cell);
        }
    }

    private void OnPlayerDragChanged(int playerId, bool isDragged)
    {
        if (isDragged)
        {
            ShowAvailable(playerId);
        }
        else
        {
            DisableCells();
        }
    }

    private void ShowAvailable(int playerId)
    {
        foreach (var cell in _cells)
        {
            cell.IsInteractable = PlayfieldController.CanSetPosition(playerId, cell.Position);
        }
    }

    private void DisableCells()
    {
        foreach (var cell in _cells)
        {
            cell.IsInteractable = false;
        }
    }
}
