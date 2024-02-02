using UnityEngine;

namespace StateSceneScripts
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterConfig _config;        
        private CharacterStateMachine _stateMachine;
        public CharacterConfig Config => _config;

        private void Awake() =>_stateMachine = new CharacterStateMachine(this);
        
        private void Update() => _stateMachine.Update();
    }
}
