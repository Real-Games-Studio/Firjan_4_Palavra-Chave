using _1._Project.Scripts.Button;
using UnityEngine;

namespace _1._Project.Scripts.StateMachine
{
	public class NFCReadState : BaseState
	{
		public override void StartState()
		{
			ButtonActions.OnClick += OnClickHandler;
			ScreenManager.CallScreen?.Invoke(StatesNames.NFCReadStateName);
		}

		private void OnClickHandler(ButtonFunctionName obj)
		{
			if (obj == ButtonFunctionName.NFCRead)
			{
				_applicationStateSystem.GoToFinal();
				return;
			}

			if (obj == ButtonFunctionName.ForceReset)
			{
				_applicationStateSystem.GoToIdle();
			}
		}


		public override void ExitState()
		{
			ButtonActions.OnClick -= OnClickHandler;
		}
	}
}