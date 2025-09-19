namespace _1._Project.Scripts.StateMachine
{
	public interface IBaseState
	{
		public void SetupState(ApplicationStateSystem stateSystem);
		public void StartState();
		public void UpdateState();
		public void ExitState();
	}
}