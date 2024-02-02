using UnityEngine;

namespace StateSceneScripts
{
    [CreateAssetMenu(menuName = "Configs/CharcterConfig", fileName = "CharcterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [Space(20)]
        [SerializeField] private float _movementSpeed = 10f;
        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private float _maxEnergy = 200f;
        [SerializeField] private float _startHealth = 50f;
        [SerializeField] private float _startEnergy = 100f;
        
        [Space(20)]
        [SerializeField] private float _healthLiveTime = 15f;
        [SerializeField] private float _energyLiveTime = 25f;
        [SerializeField, Range(0, 2)] private float _reachDistance = 1f;
        
        [Space(20)]
        [SerializeField] private EatingStateConfig _eatingStateConfig;
        [Space]
        [SerializeField] private SleepingStateConfig _sleepingStateConfig;
        [Space]
        [SerializeField] private WorkingStateConfig _workingStateConfig;

        public float MovementSpeed=> _movementSpeed;
        public float MaxHealth => _maxHealth;
        public float MaxEnergy => _maxEnergy;
        public float StartHealth => _startHealth;
        public float StartEnergy => _startEnergy;

        public float HealthLiveTime => _healthLiveTime;
        public float EnergyLiveTime => _energyLiveTime;
        public float ReachDistance => _reachDistance;

        public EatingStateConfig EatingStateConfig => _eatingStateConfig;
        public SleepingStateConfig SleepingStateConfig => _sleepingStateConfig;
        public WorkingStateConfig WorkingStateConfig => _workingStateConfig;
    }
}
