using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private UnityAdapter _unityAdapter;
    public override void InstallBindings()
    {
        Container.Bind<Startup>().AsSingle().NonLazy();
        
        Container.Bind<PlayerInputSystem>().AsSingle().NonLazy();
        Container.Bind<PlayerInitSystem>().AsSingle().NonLazy();
        Container.Bind<PlayerMoveSystem>().AsSingle().NonLazy();
        Container.Bind<CameraFollowSystem>().AsSingle().NonLazy();
        
        Container.BindInterfacesAndSelfTo<UnityAdapter>().FromComponentInHierarchy(_unityAdapter).AsSingle();
    }
}
