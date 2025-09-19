using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace _4._NFC_Firjan.Scripts.Server
{
	public class ServerComunication : MonoBehaviour
	{
		public string Ip;
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

		private string GetFullUpdateNfcUrl(string nfcId)
		{
			return $"http://{Ip}:{Port}/users/{nfcId}";
		}

		public async Task<HttpStatusCode> UpdateNfcInfoFromGame(GameModel gameInfo)
		{
			var url = GetFullUpdateNfcUrl(gameInfo.nfcId);
			var request = new HttpRequestMessage(HttpMethod.Post, url);
			var content = new StringContent(gameInfo.ToString());
			request.Content = content; 
			Debug.Log($"Sending to {url}:{request.Content?.ReadAsStringAsync().Result}");
			var response = _client.SendAsync(request).Result;
			return response.StatusCode;
		}

		public async Task<EndGameResponseModel> GetEndGameInfo(EndGameRequestModel endGameRequestModel, 
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