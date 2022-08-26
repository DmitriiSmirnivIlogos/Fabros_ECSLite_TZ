using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class DoorOpenSystem : IEcsInitSystem, IEcsRunSystem
{
    [Inject] IEnvironmentAdapter _environmentAdapter;
    
    private const float Threshold = 0.5f;

    public void Init(IEcsSystems ecsSystems)
    {
        var ecsWorld = ecsSystems.GetWorld();

        var doorsInfo = _environmentAdapter.GetDoorsInfo();

        foreach (var info in doorsInfo)
        {
            var doorEntity = ecsWorld.NewEntity();

            var doorButtonPool = ecsWorld.GetPool<DoorButtonComponent>();
            doorButtonPool.Add(doorEntity);

            ref var doorButtonComponent = ref doorButtonPool.Get(doorEntity);

            doorButtonComponent.Position = info.ButtonPosition;
            doorButtonComponent.DoorID = info.DoorID;

            var openingDoorPool = ecsWorld.GetPool<OpeningDoorComponent>();
            openingDoorPool.Add(doorEntity);
        }
    }

    public void Run(IEcsSystems ecsSystems)
    {
        var filter = ecsSystems.GetWorld().Filter<DoorButtonComponent>().Inc<OpeningDoorComponent>().End();

        var doorButtonPool = ecsSystems.GetWorld().GetPool<DoorButtonComponent>();
        var openingDoorPool = ecsSystems.GetWorld().GetPool<OpeningDoorComponent>();
        var playerPool = ecsSystems.GetWorld().GetPool<PlayerComponent>();
        var doorsInfo = _environmentAdapter.GetDoorsInfo();
        ref var playerComponent = ref playerPool.Get(0);
        
        foreach (var entity in filter)
        {
            ref var doorButtonComponent = ref doorButtonPool.Get(entity);
            ref var openingDoorComponent = ref openingDoorPool.Get(entity);
          

            if (Vector3.Distance(playerComponent.Position, doorButtonComponent.Position) < Threshold)
            {
                var component = doorButtonComponent;
                Vector3 currentRotation = doorsInfo.Find(x => x.DoorID == component.DoorID).DoorRotation;
                
                _environmentAdapter.SetDoorAngle(doorButtonComponent.DoorID,Vector3.SmoothDamp(currentRotation, new Vector3(0,90,0),
                    ref openingDoorComponent.CurrentVelocity, 5));
            }
        }
    }
}