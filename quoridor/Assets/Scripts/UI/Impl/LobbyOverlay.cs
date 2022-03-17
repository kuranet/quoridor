using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LobbyOverlay : Overlay
{
    [SerializeField] private Button _singePlayerButton;

    [Inject] public SignalBus SignalsBus { get; set; }

    private void Awake()
    {
        _singePlayerButton.onClick.AddListener(StartLocalPlayerGame);
    }

    private void StartLocalPlayerGame()
    {
        SignalsBus.Fire<StartLocalSessionSignal>();
    }
}
