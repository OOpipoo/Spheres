using System.Collections.Generic;
using UniRx;
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
			if (Input.GetMouseButtonDown(0))
			{
				_path.Clear();
			}
			else if(Input.GetMouseButton(0))
			{
				var ray = _camera.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out var hit, 200))
				{
					_path.Add(hit.point);
				}
			}
			else if(Input.GetMouseButtonUp(0))
			{
				// _sphereMoveService.MoveToPath(_path); 
			} 
		}
	}
}