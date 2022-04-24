using Shared;
using Leopotam.Ecs;
using UnityEngine;

namespace CoinCounter
{
    public class CoinCounter : MonoBehaviour
    {
        private EcsEntity _entity;
        
        public void CreateEntity(EcsWorld world)
        {
            _entity = world.NewEntity();
            _entity.Get<CoinCount>();
            
            ref var transformRef = ref _entity.Get<TransformRef>();
            transformRef.Transform = transform;
        }
    }
}
