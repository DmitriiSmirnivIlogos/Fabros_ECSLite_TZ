using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

public class DoorOpenSystem:IEcsInitSystem,IEcsRunSystem
{
    public void Init(IEcsSystems systems)
    {
        Debug.LogError("Init");
    }

    public void Run(IEcsSystems systems)
    {
        Debug.LogError("Run");
    }
}
