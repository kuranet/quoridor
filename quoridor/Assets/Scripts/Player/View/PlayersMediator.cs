using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PlayersMediator : MonoBehaviour
{
    private readonly List<PlayerView> _players = new List<PlayerView>();

    [SerializeField] private PlayerView _playerPrefab;
    [SerializeField] private Transform _playersContainer;

    [Inject] public ISessionState SessionState { get; set; }
    [Inject] public ICellSpaceConverter CellSpaceConverter { get; set; }
    [Inject] public SignalBus SignalBus { get; set; }


    [Inject]
    public void Initialize()
    {
        SignalBus.Subscribe<PlayerPositionsChangedSignal>(x => SynchronizePositions());
    }

    public void SynchronizePositions()
    {
        foreach (var player in SessionState.Players)
        {
            var playerView = GetPlayer(player.Id);
            var playerPosition = CellSpaceConverter.CellToWorld(player.Position);
            playerView.WorldPosition = playerPosition;
        }
    }

    private PlayerView GetPlayer(int playerId)
    {
        var view = _players.FirstOrDefault(p => p.PlayerId == playerId);

        if (view == null)
        {
            view = Instantiate(_playerPrefab, _playersContainer);
            view.PlayerId = playerId;
            _players.Add(view);
        }

        return view;
    }
}
