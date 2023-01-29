using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.Services.BubbleDeath;
using CodeBase.Infrastructure.Services.CubeHolder;
using CodeBase.Infrastructure.Services.CubeParametresRandomizer;
using CodeBase.Infrastructure.Services.CubesMove;
using CodeBase.Infrastructure.Services.CubeSpawner;
using CodeBase.Infrastructure.Services.GameSpeedMultiplier;
using CodeBase.Infrastructure.Services.GameStats;
using CodeBase.Infrastructure.Services.ImpactSpawner;
using CodeBase.Infrastructure.Services.OutScreenPositioner;
using CodeBase.Infrastructure.Services.OutScreenRemover;
using CodeBase.Infrastructure.Services.SphereSpawner;
using Zenject;

namespace CodeBase.Infrastructure.ContextInstallers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindAssetProvider();
            BindBubbleSpawner();
            BindOutScreenPositioner();
            BindBubbleParametresRandomizer();
            BindGameSpeedMultiplier();
            BindBubbleFactory();
            BindBubblesHolder();
            BindMoveService();
            BindOutScreenRemover();
            BindImpactSpawner();
            BindBubbleDeathService();
            BindGameStats();
            BindSphereSpawner();
        }
        
        private void BindGameStats() =>
            Container
                .BindInterfacesAndSelfTo<GameStatsService>()
                .AsSingle();

        private void BindBubbleDeathService() =>
            Container
                .BindInterfacesAndSelfTo<CubeDeathService>()
                .AsSingle();
        
        private void BindBubblesHolder() =>
            Container
                .BindInterfacesAndSelfTo<CubeHolderService>()
                .AsSingle();
        
        private void BindGameSpeedMultiplier() =>
            Container
                .BindInterfacesAndSelfTo<GameGameSpeedMultiplierService>()
                .AsSingle();
        
        private void BindAssetProvider() =>
            Container
                .BindInterfacesAndSelfTo<AssetProvider>()
                .AsSingle();

        private void BindBubbleSpawner() =>
            Container
                .BindInterfacesAndSelfTo<CubesSpawnerService>()
                .AsSingle();
        
        private void BindSphereSpawner() =>
            Container
                .BindInterfacesAndSelfTo<SphereSpawnerService>()
                .AsSingle(); 
        
        private void BindOutScreenPositioner() =>
            Container
                .BindInterfacesAndSelfTo<OutScreenPositionerService>()
                .AsSingle();
        
        private void BindBubbleParametresRandomizer() =>
            Container
                .BindInterfacesAndSelfTo<CubeParametresRandomizerService>()
                .AsSingle();
        
        private void BindBubbleFactory() =>
            Container
                .BindInterfacesAndSelfTo<CubeFactory>()
                .AsSingle();
        
        private void BindMoveService() =>
            Container
                .BindInterfacesAndSelfTo<CubesMoveService>()
                .AsSingle()
                .NonLazy();
        
        private void BindOutScreenRemover() =>
            Container
                .BindInterfacesAndSelfTo<OutScreenRemoverService>()
                .AsSingle()
                .NonLazy();
        
        private void BindImpactSpawner() =>
            Container
                .BindInterfacesAndSelfTo<ImpactSpawnerService>()
                .AsSingle();
    }
}