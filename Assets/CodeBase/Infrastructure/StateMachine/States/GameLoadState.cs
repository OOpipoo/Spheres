using CodeBase.Infrastructure.ObjectPools;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class GameLoadState : State
    {
        private BubblePool _bubblePool;
        private ImpactPool _impactPool;

        public GameLoadState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

        [Inject]
        private void Construct(BubblePool bubblePool, ImpactPool impactPool)
        {
            _impactPool = impactPool;
            _bubblePool = bubblePool;
        }

        public override void Enter()
        {
            _bubblePool.Initialize();
            _impactPool.Initialize();
            GameLoopStateMachine.Enter<ResetState>();
        }

        public override void Exit()
        {
        } 
    }
}