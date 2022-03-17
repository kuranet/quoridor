using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SessionState : ISessionState
{
    private readonly List<IPlayerState> _players = new List<IPlayerState>();

    public List<IPlayerState> Players => _players;

    [Inject]
    public void Initialize()
    {
        Debug.Log("initialized");
    }

    public void AddPlayer(int playerId)
    {
        var playerModel = new PlayerState(playerId);
        _players.Add(playerModel);
    }
}
