using System;
using UnityEngine;

namespace CharacterSceneScripts
{
    [Serializable]
    public class WalkingStateConfig
    {
        [SerializeField, Range(0, 5)] private float _speed;

        public float Speed => _speed;
    }
}
