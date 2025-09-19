namespace _1._Project.Scripts.StateMachine
{
	public class GameState : BaseState
	{
		public override void StartState()
		{
			ScreenManager.CallScreen?.Invoke(StatesNames.GameStateName);
		}
	}
}