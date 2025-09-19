namespace _1._Project.Scripts.StateMachine
{
	public abstract class BaseState : IBaseState
	{
		protected ApplicationStateSystem _applicationStateSystem;
		public virtual void SetupState(ApplicationStateSystem stateSystem)
		{
			_applicationStateSystem = stateSystem;
		}
		
		public virtual void StartState()
		{
			
		}
		
		public virtual void UpdateState()
		{
			
		}
		
		public virtual void ExitState()
		{
			
		}
	}
}