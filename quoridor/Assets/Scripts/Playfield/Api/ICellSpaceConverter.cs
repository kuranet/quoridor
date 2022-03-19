using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICellSpaceConverter 
{
    void Initialize(int boardSize);

    Vector3 CellToWorld(Vector2 cellPosition);
}
