using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PlayfieldController : IPlayfieldController
{
    private readonly List<CellModel> _cells = new List<CellModel>();

    public List<CellModel> Cells => _cells;

    public PlayfieldConfiguration Configuration => new PlayfieldConfiguration();

    [Inject] public ISessionState SessionState { get; set; }

    [Inject]
    public void Initialize()
    {
        int borderSize = Configuration.BoarderSize;

        for (var i = 0; i < borderSize; i++)
        {
            for (var j = 0; j < borderSize; j++)
            {
                var position = new Vector2Int(i, j);
                var cellModel = new CellModel(position);
                _cells.Add(cellModel);
            }
        }

        SetNeighbors();
    }

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

        var targetCell = _cells.FirstOrDefault(c => c.Position == position);
        var playerCell = _cells.FirstOrDefault(c => c.Position == currentPlayer.Position);

        var directionVector = position - currentPlayer.Position;

        var isBordering = targetCell.Neighbors.Contains(playerCell);
        if (isBordering)
        {
            // check if closed by wall;
        }
        else
        {
            // check if opponent near.
            return false;
        }

        return true;
    }

    public bool CanSetWall()
    {
        return true;
    }

    private void SetNeighbors()
    {
        foreach(var cell in _cells)
        {
            var neighbors = _cells.Where(c => Vector2Int.Distance(c.Position, cell.Position) == 1).ToList();
            cell.SetNeighbors(neighbors);
        }
    }
}
