using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.UI.CountDownTimer;
using CodeBase.Infrastructure.Services.UI.DeathCounter;
using CodeBase.Infrastructure.Services.UI.DistanceCounter;
using CodeBase.Infrastructure.Services.UI.EndGameScreen;
using CodeBase.Infrastructure.Services.UI.TapToStart;
using Zenject;

namespace CodeBase.Infrastructure.ContextInstallers
{
	public class UiInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindTapToStart();
			BindDeathCounter();
			BindDistanceCounter();
			BindCountDownTimer();
			BindEndGameScreen();
		}

		private void BindEndGameScreen() =>
			Container
				.BindInterfacesAndSelfTo<EndGameScreenService>()
				.FromComponentInNewPrefabResource(AssetPath.EndGameScreen)
				.AsSingle();

		private void BindDeathCounter() =>
			Container
				.BindInterfacesAndSelfTo<DeathCounterService>()
				.FromComponentInNewPrefabResource(AssetPath.DeathCounter)
				.AsSingle();
		
		private void BindDistanceCounter() =>
			Container
				.BindInterfacesAndSelfTo<DistanceCounterService>()
				.FromComponentInNewPrefabResource(AssetPath.DistanceCounter)
				.AsSingle();

		private void BindTapToStart() =>
			Container
				.BindInterfacesAndSelfTo<TapToStartService>()
				.FromComponentInNewPrefabResource(AssetPath.TapToStart)
				.AsSingle();

		private void BindCountDownTimer() =>
			Container
				.BindInterfacesAndSelfTo<CountDownTimerService>()
				.FromComponentInNewPrefabResource(AssetPath.CountDownTimer)
				.AsSingle();
	}
}