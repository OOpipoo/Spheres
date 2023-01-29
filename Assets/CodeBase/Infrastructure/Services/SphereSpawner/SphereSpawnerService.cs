using CodeBase.GameSphere;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.SphereSpawner
{
	public class SphereSpawnerService
	{
		private Vector3 _gameSphereStartPoint = new (0, -1f, 0);
		private readonly DiContainer _diContainer;
		private SpherePreferences _spherePreferences;
		private Sphere _sphere;

		
		private SphereSpawnerService(DiContainer diContainer, SpherePreferences spherePreferences)
		{
			_diContainer = diContainer;
			_spherePreferences = spherePreferences;
		}

		public void CreateGameSphere()
		{
			Sphere sphere = _spherePreferences.SpherePrefab;
			_sphere = _diContainer.InstantiatePrefabForComponent<Sphere>(sphere);
			SetSphereStartPosition(sphere);  
		}

		private void SetSphereStartPosition(Sphere sphere)
		{
			sphere.transform.position = _gameSphereStartPoint;
		}

		public void DestroySphere()
		{
			Object.Destroy(_sphere.gameObject);
		}
	}
}
