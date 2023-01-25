using System.Collections.Generic;
using CodeBase.Infrastructure.ObjectPools;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.SoapBubble;

namespace CodeBase.Infrastructure.Services.BubblesHolder
{
	public class BubblesHolderService : IResettable, IBubblesHolder
	{
		private readonly BubblePool _bubblePool;
		private readonly List<ComponentsHolder> _componentsHolders = new();

		public BubblesHolderService(BubblePool bubblePool) => 
			_bubblePool = bubblePool;

		public void CustomReset()
		{
			for (int i = _componentsHolders.Count - 1; i >= 0; i--)
			{
				Remove(_componentsHolders[i]);
			}
		}

		public void Add(ComponentsHolder componentsHolder) => 
			_componentsHolders.Add(componentsHolder);

		public void Remove(ComponentsHolder componentsHolder)
		{
			_componentsHolders.Remove(componentsHolder);
			_bubblePool.Return(componentsHolder);
		}

		public IEnumerable<ComponentsHolder> Get() => 
			_componentsHolders;
	}
}