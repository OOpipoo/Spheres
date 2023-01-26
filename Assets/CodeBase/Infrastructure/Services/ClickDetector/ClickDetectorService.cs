using System.Collections.Generic;
using CodeBase.Infrastructure.Services.BubbleDeath;
using CodeBase.Infrastructure.Services.SphereMove;
using CodeBase.SoapBubble;
using UniRx;
using UnityEngine;
using Object = System.Object;

namespace CodeBase.Infrastructure.Services.ClickDetector
{
	public class ClickDetectorService  //Rename MOveOnClickService
	{
		// private readonly BubbleDeathService _bubbleDeathService;
		
		private const float MaxRayDistance = 50;
		private readonly Camera _camera;
		private readonly RaycastHit[] _raycastHits = new RaycastHit[1];
		private readonly CompositeDisposable _compositeDisposable = new();
		private SphereMoveService _sphereMoveService;

		private List<Vector3> _path = new ();


		public ClickDetectorService(SphereMoveService sphereMoveService)
		{
			// _bubbleDeathService = bubbleDeathService;
			_sphereMoveService = sphereMoveService;
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
				_sphereMoveService.MoveToPath(_path); 
			} 
		}

		private bool GetMouseClickWorldPosition(out Vector3 positon)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				var ray = _camera.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out var hit, 200))
				{
					positon = hit.point;
					return true; 
				}
			}
			positon = Vector3.zero; 
			return false;
		}

		// private void Detect()
		// {
		// 	if (Input.GetKeyDown(KeyCode.Mouse0))
		// 	{
		// 		var ray = _camera.ScreenPointToRay(Input.mousePosition);
		// 		if (Physics.Raycast(ray,out var hit, 200))
		// 		{
		// 			_sphereMoveService.MoveTo(hit.point);
		// 		} 
		// 	}
		// }
		
	}
}