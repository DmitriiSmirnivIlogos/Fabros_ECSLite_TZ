using Leopotam.EcsLite;
using UnityEngine;
using Zenject;


public class Startup
{
    private EcsWorld _ecsWorld;
    private IEcsSystems _systems;

    [Inject] private PlayerInitSystem _playerInitSystem;
    [Inject] private PlayerInputSystem _playerInputSystem;
    [Inject] private PlayerMoveSystem _playerMoveSystem;
    [Inject] private CameraFollowSystem _cameraFollowSystem;
    [Inject] private DoorOpenSystem _doorOpenSystem;

    public void Init()
    {
        _ecsWorld = new EcsWorld();

        _systems = new EcsSystems(_ecsWorld)
            .Add(_playerInitSystem)
            .Add(_playerInputSystem)
            .Add(_playerMoveSystem)
            .Add(_cameraFollowSystem)
            .Add(_doorOpenSystem);


        _systems.Init();
    }

    public void Update()
    {
        _systems.Run();
    }

    public void OnDestroy()
    {
        _systems.Destroy();
        _ecsWorld.Destroy();
    }
}