using Zenject;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class ResetState : State
    {
        private IResettable[] _resettable;
        public ResetState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

        [Inject]
        private void Construct(IResettable[] resettable)
        {
            _resettable = resettable;
        }
        public override void Enter()
        {
            foreach (IResettable resettable in _resettable)
            {
                resettable.CustomReset();
            }

            GameLoopStateMachine.Enter<MenuState>();
        }

        public override void Exit()
        {
        }
    }
}