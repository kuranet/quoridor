using UnityEngine;

public class PlayerState : IPlayerState
{
    public int Id { get; }

    public Vector2Int Position { get; set; }

    public int BordersCount { get; set; }

    public PlayerState(int id)
    {
        Id = id;
    }
}
