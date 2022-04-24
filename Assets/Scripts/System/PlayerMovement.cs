using Leopotam.Ecs;
using Player;
using Shared;
using UnityEngine;

namespace System
{
    public class PlayerMovement : IEcsRunSystem
    {
        private EcsFilter<TransformRef, Rotation, MovementSpeed, PlayerTag> _filter;
    
        public void Run()
        {
            var shouldChangeDirection = Input.GetMouseButtonDown(0);
            foreach (var i in _filter)
            {
                ref var transformRef = ref _filter.Get1(i);
                ref var rotation = ref _filter.Get2(i);
            
                // Rotate if button is clicked
                if (shouldChangeDirection)
                {
                    rotation.IsRotated = !rotation.IsRotated;
                }
            
                // Get direction and speed
                var direction = rotation.IsRotated ? Vector3.forward : Vector3.right;
                var speed = _filter.Get3(i).speed;
            
                // Move
                transformRef.Transform.position += direction * speed * Time.deltaTime;
            }
        }
    }
}