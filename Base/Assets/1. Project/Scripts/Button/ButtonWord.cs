using System;
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
		public Color BorderRight;
		public Color BorderWrong;
		public Color BorderDefault;
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
			_borderRawImage = GetComponentsInChildren<RawImage>()[1];
			BorderDefault = GetComponent<RawImage>().color;
			_gORectTransform = GetComponent<RectTransform>();
			_tMPRectTransform = _tmpGui.GetComponent<RectTransform>();
			base.SetUp();
		}

		public void Select(bool isRight)
		{
			if (isRight)
			{
				_borderRawImage.color = BorderRight;
				IsRight = isRight;
			}
			else
			{
				IsRight = isRight;
				_borderRawImage.color = BorderWrong;
			}
			
			IsSelected = true;
		}

		public void Deselect()
		{
			IsSelected = false;
			IsRight = false;
			_borderRawImage.color = BorderDefault;
		}
		
		public void SetWordText(string wordText)
		{
			WordText = wordText;
			_tmpGui.text = WordText;
		}
		public void SetUpGO()
		{
			_borderRawImage.color = BorderDefault;
			
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