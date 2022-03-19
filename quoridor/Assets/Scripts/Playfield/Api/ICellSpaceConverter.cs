using UnityEngine;

public interface ICellSpaceConverter 
{
    void Initialize(int boardSize);

    Vector3 CellToWorld(Vector2Int cellPosition);
    Vector2Int WorldToCell(Vector3 worldPosition);
}
