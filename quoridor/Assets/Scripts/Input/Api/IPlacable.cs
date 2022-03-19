using UnityEngine;

public interface IPlacable : IInteractable
{
    Vector3 WorldPosition { get; }
}
