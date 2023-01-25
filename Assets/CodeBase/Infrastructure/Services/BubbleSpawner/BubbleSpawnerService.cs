using System;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.Services.BubblesHolder;
using CodeBase.Infrastructure.StaticData;
using CodeBase.SoapBubble;
using UniRx;

namespace CodeBase.Infrastructure.Services.BubbleSpawner
{
	public class BubbleSpawnerService
	{
		private readonly SpawnPreferences _spawnPreferences;
		private readonly BubbleFactory _bubbleFactory;
		private readonly IBubblesHolder _bubblesHolder;
		private readonly CompositeDisposable _disposables = new();

		public BubbleSpawnerService(SpawnPreferences spawnPreferences, BubbleFactory bubbleFactory, IBubblesHolder bubblesHolder)
		{
			_spawnPreferences = spawnPreferences;
			_bubbleFactory = bubbleFactory;
			_bubblesHolder = bubblesHolder;
		}

		public void StartSpawn() =>
			Observable
				.Timer(TimeSpan.FromSeconds(1 / _spawnPreferences.BubblesPerSecond))
				.Repeat()
				.Subscribe(_ => SpawnEntity())
				.AddTo(_disposables);

		public void StopSpawn() => 
			_disposables.Clear();

		private void SpawnEntity()
		{
			ComponentsHolder bubble = _bubbleFactory.CreateBubble();
			_bubblesHolder.Add(bubble);
		}
	}
}