using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class PlayerInitSystem : IEcsInitSystem
    {
        [Inject] IEnvironmentAdapter _environmentAdapter;
        public void Init(IEcsSystems ecsSystems)
        {
            var ecsWorld = ecsSystems.GetWorld();

            var playerEntity = ecsWorld.NewEntity();

            var playerPool = ecsWorld.GetPool<PlayerComponent>();
            playerPool.Add(playerEntity);
            var playerInputPool = ecsWorld.GetPool<PlayerInputComponent>();
            playerInputPool.Add(playerEntity);
        }
    }
