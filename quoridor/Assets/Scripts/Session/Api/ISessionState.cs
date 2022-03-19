using System.Collections.Generic;

public interface ISessionState
{
    List<IPlayerState> Players { get; }



    public void Reset();
}
