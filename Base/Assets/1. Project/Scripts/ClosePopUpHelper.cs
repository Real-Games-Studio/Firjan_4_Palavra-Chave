using System;
using _1._Project.Scripts.Button;
using UnityEngine;

namespace _1._Project.Scripts
{
	public class ClosePopUpHelper : MonoBehaviour
	{
		public GameObject PopUpGameObject;

		private void Start()
		{
			ButtonActions.OnClick += OnClickHandler;
			ClosePopUp();
		}

		private void OnClickHandler(ButtonFunctionName obj)
		{
			ClosePopUp();
		}

		public void TogglePopUp()
		{
			if (PopUpGameObject != null)
			{
				PopUpGameObject.SetActive(!PopUpGameObject.activeSelf);
			}
		}
		
		public void ClosePopUp()
		{
			if (PopUpGameObject != null)
			{
				PopUpGameObject.SetActive(false);
			}
		}

		public void ResetGame()
		{
			ButtonActions.OnClick?.Invoke(ButtonFunctionName.ForceReset);
			ClosePopUp();
		}

		private void OnDestroy()
		{
			ButtonActions.OnClick -= OnClickHandler;
		}
	}
}