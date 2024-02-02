using System;
using UnityEngine;

namespace StateSceneScripts
{
    [Serializable]
    public class EatingStateConfig
    {
        [SerializeField, Range(1, 8)] private float _healthRestoreTime = 5f;
        [SerializeField, Range(0, 1)] private float _energyMultiplayer = 0.5f;
        [SerializeField] private Vector3 _eatPoint;

        public float HealthRestoreTime => _healthRestoreTime;
        public float EnergyMultiplayer => _energyMultiplayer;
        public Vector3 EatPoint => _eatPoint;
    }
}
