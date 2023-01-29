using CodeBase.Infrastructure.Services.GameStats;
using CodeBase.Infrastructure.StateMachine;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.UI.DistanceCounter
{
	[RequireComponent(typeof(Canvas))]
	public class DistanceCounterService : MonoBehaviour, IResettable
	{
		private readonly IntReactiveProperty _counter  = new(0);
		[SerializeField] private TextMeshProUGUI _counterText;
		private Canvas _canvas;
		
		private void Awake()
		{
			_canvas = GetComponent<Canvas>();
			_canvas.enabled = false;
		}
		
		[Inject]
		private void Construct(GameStatsService gameStatsService) =>
			gameStatsService.Distance
				.Subscribe(x =>
				{
					_counterText.text = x.ToString("0");
				})
				.AddTo(this);

		public void Increment() => 
			_counter.Value++;

		public void Show() => 
			_canvas.enabled = true;

		public void Hide() => 
			_canvas.enabled = false;

		public void CustomReset() => 
			_counter.Value = 0; 
	}
}