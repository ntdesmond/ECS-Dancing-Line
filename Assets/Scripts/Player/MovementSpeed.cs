using System;
using UnityEngine;

namespace Player
{
    [Serializable]
    public struct MovementSpeed
    {
        [Min(0)]
        public float speed;
    }
}