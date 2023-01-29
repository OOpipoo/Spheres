using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.ClickDetector
{
	public class ClickDetectorService  //Rename MOveOnClickService
	{
		// private readonly BubbleDeathService _bubbleDeathService;
		
		private const float MaxRayDistance = 50;
		private readonly Camera _camera;
		private readonly RaycastHit[] _raycastHits = new RaycastHit[1];
		private readonly CompositeDisposable _compositeDisposable = new();

		private List<Vector3> _path = new ();


		public ClickDetectorService()
		{
			// _bubbleDeathService = bubbleDeathService;
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
			
		}
	}
}