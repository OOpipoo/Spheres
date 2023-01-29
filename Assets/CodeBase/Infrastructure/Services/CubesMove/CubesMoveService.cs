using CodeBase.Cubes;
using CodeBase.Infrastructure.Services.CubeHolder;
using CodeBase.Infrastructure.Services.GameSpeedMultiplier;
using CodeBase.SoapBubble;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.CubesMove
{
	public class CubesMoveService : ITickable
	{
		private readonly ICubesHolder _cubesHolder;
		private readonly IGameSpeed _gameSpeed;

		public CubesMoveService(ICubesHolder cubesHolder, IGameSpeed gameSpeed)
		{
			_cubesHolder = cubesHolder;
			_gameSpeed = gameSpeed;
		}
		public void Tick()
		{
			foreach (ComponentsHolder componentsHolder in _cubesHolder.Get())
			{
				componentsHolder.Transform.Translate(Vector3.up * _gameSpeed.GameSpeed * componentsHolder.Speed * Time.deltaTime);
			}
		}
	}
}