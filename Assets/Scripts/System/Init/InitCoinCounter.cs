using System.Utils;
using Coin;
using CoinCounter;
using Leopotam.Ecs;
using Shared;

namespace System.Init
{
    public class InitCoinCounter : IEcsInitSystem
    {
        private EcsFilter<CoinTag> _coinFilter;
        private EcsFilter<CoinCount, TransformRef> _counterFilter;
        
        public void Init()
        {
            foreach (var i in _counterFilter)
            {
                // Find the total coin count and update the component
                var totalCoins = _coinFilter.GetEntitiesCount();
                ref var coinCount = ref _counterFilter.Get1(i);
                coinCount.total = totalCoins;
                
                // Update the counter text
                CoinCounterActions.Update(
                    _counterFilter.Get2(i).Transform.GetComponent<UnityEngine.UI.Text>(),
                    coinCount
                );
            }
        }
    }
}