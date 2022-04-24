using FallTrigger;
using FinishTrigger;
using Leopotam.Ecs;
using Player;
using UnityEngine;

namespace System
{
    public class FinishGame : IEcsRunSystem
    {
        private EcsFilter<FellDownEvent, FallTriggerTag> _fallFilter;
        private EcsFilter<FinishReachedEvent, FinishTag> _finishFilter;
        private EcsFilter<PlayerTag> _playerFilter;
        
        public void Run()
        {
            // Destroy the entities since we won't need them anymore
            var finishReached = DestroyEntities(_finishFilter);
            var fellDown = DestroyEntities(_fallFilter);
            
            if (!finishReached && !fellDown)
            {
                return;
            }
            
            Debug.Log(fellDown ? "You lose" : "Level complete!");
            
            // Player GameObject would remain
            DestroyEntities(_playerFilter);
        }

        /// <summary>
        /// Destroy the entities matched by filter
        /// </summary>
        /// <param name="filter">Filter with matched entities</param>
        /// <returns>true if the filter matched any entity, false otherwise</returns>
        private bool DestroyEntities(EcsFilter filter)
        {
            bool destroyedAny = false;
            foreach (var i in filter)
            {
                filter.GetEntity(i).Destroy();
                destroyedAny = true;
            }

            return destroyedAny;
        }
    }
}