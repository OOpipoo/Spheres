using CodeBase.Infrastructure.Services.BubbleSpawner;
using CodeBase.Infrastructure.Services.GameSpeedMultiplier;
using CodeBase.Infrastructure.Services.SphereSpawner;
using CodeBase.Infrastructure.Services.UI.CountDownTimer;
using CodeBase.Infrastructure.Services.UI.DeathCounter;
using CodeBase.Infrastructure.Services.UI.DistanceCounter;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class GameState : State
    {
        private BubbleSpawnerService _bubbleSpawnerService;
        private GameGameSpeedMultiplierService _gameGameSpeedMultiplierService;
        private DeathCounterService _deathCounterService;
        private CountDownTimerService _countDownTimerService;
        private SphereSpawnerService _sphereSpawnerService;
        private DistanceCounterService _distanceCounterService;

        public GameState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

        [Inject]
        private void Construct(BubbleSpawnerService bubbleSpawnerService, GameGameSpeedMultiplierService gameGameSpeedMultiplierService,
            DeathCounterService deathCounterService, CountDownTimerService countDownTimerService,
           SphereSpawnerService sphereSpawnerService, DistanceCounterService distanceCounterService)
        {
            _countDownTimerService = countDownTimerService;
            _deathCounterService = deathCounterService;
            _gameGameSpeedMultiplierService = gameGameSpeedMultiplierService;
            _bubbleSpawnerService = bubbleSpawnerService;
            _sphereSpawnerService = sphereSpawnerService;
            _distanceCounterService = distanceCounterService;
        }
        public override void Enter()
        {
            _bubbleSpawnerService.StartSpawn();
            _gameGameSpeedMultiplierService.Start();
            _deathCounterService.Show();
            _distanceCounterService.Show();
            _countDownTimerService.StartTimer(); 
            _sphereSpawnerService.CreateGameSphere();  
        }

        public override void Exit()
        {
            _bubbleSpawnerService.StopSpawn();
            _gameGameSpeedMultiplierService.Stop();
            _deathCounterService.Hide();
            _distanceCounterService.Hide();
            _sphereSpawnerService.DestroySphere();
        }
    }
}