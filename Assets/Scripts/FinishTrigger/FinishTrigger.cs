using Leopotam.Ecs;
using UnityEngine;

namespace FinishTrigger
{
    public class FinishTrigger : MonoBehaviour
    {
        private EcsEntity _entity;
        
        public void CreateEntity(EcsWorld world)
        {
            _entity = world.NewEntity();
            _entity.Get<FinishTag>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player.Player>())
            {
                _entity.Get<FinishReachedEvent>();
            }
        }
    }
}