using System.Collections.Generic;
using UnityEngine;

public class CellModel 
{
    private List<CellModel> _neighbors = new List<CellModel>();

    public Vector2Int Position { get; }

    public List<CellModel> Neighbors => _neighbors;

    public CellModel(Vector2Int position)
    {
        Position = position;
    }

    public void SetNeighbors(List<CellModel> neighbors)
    {
        _neighbors = neighbors;
    }
}
