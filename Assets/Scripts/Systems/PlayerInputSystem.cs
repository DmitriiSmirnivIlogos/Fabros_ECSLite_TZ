using Leopotam.EcsLite;
using UnityEngine;

public class PlayerInputSystem : IEcsRunSystem
{
    public void Run(IEcsSystems ecsSystems)
    {
        var filter = ecsSystems.GetWorld().Filter<PlayerInputComponent>().End();
        var playerInputPool = ecsSystems.GetWorld().GetPool<PlayerInputComponent>();

        foreach (var entity in filter)
        {
            ref var playerInputComponent = ref playerInputPool.Get(entity);

            playerInputComponent.moveInput =
                new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }
    }
}