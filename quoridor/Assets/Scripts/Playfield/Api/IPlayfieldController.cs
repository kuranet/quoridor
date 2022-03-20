using System.Collections.Generic;
using UnityEngine;

public interface IPlayfieldController
{
    List<CellModel> Cells { get; }
    PlayfieldConfiguration Configuration { get; }

    bool CanSetPosition(int playerId, Vector2Int position);
}
