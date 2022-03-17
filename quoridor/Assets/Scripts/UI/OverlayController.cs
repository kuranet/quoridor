using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OverlayController : MonoBehaviour
{
    private static List<Overlay> _overlays = new List<Overlay>();

    private void Awake()
    {
        _overlays.AddRange(GetComponentsInChildren<Overlay>());

        foreach (var overlay in _overlays)
        {
            DisableOverlay(overlay.GetType());
        }
    }

    public static void EnableOverlay(Type overlayType)
    {
        var targetOverlay = _overlays.FirstOrDefault(o => o.GetType() == overlayType);

        if (targetOverlay == null)
        {
            UnityEngine.Debug.LogError($"Can't find overlay type of {overlayType}");
            return;
        }

        targetOverlay.gameObject.SetActive(true);
    }

    public static void DisableOverlay(Type overlayType)
    {
        var targetOverlay = _overlays.FirstOrDefault(o => o.GetType() == overlayType);

        if (targetOverlay == null)
        {
            UnityEngine.Debug.LogError($"Can't find overlay type of {overlayType}");
            return;
        }

        targetOverlay.gameObject.SetActive(false);
    }
}
