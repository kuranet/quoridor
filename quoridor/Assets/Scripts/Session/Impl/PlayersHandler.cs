using System.Collections.Generic;
using System.Linq;

public class PlayersHandler : IPlayersHandler
{
    private readonly List<IPlayerController> _playerControllers = new List<IPlayerController>();

    public List<IPlayerController> PlayerControllers => _playerControllers;

    public void SimulationStep()
    {
        var activePlayer = _playerControllers.FirstOrDefault(p => p.IsCurrentTurn);

        if (activePlayer == null)
            return;

        activePlayer.SimulationStep();
    }

    public void AddController(IPlayerController playerController)
    {
        _playerControllers.Add(playerController);
    }
}
