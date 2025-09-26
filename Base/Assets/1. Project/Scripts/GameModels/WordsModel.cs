using System.Collections.Generic;
using Newtonsoft.Json;

namespace _1._Project.Scripts.GameModels
{
	public class WordsModel
	{
		[JsonProperty("Grupo1")]
		public List<string> Group1;
		[JsonProperty("Grupo2")]
		public List<string> Group2;
		[JsonProperty("Grupo3")]
		public List<string> Group3;
		[JsonProperty("Grupo4")]
		public List<string> Group4;
		[JsonProperty("Grupo5")]
		public List<string> Group5;
		[JsonProperty("Grupo6")]
		public List<string> Group6;
		[JsonProperty("Grupo7")]
		public List<string> Group7;
	}
}