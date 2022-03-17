using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SessionState : ISessionState
{
    private readonly List<IPlayerState> _players = new List<IPlayerState>();

    public List<IPlayerState> Players => _players;

    public void AddPlayer(int playerId)
    {
        var playerModel = new PlayerState(playerId);
        _players.Add(playerModel);
    }

    public void Reset()
    {
        _players.Clear();
    }
}
