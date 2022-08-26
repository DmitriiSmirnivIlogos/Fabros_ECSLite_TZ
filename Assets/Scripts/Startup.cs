using Leopotam.EcsLite;
using UnityEngine;
using Zenject;


public class Startup
{
    private EcsWorld ecsWorld;
    private IEcsSystems initSystems;
    private IEcsSystems updateSystems;

    [Inject] private PlayerInitSystem _playerInitSystem;
    [Inject] private PlayerInputSystem _playerInputSystem;
    [Inject] private PlayerMoveSystem _playerMoveSystem;
    [Inject] private PlayerInitSystem _cameraFollowSystem;

    public void Init()
    {
        ecsWorld = new EcsWorld();


        initSystems = new EcsSystems(ecsWorld)
            .Add(_playerInitSystem);
        initSystems.Init();
        
        updateSystems = new EcsSystems(ecsWorld)
            .Add(_playerInputSystem)
            .Add(_playerMoveSystem)
            .Add(_cameraFollowSystem);

 
      
        updateSystems.Init();

       
    }

    public void Update()
    {
        updateSystems.Run();
    }

    public void OnDestroy()
    {
        initSystems.Destroy();
        updateSystems.Destroy();
        ecsWorld.Destroy();
    }
}