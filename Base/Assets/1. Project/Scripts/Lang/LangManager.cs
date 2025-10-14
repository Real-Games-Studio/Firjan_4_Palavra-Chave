using System;
using _1._Project.Scripts.Button;
using UnityEngine;

namespace _1._Project.Scripts.Lang
{
	public class LangManager : MonoBehaviour
	{
		public LangAvailable CurrentLang;


		private void Start()
		{
			ButtonActions.OnClick += OnClickHandler;
		}

		private void OnClickHandler(ButtonFunctionName obj)
		{
			if (obj == ButtonFunctionName.PTSelect)
			{
				CurrentLang = LangAvailable.PT;
			}
			else if (obj == ButtonFunctionName.ENSelect)
			{
				CurrentLang = LangAvailable.EN;
			}
			
		}
		
	}
	
	public enum LangAvailable
	{
		EN,
		PT
	}
}