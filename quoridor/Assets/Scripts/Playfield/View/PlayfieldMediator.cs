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

    private void Start()
    {
        CreateField();
    }

    public void CreateField()
    {
        var borderSize = PlayfieldController.Configuration.BoarderSize;
        CellSpaceConverter.Initialize(borderSize);

        for (var i = 0; i < borderSize; i++)
        {
            for (var j = 0; j < borderSize; j++)
            {
                var cell = Instantiate(_cellPrefab, _cellsContainer);

                var cellPosition = new Vector2Int(i, j);

                cell.Initialize(cellPosition);

                var worldPosition = CellSpaceConverter.CellToWorld(cellPosition);
                cell.transform.position = worldPosition;

                cell.name = $"cell_({i},{j})";
                _cells.Add(cell);
            }
        }
    }

    public void ShowAvailable(int playerId)
    {
        foreach (var cell in _cells)
        {
            cell.IsInteractable = PlayfieldController.CanSetPosition(playerId, cell.Position);
        }
    }

    public void DisableCells()
    {
        foreach (var cell in _cells)
        {
            cell.IsInteractable = false;
        }
    }
}
