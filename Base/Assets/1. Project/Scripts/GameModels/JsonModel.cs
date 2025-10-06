using Newtonsoft.Json;

namespace _1._Project.Scripts.GameModels
{
	public class JsonModel
	{
		public string IP;
		[JsonProperty("Porta")]
		public int Port;
		[JsonProperty("IdDoJogo")]
		public int GameId;
		[JsonProperty("TempoMaximoAfk")]
		public float MaxTimeAfk;
		[JsonProperty("TempoMaximoTelaFinal")]
		public float FinalScreenTime;
		[JsonProperty("TempoDeJogo")] 
		public float TotalGameplayTime;
		[JsonProperty("PalavrasPT")]
		public WordsBaseModel WordsPT;
		[JsonProperty("PalavrasEN")]
		public WordsBaseModel WordsEN;
	}
	
	public class WordsBaseModel
	{
		
		[JsonProperty("PalavrasGrupo1")]
		public WordsModel WordsGroup1;
		[JsonProperty("PalavrasGrupo2")]
		public WordsModel WordsGroup2;
		[JsonProperty("PalavrasGrupo3")]
		public WordsModel WordsGroup3;
		[JsonProperty("PalavrasGrupo4")]
		public WordsModel WordsGroup4;
		[JsonProperty("PalavrasGrupo5")]
		public WordsModel WordsGroup5;
		[JsonProperty("PalavrasGrupo6")]
		public WordsModel WordsGroup6;
		[JsonProperty("PalavrasGrupo7")]
		public WordsModel WordsGroup7;
	}
}