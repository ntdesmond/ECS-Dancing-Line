using System.Utils;
using Coin;
using CoinCounter;
using Leopotam.Ecs;
using Player;
using Shared;

namespace System
{
    public class CoinPickup : IEcsRunSystem
    {
        private EcsFilter<CoinPickupEvent, TransformRef, CoinTag> _coinFilter;
        private EcsFilter<CoinCount, TransformRef> _counterFilter;
        private EcsFilter<PlayerTag> _playerFilter;
        
        public void Run()
        {
            foreach (var i in _coinFilter)
            {
                foreach (var _ in _playerFilter)
                {
                    // Destroy the coin and its entity
                    UnityEngine.Object.Destroy(_coinFilter.Get2(i).Transform.gameObject);
                    _coinFilter.GetEntity(i).Destroy();
                }
                
                foreach (var j in _counterFilter)
                {
                    // Update the collected count
                    ref var coinCount = ref _counterFilter.Get1(j);
                    coinCount.collected++;
                    
                    // Update the counter text
                    CoinCounterActions.Update(
                        _counterFilter.Get2(i).Transform.GetComponent<UnityEngine.UI.Text>(),
                        coinCount
                    );
                }
            }
        }
    }
}