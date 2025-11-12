using System;
using UnityEngine;

namespace _1._Project.Scripts.StateMachine
{
	public class ApplicationStateSystem : MonoBehaviour
	{
		private readonly IBaseState _idleState = new IdleState();
		private readonly IBaseState _gameState = new GameState();
		private readonly IBaseState _nfcState = new NFCReadState();
		private readonly IBaseState _finalState = new FinalState();
		private IBaseState _currentState;
		
		[Header("For Debug On Editor")] 
		public string CurrentStateName = "";

		public void GoToIdle()
		{
			SwitchState(_idleState);
		}

		public void GoToNFC()
		{
			SwitchState(_nfcState);
		}
		public void GoToGame()
		{
			SwitchState(_gameState);
		}

		public void GoToFinal()
		{
			SwitchState(_finalState);
		}
		
		private void Awake()
		{
			SetUpStates();
		}

		private void Start()
		{
			GoToIdle();
		}

		private void Update()
		{
			_currentState.UpdateState();
		}

		private void SwitchState(IBaseState nextState)
		{
			if (_currentState != null)
			{
				_currentState.ExitState();
			}
			_currentState = nextState;
			CurrentStateName = nextState.GetType().Name;
			Debug.Log($"Switched to state: {CurrentStateName}");
			_currentState.StartState();
		}
		
		private void SetUpStates()
		{
			_idleState.SetupState(this);
			_gameState.SetupState(this);
			_finalState.SetupState(this);
			_nfcState.SetupState(this);
		}
	}

	public class StatesNames
	{
		public const string IdleStateName = "IdleState";
		public const string GameStateName = "GameState";
		public const string NFCReadStateName = "NFCReadState";
		public const string FinalStateName = "FinalState";
		
		public enum States
		{
			IdleState = 0,
			GameState = 1,
			FinalState = 2,
			NFCState = 3
		}
		
		public static States GetStateByName(string stateName)
		{
			switch (stateName)
			{
				case StatesNames.IdleStateName:
					return States.IdleState;
				case StatesNames.GameStateName:
					return States.GameState;
				case StatesNames.FinalStateName:
					return States.FinalState;
				case NFCReadStateName:
					return States.NFCState;
				default:
					return States.IdleState;
			}
		}
		public static string GetStateByName(States stateEnum)
		{
			switch (stateEnum)
			{
				case States.IdleState:
					return StatesNames.IdleStateName;
				case States.GameState:
					return StatesNames.GameStateName;
				case States.FinalState:
					return StatesNames.FinalStateName;
				case States.NFCState:
					return NFCReadStateName;
				default:
					return null;
			}
		}
	}
	
}