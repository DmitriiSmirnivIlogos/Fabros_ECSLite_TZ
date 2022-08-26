using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMoveSystem : IEcsRunSystem
    {
        [Inject] private IEnvironmentAdapter _adapter;

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

                if(playerInputComponent.moveInput.magnitude>0.1f)
                {
                   _adapter.SetCharacterMoveForward();
                }
                else
                {
                    _adapter.StopCharacter();
                }
            }
            
        }
    }
