using System;
using UnityEngine;

namespace CharacterSceneScripts
{
    [Serializable]
    public class AccelerationStateConfig
    {
        [SerializeField, Range(10, 50)] private float _speed;

        public float Speed => _speed;
    }
}
