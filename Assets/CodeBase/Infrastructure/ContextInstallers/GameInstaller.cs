using CodeBase.Infrastructure.Services.ClickDetector;
using CodeBase.Infrastructure.StateMachine;
using Zenject;

namespace CodeBase.Infrastructure.ContextInstallers
{
	public class GameInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindGameStateMachine();
			BindClickDetector();
		}

		private void BindGameStateMachine() =>
			Container
				.BindInterfacesAndSelfTo<GameLoopStateMachine>()
				.AsSingle();
		
		private void BindClickDetector() =>
			Container
				.BindInterfacesAndSelfTo<ClickDetectorService>()
				.AsSingle();
	}
}