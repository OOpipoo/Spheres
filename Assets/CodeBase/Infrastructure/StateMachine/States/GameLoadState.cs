using CodeBase.Infrastructure.ObjectPools;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class GameLoadState : State
    {
        private CubePool _cubePool;
        private ImpactPool _impactPool;

        public GameLoadState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

        [Inject]
        private void Construct(CubePool cubePool, ImpactPool impactPool)
        {
            _impactPool = impactPool;
            _cubePool = cubePool;
        }

        public override void Enter()
        {
            _cubePool.Initialize();
            _impactPool.Initialize();
            GameLoopStateMachine.Enter<ResetState>();
        }

        public override void Exit()
        {
        } 
    }
}