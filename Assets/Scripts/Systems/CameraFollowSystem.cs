using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class CameraFollowSystem : IEcsInitSystem, IEcsRunSystem
    {
        [Inject] IEnvironmentAdapter _environmentAdapter;
        private int _cameraEntity;
        private const float Smoothness = 0.5f;
        private Vector3 _cameraOffset = new Vector3(-1, 7, 5);

        public void Init(IEcsSystems ecsSystems)
        {
            var cameraEntity = ecsSystems.GetWorld().NewEntity();

            var cameraPool = ecsSystems.GetWorld().GetPool<CameraComponent>();
            cameraPool.Add(cameraEntity);
            ref var cameraComponent = ref cameraPool.Get(cameraEntity);

            cameraComponent.cameraSmoothness = Smoothness;
            cameraComponent.curVelocity = Vector3.zero;
            cameraComponent.offset = _cameraOffset;
            cameraComponent.rotation = _environmentAdapter.GetCameraEulerAngles();

            this._cameraEntity = cameraEntity;
        }

        public void Run(IEcsSystems ecsSystems)
        {
            var filter = ecsSystems.GetWorld().Filter<PlayerComponent>().End();
            var playerPool = ecsSystems.GetWorld().GetPool<PlayerComponent>();
            var cameraPool = ecsSystems.GetWorld().GetPool<CameraComponent>();

            ref var cameraComponent = ref cameraPool.Get(_cameraEntity);

            foreach (var entity in filter)
            {
                ref var playerComponent = ref playerPool.Get(entity);

                Vector3 currentPosition = _environmentAdapter.GetCameraPosition();
                Vector3 targetPoint = playerComponent.Position + cameraComponent.offset;

                _environmentAdapter.SetCameraPosition(Vector3.SmoothDamp(currentPosition, targetPoint,
                    ref cameraComponent.curVelocity, cameraComponent.cameraSmoothness));
            }
        }
    }
