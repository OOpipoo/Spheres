using CodeBase.Infrastructure.Services.SphereSpawner;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.SphereMove
{
	public class SphereMoveService
	{
		private SphereSpawnerService _sphereSpawnerService;
		public SphereMoveService(SphereSpawnerService sphereSpawnerService)
		{
			_sphereSpawnerService = sphereSpawnerService;
		}

		public void MoveTo(Vector3 point)
		{
			var spherePos = _sphereSpawnerService.GetSphere().transform;
			var endPos = new Vector3(
				Mathf.Clamp(point.x, -2.3f, 2.3f),
				Mathf.Clamp(point.y, -3.5f, 5.5f), 
				0);

			spherePos.DOMove(endPos, .5f);
		}
		
	}
}