using CodeBase.Infrastructure.Services.BubbleDeath;
using CodeBase.Infrastructure.Services.SphereMove;
using CodeBase.SoapBubble;
using UniRx;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.ClickDetector
{
	public class ClickDetectorService  //Rename MOveOnClickService
	{
		private readonly BubbleDeathService _bubbleDeathService;
		private const float MaxRayDistance = 50;
		private readonly Camera _camera;
		private readonly RaycastHit[] _raycastHits = new RaycastHit[1];
		private readonly CompositeDisposable _compositeDisposable = new();
		private SphereMoveService _sphereMoveService;
		private LayerMask _terraineMask = LayerMask.NameToLayer("Plane");
		
		
		public ClickDetectorService(BubbleDeathService bubbleDeathService, SphereMoveService sphereMoveService)
		{
			_bubbleDeathService = bubbleDeathService;
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
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				var ray = _camera.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(ray,out var hit, 2000))
				{
					_sphereMoveService.MoveTo(hit.point);
				} 
			}
		}
		
		// private void OnDrawGizmos()
		// {
		// 	Gizmos.color = Color.red;
		// 	Gizmos.DrawRay(_ray.origin, _ray.direction * 200f);
		// }
	}
}