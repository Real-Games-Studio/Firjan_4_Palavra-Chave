using System;
using _4._NFC_Firjan.Scripts.Server;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace _4._NFC_Firjan.Scripts.Helper
{
	public class GameTest : MonoBehaviour
	{
		public TextMeshProUGUI DebugTextNfc;
		public string NfcId;
		public int GameId;
		public int Skill1;
		public int Skill2;
		public int Skill3;

		public string Name;
		public string CardConnectedName;
		public bool IsCardConnected;
		public string CardReaderName;
		public bool IsCardReaderConnected;

		public GameModel gameModel = new GameModel();

		public ServerComunication serverComunication;
		[FormerlySerializedAs("ServerDebug")] public TextMeshProUGUI ServerDebugGetGame;
		public TextMeshProUGUI ServerDebugGetEndGame;
	
		public EndGameResponseModel EndGameResponseModel = new EndGameResponseModel()
		{
			attributes = new EndGameResponseModel.Attributes
			{
				active_listening = 0,
				adaptability = 0,
				agility = 0,
				analytical_thinking = 0,
				communication = 0,
				continuous_learning = 0,
				creativity = 0,
				critical_thinking = 0,
				curiosity = 0,
				decision_making = 0,
				digital_literacy = 0,
				empathy = 0,
				leadership = 0,
				logical_reasoning = 0,
				problem_solving = 0,
				resilience = 0,
				self_awareness = 0,

			}
		};
		private void FixedUpdate()
		{
			gameModel.nfcId = NfcId;
			gameModel.gameId = GameId;
			gameModel.skill1 = Skill1;
			gameModel.skill2 = Skill2;
			gameModel.skill3 = Skill3;
			DebugTextNfc.text = DebugTextStrNfc();
			ServerDebugGetEndGame.text = DebugTextEndGame();
		}

		public void SetNfcId(string nfcId)
		{
			NfcId = nfcId;
		}

		public void SetGameId(string gameId)
		{
			GameId = int.Parse(gameId);
		}
		public void SetSkill1(string skill)
		{
			Skill1 = int.Parse(skill);
		}
		public void SetSkill2(string skill)
		{
			Skill2 = int.Parse(skill);
		}
		public void SetSkill3(string skill)
		{
			Skill3 = int.Parse(skill);
		}

		public void SetName(string name)
		{
			Name = name;
		}
		public void CardConnected(string nfcId)
		{
			CardConnectedName = nfcId;
			IsCardConnected = true;
		}

		public void CardDisconnected()
		{
			IsCardConnected = false;
		}

		public void CardReaderConnected(string readerName)
		{
			CardReaderName = readerName;
			IsCardReaderConnected = true;
		}

		public void CardReaderDisconnected()
		{
			IsCardReaderConnected = false;
		}

		public void SendGame()
		{
			var a = serverComunication.UpdateNfcInfoFromGame(gameModel);
			ServerDebugGetGame.text = $"Resposta: {a.Result.ToString()}";
		}

		public void GetCardInfo()
		{
			EndGameResponseModel = serverComunication.GetCardInfo(NfcId).Result;
		}

		public void GetFinalGameInfo()
		{
			var gm = new EndGameRequestModel
			{
				name = Name
			};
			EndGameResponseModel = serverComunication.PostNameForEndGameInfo(gm, NfcId).Result;
		}

		public string DebugTextEndGame()
		{
			return $"Emptia:{EndGameResponseModel.attributes.empathy:00}\n" +
			       $"Letramento Digital:{EndGameResponseModel.attributes.digital_literacy:00}\n" +
			       $"Tomada de Decisão:{EndGameResponseModel.attributes.decision_making:00}\n" +
			       $"Aprendizado contínuo:{EndGameResponseModel.attributes.continuous_learning:00}\n" +
			       $"Curiosidade:{EndGameResponseModel.attributes.curiosity:00}\n" +
			       $"Resolução de problemas:{EndGameResponseModel.attributes.problem_solving:00}\n" +
			       $"Autoconsiência:{EndGameResponseModel.attributes.self_awareness:00}\n" +
			       $"Comunicação:{EndGameResponseModel.attributes.communication:00}\n" +
			       $"Pensamento crítico:{EndGameResponseModel.attributes.critical_thinking:00}\n" +
			       $"Raciocínio Lógico:{EndGameResponseModel.attributes.logical_reasoning:00}\n" +
			       $"Liderança:{EndGameResponseModel.attributes.leadership:00}\n" +
			       $"Adaptabilidade:{EndGameResponseModel.attributes.adaptability:00}\n" +
			       $"Agilidade:{EndGameResponseModel.attributes.agility:00}\n" +
			       $"Criatividade:{EndGameResponseModel.attributes.creativity:00}\n" +
			       $"Escuta Ativa:{EndGameResponseModel.attributes.active_listening:00}\n" +
			       $"Pensamento analítico:{EndGameResponseModel.attributes.analytical_thinking:00}\n" +
			       $"Resiliência:{EndGameResponseModel.attributes.resilience:00}\n";
		}
		public string DebugTextStrNfc()
		{
			return $"Last nfc Id:{CardConnectedName} is connected:{IsCardConnected} " +
			       $"and Last Reader Name:{CardReaderName} is  connected:{IsCardReaderConnected}";
		}
	}
}