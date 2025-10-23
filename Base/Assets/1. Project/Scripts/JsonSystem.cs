using System;
using System.IO;
using _1._Project.Scripts.GameModels;
using Newtonsoft.Json;
using UnityEngine;

namespace _1._Project.Scripts
{
	public class JsonSystem : MonoBehaviour
	{
		public JsonModel JsonModel;
		public LanguageJsonModel LanguageJsonModel;
		
		public static JsonSystem Instance;

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
				LoadJson();
				DontDestroyOnLoad(this);
			}
			else
			{
				Destroy(gameObject);
			}
		}

		private void LoadJson()
		{
			
			string _jsonPath = "";
			string _rootFolder = Path.GetDirectoryName(Application.dataPath);
			
#if UNITY_EDITOR
			_jsonPath = Application.streamingAssetsPath;
#else
            _jsonPath = Path.Combine(_rootFolder, "contents");
#endif
			var _langJsonPath = Path.Combine(_jsonPath, "Language.json");
			_jsonPath = Path.Combine(_jsonPath, "appconfig.json");
			var _dataJson = File.ReadAllText(_jsonPath);
			var _langJson = File.ReadAllText(_langJsonPath);
			LanguageJsonModel = JsonConvert.DeserializeObject<LanguageJsonModel>(_langJson);
			JsonModel = JsonConvert.DeserializeObject<JsonModel>(_dataJson);
		}
	}
}