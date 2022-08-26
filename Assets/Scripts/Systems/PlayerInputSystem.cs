using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class PlayerInputSystem : IEcsRunSystem
{
    [Inject] IEnvironmentAdapter _environmentAdapter;
    
    public void Run(IEcsSystems ecsSystems)
    {
        var filter = ecsSystems.GetWorld().Filter<PlayerInputComponent>().End();
        var playerInputPool = ecsSystems.GetWorld().GetPool<PlayerInputComponent>();

        foreach (var entity in filter)
        {
            ref var playerInputComponent = ref playerInputPool.Get(entity);
            playerInputComponent.Waypoint = _environmentAdapter.LastClickPosition;
        }
    }
}