using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.States;
using CodeBase.Infrastructure.StaticData;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.UI.CountDownTimer
{
	[RequireComponent(typeof(Canvas))]
	public class CountDownTimerService : MonoBehaviour, IResettable
	{
		private readonly FloatReactiveProperty _timeLeft = new();
		[SerializeField] private TextMeshProUGUI _text;
		private Canvas _canvas;
		private GamePreferences _gamePreferences;
		private GameLoopStateMachine _gameLoopStateMachine;

		private void Awake()
		{
			_canvas = GetComponent<Canvas>();
			_canvas.enabled = false;
			MakeSubscription();
		}

		[Inject]
		private void Construct(GamePreferences gamePreferences, GameLoopStateMachine gameLoopStateMachine)
		{
			_gameLoopStateMachine = gameLoopStateMachine;
			_gamePreferences = gamePreferences;
		}

		public void StartTimer()
		{
			_canvas.enabled = true;
			Observable
				.EveryLateUpdate()
				.TakeWhile(_ => _timeLeft.Value > 0)
				.Subscribe(
					onNext: _ => _timeLeft.Value -= Time.deltaTime,
					onCompleted: () =>
					{
						_gameLoopStateMachine.Enter<EndGameState>();
						_canvas.enabled = false;
					})
				.AddTo(this);
		}

		public void CustomReset() => 
			_timeLeft.Value = _gamePreferences.RoundDuration;

		private void MakeSubscription() =>
			_timeLeft
				.Subscribe(x => _text.text = x.ToString("F2"))
				.AddTo(this);
	}
}