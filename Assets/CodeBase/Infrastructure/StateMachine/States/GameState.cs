using CodeBase.Infrastructure.Services.CubeSpawner;
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
        private CubesSpawnerService _cubesSpawnerService;
        private GameSpeedMultiplierService _gameSpeedMultiplierService;
        private DeathCounterService _deathCounterService;
        private CountDownTimerService _countDownTimerService;
        private SphereSpawnerService _sphereSpawnerService;
        private DistanceCounterService _distanceCounterService;

        public GameState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

        [Inject]
        private void Construct(CubesSpawnerService cubesSpawnerService, GameSpeedMultiplierService gameSpeedMultiplierService,
            DeathCounterService deathCounterService, CountDownTimerService countDownTimerService,
           SphereSpawnerService sphereSpawnerService, DistanceCounterService distanceCounterService)
        {
            _countDownTimerService = countDownTimerService;
            _deathCounterService = deathCounterService;
            _gameSpeedMultiplierService = gameSpeedMultiplierService;
            _cubesSpawnerService = cubesSpawnerService;
            _sphereSpawnerService = sphereSpawnerService;
            _distanceCounterService = distanceCounterService;
        }
        public override void Enter()
        {
            _cubesSpawnerService.StartSpawn();
            _gameSpeedMultiplierService.Start();
            _deathCounterService.Show();
            _distanceCounterService.Show();
            _countDownTimerService.StartTimer(); 
            _sphereSpawnerService.CreateGameSphere();  
        }

        public override void Exit()
        {
            _cubesSpawnerService.StopSpawn();
            _gameSpeedMultiplierService.Stop();
            _deathCounterService.Hide();
            _distanceCounterService.Hide();
            _sphereSpawnerService.DestroySphere();
        }
    }
}