using CodeBase.Cubes;
using CodeBase.Infrastructure.Services.CubeDeath;
using UnityEngine;
using Zenject;

namespace CodeBase.CubeDetectTrigger
{
	public class DetectCubes : MonoBehaviour
	{
		private CubeDeathService _cubeDeathService;

		
		[Inject]
		private void Construct(CubeDeathService cubeDeathService)
		{
			_cubeDeathService = cubeDeathService;
		}
		
		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out Cube bubble))
			{
				_cubeDeathService.KillBubble(bubble);
			}
		}


	}
}