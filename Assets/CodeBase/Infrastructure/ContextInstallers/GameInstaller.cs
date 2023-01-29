using CodeBase.Infrastructure.StateMachine;
using Zenject;

namespace CodeBase.Infrastructure.ContextInstallers
{
	public class GameInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindGameStateMachine();
		}

		private void BindGameStateMachine() =>
			Container
				.BindInterfacesAndSelfTo<GameLoopStateMachine>()
				.AsSingle();
	}
}