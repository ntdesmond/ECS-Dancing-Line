using Camera;
using Leopotam.Ecs;
using Player;
using Shared;
using UnityEngine;

namespace System
{
    public class CameraMovement : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<TransformRef, PlayerTag> _playerFilter;
        private EcsFilter<TransformRef, CameraTag> _cameraFilter;

        private Vector3 _initialCameraOffset;
        public void Init()
        {
            foreach (var i in _playerFilter)
            {
                var playerPos = _playerFilter.Get1(i).Transform.position;
                foreach (var j in _cameraFilter)
                {
                    var cameraPos = _cameraFilter.Get1(i).Transform.position;
                    _initialCameraOffset = cameraPos - playerPos;
                }
            }
        }

        public void Run()
        {
            foreach (var i in _playerFilter)
            {
                var playerPos = _playerFilter.Get1(i).Transform.position;
                foreach (var j in _cameraFilter)
                {
                    ref var cameraTransform = ref _cameraFilter.Get1(i);
                    cameraTransform.Transform.position = playerPos + _initialCameraOffset;
                }
            }
        }
    }
}