using Leopotam.EcsLite;


    public class Startup
    {
        private EcsWorld ecsWorld;
        private IEcsSystems initSystems;
        private IEcsSystems updateSystems;

        public void Init()
        {
            ecsWorld = new EcsWorld();


            initSystems = new EcsSystems(ecsWorld)
                .Add(new PlayerInitSystem());

            initSystems.Init();

            updateSystems = new EcsSystems(ecsWorld)
                .Add(new PlayerInputSystem())
                .Add(new PlayerMoveSystem())
                .Add(new CameraFollowSystem());

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
