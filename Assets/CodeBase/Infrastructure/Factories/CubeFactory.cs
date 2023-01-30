using CodeBase.Cubes;
using CodeBase.Infrastructure.ObjectPools;
using CodeBase.Infrastructure.Services.CubeParametresRandomizer;
using CodeBase.Infrastructure.Services.OutScreenPositioner;

namespace CodeBase.Infrastructure.Factories
{
	public class CubeFactory
	{
		private readonly CubePool _cubePool;
		private readonly OutScreenPositionerService _outScreenPositionerService;
		private readonly CubeParametresRandomizerService _cubeParametresRandomizerService;

		public CubeFactory(CubePool cubePool, OutScreenPositionerService outScreenPositionerService, CubeParametresRandomizerService cubeParametresRandomizerService)
		{
			_cubePool = cubePool;
			_outScreenPositionerService = outScreenPositionerService;
			_cubeParametresRandomizerService = cubeParametresRandomizerService;
		}
		public ComponentsHolder CreateBubble()
		{
			ComponentsHolder bubble = _cubePool.Get();
			_cubeParametresRandomizerService.RandomizeParametres(bubble);
			_outScreenPositionerService.SetPosition(bubble);
			return bubble;
		}
	}
}