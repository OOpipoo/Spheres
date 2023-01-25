using CodeBase.Infrastructure.StaticData;
using CodeBase.SoapBubble;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.BubbleParametresRandomizer
{
	public class BubbleParametresRandomizerService
	{
		private readonly SpawnPreferences _spawnPreferences;

		public BubbleParametresRandomizerService(SpawnPreferences spawnPreferences)
		{
			_spawnPreferences = spawnPreferences;
		}
		public void RandomizeParametres(ComponentsHolder componentsHolder)
		{
			float randomValue = Random.value;
			float sizeModificator = Mathf.Lerp(_spawnPreferences.MinSize, _spawnPreferences.MaxSize, randomValue);
			Vector3 targetSize = Vector3.one * sizeModificator;
			componentsHolder.Transform.localScale = targetSize;
			componentsHolder.Radius = sizeModificator / 2;
			componentsHolder.Speed = Mathf.Lerp(_spawnPreferences.MaxSpeed, _spawnPreferences.MinSpeed, randomValue);
			componentsHolder.Points = Mathf.Lerp(_spawnPreferences.MaxPoints, _spawnPreferences.MinPoints, randomValue);
		}
	}
}