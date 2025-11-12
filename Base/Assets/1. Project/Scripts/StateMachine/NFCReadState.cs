using _1._Project.Scripts.Button;
using UnityEngine;

namespace _1._Project.Scripts.StateMachine
{
	public class NFCReadState : BaseState
	{
		private float _timer;
		private float _timeOut;
		
		public override void StartState()
		{
			ButtonActions.OnClick += OnClickHandler;
			_timeOut = JsonSystem.Instance.JsonModel.MaxTimeAfk;
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

		public override void UpdateState()
		{
			if (_timer >= _timeOut)
			{
				_applicationStateSystem.GoToIdle();
			}
			else
			{
				_timer += Time.deltaTime;
			}
		}

		public override void ExitState()
		{			
			_timer = 0f;
			ButtonActions.OnClick -= OnClickHandler;
		}
	}
}