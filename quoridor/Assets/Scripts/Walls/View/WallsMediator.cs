using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WallsMediator : MonoBehaviour
{
    [Inject] public IWallsController WallsController { get; set; }
}
