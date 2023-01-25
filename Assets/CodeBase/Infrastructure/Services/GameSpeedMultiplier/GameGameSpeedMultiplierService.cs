using System;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StaticData;
using UniRx;

namespace CodeBase.Infrastructure.Services.GameSpeedMultiplier
{
	public class GameGameSpeedMultiplierService : IResettable, IGameSpeed
	{
		public float GameSpeed { get; set; }
		private readonly GamePreferences _gamePreferences;
		private readonly CompositeDisposable _disposables = new();

		public GameGameSpeedMultiplierService(GamePreferences gamePreferences)
		{
			_gamePreferences = gamePreferences;
		}

		public void Start() =>
			Observable
				.Timer(TimeSpan.FromSeconds(_gamePreferences.SpeedUpTimer))
				.Repeat()
				.Subscribe(_ => GameSpeed *= _gamePreferences.SpeedUpFactor)
				.AddTo(_disposables);

		public void Stop() => 
			_disposables.Clear();

		public void CustomReset() => 
			GameSpeed = 1;
	}
}