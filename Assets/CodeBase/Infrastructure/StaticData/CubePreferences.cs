using CodeBase.SoapBubble;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Infrastructure.StaticData
{
	[CreateAssetMenu(fileName = "CubePreferences", menuName = "Preferences/Create Cube Preferences")]
	public class CubePreferences : ScriptableObject
	{
		public Cube cubePrefab;
		public int PoolSize;
	}
}