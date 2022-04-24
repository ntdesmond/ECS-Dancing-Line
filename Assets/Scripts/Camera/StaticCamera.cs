using Leopotam.Ecs;
using Shared;
using UnityEngine;

namespace Camera
{
    public class StaticCamera : MonoBehaviour
    {
        public void CreateEntity(EcsWorld world)
        {
            var entity = world.NewEntity();
            entity.Get<CameraTag>();
        
            ref var transformRef = ref entity.Get<TransformRef>();
            transformRef.Transform = transform;
        }
    }
}