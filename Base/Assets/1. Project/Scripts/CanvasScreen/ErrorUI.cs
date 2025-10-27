using System;
using System.Collections.Generic;
using UnityEngine;

namespace _1._Project.Scripts.CanvasScreen
{
	public class ErrorUI : MonoBehaviour
	{
		private List<GameObject> _errors;


		private void Awake()
		{
			FillErrors();
		}

		public void ResetErrors()
		{
			for (int i = 0; i < _errors.Count; i++)
			{
				_errors[i].SetActive(false);
			}
		}

		public void TurnOnError(int errorCount)
		{
			_errors[errorCount-1].SetActive(true);
		}

		private void FillErrors()
		{
			_errors = new List<GameObject>();
			var list = GetComponentsInChildren<Transform>();
			for (int i = 0; i < list.Length; i++)
			{
				if (list[i].gameObject != this.gameObject)
				{
					_errors.Add(list[i].gameObject);
				}
			}
		}
	}
}