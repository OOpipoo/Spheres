using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.StateMachine.States;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine
{
	public class GameLoopStateMachine : IInitializable
	{
		private readonly DiContainer _diContainer;
		private Dictionary<Type, IState> _states;
		private IState _activeState;

		public GameLoopStateMachine(DiContainer diContainer)
		{
			_diContainer = diContainer;
		}
		public IState ActiveState => _activeState;
		public void Initialize()
		{
			_states = new Dictionary<Type, IState>
			{
				{ typeof(GameLoadState), new GameLoadState(this) },
				{ typeof(MenuState), new MenuState(this) },
				{ typeof(GameState), new GameState(this) },
				{ typeof(EndGameState), new EndGameState(this) },
				{ typeof(ResetState), new ResetState(this) }
			};
			foreach ((Type key, IState state) in _states)
			{
				_diContainer.Inject(state);
			}
		}
		
		public void Enter<TState>() where TState : class, IState
		{
			IState state = ChangeState<TState>();
			state.Enter();
		}

		private TState ChangeState<TState>() where TState : class, IState
		{
			_activeState?.Exit();
      
			TState state = GetState<TState>();
			_activeState = state;
      
			return state;
		}

		private TState GetState<TState>() where TState : class, IState => 
			_states[typeof(TState)] as TState;
	}
}