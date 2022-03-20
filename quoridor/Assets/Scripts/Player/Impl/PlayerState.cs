using UnityEngine;

public class PlayerState : IPlayerState
{
    public int Id { get; }

    public Vector2Int Position { get; set; }

    public int WallsCount { get; set; }
    public bool IsCurrentTurn { get; set; }

    public PlayerState(int id, int wallsCount)
    {
        Id = id;
        WallsCount = wallsCount;
    }
}
