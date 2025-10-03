using _1._Project.Scripts.Button;
using _4._NFC_Firjan.Scripts.Server;
using TMPro;
using UnityEngine;

namespace _1._Project.Scripts.GameMechanics
{
	public class FinalPoints : MonoBehaviour
	{
		public string LastNFCConnected;
		public GameController GameController;
		public ServerComunication ServerComunication;
		public GameModel GameModel = new GameModel();

		public TextMeshProUGUI TextPoints;

		public void Start()
		{
			GameModel.gameId = JsonSystem.JsonModel.GameId;
			ServerComunication.Ip = JsonSystem.JsonModel.IP;
			ServerComunication.Port = JsonSystem.JsonModel.Port;
		}

		public void GetNfcUser(string nfcId, string readerName)
		{
			LastNFCConnected = nfcId;
			ButtonActions.OnClick?.Invoke(ButtonFunctionName.NFCRead);
			SendPointsToServer(GameController.RightCount);
		}

		public async void SendPointsToServer(int points)
		{
			GameModel.nfcId = LastNFCConnected;
			switch (points)
			{
				case 0:
					Debug.Log("Tentar novamente");
					TextPoints.text = "Tentar novamente";
					break;
				case 1:
					GameModel.skill1 = 6;
					GameModel.skill2 = 5;
					GameModel.skill3 = 4;
					TextPoints.text = $"Aprendizado contínuo - {GameModel.skill1}  Adaptabilidade - {GameModel.skill2}  Resiliência - {GameModel.skill3}";
					break;
				case 2: 
					GameModel.skill1 = 7;
					GameModel.skill2 = 6;
					GameModel.skill3 = 5;
					TextPoints.text = $"Aprendizado contínuo - {GameModel.skill1}  Adaptabilidade - {GameModel.skill2}  Resiliência - {GameModel.skill3}";
					break;
				default:
					GameModel.skill1 = 8;
					GameModel.skill2 = 7;
					GameModel.skill3 = 6;
					TextPoints.text = $"Aprendizado contínuo - {GameModel.skill1}  Adaptabilidade - {GameModel.skill2}  Resiliência - {GameModel.skill3}";

					break;
			}
#if UNITY_EDITOR
					return;
#endif
					await ServerComunication.UpdateNfcInfoFromGame(GameModel);

		}
		
	}
}