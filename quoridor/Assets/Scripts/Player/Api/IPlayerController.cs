using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerController
{
    int Id { get; }
    bool IsCurrentTurn { get; }

    bool IsReady { get; }

    void Initialize(int playerId);

    public void SimulationStep();
}
