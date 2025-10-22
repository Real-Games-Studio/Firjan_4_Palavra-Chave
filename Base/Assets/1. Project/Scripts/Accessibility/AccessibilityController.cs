using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _1._Project.Scripts.Accessibility
{
	public class AccessibilityController : MonoBehaviour
	{
		private Languages _currentLanguage;
		public List<RawImage> LangsBG;
		public Color Transparent;

		public void Start()
		{
			ChangeToPortuguese();
		}

		private void ChangeLanguage(Languages language)
		{
			_currentLanguage = language;
			foreach (var item in LangsBG)
			{
				item.color = Transparent;
			}
			LangsBG[(int)_currentLanguage].color =Color.white;
			AccessibilityEvents.OnChange?.Invoke(_currentLanguage);
		}
		
		public void ChangeToPortuguese() => ChangeLanguage(Languages.Portuguese);
		public void ChangeToEnglish() => ChangeLanguage(Languages.English);
		
		
	}
}