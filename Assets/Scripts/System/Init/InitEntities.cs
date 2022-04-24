using Leopotam.Ecs;

namespace System.Init
{
    public class InitEntities : IEcsInitSystem
    {
        private EcsWorld _world;

        private Player.Player _player;
        private Camera.StaticCamera _camera;
        private CoinCounter.CoinCounter _coinCounter;
        private FallTrigger.FallTrigger _fallTrigger;
        
        public void Init()
        {
            _player.CreateEntity(_world);
            _camera.CreateEntity(_world);
            _coinCounter.CreateEntity(_world);
            _fallTrigger.CreateEntity(_world);
        }
    }
}