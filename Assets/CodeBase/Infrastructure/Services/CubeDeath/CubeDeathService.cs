using CodeBase.Cubes;
using CodeBase.Infrastructure.Services.CubeHolder;
using CodeBase.Infrastructure.Services.GameStats;
using CodeBase.Infrastructure.Services.ImpactSpawner;

namespace CodeBase.Infrastructure.Services.CubeDeath
{
	public class CubeDeathService
	{
		private readonly GameStatsService _gameStatsService;
		private readonly CubeHolderService _cubeHolderService;
		private readonly ImpactSpawnerService _impactSpawnerService;

		public CubeDeathService(GameStatsService gameStatsService, CubeHolderService cubeHolderService, ImpactSpawnerService impactSpawnerService)
		{
			_gameStatsService = gameStatsService;
			_cubeHolderService = cubeHolderService;
			_impactSpawnerService = impactSpawnerService;
		}

		public void KillBubble(Cube cube)
		{
			_gameStatsService.Deaths.Value++;
			_gameStatsService.Points += cube.ComponentsHolder.Points;
			_cubeHolderService.Remove(cube.ComponentsHolder);
			_impactSpawnerService.Spawn(cube.ComponentsHolder.Transform.position);
		}
	}
}