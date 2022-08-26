using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMoveSystem : IEcsRunSystem
{
    [Inject] private IEnvironmentAdapter _adapter;
    
    private const float Threshold = 0.1f;

    public void Run(IEcsSystems ecsSystems)
    {
        var filter = ecsSystems.GetWorld().Filter<PlayerComponent>().Inc<PlayerInputComponent>().End();
        var playerPool = ecsSystems.GetWorld().GetPool<PlayerComponent>();
        var playerInputPool = ecsSystems.GetWorld().GetPool<PlayerInputComponent>();

        foreach (var entity in filter)
        {
            ref var playerComponent = ref playerPool.Get(entity);
            ref var playerInputComponent = ref playerInputPool.Get(entity);

            playerComponent.Position = _adapter.GetCharacterPosition();

            if (playerInputComponent.Waypoint == Vector3.zero)
            {
                continue;
            }

            if (Vector3.Distance(GroundedPosition(playerInputComponent.Waypoint),
                    GroundedPosition(playerComponent.Position)) < Threshold)
            {
                _adapter.StopCharacter();
                playerComponent.IsMoving = false;
                continue;
            }

            if (playerComponent.IsMoving)
            {
                continue;
            }

            _adapter.SetCharacterLookAt(playerInputComponent.Waypoint);
            _adapter.SetCharacterMoveForward();
        }
    }

    private Vector3 GroundedPosition(Vector3 position)
    {
        return new Vector3(position.x, 0, position.z);
    }
}