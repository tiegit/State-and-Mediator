using UnityEngine;

namespace MediatorSceneScripts
{
    public class Player : MonoBehaviour, IControllable
    {
        private ViewPanelsMediator _viewPanelsMediator;

        [SerializeField] private int _playerLevel = 0;
        [SerializeField] private int _health = 50;
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _healthChangeValue = 10;

        private int _startPlayerLevel;
        private int _startPlayerHealth;

        protected int PlayerLevel
        {
            get => _playerLevel;
            private set => _playerLevel = value;
        }
        protected int PlayerHealth
        {
            get => _health;
            private set
            {
                if (value <= 0)
                {
                    _health = 0;
                    OnDefeat();
                }
                else if (value > _maxHealth)
                    _health = _maxHealth;
                else
                    _health = value;
            }
        }

        private void Start()
        {
            _startPlayerLevel = PlayerLevel;
            _startPlayerHealth = PlayerHealth;

            RestartGame();
        }

        public void Initialize(ViewPanelsMediator viewPanelMediator) => _viewPanelsMediator = viewPanelMediator;

        public void AddHealth()
        {
            PlayerHealth += _healthChangeValue;
            SetHealth(PlayerHealth);
        }

        public void RemoveHealth()
        {
            PlayerHealth -= _healthChangeValue;
            SetHealth(PlayerHealth);
        }

        public void IncreaseLevel()
        {
            PlayerLevel++;
            SetLevel(PlayerLevel);
        }

        public void RestartGame()
        {
            PlayerLevel = _startPlayerLevel;
            PlayerHealth = _startPlayerHealth;

            SetLevel(PlayerLevel);
            SetHealth(PlayerHealth);
        }

        private void OnDefeat() => _viewPanelsMediator.OnDefeat();

        private void SetLevel(int level) => _viewPanelsMediator.SetLevel(level);

        private void SetHealth(int health) => _viewPanelsMediator.SetHealth(health);
    }
}