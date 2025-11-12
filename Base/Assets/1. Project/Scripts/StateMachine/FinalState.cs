using _1._Project.Scripts.Button;
using UnityEngine;

namespace _1._Project.Scripts.StateMachine
{
	public class FinalState : BaseState
	{
		private float _timer;
		public override void StartState()
		{
			ScreenManager.CallScreen?.Invoke(StatesNames.FinalStateName);
			Button.ButtonActions.OnClick += OnClick;
			_timer = JsonSystem.Instance.JsonModel.FinalScreenTime;
		}

		private void OnClick(ButtonFunctionName obj)
		{
			if (obj == ButtonFunctionName.ForceReset)
			{
				_applicationStateSystem.GoToIdle();
			}
		}

		public override void ExitState()
		{
			Button.ButtonActions.OnClick -= OnClick;
		}

		public override void UpdateState()
		{
			_timer -= Time.deltaTime;
			if (_timer <= 0)
			{
				_applicationStateSystem.GoToIdle();
			}
		}
	}
}