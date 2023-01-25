using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
	[CreateAssetMenu(fileName = "SpawnPreferences", menuName = "Preferences/Create Spawn Preferences")]
	public class SpawnPreferences : ScriptableObject
	{
		public float BubblesPerSecond;
		public float MinSpeed;
		public float MaxSpeed;
		public float MinSize;
		public float MaxSize;
		public float MinPoints;
		public float MaxPoints;
	}
}