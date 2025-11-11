using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _1._Project.Scripts.CanvasScreen
{
	public class ErrorUI : MonoBehaviour
	{
		private List<RawImage> _errors;
		public Color32 FillColor;
		public Color32 EmptyColor;

		private void Awake()
		{
			FillErrors();
		}

		public void ResetErrors()
		{
			for (int i = 0; i < _errors.Count; i++)
			{
				_errors[i].color = EmptyColor;
			}
		}

		public void TurnOnError(int errorCount)
		{
			_errors[errorCount-1].color = FillColor;
		}

		private void FillErrors()
		{
			_errors = new List<RawImage>();
			var list = GetComponentsInChildren<RawImage>();
			for (int i = 0; i < list.Length; i++)
			{
				if (list[i].gameObject != this.gameObject)
				{
					_errors.Add(list[i]);
				}
			}
		}
	}
}