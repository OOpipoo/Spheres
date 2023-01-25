using CodeBase.Infrastructure.ObjectPools;
using CodeBase.Infrastructure.Services.BubbleParametresRandomizer;
using CodeBase.Infrastructure.Services.OutScreenPositioner;
using CodeBase.SoapBubble;

namespace CodeBase.Infrastructure.Factories
{
	public class BubbleFactory
	{
		private readonly BubblePool _bubblePool;
		private readonly OutScreenPositionerService _outScreenPositionerService;
		private readonly BubbleParametresRandomizerService _bubbleParametresRandomizerService;

		public BubbleFactory(BubblePool bubblePool, OutScreenPositionerService outScreenPositionerService, BubbleParametresRandomizerService bubbleParametresRandomizerService)
		{
			_bubblePool = bubblePool;
			_outScreenPositionerService = outScreenPositionerService;
			_bubbleParametresRandomizerService = bubbleParametresRandomizerService;
		}
		public ComponentsHolder CreateBubble()
		{
			ComponentsHolder bubble = _bubblePool.Get();
			_bubbleParametresRandomizerService.RandomizeParametres(bubble);
			_outScreenPositionerService.SetPosition(bubble);
			return bubble;
		}
	}
}