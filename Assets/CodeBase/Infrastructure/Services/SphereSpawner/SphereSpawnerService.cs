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
		private Sphere _sphere;

		
		private SphereSpawnerService(DiContainer diContainer, SpherePreferences spherePreferences)
		{
			_diContainer = diContainer;
			_spherePreferences = spherePreferences;
		}

		public void CreateGameSphereSetStartPosition()
		{
			Sphere sphere = _spherePreferences.SpherePrefab;
			_sphere = _diContainer.InstantiatePrefabForComponent<Sphere>(sphere);
			sphere.transform.position = _gameSphereStartPoint;  
		}
	
		public void DestroySphere()
		{
			Object.Destroy(_sphere.gameObject);
		}
		
		public Sphere GetSphere()
		{
			return _sphere; 
		}
	}
}

// var componentsHolder = new ComponentsHolder(obj);
// obj.ComponentsHolder = componentsHolder;
