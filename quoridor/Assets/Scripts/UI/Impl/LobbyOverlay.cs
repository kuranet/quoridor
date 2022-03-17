using UnityEngine;
using UnityEngine.UI;

public class LobbyOverlay : Overlay
{
    [SerializeField] private Button _singePlayerButton;

    private void Awake()
    {
        _singePlayerButton.onClick.AddListener(StartLocalPlayerGame);
    }

    private void StartLocalPlayerGame()
    {
        Debug.Log("start local player");
    }
}
