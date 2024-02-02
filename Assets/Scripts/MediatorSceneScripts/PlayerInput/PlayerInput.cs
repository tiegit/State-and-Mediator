using UnityEngine;

namespace MediatorSceneScripts
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerInputMediator _playerInputMediator;
        public void Initialize(PlayerInputMediator playerInputMediator) => _playerInputMediator = playerInputMediator;

        public void Update()
        {
            bool levelUp = Input.GetKeyDown(KeyCode.L);
            bool healthAdd = Input.GetKeyDown(KeyCode.UpArrow);
            bool healthReduce = Input.GetKeyDown(KeyCode.DownArrow);

            if (levelUp) _playerInputMediator.IncreaseLevel();

            if (healthAdd) _playerInputMediator.AddHealth();

            if (healthReduce) _playerInputMediator.RemoveHealth();
        }
    }
}