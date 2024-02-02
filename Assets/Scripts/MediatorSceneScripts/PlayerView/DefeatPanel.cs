using System;
using UnityEngine;
using UnityEngine.UI;

namespace MediatorSceneScripts
{
    public class DefeatPanel : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;

        private ViewPanelsMediator _viewPanelsMediator;
        private IRestartLevel _playerInputMediator;

        public void Initialize(ViewPanelsMediator viewPanelMediator, IRestartLevel playerInputMediator)
        {
            _viewPanelsMediator = viewPanelMediator;
            _playerInputMediator = playerInputMediator;

            _viewPanelsMediator.DefeatPanelOpened += OnDefeatPanelOpened;
        }

        public void ShowPanel() => gameObject.SetActive(true);

        public void HidePanel() => gameObject.SetActive(false);

        private void OnEnable() => _restartButton.onClick.AddListener(OnRestartClick);

        private void OnDisable() => _restartButton.onClick.RemoveListener(OnRestartClick);

        private void OnDestroy() => _viewPanelsMediator.DefeatPanelOpened -= OnDefeatPanelOpened; // если делать в OnDisable(), то второй раз не сработает. Отпишется, а подписка только в Initialize()

        private void OnDefeatPanelOpened()
        {
            ShowPanel();
            BlockPlayerInputBeforRestart();
        }

        private void OnRestartClick()
        {
            HidePanel();
            _playerInputMediator.RestartGame();

            UnblockPlayerInputAfterRestart();
        }

        private void BlockPlayerInputBeforRestart() => _playerInputMediator.BlockPlayerInput();

        private void UnblockPlayerInputAfterRestart() => _playerInputMediator.UnblockPlayerInput();
    }
}
