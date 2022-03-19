using System.Collections.Generic;

public class SessionState : ISessionState
{
    private readonly List<IPlayerState> _players = new List<IPlayerState>();

    public List<IPlayerState> Players => _players;

    public GameState GameState { get; set; }

    public void Reset()
    {
        _players.Clear();

        GameState = GameState.Preparing;
    }
}
