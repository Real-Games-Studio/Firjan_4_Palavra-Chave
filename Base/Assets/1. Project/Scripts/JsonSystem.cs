using System.IO;
using _1._Project.Scripts.GameModels;
using Newtonsoft.Json;
using UnityEngine;

namespace _1._Project.Scripts
{
	public static class JsonSystem
	{
		public static JsonModel JsonModel;

		static JsonSystem()
		{
			LoadJson();
		}


		private static void LoadJson()
		{
			
			string _jsonPath = "";
			string _rootFolder = Path.GetDirectoryName(Application.dataPath);
            

#if UNITY_EDITOR
			_jsonPath = Application.streamingAssetsPath;
#else
            _jsonPath = Path.Combine(_rootFolder, "contents");
#endif
			_jsonPath = Path.Combine(_jsonPath, "appconfig.json");
			var _dataJson = File.ReadAllText(_jsonPath);
			JsonModel = JsonConvert.DeserializeObject<JsonModel>(_dataJson);
		}
	}
}