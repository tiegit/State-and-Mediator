using UnityEngine;

namespace StateSceneScripts
{
    public class SleepingState : BehaviorState
    {
        private readonly SleepingStateConfig _sleepingStateConfig;
        public SleepingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {            
            _sleepingStateConfig = CharacterConfig.SleepingStateConfig;
            TargetPoint = _sleepingStateConfig.SleepPoint;
        }
        public override void Enter() => base.Enter();

        public override void Exit() => base.Exit();

        public override void HandleInput()
        {
            base.HandleInput();

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Меня заставили и Я иду есть мясо");
                StateSwitcher.SwitchState<EatingState>();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Меня заставили и Я иду работать работу");
                StateSwitcher.SwitchState<WorkingState>();
            }
        }

        public override void Update()
        {
            base.Update();

            float distance = (TargetPoint - _character.transform.position).magnitude;

            if (distance < CharacterConfig.ReachDistance)
            {
                if (IsStatePointReached == false)
                    IsStatePointReached = true;

                Data.Health -= (Time.deltaTime / CharacterConfig.HealthLiveTime) * _sleepingStateConfig.HealthMultiplayer * CharacterConfig.MaxHealth;
                Data.Energy += Time.deltaTime / _sleepingStateConfig.EnergyRestoreTime * CharacterConfig.MaxEnergy;

                if (Data.Energy >= (CharacterConfig.MaxEnergy * 0.9f))
                    StateSwitcher.SwitchState<EatingState>();
            }
        }
    }
}
