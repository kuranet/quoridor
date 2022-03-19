using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PlayfieldController : IPlayfieldController
{
    public PlayfieldConfiguration Configuration => new PlayfieldConfiguration();

    [Inject] public ISessionState SessionState { get; set; }

    public bool CanSetPosition(int playerId, Vector2Int position)
    {
        foreach (var player in SessionState.Players)
        {
            if (player.Position == position)
                return false;
        }

        var currentPlayer = SessionState.Players.FirstOrDefault(p => p.Id == playerId);

        if (currentPlayer == null)
            return false;

        var directionVector = position - currentPlayer.Position;

        var isBordering = directionVector.magnitude == 1;
        if (isBordering)
        {
            // check if closed by wall;
        }
        else
        {
            // check if opponent near.
        }

        return true;
    }
}
