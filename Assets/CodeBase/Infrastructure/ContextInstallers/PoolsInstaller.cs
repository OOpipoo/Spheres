using CodeBase.Infrastructure.ObjectPools;
using Zenject;

namespace CodeBase.Infrastructure.ContextInstallers
{
	public class PoolsInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindBubblePool();
			BindImpactPool();
		}
		
		private void BindBubblePool() =>
			Container
				.BindInterfacesAndSelfTo<CubePool>()
				.AsSingle();
		
		private void BindImpactPool() =>
			Container
				.BindInterfacesAndSelfTo<ImpactPool>()
				.AsSingle();
	}
}