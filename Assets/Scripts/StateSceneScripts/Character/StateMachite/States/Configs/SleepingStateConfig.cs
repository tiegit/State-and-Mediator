using System;
using UnityEngine;

namespace StateSceneScripts
{
    [Serializable]
    public class SleepingStateConfig
    {
        [SerializeField, Range(0, 1)] private float _healthMultiplayer = 0.2f;
        [SerializeField, Range(1, 8)] private float _energyRestoreTime = 5f;
        [SerializeField] private Vector3 _sleepPoint;

        public float HealthMultiplayer => _healthMultiplayer;
        public float EnergyRestoreTime => _energyRestoreTime;
        public Vector3 SleepPoint => _sleepPoint;
    }
}
