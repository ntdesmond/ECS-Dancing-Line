using Leopotam.Ecs;
using UnityEngine;

namespace System.Init
{
    public class InitGameField : IEcsInitSystem
    {
        private EcsWorld _world;
        
        private StaticData _prefabs;
        private int _levelLength;

        private bool isRotated;
        private Vector3 nextPiecePosition;
        
        public void Init()
        {
            GenerateWorld();
        }
        
        private void GenerateWorld()
        {
            var remainingLength = _levelLength - 1;
        
            // Generate field pieces up to level length in total
            while (remainingLength > 0)
            {
                var lineLength = Mathf.Clamp(UnityEngine.Random.Range(3, 8), 0, remainingLength);
                for (var i = 0; i < lineLength; i++)
                {
                    if (UnityEngine.Random.value > 0.7)
                    {
                        // Place a coin and create an entity for it
                        var coin = PlaceCoin();
                        coin.GetComponent<Coin.Coin>().CreateEntity(_world);
                    }
                    
                    PlaceFieldPiece(_prefabs.fieldPiecePrefab);
                }
            
                isRotated = !isRotated;
                remainingLength -= lineLength;
            }
            
            // Place the finish
            isRotated = !isRotated; 
            var finish = PlaceFieldPiece(_prefabs.finishPrefab);
            
            // Create FinishTrigger entity
            finish.GetComponentInChildren<FinishTrigger.FinishTrigger>().CreateEntity(_world);
        }

        private Transform PlaceFieldPiece(Transform fieldPiece)
        {
            Transform instance;
            var scale = fieldPiece.localScale;
            if (isRotated)
            {
                instance = UnityEngine.Object.Instantiate(
                    fieldPiece, nextPiecePosition, Quaternion.Euler(0, -90, 0)
                );
                nextPiecePosition.z += scale.z;
            }
            else
            {
                instance = UnityEngine.Object.Instantiate(
                    fieldPiece, nextPiecePosition, Quaternion.identity
                );
                nextPiecePosition.x += scale.x;
            }

            return instance;
        }

        private Transform PlaceCoin()
        {
            var coinPosition = nextPiecePosition;
            coinPosition.y += _prefabs.fieldPiecePrefab.transform.lossyScale.y * 1.5f;
            return UnityEngine.Object.Instantiate(_prefabs.coinPrefab, coinPosition, Quaternion.identity);
        }
    }
}