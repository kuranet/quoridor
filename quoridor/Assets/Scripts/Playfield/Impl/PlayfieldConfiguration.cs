using UnityEngine;

public class PlayfieldConfiguration
{
    public int PlayersCount { get; set; } = 2;
    public int BoarderSize { get; set; } = 9;

    public int WallsCount { get; set; } = 9;

    public Vector2Int[] PlayersStartPositions { get; set; } =
            new Vector2Int[] { new Vector2Int(0, 1), new Vector2Int(8, 1) };

    public Vector2Int[][] PlayersZonePositions { get; set; } =
        new[]
        {
            new Vector2Int [] { new Vector2Int(0, 0), new Vector2Int(0,1), new Vector2Int(0,2), new Vector2Int(0,3) },
            new Vector2Int [] { new Vector2Int(8, 0), new Vector2Int(8,1), new Vector2Int(8,2), new Vector2Int(8,3) },
        };
}
