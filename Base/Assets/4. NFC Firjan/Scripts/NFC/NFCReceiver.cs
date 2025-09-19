using System;
using UnityEngine;
using Lando;
using UnityEngine.Events;

namespace _4._NFC_Firjan.Scripts.NFC
{
	public class NFCReceiver : MonoBehaviour
	{
		
		public UnityEvent<string> OnNFCConnected;
		public UnityEvent OnNFCDisconnected;
		public UnityEvent<string> OnNFCReaderConnected;
		public UnityEvent OnNFCReaderDisconected;
		private  Cardreader _cardreader = new Cardreader();

		private void Awake()
		{
			_cardreader.CardConnected += OnCardConnectedHandler;
			_cardreader.CardDisconnected += OnCardDisconnectedHandler;
			_cardreader.CardreaderConnected += OnCardreaderConnectedHandler;
			_cardreader.CardreaderDisconnected += OnCardreaderDisconnectedHandler;
			_cardreader.StartWatch();
		}

		private void OnCardreaderDisconnectedHandler(object sender, CardreaderEventArgs e)
		{
			OnNFCReaderDisconected.Invoke();
		}

		private void OnCardreaderConnectedHandler(object sender, CardreaderEventArgs e)
		{
			OnNFCReaderConnected.Invoke(e.CardreaderName);
		}

		private void OnCardDisconnectedHandler(object sender, CardreaderEventArgs e)
		{
			OnNFCDisconnected.Invoke();
		}

		private void OnCardConnectedHandler(object sender, CardreaderEventArgs e)
		{
			OnNFCConnected.Invoke(e.Card.Id);
		}

		private void OnDestroy()
		{
			_cardreader.StopWatch();
		}
	}
}