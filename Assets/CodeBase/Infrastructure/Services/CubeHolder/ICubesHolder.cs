using System.Collections.Generic;
using CodeBase.Cubes;

namespace CodeBase.Infrastructure.Services.CubeHolder
{
	public interface ICubesHolder
	{
		void Add(ComponentsHolder componentsHolder);
		void Remove(ComponentsHolder componentsHolder);
		IEnumerable<ComponentsHolder> Get();
	}
}