using System;
using System.Collections.Generic;
using _1._Project.Scripts.Accessibility;
using _1._Project.Scripts.GameModels;
using TMPro;
using UnityEngine;

namespace _1._Project.Scripts.Lang
{
	public class UILangHandler : MonoBehaviour
	{
		
		public TextMeshProUGUI GameTile1;
		public TextMeshProUGUI GameTile2;
		public TextMeshProUGUI StartButton;
		public TextMeshProUGUI CTADetails;
		public TextMeshProUGUI GameDescription;
		public TextMeshProUGUI ReadNFCTitleWin;
		public TextMeshProUGUI ReadNFCDescriptionWin;
		public TextMeshProUGUI ReadNFCTitleLose;
		public TextMeshProUGUI ReadNFCDescriptionLose;
		public TextMeshProUGUI ScanCard;
		public TextMeshProUGUI Skill1Name;
		public TextMeshProUGUI Skill2Name;
		public TextMeshProUGUI Skill3Name;
		public TextMeshProUGUI Skill1NameFinal;
		public TextMeshProUGUI Skill2NameFinal;
		public TextMeshProUGUI Skill3NameFinal;
		public TextMeshProUGUI FinalButton;
		public TextMeshProUGUI FinalTitle;
		public TextMeshProUGUI FinalDescription;
		public List<TextMeshProUGUI> PopUpTexts = new List<TextMeshProUGUI>();
		public List<TextMeshProUGUI> PopUpTextButtonYes = new List<TextMeshProUGUI>();
		public List<TextMeshProUGUI> PopUpTextButtonNo = new List<TextMeshProUGUI>();

		private void Awake()
		{
			AccessibilityEvents.OnChange += OnLangChangeHandler;
		}

		private void OnLangChangeHandler(Languages obj)
		{
			GameTile1.ChangeLang(JsonSystem.Instance.LanguageJsonModel.GameTile1,obj);
			GameTile2.ChangeLang(JsonSystem.Instance.LanguageJsonModel.GameTile2,obj);
			StartButton.ChangeLang(JsonSystem.Instance.LanguageJsonModel.StartButton,obj);
			CTADetails.ChangeLang(JsonSystem.Instance.LanguageJsonModel.CTADetails,obj);
			GameDescription.ChangeLang(JsonSystem.Instance.LanguageJsonModel.GameDescription,obj);
			ReadNFCTitleWin.ChangeLang(JsonSystem.Instance.LanguageJsonModel.ReadNFCTitleWin,obj);
			ReadNFCDescriptionWin.ChangeLang(JsonSystem.Instance.LanguageJsonModel.ReadNFCDescriptionWin,obj);
			ReadNFCTitleLose.ChangeLang(JsonSystem.Instance.LanguageJsonModel.ReadNFCTitleLose,obj);
			ReadNFCDescriptionLose.ChangeLang(JsonSystem.Instance.LanguageJsonModel.ReadNFCDescriptionLose,obj);
			ScanCard.ChangeLang(JsonSystem.Instance.LanguageJsonModel.ScanCard,obj);
			Skill1Name.ChangeLang(JsonSystem.Instance.LanguageJsonModel.Skill1Name,obj);
			Skill2Name.ChangeLang(JsonSystem.Instance.LanguageJsonModel.Skill2Name,obj);
			Skill3Name.ChangeLang(JsonSystem.Instance.LanguageJsonModel.Skill3Name,obj);
			Skill1NameFinal.ChangeLang(JsonSystem.Instance.LanguageJsonModel.Skill1Name,obj);
			Skill2NameFinal.ChangeLang(JsonSystem.Instance.LanguageJsonModel.Skill2Name,obj);
			Skill3NameFinal.ChangeLang(JsonSystem.Instance.LanguageJsonModel.Skill3Name,obj);
			FinalButton.ChangeLang(JsonSystem.Instance.LanguageJsonModel.FinalButton,obj);
			FinalTitle.ChangeLang(JsonSystem.Instance.LanguageJsonModel.FinalTitle,obj);
			FinalDescription.ChangeLang(JsonSystem.Instance.LanguageJsonModel.FinalDescription,obj);
			for (int i = 0; i < PopUpTextButtonNo.Count; i++)
			{
				PopUpTextButtonNo[i].ChangeLang(JsonSystem.Instance.LanguageJsonModel.PopUpTextButtonNo,obj);
			}
			for (int i = 0; i < PopUpTextButtonYes.Count; i++)
			{
				PopUpTextButtonYes[i].ChangeLang(JsonSystem.Instance.LanguageJsonModel.PopUpTextButtonYes,obj);
			}
			for (int i = 0; i < PopUpTexts.Count; i++)
			{
				PopUpTexts[i].ChangeLang(JsonSystem.Instance.LanguageJsonModel.PopUpTexts,obj);
			}
		}

		private void OnDestroy()
		{
			AccessibilityEvents.OnChange -= OnLangChangeHandler;
		}
	}

	public static class LangUtil
	{
		public static void ChangeLang(this TextMeshProUGUI textMeshProUGUI, LanguageModel languageModel, Languages langAvailable)
		{
			if (textMeshProUGUI == null)
			{
				return;
			}
			switch (langAvailable)
			{
				case Languages.English:
					textMeshProUGUI.text = languageModel.ENText;
					break;
				case Languages.Portuguese:
					textMeshProUGUI.text = languageModel.PTText;
					break;
				
			}
		}
	}
}