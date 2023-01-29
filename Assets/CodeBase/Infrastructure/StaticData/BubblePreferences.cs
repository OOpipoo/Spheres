using CodeBase.SoapBubble;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Infrastructure.StaticData
{
	[CreateAssetMenu(fileName = "BubblePreferences", menuName = "Preferences/Create Bubble Preferences")]
	public class BubblePreferences : ScriptableObject
	{
		[FormerlySerializedAs("BubblePrefab")]
		public Cube cubePrefab;
		public int PoolSize;
	}
}