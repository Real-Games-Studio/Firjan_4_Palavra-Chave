using UnityEngine;

namespace _1._Project.Scripts.StateMachine
{
	public class FinalState : BaseState
	{
		private float _timer;
		public override void StartState()
		{
			ScreenManager.CallScreen?.Invoke(StatesNames.FinalStateName);
			_timer = JsonSystem.JsonModel.FinalScreenTime;
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