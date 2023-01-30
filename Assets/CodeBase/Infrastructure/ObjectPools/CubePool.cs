using CodeBase.Cubes;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.ObjectPools
{
	public class CubePool : BasePool<Cube, ComponentsHolder>
	{
		private readonly DiContainer _diContainer;
		private readonly CubePreferences _cubePreferences;

		public CubePool(DiContainer diContainer, CubePreferences cubePreferences)
		{
			_diContainer = diContainer;
			_cubePreferences = cubePreferences;
		}

		public void Initialize() => 
			Fill(_cubePreferences.PoolSize, _cubePreferences.cubePrefab);

		protected override ComponentsHolder CreateObject(Cube prefab)
		{
			Cube cube = _diContainer.InstantiatePrefabForComponent<Cube>(prefab);
			ComponentsHolder componentsHolder = new ComponentsHolder(cube);
			cube.ComponentsHolder = componentsHolder;
			return componentsHolder;
		}

		protected override void Deactivate(ComponentsHolder obj) => 
			obj.GameObject.SetActive(false);

		protected override void Activate(ComponentsHolder obj) => 
			obj.GameObject.SetActive(true);
	}
}