using System.Collections.Generic;
using CodeBase.Cubes;
using CodeBase.SoapBubble;

namespace CodeBase.Infrastructure.Services.CubeHolder
{
	public interface ICubesHolder
	{
		void Add(ComponentsHolder componentsHolder);
		void Remove(ComponentsHolder componentsHolder);
		IEnumerable<ComponentsHolder> Get();
	}
}