using System;
using System.Init;
using Camera;
using Leopotam.Ecs;
using UnityEngine;

public class Startup : MonoBehaviour
{
    [SerializeField] private Player.Player _player;
    [SerializeField] private StaticCamera _camera;
    [SerializeField] private CoinCounter.CoinCounter _coinCounter;
    [SerializeField] private FallTrigger.FallTrigger _fallTrigger;

    [SerializeField] private StaticData _prefabs;
    
    [Min(5)]
    [Tooltip("Level length in field part pieces")]
    [SerializeField] private int _levelLength;
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world)
            .Add(new FinishGame())
            .Add(new CoinPickup())
            .Add(new InitGameField())
            .Add(new InitEntities())
            .Add(new InitCoinCounter())
            .Add(new PlayerMovement())
            .Add(new CameraMovement())
            .Inject(_player)
            .Inject(_camera)
            .Inject(_coinCounter)
            .Inject(_fallTrigger)
            .Inject(_prefabs)
            .Inject(_levelLength);
        _systems.Init();
    }

    private void Update() {
        _systems.Run();
    }

    private void OnDestroy() {
        _systems.Destroy();
        _world.Destroy();
    }
}