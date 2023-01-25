using CodeBase.Infrastructure.Services.BubbleDeath;
using CodeBase.SoapBubble;
using UniRx;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.ClickDetector
{
	public class ClickDetectorService
	{
		private readonly BubbleDeathService _bubbleDeathService;
		private const float MaxRayDistance = 10;
		private readonly Camera _camera;
		private readonly RaycastHit[] _raycastHits = new RaycastHit[20];
		private readonly CompositeDisposable _compositeDisposable = new();

		public ClickDetectorService(BubbleDeathService bubbleDeathService)
		{
			_bubbleDeathService = bubbleDeathService;
			_camera = Camera.main;
		}
		public void StartDetecting()
		{
			Observable
				.EveryUpdate()
				.Subscribe(_ => Detect())
				.AddTo(_compositeDisposable);
		}
		public void StopDetecting() => 
			_compositeDisposable.Clear();

		private void Detect()
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
				int size = Physics.RaycastNonAlloc(ray, _raycastHits, MaxRayDistance);
				for (int i = 0; i < size; i++)
				{
					RaycastHit hit = _raycastHits[i];
					if (hit.collider.TryGetComponent(out Bubble bubble))
					{
						_bubbleDeathService.KillBubble(bubble);
					}
				}
			}
		}
	}
}