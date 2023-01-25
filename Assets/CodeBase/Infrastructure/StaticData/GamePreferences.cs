using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
	[CreateAssetMenu(fileName = "GamePreferences", menuName = "Preferences/Create Game Preferences")]
	public class GamePreferences : ScriptableObject
	{
		public float SpeedUpFactor = 1.2f;
		public float SpeedUpTimer = 1;
		public float RoundDuration = 20;
	}
}