using UnityEngine;

namespace MediatorSceneScripts
{
    public class GameLoader : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private DefeatPanel _defeatPanel;
        [SerializeField] private PlayerViewPanel _playerViewPanel;

        private PlayerInputMediator _playerInputMediator;
        private ViewPanelsMediator _viewPanelsMediator;

        public PlayerInputMediator PlayerInputMediator => _playerInputMediator;

        private void Awake()
        {
            _playerInputMediator = new PlayerInputMediator(_player);
            _viewPanelsMediator = new ViewPanelsMediator();

            _playerInput.Initialize(_playerInputMediator);
            _player.Initialize(_viewPanelsMediator);

            _playerViewPanel.Initialize(_viewPanelsMediator);
            _defeatPanel.Initialize(_viewPanelsMediator, _playerInputMediator);
        }
    }
}
