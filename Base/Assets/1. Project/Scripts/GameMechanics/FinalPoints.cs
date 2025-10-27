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
		public void Start()
		{
			_maxPoint1 = JsonSystem.Instance.JsonModel.MaxPoints1;
			_maxPoint2 = JsonSystem.Instance.JsonModel.MaxPoints2;
			_maxPoint3 = JsonSystem.Instance.JsonModel.MaxPoints3;
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
					Bar1.fillAmount = Percent(6,_maxPoint1);
					Bar1NFC.fillAmount = Percent(6,_maxPoint1);
					Bar2.fillAmount = Percent(5,_maxPoint2);
					Bar2NFC.fillAmount = Percent(5,_maxPoint2);
					Bar3.fillAmount = Percent(4,_maxPoint3);
					Bar3NFC.fillAmount = Percent(4,_maxPoint3);
					break;
				case 2: 
					Bar1.fillAmount = Percent(7,_maxPoint1);
					Bar1NFC.fillAmount = Percent(7,_maxPoint1);
					Bar2.fillAmount = Percent(6,_maxPoint2);
					Bar2NFC.fillAmount = Percent(6,_maxPoint2);
					Bar3.fillAmount = Percent(5,_maxPoint3);				
					Bar3NFC.fillAmount = Percent(5,_maxPoint3);				
					break;
				default:
					Bar1.fillAmount = Percent(8,_maxPoint1);
					Bar1NFC.fillAmount = Percent(8,_maxPoint1);
					Bar2.fillAmount = Percent(7,_maxPoint2);
					Bar1NFC.fillAmount = Percent(7,_maxPoint2);
					Bar3.fillAmount = Percent(6,_maxPoint3);
					Bar1NFC.fillAmount = Percent(6,_maxPoint3);
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
					break;
				case 1:
					GameModel.skill1 = 6;
					GameModel.skill2 = 5;
					GameModel.skill3 = 4;
					break;
				case 2: 
					GameModel.skill1 = 7;
					GameModel.skill2 = 6;
					GameModel.skill3 = 5;			
					break;
				default:
					GameModel.skill1 = 8;
					GameModel.skill2 = 7;
					GameModel.skill3 = 6;
					break;
			}
#if UNITY_EDITOR
					return;
#endif
					await ServerComunication.UpdateNfcInfoFromGame(GameModel);

		}
		
	}
}