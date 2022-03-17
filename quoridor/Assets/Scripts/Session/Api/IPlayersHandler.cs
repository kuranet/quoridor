using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayersHandler
{
    void SimulationStep();
    void AddController(IPlayerController playerController);
}
