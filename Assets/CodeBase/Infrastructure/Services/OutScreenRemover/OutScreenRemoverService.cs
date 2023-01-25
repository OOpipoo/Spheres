using System.Collections.Generic;
using CodeBase.Infrastructure.Services.BubblesHolder;
using CodeBase.SoapBubble;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.OutScreenRemover
{
	public class OutScreenRemoverService : ITickable
	{
		private readonly IBubblesHolder _bubblesHolder;
		private readonly float _upBorder;

		public OutScreenRemoverService(IBubblesHolder bubblesHolder)
		{
			_bubblesHolder = bubblesHolder;
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
			foreach (ComponentsHolder componentsHolder in _bubblesHolder.Get())
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
				_bubblesHolder.Remove(bubblesToRemove[i]);
			}
		}
	}
}