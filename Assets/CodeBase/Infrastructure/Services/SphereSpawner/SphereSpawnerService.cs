using CodeBase.GameSphere;
using CodeBase.Infrastructure.StaticData;
using CodeBase.SoapBubble;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.SphereSpawner
{
	public class SphereSpawnerService
	{
		private Vector3 _gameSphereStartPoint = new (0, -3.5f, 0);
		private readonly DiContainer _diContainer;
		private SpherePreferences _spherePreferences;

		
		private SphereSpawnerService(DiContainer diContainer, SpherePreferences spherePreferences)
		{
			_diContainer = diContainer;
			_spherePreferences = spherePreferences;
		}

		public void CreateGameSphereSetStartPosition()
		{
			Sphere sphere = _spherePreferences.SpherePrefab;
			var obj = _diContainer.InstantiatePrefabForComponent<Sphere>(sphere);
			// var componentsHolder = new ComponentsHolder(obj);
			// obj.ComponentsHolder = componentsHolder;
			sphere.transform.position = _gameSphereStartPoint;  
		}
	}
}