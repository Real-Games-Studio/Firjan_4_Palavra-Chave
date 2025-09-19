using Newtonsoft.Json;

namespace _1._Project.Scripts.GameModels
{
	public class JsonModel
	{
		[JsonProperty("TempoMaximoAfk")]
		public float MaxTimeAfk;
		[JsonProperty("TempoMaximoTelaFinal")]
		public float FinalScreenTime;
		[JsonProperty("TempoDeJogo")] 
		public float TotalGameplayTime;
		[JsonProperty("PalavrasDoJogo")]
		public WordsModel wordsModel;
	}
}