using System;
using UnityEngine;

namespace StateSceneScripts
{
    public abstract class BehaviorState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly StateMachineData Data;
        protected readonly Character _character;
        
        protected Vector3 TargetPoint;        
        protected bool IsStatePointReached;

        private readonly Transform _characterTransform;
        private readonly CharacterConfig _config;

        public BehaviorState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
        {
            StateSwitcher = stateSwitcher;
            Data = data;
            _character = character;

            _characterTransform = _character.transform;
            _config = _character.Config;
        }

        public CharacterConfig CharacterConfig => _config;

        public virtual void Enter()
        {
            IsStatePointReached = false;
            Debug.Log(GetType());
        }

        public virtual void Exit()
        {
            Debug.Log("Мое здоровье: " + (int)Data.Health);
            Debug.Log("Моя энергия: " + (int)Data.Energy);
        }

        public virtual void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Debug.Log("Что-то можно сделать одинаковое для всех");            
        }
            
        public virtual void Update()
        {
            HandleInput();

            if (IsStatePointReached == false)
                MoveTo(TargetPoint);
        }

        public void MoveTo(Vector3 position)
        {
            position.y = _characterTransform.position.y;

            _characterTransform.position = Vector3.MoveTowards(_characterTransform.position, position, Time.deltaTime * CharacterConfig.MovementSpeed);
            _characterTransform.rotation = Quaternion.LookRotation(position - _characterTransform.position);
        }
    }
}
