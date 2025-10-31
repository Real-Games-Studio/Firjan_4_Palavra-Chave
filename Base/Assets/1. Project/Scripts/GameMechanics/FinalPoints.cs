using System;
using _1._Project.Scripts.Button;
using _4._NFC_Firjan.Scripts.Server;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _1._Project.Scripts.GameMechanics
{
	public class FinalPoints : MonoBehaviour
	{
		public string LastNFCConnected;
		public GameController GameController;
		public ServerComunication ServerComunication;
		public GameModel GameModel = new GameModel();

		public Image Bar1;
		public Image Bar1NFC;
		public Image Bar2;
		public Image Bar2NFC;
		public Image Bar3;
		public Image Bar3NFC;

		private int _maxPoint1;
		private int _maxPoint2;
		private int _maxPoint3;
		
		private int _pointLostPerError;
		
		private int _currentPointsAbility1;
		private int _currentPointsAbility2;
		private int _currentPointsAbility3;
		public void Start()
		{
			_pointLostPerError = JsonSystem.Instance.JsonModel.PointLostPerError;
			_maxPoint1 = JsonSystem.Instance.JsonModel.MaxPoints1;
			_maxPoint2 = JsonSystem.Instance.JsonModel.MaxPoints2;
			_maxPoint3 = JsonSystem.Instance.JsonModel.MaxPoints3;
			GameModel.gameId = JsonSystem.Instance.JsonModel.GameId;
			ServerComunication.Ip = JsonSystem.Instance.JsonModel.IP;
			ServerComunication.Port = JsonSystem.Instance.JsonModel.Port;
		}

		private void FixedUpdate()
		{
			FillBars();
		}

		private void CalculatePoints()
		{
			if (GameController.RightCount == 0)
			{
				_currentPointsAbility1 = 0;
				_currentPointsAbility2 = 0;
				_currentPointsAbility3 = 0;
				return;
			}

			if (GameController.RightCount == 1)
			{
				_currentPointsAbility1 = JsonSystem.Instance.JsonModel.Right1Points1;
				_currentPointsAbility2 = JsonSystem.Instance.JsonModel.Right1Points2;
				_currentPointsAbility3 = JsonSystem.Instance.JsonModel.Right1Points3;
			}
			if (GameController.RightCount == 2)
			{
				_currentPointsAbility1 = JsonSystem.Instance.JsonModel.Right2Points1;
				_currentPointsAbility2 = JsonSystem.Instance.JsonModel.Right2Points2;
				_currentPointsAbility3 = JsonSystem.Instance.JsonModel.Right2Points3;
			}
			if (GameController.RightCount == 3)
			{
				_currentPointsAbility1 = JsonSystem.Instance.JsonModel.Right3Points1;
				_currentPointsAbility2 = JsonSystem.Instance.JsonModel.Right3Points2;
				_currentPointsAbility3 = JsonSystem.Instance.JsonModel.Right3Points3;
			}
			if (GameController.RightCount == 4)
			{
				_currentPointsAbility1 = JsonSystem.Instance.JsonModel.MaxPoints1;
				_currentPointsAbility2 = JsonSystem.Instance.JsonModel.MaxPoints2;
				_currentPointsAbility3 = JsonSystem.Instance.JsonModel.MaxPoints3;
			}
			_currentPointsAbility1 -= GameController.WrongCount * _pointLostPerError;
			_currentPointsAbility2 -= GameController.WrongCount * _pointLostPerError;
			_currentPointsAbility3 -= GameController.WrongCount * _pointLostPerError;
		}

		public void GetNfcUser(string nfcId, string readerName)
		{
			LastNFCConnected = nfcId;
			ButtonActions.OnClick?.Invoke(ButtonFunctionName.NFCRead);
			SendPointsToServer(GameController.RightCount);
		}

		public void FillBars()
		{
			CalculatePoints();
			Bar1.fillAmount = Percent(_currentPointsAbility1, _maxPoint1);
			Bar1NFC.fillAmount = Percent(_currentPointsAbility1, _maxPoint1);
			Bar2.fillAmount = Percent(_currentPointsAbility2, _maxPoint2);
			Bar2NFC.fillAmount = Percent(_currentPointsAbility2, _maxPoint2);
			Bar3.fillAmount = Percent(_currentPointsAbility3, _maxPoint3);
			Bar3NFC.fillAmount = Percent(_currentPointsAbility3, _maxPoint3);
		}


		public float Percent(float point, float MaxPoint)
		{

			return (float) point / MaxPoint;

		}

		public async void SendPointsToServer(int points)
		{
			GameModel.nfcId = LastNFCConnected;
			if (_currentPointsAbility1 ==0 && _currentPointsAbility2 ==0 && _currentPointsAbility3 ==0)
			{
				return;
			}
			GameModel.skill1 = _currentPointsAbility1;
			GameModel.skill2 = _currentPointsAbility2;
			GameModel.skill3 = _currentPointsAbility3;
#if UNITY_EDITOR
					return;
#endif
					await ServerComunication.UpdateNfcInfoFromGame(GameModel);

		}
		
	}
}