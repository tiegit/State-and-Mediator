using UnityEngine.InputSystem;

namespace CharacterSceneScripts
{
    public abstract class GroundedState : MovementState
    {        
        private readonly GroundChecker _groundChecker;
        private readonly CharacterConfig _config;

        public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
            _groundChecker = character.GroundChecker;
            _config = character.Config;
        }

        public bool IsWalkingState { get; private set; } = false;

        public override void Enter()
        {
            base.Enter();

            View.StartGrounded();
        }

        public override void Exit()
        {
            base.Exit();

            View.StopGrounded();
        }

        public override void Update()
        {
            base.Update();

            if (_groundChecker.IsTouches == false)
                StateSwitcher.SwitchState<FallingState>();
        }

        protected override void AddInputActionCallbacks()
        {
            base.AddInputActionCallbacks();

            Input.Movement.Jump.started += OnJumpKeyPressed;
            Input.Movement.Acceleration.performed += OnAccelerationKeyPressed;
            Input.Movement.Acceleration.canceled += OnAccelerationKeyCanceled;
            Input.Movement.Walk.performed += OnWalkKeyPressed;
        }

        protected override void RemoveInputActionCallbacks()
        {
            base.RemoveInputActionCallbacks();

            Input.Movement.Jump.started -= OnJumpKeyPressed;
            Input.Movement.Acceleration.performed -= OnAccelerationKeyPressed;
            Input.Movement.Acceleration.canceled -= OnAccelerationKeyCanceled;
            Input.Movement.Walk.performed -= OnWalkKeyPressed;
        }

        protected virtual float Modify(float speed)
            => speed / _config.RunningStateConfig.AnimationSpeedModifier;            
        
        private void OnJumpKeyPressed(InputAction.CallbackContext obj) 
            => StateSwitcher.SwitchState<JumpingState>();
        
        private void OnAccelerationKeyPressed(InputAction.CallbackContext obj)
        {
            Data.IsAcceleration = true;

            StateSwitcher.SwitchState<AccelerationState>();
        }

        private void OnAccelerationKeyCanceled(InputAction.CallbackContext obj) 
            => Data.IsAcceleration = false;
        
        private void OnWalkKeyPressed(InputAction.CallbackContext obj)
        {
            Data.IsWilking = !Data.IsWilking;

            if (Data.IsWilking)
                StateSwitcher.SwitchState<WalkingState>();
        }
    }
}