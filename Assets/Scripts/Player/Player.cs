using Leopotam.Ecs;
using Shared;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private MovementSpeed _movementSpeed;
        public void CreateEntity(EcsWorld world)
        {
            var entity = world.NewEntity();
            
            entity.Get<PlayerTag>();
            entity.Get<Rotation>();
        
            ref var transformRef = ref entity.Get<TransformRef>();
            transformRef.Transform = transform;

            entity.Get<MovementSpeed>() = _movementSpeed;
        }
    }
}