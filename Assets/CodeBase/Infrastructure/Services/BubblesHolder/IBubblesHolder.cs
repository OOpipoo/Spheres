using System.Collections.Generic;
using CodeBase.SoapBubble;

namespace CodeBase.Infrastructure.Services.BubblesHolder
{
	public interface IBubblesHolder
	{
		void Add(ComponentsHolder componentsHolder);
		void Remove(ComponentsHolder componentsHolder);
		IEnumerable<ComponentsHolder> Get();
	}
}