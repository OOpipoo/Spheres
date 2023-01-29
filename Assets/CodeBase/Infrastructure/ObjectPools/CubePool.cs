using CodeBase.Cubes;
using CodeBase.Infrastructure.StaticData;
using CodeBase.SoapBubble;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.ObjectPools
{
	public class CubePool : BasePool<Cube, ComponentsHolder>
	{
		private readonly DiContainer _diContainer;
		private readonly BubblePreferences _bubblePreferences;

		public CubePool(DiContainer diContainer, BubblePreferences bubblePreferences)
		{
			_diContainer = diContainer;
			_bubblePreferences = bubblePreferences;
		}

		public void Initialize() => 
			Fill(_bubblePreferences.PoolSize, _bubblePreferences.cubePrefab);

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