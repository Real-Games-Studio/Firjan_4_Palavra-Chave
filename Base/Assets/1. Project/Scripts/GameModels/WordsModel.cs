using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace _1._Project.Scripts.GameModels
{
	[Serializable]
	public class WordsModel
	{
		
		[JsonProperty("Tema")]
		public string Category;
		[JsonProperty("Palavras")]
		public List<string> Words; 
	}
}