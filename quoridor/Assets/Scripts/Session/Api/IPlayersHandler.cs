using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayersHandler
{
    List<IPlayerController> PlayerControllers { get; }

    void SimulationStep();
    void AddController(IPlayerController playerController);
}
