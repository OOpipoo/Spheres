using CodeBase.Infrastructure.StaticData;
using CodeBase.SoapBubble;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.ObjectPools
{
	public class BubblePool : BasePool<Bubble, ComponentsHolder>
	{
		private readonly DiContainer _diContainer;
		private readonly BubblePreferences _bubblePreferences;

		public BubblePool(DiContainer diContainer, BubblePreferences bubblePreferences)
		{
			_diContainer = diContainer;
			_bubblePreferences = bubblePreferences;
		}

		public void Initialize() => 
			Fill(_bubblePreferences.PoolSize, _bubblePreferences.BubblePrefab);

		protected override ComponentsHolder CreateObject(Bubble prefab)
		{
			Bubble bubble = _diContainer.InstantiatePrefabForComponent<Bubble>(prefab);
			ComponentsHolder componentsHolder = new ComponentsHolder(bubble);
			bubble.ComponentsHolder = componentsHolder;
			return componentsHolder;
		}

		protected override void Deactivate(ComponentsHolder obj) => 
			obj.GameObject.SetActive(false);

		protected override void Activate(ComponentsHolder obj) => 
			obj.GameObject.SetActive(true);
	}
}