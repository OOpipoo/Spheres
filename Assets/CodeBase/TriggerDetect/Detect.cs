using System;
using CodeBase.Infrastructure.Services.BubbleDeath;
using CodeBase.SoapBubble;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace CodeBase.TriggerDetect
{
	public class Detect : MonoBehaviour
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