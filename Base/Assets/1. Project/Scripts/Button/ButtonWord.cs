using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _1._Project.Scripts.Button
{
	public class ButtonWord : ButtonFunctionBase
	{
		public string WordText;
		[SerializeField] private TextMeshProUGUI _tmpGui;
		private RectTransform _gORectTransform;
		private RectTransform _tMPRectTransform;
		public bool IsSelected = false;
		public bool IsRight;
		public Texture2D BorderRight;
		public Texture2D BorderWrong;
		public Texture2D BorderDefault;
		public Texture2D BorderSelected;
		private RawImage _borderRawImage;
		private void OnValidate()
		{
			_tmpGui = GetComponentInChildren<TextMeshProUGUI>();
			if (_tmpGui == null)
			{
				Debug.LogError($"{gameObject.name}: ButtonWord.OnValidate(): No TextMeshProUGUI attached.");
			}
		}

		private void Start()
		{
			SetUp();
		}

		public override void SetUp()
		{
			_borderRawImage = GetComponent<RawImage>();
			_gORectTransform = GetComponent<RectTransform>();
			_tMPRectTransform = _tmpGui.GetComponent<RectTransform>();
			base.SetUp();
		}
		
		public void Lock()
		{
			GetComponent<UnityEngine.UI.Button>().interactable = false;
		}

		public void Unlock()
		{
			GetComponent<UnityEngine.UI.Button>().interactable = true;
		}

		public void Select()
		{
			IsSelected = true;
			_borderRawImage.texture = BorderSelected;
		}

		public void CheckWord(List<string> rightWords)
		{
			
			if (rightWords.Contains(WordText))
			{
				_borderRawImage.texture = BorderRight;
				IsRight = true;
			}
			else
			{
				IsRight = false;
				_borderRawImage.texture = BorderWrong;
			}
		}

		public void Deselect()
		{
			IsSelected = false;
			IsRight = false;
			_borderRawImage.texture = BorderDefault;
		}
		
		public void SetWordText(string wordText)
		{
			IsRight = false;
			WordText = wordText;
			_tmpGui.text = WordText;
		}
		public void SetUpGO()
		{
			_borderRawImage.texture = BorderDefault;
			
			SetTMPSize();
		}

		public override void OnClick()
		{
			ButtonActions.OnClickWord?.Invoke(this);
		}
		private void SetTMPSize()
		{
			_tMPRectTransform.sizeDelta = _gORectTransform.sizeDelta;
		}
		
	}
}