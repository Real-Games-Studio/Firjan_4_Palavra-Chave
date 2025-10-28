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

		private int _point1RightAbility1;
		private int _point1RightAbility2;
		private int _point1RightAbility3;
		private int _point2RightAbility1;
		private int _point2RightAbility2;
		private int _point2RightAbility3;
		private int _point3RightAbility1;
		private int _point3RightAbility2;
		private int _point3RightAbility3;
		private int _point4RightAbility1;
		private int _point4RightAbility2;
		private int _point4RightAbility3;
		public void Start()
		{
			_maxPoint1 = JsonSystem.Instance.JsonModel.MaxPoints1;
			_maxPoint2 = JsonSystem.Instance.JsonModel.MaxPoints2;
			_maxPoint3 = JsonSystem.Instance.JsonModel.MaxPoints3;
			_point1RightAbility1 = JsonSystem.Instance.JsonModel.Points1RightAbility1;
			_point1RightAbility2 = JsonSystem.Instance.JsonModel.Points1RightAbility2;
			_point1RightAbility3 = JsonSystem.Instance.JsonModel.Points1RightAbility3;
			_point2RightAbility1 = JsonSystem.Instance.JsonModel.Points2RightAbility1;
			_point2RightAbility2 = JsonSystem.Instance.JsonModel.Points2RightAbility2;
			_point2RightAbility3 = JsonSystem.Instance.JsonModel.Points2RightAbility3;
			_point3RightAbility1 = JsonSystem.Instance.JsonModel.Points3RightAbility1;
			_point3RightAbility2 = JsonSystem.Instance.JsonModel.Points3RightAbility2;
			_point3RightAbility3 = JsonSystem.Instance.JsonModel.Points3RightAbility3;
			_point4RightAbility1 = JsonSystem.Instance.JsonModel.Points4RightAbility1;
			_point4RightAbility2 = JsonSystem.Instance.JsonModel.Points4RightAbility2;
			_point4RightAbility3 = JsonSystem.Instance.JsonModel.Points4RightAbility3;
			GameModel.gameId = JsonSystem.Instance.JsonModel.GameId;
			ServerComunication.Ip = JsonSystem.Instance.JsonModel.IP;
			ServerComunication.Port = JsonSystem.Instance.JsonModel.Port;
		}

		private void FixedUpdate()
		{
			FillBars(GameController.RightCount);
		}

		public void GetNfcUser(string nfcId, string readerName)
		{
			LastNFCConnected = nfcId;
			ButtonActions.OnClick?.Invoke(ButtonFunctionName.NFCRead);
			SendPointsToServer(GameController.RightCount);
		}

		public void FillBars(int points)
		{
			switch (points)
			{
				case 0:
					Bar1.fillAmount = Percent(0,_maxPoint1);
					Bar1NFC.fillAmount = Percent(0,_maxPoint1);
					Bar2.fillAmount = Percent(0,_maxPoint2);
					Bar2NFC.fillAmount = Percent(0,_maxPoint2);
					Bar3.fillAmount = Percent(0,_maxPoint3);
					Bar3NFC.fillAmount = Percent(0,_maxPoint3);
					break;
				case 1:
					Bar1.fillAmount = Percent(_point1RightAbility1,_maxPoint1);
					Bar1NFC.fillAmount = Percent(_point1RightAbility1,_maxPoint1);
					Bar2.fillAmount = Percent(_point1RightAbility2,_maxPoint2);
					Bar2NFC.fillAmount = Percent(_point1RightAbility2,_maxPoint2);
					Bar3.fillAmount = Percent(_point1RightAbility3,_maxPoint3);
					Bar3NFC.fillAmount = Percent(_point1RightAbility3,_maxPoint3);
					break;
				case 2: 
					Bar1.fillAmount = Percent(_point2RightAbility1,_maxPoint1);
					Bar1NFC.fillAmount = Percent(_point2RightAbility1,_maxPoint1);
					Bar2.fillAmount = Percent(_point2RightAbility2,_maxPoint2);
					Bar2NFC.fillAmount = Percent(_point2RightAbility2,_maxPoint2);
					Bar3.fillAmount = Percent(_point2RightAbility3,_maxPoint3);				
					Bar3NFC.fillAmount = Percent(_point2RightAbility3,_maxPoint3);				
					break;
				case 3: 
					Bar1.fillAmount = Percent(_point3RightAbility1,_maxPoint1);
					Bar1NFC.fillAmount = Percent(_point3RightAbility1,_maxPoint1);
					Bar2.fillAmount = Percent(_point3RightAbility2,_maxPoint2);
					Bar2NFC.fillAmount = Percent(_point3RightAbility2,_maxPoint2);
					Bar3.fillAmount = Percent(_point3RightAbility3,_maxPoint3);				
					Bar3NFC.fillAmount = Percent(_point3RightAbility3,_maxPoint3);				
					break;
				default:
					Bar1.fillAmount = Percent(_point4RightAbility1,_maxPoint1);
					Bar1NFC.fillAmount = Percent(_point4RightAbility1,_maxPoint1);
					Bar2.fillAmount = Percent(_point4RightAbility2,_maxPoint2);
					Bar2NFC.fillAmount = Percent(_point4RightAbility2,_maxPoint2);
					Bar3.fillAmount = Percent(_point4RightAbility3,_maxPoint3);				
					Bar3NFC.fillAmount = Percent(_point4RightAbility3,_maxPoint3);				
					break;
			}
		}


		public float Percent(float point, float MaxPoint)
		{

			return (float) point / MaxPoint;

		}

		public async void SendPointsToServer(int points)
		{
			GameModel.nfcId = LastNFCConnected;
			switch (points)
			{
				case 0:
					Debug.Log("Tentar novamente");
					return;
					break;
				case 1:
					GameModel.skill1 = _point1RightAbility1;
					GameModel.skill2 = _point1RightAbility2;
					GameModel.skill3 = _point1RightAbility3;
					break;
				case 2:
					GameModel.skill1 = _point2RightAbility1;
					GameModel.skill2 = _point2RightAbility2;
					GameModel.skill3 = _point2RightAbility3;
					break;
				case 3:
					GameModel.skill1 = _point3RightAbility1;
					GameModel.skill2 = _point3RightAbility2;
					GameModel.skill3 = _point3RightAbility3;
					break;
				default:
					GameModel.skill1 = _point4RightAbility1;
					GameModel.skill2 = _point4RightAbility2;
					GameModel.skill3 = _point4RightAbility3;
					break;
			}
#if UNITY_EDITOR
					return;
#endif
					await ServerComunication.UpdateNfcInfoFromGame(GameModel);

		}
		
	}
}