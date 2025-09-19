namespace _4._NFC_Firjan.Scripts.Server
{
	public class GameModel
	{
		public string nfcId;
		public int gameId;
		public int skill1;
		public int skill2;
		public int skill3;

		public override string ToString()
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
		}
	}
}