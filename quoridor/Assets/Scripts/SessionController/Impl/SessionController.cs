using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SessionController : ISessionController
{
    [Inject]
    public void Initialize()
    {
        Debug.Log("initialized");
    }
}
