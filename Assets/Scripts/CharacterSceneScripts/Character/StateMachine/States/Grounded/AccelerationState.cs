namespace CharacterSceneScripts
{
    public class AccelerationState : RunningState
    {
        private readonly AccelerationStateConfig _config;

        public AccelerationState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
            => _config = character.Config.RunningStateConfig.AccelerationStateConfig;

        public override void Enter()
        {
            base.Enter();

            Data.Speed = _config.Speed;

            View.Speed = Modify(Data.Speed);

            View.StartRunning();
        }

        public override void Exit() => base.Exit();
        
        public override void Update() 
        {
            base.Update();

            if (Data.IsAcceleration == false)
                StateSwitcher.SwitchState<RunningState>();
        }
    }
}