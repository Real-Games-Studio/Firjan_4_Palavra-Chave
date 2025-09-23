using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace _4._NFC_Firjan.Scripts.Server
{
	public class ServerComunication : MonoBehaviour
	{
		/// <summary>
		/// Precisa ser colocado para receber do Json em cada aplicação.
		/// </summary>
		public string Ip;
		
		/// <summary>
		/// Precisa ser colocado para receber do Json em cada aplicação.
		/// </summary>
		public int Port;

		private HttpClient _client;

		private void Awake()
		{
			_client = new HttpClient();
		}

		private string GetFullEndGameUrl(string nfcId)
		{
			return $"http://{Ip}:{Port}/users/{nfcId}/endgame";
		}

		private string GetFullNfcUrl(string nfcId)
		{
			return $"http://{Ip}:{Port}/users/{nfcId}";
		}

		/// <summary>
		/// Informação deve ser enviada após o jogo, aconselho colocar o id do jogo por Json
		/// </summary>
		/// <param name="gameInfo"></param>
		/// Pontuação depende de cada jogo
		/// <returns></returns>
		public async Task<HttpStatusCode> UpdateNfcInfoFromGame(GameModel gameInfo)
		{
			var url = GetFullNfcUrl(gameInfo.nfcId);
			var request = new HttpRequestMessage(HttpMethod.Post, url);
			var content = new StringContent(gameInfo.ToString());
			request.Content = content; 
			Debug.Log($"Sending to {url}:{request.Content?.ReadAsStringAsync().Result}");
			var response = _client.SendAsync(request).Result;
			return response.StatusCode;
		}

		public async Task<EndGameResponseModel> GetCardInfo(string nfcId)
		{
			var url = GetFullNfcUrl(nfcId);
			var request = new HttpRequestMessage(HttpMethod.Get, url);
			Debug.Log($"Sending to {url}");
			var response = _client.SendAsync(request).Result;
			Debug.Log($"Response code is {response.StatusCode}");
			if (response.StatusCode == HttpStatusCode.OK)
			{
				return JsonConvert.DeserializeObject<EndGameResponseModel>(await response.Content.ReadAsStringAsync());
			}
			else
			{
				return null;
			}
		}
		public async Task<EndGameResponseModel> PostNameForEndGameInfo(EndGameRequestModel endGameRequestModel, 
			string nfcId)
		{
			var url = GetFullEndGameUrl(nfcId);
			var request = new HttpRequestMessage(HttpMethod.Post, url);
			var content = new StringContent(endGameRequestModel.ToString());
			request.Content = content;
			
			Debug.Log($"Sending to {url}:{request.Content?.ReadAsStringAsync().Result}");
			var response = _client.SendAsync(request).Result;
			Debug.Log($"Response code is {response.StatusCode}");
			if (response.StatusCode == HttpStatusCode.OK)
			{
				return Newtonsoft.Json.JsonConvert.DeserializeObject<EndGameResponseModel>(response.Content.ReadAsStringAsync().Result);
			}
			else
			{
				Debug.Log($"Response code is {response.StatusCode}");
				return null;
			}
			
		}
		
	}
}