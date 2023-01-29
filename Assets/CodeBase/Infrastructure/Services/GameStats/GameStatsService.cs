using CodeBase.Infrastructure.StateMachine;
using UniRx;

namespace CodeBase.Infrastructure.Services.GameStats
{
	public class GameStatsService : IResettable
	{
		public readonly IntReactiveProperty Deaths = new();
		public readonly FloatReactiveProperty Distance = new();
		public float Points;
		
		
		public void CustomReset()
		{
			Deaths.Value = 0;
			Distance.Value = 0;
			Points = 0;
		}
	}
}