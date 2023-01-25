using CodeBase.Infrastructure.Services.BubblesHolder;
using CodeBase.Infrastructure.Services.GameSpeedMultiplier;
using CodeBase.SoapBubble;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.Move
{
	public class MoveService : ITickable
	{
		private readonly IBubblesHolder _bubblesHolder;
		private readonly IGameSpeed _gameSpeed;

		public MoveService(IBubblesHolder bubblesHolder, IGameSpeed gameSpeed)
		{
			_bubblesHolder = bubblesHolder;
			_gameSpeed = gameSpeed;
		}
		public void Tick()
		{
			foreach (ComponentsHolder componentsHolder in _bubblesHolder.Get())
			{
				componentsHolder.Transform.Translate(Vector3.up * _gameSpeed.GameSpeed * componentsHolder.Speed * Time.deltaTime);
			}
		}
	}
}