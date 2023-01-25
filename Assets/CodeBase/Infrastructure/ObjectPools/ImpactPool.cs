using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CodeBase.Infrastructure.ObjectPools
{
	public class ImpactPool : BasePool<GameObject, GameObject>
	{
		private readonly AssetProvider _assetProvider;
		private const int DefaultPoolSize = 20;
		public ImpactPool(AssetProvider assetProvider)
		{
			_assetProvider = assetProvider;
		}
		public void Initialize() => 
			Fill(DefaultPoolSize, _assetProvider.Load<GameObject>(AssetPath.VFXImpact));
		protected override GameObject CreateObject(GameObject prefab)
		{
			return Object.Instantiate(prefab);
		}

		protected override void Deactivate(GameObject obj) => 
			obj.SetActive(false);

		protected override void Activate(GameObject obj) => 
			obj.SetActive(true);
	}
}