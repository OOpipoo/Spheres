using CodeBase.Infrastructure.Services.UI.TapToStart;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class MenuState : State
    {
        private TapToStartService _tapToStartService;
        public MenuState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }
        

        [Inject]
        private void Construct(TapToStartService tapToStartService)
        {
            _tapToStartService = tapToStartService;
        }
        public override void Enter()
        {
            _tapToStartService.Show();
        }

        public override void Exit()
        {
            _tapToStartService.Hide();
        }
    }
}