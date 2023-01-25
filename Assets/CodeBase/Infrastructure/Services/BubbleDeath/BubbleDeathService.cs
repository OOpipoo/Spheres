using CodeBase.Infrastructure.Services.BubblesHolder;
using CodeBase.Infrastructure.Services.GameStats;
using CodeBase.Infrastructure.Services.ImpactSpawner;
using CodeBase.SoapBubble;

namespace CodeBase.Infrastructure.Services.BubbleDeath
{
	public class BubbleDeathService
	{
		private readonly GameStatsService _gameStatsService;
		private readonly BubblesHolderService _bubblesHolderService;
		private readonly ImpactSpawnerService _impactSpawnerService;

		public BubbleDeathService(GameStatsService gameStatsService, BubblesHolderService bubblesHolderService, ImpactSpawnerService impactSpawnerService)
		{
			_gameStatsService = gameStatsService;
			_bubblesHolderService = bubblesHolderService;
			_impactSpawnerService = impactSpawnerService;
		}

		public void KillBubble(Bubble bubble)
		{
			_gameStatsService.Deaths.Value++;
			_gameStatsService.Points += bubble.ComponentsHolder.Points;
			_bubblesHolderService.Remove(bubble.ComponentsHolder);
			_impactSpawnerService.Spawn(bubble.ComponentsHolder.Transform.position);
		}
	}
}