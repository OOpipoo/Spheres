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
		private readonly FloatReactiveProperty _recordCounter  = new(0);
		[SerializeField] private TextMeshProUGUI _counterText;
		[SerializeField] private TextMeshProUGUI _recordText;
		private Canvas _canvas;
		
		private const string key = "distance";
		public float Record
		{
			get => PlayerPrefs.GetFloat(key); 
			set => PlayerPrefs.SetFloat(key, _recordCounter.Value); 
		}
		
		private void Awake()
		{
			_canvas = GetComponent<Canvas>();
			_canvas.enabled = false;
			_recordText.color = Color.green;

			_recordCounter.Value = Record;
			_recordText.text = _recordCounter.Value.ToString("0");
		}

		[Inject]
		private void Construct(GameStatsService gameStatsService)
		{
			UpdateDistanceCounter(gameStatsService);
		}

		private void UpdateDistanceCounter(GameStatsService gameStatsService)
		{
			gameStatsService.Distance
				.Subscribe(x =>
				{
					if (x > _recordCounter.Value)
					{
						_recordCounter.Value = x;
						Record = _recordCounter.Value;
					}

					_counterText.text = x.ToString("0");
					_recordText.text = _recordCounter.Value.ToString("0");
				})
				.AddTo(this);
		}

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