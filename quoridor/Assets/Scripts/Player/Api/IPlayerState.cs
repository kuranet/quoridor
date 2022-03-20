using UnityEngine;

public interface IPlayerState
{
    int Id { get; }

    Vector2Int Position { get; set; }

    bool IsCurrentTurn { get; set; }
}
