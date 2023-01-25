using CodeBase.Infrastructure.Services.GameStats;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.States;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.UI.EndGameScreen
{
	[RequireComponent(typeof(Canvas))]
	public class EndGameScreenService : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _pointsText;
		private Canvas _canvas;
		private GameStatsService _gameStatsService;
		private GameLoopStateMachine _gameLoopStateMachine;

		private void Awake()
		{
			_canvas = GetComponent<Canvas>();
			_canvas.enabled = false;
		}

		[Inject]
		private void Construct(GameStatsService gameStatsService, GameLoopStateMachine gameLoopStateMachine)
		{
			_gameLoopStateMachine = gameLoopStateMachine;
			_gameStatsService = gameStatsService;
		}

		public void Show()
		{
			_canvas.enabled = true;
			_pointsText.text = _gameStatsService.Points.ToString("F0");
		}

		public void Hide() => 
			_canvas.enabled = false;

		public void Restart() =>						//Called by RESTART button
			_gameLoopStateMachine.Enter<ResetState>();
	}
}