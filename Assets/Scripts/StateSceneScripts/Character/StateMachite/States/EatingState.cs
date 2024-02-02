using UnityEngine;

namespace StateSceneScripts
{
    public class EatingState : BehaviorState
    {
        private readonly EatingStateConfig _eatingStateConfig;
        
        public EatingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
            _eatingStateConfig = CharacterConfig.EatingStateConfig;
            TargetPoint = _eatingStateConfig.EatPoint;
        }
        public override void Enter() => base.Enter();            
        
        public override void Exit() => base.Exit();
        
        public override void HandleInput()
        {
            base.HandleInput();

            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Меня заставили и Я иду отдыхать");
                StateSwitcher.SwitchState<SleepingState>();
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

                Data.Health += Time.deltaTime / _eatingStateConfig.HealthRestoreTime * CharacterConfig.MaxHealth;
                Data.Energy -= Time.deltaTime / CharacterConfig.EnergyLiveTime * _eatingStateConfig.EnergyMultiplayer * CharacterConfig.MaxEnergy;

                if (Data.Health >= (CharacterConfig.MaxHealth * 0.9f) && Data.Energy <= (CharacterConfig.MaxEnergy * 0.1f))
                    StateSwitcher.SwitchState<SleepingState>();
                
                if (Data.Health >= CharacterConfig.MaxHealth * 0.5f && Data.Energy > (CharacterConfig.MaxEnergy * 0.4f))
                    StateSwitcher.SwitchState<WorkingState>();                
            }
        }
    }
}
