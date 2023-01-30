using System.Collections.Generic;
using CodeBase.Cubes;
using CodeBase.Infrastructure.ObjectPools;
using CodeBase.Infrastructure.StateMachine;

namespace CodeBase.Infrastructure.Services.CubeHolder
{
	public class CubeHolderService : IResettable, ICubesHolder
	{
		private readonly CubePool _cubePool;
		private readonly List<ComponentsHolder> _componentsHolders = new();

		public CubeHolderService(CubePool cubePool) => 
			_cubePool = cubePool;

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
			_cubePool.Return(componentsHolder);
		}

		public IEnumerable<ComponentsHolder> Get() => 
			_componentsHolders;
	}
}