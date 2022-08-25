using Leopotam.EcsLite;
using UnityEngine;

public class PlayerInitSystem : IEcsInitSystem
{
    public void Init(IEcsSystems systems)
    {
        var ecsWorld = systems.GetWorld();

        var playerEntity = ecsWorld.NewEntity();
        
        var playerPool = ecsWorld.GetPool<PlayerComponent>();
        playerPool.Add(playerEntity);
        ref var playerComponent = ref playerPool.Get(playerEntity);
        var playerInputPool = ecsWorld.GetPool<PlayerInputComponent>();
        playerInputPool.Add(playerEntity);
        
        var playerGO = GameObject.FindGameObjectWithTag("Player");
        playerComponent.playerSpeed = 1;
        playerComponent.playerTransform = playerGO.transform;
        playerComponent.playerCollider = playerGO.GetComponent<CapsuleCollider>();
        playerComponent.playerRB = playerGO.GetComponent<Rigidbody>();

    }
}
