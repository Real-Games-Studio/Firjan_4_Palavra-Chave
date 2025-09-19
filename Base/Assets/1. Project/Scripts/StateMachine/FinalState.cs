namespace _1._Project.Scripts.StateMachine
{
	public class FinalState : BaseState
	{
		public override void StartState()
		{
			ScreenManager.CallScreen?.Invoke(StatesNames.FinalStateName);
		}
		
	}
}