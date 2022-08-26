using Leopotam.EcsLite;
using UnityEngine;

    public class PlayerInitSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems ecsSystems)
        {
            var ecsWorld = ecsSystems.GetWorld();

            var playerEntity = ecsWorld.NewEntity();

            var playerPool = ecsWorld.GetPool<PlayerComponent>();
            playerPool.Add(playerEntity);
            ref var playerComponent = ref playerPool.Get(playerEntity);
            var playerInputPool = ecsWorld.GetPool<PlayerInputComponent>();
            playerInputPool.Add(playerEntity);

            var playerGO = GameObject.FindGameObjectWithTag("Player");
            playerComponent.playerSpeed = 10;
            playerComponent.playerTransform = playerGO.transform;
            playerComponent.playerRB = playerGO.GetComponent<Rigidbody>();
        }
    }
