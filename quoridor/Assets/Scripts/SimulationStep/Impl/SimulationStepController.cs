using UnityEngine;
using Zenject;

public class SimulationStepController : MonoBehaviour
{
    [Inject] public IPlayersHandler PlayersHandler { get; private set; }

    private void Update()
    {
        PlayersHandler.SimulationStep();
    }

    private void LateUpdate()
    {
        // ui updates.
    }
}
