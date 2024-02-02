namespace CharacterSceneScripts
{
    public class WalkingState : RunningState
    {
        private readonly WalkingStateConfig _config;

        public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
            => _config = character.Config.RunningStateConfig.WalkingStateConfig;

        public override void Enter()
        {
            base.Enter();

            Data.Speed = _config.Speed;

            View.Speed = Modify(_config.Speed);

            View.StartRunning();
        }

        public override void Exit() => base.Exit();

        public override void Update()
        {
            base.Update();

            if (Data.IsWilking == false)
                StateSwitcher.SwitchState<RunningState>();
        }
    }
}