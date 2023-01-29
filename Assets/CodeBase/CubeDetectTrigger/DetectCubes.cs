using CodeBase.Infrastructure.Services.BubbleDeath;
using CodeBase.SoapBubble;
using UnityEngine;
using Zenject;

namespace CodeBase.CubeDetectTrigger
{
	public class DetectCubes : MonoBehaviour
	{
		private BubbleDeathService _bubbleDeathService;

		
		[Inject]
		private void Construct(BubbleDeathService bubbleDeathService)
		{
			_bubbleDeathService = bubbleDeathService;
		}
		
		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out Bubble bubble))
			{
				_bubbleDeathService.KillBubble(bubble);
			}
		}


	}
}