using CodeBase.GameSphere;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
	[CreateAssetMenu(fileName = "SpherePreferences", menuName = "Preferences/Create Sphere Preferences")]
	public class SpherePreferences : ScriptableObject
	{
		public Sphere SpherePrefab;
		public int PoolSize;
	}
}