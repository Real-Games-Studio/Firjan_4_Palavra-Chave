using _1._Project.Scripts.Button;

namespace _1._Project.Scripts.StateMachine
{
	public class IdleState : BaseState
	{
		public override void StartState()
		{
			ButtonActions.OnClick += OnClickHandler;
			ScreenManager.CallScreen?.Invoke(StatesNames.IdleStateName);
		}

		private void OnClickHandler(ButtonFunctionName obj)
		{
			switch (obj)
			{
				case ButtonFunctionName.StartGame:
					_applicationStateSystem.GoToGame();
					break;
			}
		}

		public override void ExitState()
		{
			ButtonActions.OnClick -= OnClickHandler;
		}
	}
}