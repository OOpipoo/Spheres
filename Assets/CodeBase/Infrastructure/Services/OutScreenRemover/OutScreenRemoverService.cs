using System.Collections.Generic;
using CodeBase.Cubes;
using CodeBase.Infrastructure.Services.CubeHolder;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.OutScreenRemover
{
	public class OutScreenRemoverService : ITickable
	{
		private readonly ICubesHolder _cubesHolder;
		private readonly float _upBorder;

		public OutScreenRemoverService(ICubesHolder cubesHolder)
		{
			_cubesHolder = cubesHolder;
			float orthographicSize = Camera.main.orthographicSize;
			_upBorder = orthographicSize;
		}
		public void Tick()
		{
			List<ComponentsHolder> bubblesToRemove = GetBubblesToRemove();
			RemoveBubbles(bubblesToRemove);
		}

		private List<ComponentsHolder> GetBubblesToRemove()
		{
			List<ComponentsHolder> bubblesToRemove = new List<ComponentsHolder>();
			foreach (ComponentsHolder componentsHolder in _cubesHolder.Get())
			{
				float downBubblePoint = componentsHolder.Transform.position.y - componentsHolder.Radius;
				if (downBubblePoint > _upBorder)
				{
					bubblesToRemove.Add(componentsHolder);
				}
			}

			return bubblesToRemove;
		}

		private void RemoveBubbles(List<ComponentsHolder> bubblesToRemove)
		{
			for (var i = bubblesToRemove.Count - 1; i >= 0; i--)
			{
				_cubesHolder.Remove(bubblesToRemove[i]);
			}
		}
	}
}