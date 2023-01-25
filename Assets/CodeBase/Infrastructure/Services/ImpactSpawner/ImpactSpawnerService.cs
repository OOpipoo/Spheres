using System;
using CodeBase.Infrastructure.ObjectPools;
using UniRx;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.ImpactSpawner
{
	public class ImpactSpawnerService
	{
		private const float TimeToReturnToPool = 2f;
		private readonly ImpactPool _impactPool;

		public ImpactSpawnerService(ImpactPool impactPool) => 
			_impactPool = impactPool;

		public void Spawn(Vector3 at)
		{
			GameObject impactObject = _impactPool.Get();
			impactObject.transform.position = at;
			Observable
				.Timer(TimeSpan.FromSeconds(TimeToReturnToPool))
				.Subscribe(_ => _impactPool.Return(impactObject));
		}
	}
}