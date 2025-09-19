using System.Collections.Generic;
using Newtonsoft.Json;

namespace _1._Project.Scripts.GameModels
{
	public class WordsModel
	{
		[JsonProperty("TodasAsPalavras")]
		public List<string> AllWords;
		[JsonProperty("PalavrasCorretasAzul")]
		public List<string> CorrectWordsBlue;
		[JsonProperty("PalavrasCorretasVermelho")]
		public List<string> CorrectWordsRed;
	}
}