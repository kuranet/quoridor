using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayfieldController
{
    PlayfieldConfiguration Configuration { get; }

    bool CanSetPosition(int playerId, Vector2Int position);
}
