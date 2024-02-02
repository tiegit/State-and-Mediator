using TMPro;
using UnityEngine;

namespace MediatorSceneScripts
{
    public class PlayerViewPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelNumber;
        [SerializeField] private TextMeshProUGUI _healthCount;

        private ViewPanelsMediator _viewPanelsMediator;

        public void Initialize(ViewPanelsMediator viewPanelMediator)
        {
            _viewPanelsMediator = viewPanelMediator;

            _viewPanelsMediator.LevelChanged += OnLevelChanged;
            _viewPanelsMediator.HealthChanged += OnHealthChanged;
        }

        private void OnLevelChanged(int level) => _levelNumber.text = level.ToString();

        private void OnHealthChanged(int health) => _healthCount.text = health.ToString();

        private void OnDisable()
        {
            _viewPanelsMediator.LevelChanged -= OnLevelChanged;
            _viewPanelsMediator.HealthChanged -= OnHealthChanged;
        }
    }
}