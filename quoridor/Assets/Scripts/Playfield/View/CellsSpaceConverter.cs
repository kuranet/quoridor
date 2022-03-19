using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsSpaceConverter : ICellSpaceConverter
{
    private int _boardSizeX;
    private int _boardSizeY;

    private float _cellSizeX;
    private float _cellSizeY;

    private float _cellDistanceX;
    private float _cellDistanceY;

    private Vector3 _zeroPositionWorld;

    public void Initialize(int boardSize)
    {
        _boardSizeX = _boardSizeY = boardSize;

        _cellSizeX = _cellSizeY = 1;
        _cellDistanceX = _cellDistanceY = 0.1f;

        _zeroPositionWorld = Vector3.zero;
    }

    public Vector3 CellToWorld(Vector2 cellPosition)
    {
        var xPosition = cellPosition.x * _cellSizeX + (cellPosition.x - 1) * _cellDistanceX;
        var yPosition = cellPosition.y * _cellSizeY + (cellPosition.y - 1) * _cellDistanceY;

        var fromStartPosition = new Vector3(xPosition, 0, yPosition);

        return fromStartPosition;
    }
}
