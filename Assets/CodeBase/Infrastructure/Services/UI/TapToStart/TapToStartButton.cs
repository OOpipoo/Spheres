using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.States;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace CodeBase.Infrastructure.Services.UI.TapToStart
{
	public class TapToStartButton : MonoBehaviour, IPointerDownHandler
	{
		private GameLoopStateMachine _gameLoopStateMachine;

		[Inject]
		private void Construct(GameLoopStateMachine gameLoopStateMachine) => 
			_gameLoopStateMachine = gameLoopStateMachine;

		public void OnPointerDown(PointerEventData eventData) => 
			_gameLoopStateMachine.Enter<GameState>();
	}
}