using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerController
{
    int Id { get; }
    bool IsCurrentTurn { get; }

    bool IsReady { get; }

    void Initialize(IPlayerState playerState);

    public void SimulationStep();

    public void SetPlayerPosition(Vector2Int cellPosition);
    public void SetWall();
}
