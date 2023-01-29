using System;
using CodeBase.Cubes;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.Services.CubeHolder;
using CodeBase.Infrastructure.StaticData;
using CodeBase.SoapBubble;
using UniRx;

namespace CodeBase.Infrastructure.Services.CubeSpawner
{
	public class CubesSpawnerService
	{
		private readonly SpawnPreferences _spawnPreferences;
		private readonly CubeFactory _cubeFactory;
		private readonly ICubesHolder _cubesHolder;
		private readonly CompositeDisposable _disposables = new();

		public CubesSpawnerService(SpawnPreferences spawnPreferences, CubeFactory cubeFactory, ICubesHolder cubesHolder)
		{
			_spawnPreferences = spawnPreferences;
			_cubeFactory = cubeFactory;
			_cubesHolder = cubesHolder;
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
			ComponentsHolder bubble = _cubeFactory.CreateBubble();
			_cubesHolder.Add(bubble);
		}
	}
}