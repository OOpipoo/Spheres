using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace CodeBase
{
	public class EntryPoint : MonoBehaviour
	{
		private GameLoopStateMachine _gameLoopStateMachine;

		[Inject]
		private void Construct(GameLoopStateMachine gameLoopStateMachine) => 
			_gameLoopStateMachine = gameLoopStateMachine;

		private void Start() => 
			_gameLoopStateMachine.Enter<GameLoadState>();
	}
}