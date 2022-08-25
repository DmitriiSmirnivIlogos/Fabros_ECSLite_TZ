using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

class Startup : MonoBehaviour
{
    private EcsWorld _world;
    private IEcsSystems _initSystems;
    private IEcsSystems _updateSystems;
    private List<IEcsSystems> _allSystems;


    void Start()
    {
        _world = new EcsWorld();

        var gameData = new GameData();
        _initSystems = new EcsSystems(_world, gameData)
            .Add(new PlayerInitSystem());

        _initSystems.Init();


        _updateSystems = new EcsSystems(_world, gameData)
            .Add(new PlayerInputSystem())
            .Add(new PlayerMoveSystem())
            .Add(new CameraFollowSystem());

        _updateSystems.Init();


        _allSystems = new List<IEcsSystems>() { _initSystems, _updateSystems };
    }

    void Update()
    {
        // Выполняем все подключенные системы.
        _updateSystems?.Run();
    }

    void OnDestroy()
    {
        for (var index = 0; index < _allSystems.Count; index++)
        {
            if (_allSystems[index] != null)
            {
                _allSystems[index].Destroy();
                _allSystems[index] = null;
            }
        }
        _allSystems.Clear();
        _allSystems = null;
    }
}