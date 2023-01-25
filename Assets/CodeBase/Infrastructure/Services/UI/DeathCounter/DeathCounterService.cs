using CodeBase.Infrastructure.Services.GameStats;
using CodeBase.Infrastructure.StateMachine;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.UI.DeathCounter
{
	[RequireComponent(typeof(Canvas))]
	public class DeathCounterService : MonoBehaviour, IResettable
	{
		private readonly IntReactiveProperty _counter  = new(0);
		[SerializeField] private TextMeshProUGUI _counterText;
		[SerializeField] private float _scaleFactor = 1.2f;
		[SerializeField] private float _scaleDuration = 0.2f;
		private Canvas _canvas;

		private void Awake()
		{
			_canvas = GetComponent<Canvas>();
			_canvas.enabled = false;
		}

		[Inject]
		private void Construct(GameStatsService gameStatsService) =>
			gameStatsService.Deaths
				.Subscribe(x =>
				{
					_counterText.text = x.ToString();
					DOTween.Kill(_counterText);
					_counterText.transform.localScale = Vector3.one;
					_counterText.transform.DOPunchScale(Vector3.one * _scaleFactor, _scaleDuration);
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