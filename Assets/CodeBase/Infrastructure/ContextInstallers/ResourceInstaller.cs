using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.StaticData;
using Zenject;

namespace CodeBase.Infrastructure.ContextInstallers
{
	public class ResourceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindBubblePreferences();
			BindSpawnerPreferences();
			BindGamePreferences();
			BindSpherePreferences();
		}
		private void BindSpherePreferences() =>
			Container
				.BindInterfacesAndSelfTo<SpherePreferences>()
				.FromResource(AssetPath.SpherePreferences)
				.AsSingle();
		
		private void BindBubblePreferences() =>
			Container
				.BindInterfacesAndSelfTo<CubePreferences>()
				.FromResource(AssetPath.CubePreferences)
				.AsSingle();
		
		private void BindSpawnerPreferences() =>
			Container
				.BindInterfacesAndSelfTo<SpawnPreferences>()
				.FromResource(AssetPath.SpawnerPreferences)
				.AsSingle();
		
		private void BindGamePreferences() =>
			Container
				.BindInterfacesAndSelfTo<GamePreferences>()
				.FromResource(AssetPath.GamePreferences)
				.AsSingle(); 
	}
}