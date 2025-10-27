using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace _1._Project.Scripts.GameModels
{
	[Serializable]
	public class WordsModel
	{
		[JsonProperty("Palavras")]
		public List<string> Words; 
	}

	public class WordAndGroupModel
	{
		[JsonProperty("Palavra")] 
		public string Word;
		[JsonProperty("Grupo")] 
		public int Group;
	}
}