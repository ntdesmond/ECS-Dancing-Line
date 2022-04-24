using Leopotam.Ecs;
using UnityEngine;

namespace FallTrigger
{
    public class FallTrigger : MonoBehaviour
    {
        private EcsEntity _entity;
        
        public void CreateEntity(EcsWorld world)
        {
            _entity = world.NewEntity();
            _entity.Get<FallTriggerTag>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player.Player>())
            {
                _entity.Get<FellDownEvent>();
            }
        }
    }
}