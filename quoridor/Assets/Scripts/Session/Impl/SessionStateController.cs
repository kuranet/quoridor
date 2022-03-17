using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SessionStateController
{
    [Inject] public ISessionState SessionState { get; private set; }

    public void Initialize(int playerCount)
    {
        SessionState.Reset();
        CreatePlayers(playerCount);
    }

    private void CreatePlayers(int playerCount)
    {
        for (var i = 0; i < playerCount; i++)
        {
            var playerModel = new PlayerState(i);

            SessionState.Players.Add(playerModel);
        }
    }
}
