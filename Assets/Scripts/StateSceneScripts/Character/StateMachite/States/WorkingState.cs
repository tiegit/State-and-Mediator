using UnityEngine;

namespace StateSceneScripts
{
    public class WorkingState : BehaviorState
    {
        private readonly WorkingStateConfig _wokingStateConfig;
        public WorkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
            _wokingStateConfig = CharacterConfig.WorkingStateConfig;
            TargetPoint = _wokingStateConfig.WorkPoint;
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

            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Меня заставили и Я иду отдыхать");
                StateSwitcher.SwitchState<SleepingState>();
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

                Data.Health -= Time.deltaTime / CharacterConfig.HealthLiveTime * CharacterConfig.MaxHealth;
                Data.Energy -= Time.deltaTime / CharacterConfig.EnergyLiveTime * CharacterConfig.MaxEnergy;

                if (Data.Health <= (CharacterConfig.MaxHealth * 0.2f))
                    StateSwitcher.SwitchState<EatingState>();

                if (Data.Energy <= (CharacterConfig.MaxEnergy * 0.1f))
                    StateSwitcher.SwitchState<SleepingState>();
            }
        }
    }
}
