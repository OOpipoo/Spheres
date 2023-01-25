using CodeBase.Infrastructure.Services.UI.EndGameScreen;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class EndGameState : State
    {
        private EndGameScreenService _endGameScreenService;
        public EndGameState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }


        [Inject]
        private void Construct(EndGameScreenService endGameScreenService)
        {
            _endGameScreenService = endGameScreenService;
        }
        public override void Enter()
        {
            _endGameScreenService.Show();
        }

        public override void Exit()
        {
            _endGameScreenService.Hide();
        }
    }
}