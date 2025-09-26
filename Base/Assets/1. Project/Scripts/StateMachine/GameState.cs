using _1._Project.Scripts.Button;

namespace _1._Project.Scripts.StateMachine
{
	public class GameState : BaseState
	{
		public override void StartState()
		{
			ScreenManager.CallScreen?.Invoke(StatesNames.GameStateName);
			ButtonActions.OnClick += OnClickHandler;
		}

		private void OnClickHandler(ButtonFunctionName obj)
		{
			if (obj == ButtonFunctionName.EndGame)
			{
				_applicationStateSystem.GoToFinal();
			}
		}


		public override void ExitState()
		{
			ButtonActions.OnClick -= OnClickHandler;
		}
	}
}