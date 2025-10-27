using System;
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
		[JsonProperty("PontuaçãoMaxima1")]
		public int MaxPoints1;
		[JsonProperty("PontuaçãoMaxima2")]
		public int MaxPoints2;
		[JsonProperty("PontuaçãoMaxima3")]
		public int MaxPoints3;
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
	}

	[Serializable]
	public class LanguageJsonModel
	{
		[JsonProperty("TituloDoJogo")]
		public LanguageModel GameTile;
		[JsonProperty("BotãoDeComeçar")]
		public LanguageModel StartButton;
		[JsonProperty("DetalhesCTA")]
		public LanguageModel CTADetails;
		[JsonProperty("DescriçãoDoJogo")]
		public LanguageModel GameDescription;
		[JsonProperty("SeGanharTiuloLerNFC")]
		public LanguageModel ReadNFCTitleWin;
		[JsonProperty("SeGanharDescriçãoLerNFC")]
		public LanguageModel ReadNFCDescriptionWin;
		[JsonProperty("SePerderTituloLerNFC")]
		public LanguageModel ReadNFCTitleLose;
		[JsonProperty("SePerderDescriçãoLerNFC")]
		public LanguageModel ReadNFCDescriptionLose;
		[JsonProperty("LerCartão")]
		public LanguageModel ScanCard;
		[JsonProperty("NomeSkill1")]
		public LanguageModel Skill1Name;
		[JsonProperty("NomeSkill2")]
		public LanguageModel Skill2Name;
		[JsonProperty("NomeSkill3")]
		public LanguageModel Skill3Name;
		[JsonProperty("BotãoFinal")]
		public LanguageModel FinalButton;
		[JsonProperty("TituloFinal")]
		public LanguageModel FinalTitle;
		[JsonProperty("DescriçãoFinal")]
		public LanguageModel FinalDescription;
	}
	[Serializable]
	public class LanguageModel
	{
		[JsonProperty("PT")]
		public string PTText;
		[JsonProperty("EN")]
		public string ENText;
	}
}