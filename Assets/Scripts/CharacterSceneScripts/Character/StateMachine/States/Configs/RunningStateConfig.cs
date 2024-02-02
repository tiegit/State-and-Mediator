using System;
using UnityEngine;

namespace CharacterSceneScripts
{
    [Serializable]
    public class RunningStateConfig
    {
        [SerializeField, Range(0, 10)] private float _speed;
        [SerializeField, Range(1, 10)] private float _animationSpeedModifier = 5f;

        public float Speed => _speed;

        [SerializeField] private AccelerationStateConfig _accelerationStateConfig;
        [SerializeField] private WalkingStateConfig _walkingStateConfig;

        public AccelerationStateConfig AccelerationStateConfig => _accelerationStateConfig;
        public WalkingStateConfig WalkingStateConfig => _walkingStateConfig;

        public float AnimationSpeedModifier => _animationSpeedModifier;
    }
}