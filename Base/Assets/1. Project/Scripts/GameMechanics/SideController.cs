using System;
using System.Collections.Generic;
using _1._Project.Scripts.Button;
using UnityEngine;

namespace _1._Project.Scripts.GameMechanics
{
	public class SideController : MonoBehaviour
	{
		private GameController _gameController;
		public List<ButtonWord> WordButtons;
		public List<ButtonWord> SelectedButtonWords;
		public int MaxSelectCount = 4;
		public int SelectCount;
		private void Awake()
		{
			ButtonActions.OnClickWord += OnClickWordHandler;
		}

		public void SetGameController(GameController gameController)
		{
			_gameController = gameController;
		}

		public bool IsFinished()
		{
			return SelectedButtonWords.Count == MaxSelectCount;
		}
		private void OnClickWordHandler(ButtonWord arg1)
		{
			if (!WordButtons.Contains(arg1))
				return;

			if (arg1.IsSelected)
			{
				arg1.Deselect();
				SelectedButtonWords.Remove(arg1);
				SelectCount--;
				return;
			}
			
			SelectedButtonWords.Add(arg1);
			SelectCount++;
			arg1.Select();
			_gameController.CheckIfFinished();

		}

		public void LockSide()
		{
			foreach (ButtonWord word in WordButtons)
			{
				word.Lock();
			}
		}
		public void UnlockSide()
		{
			foreach (ButtonWord word in WordButtons)
			{
				word.Unlock();
			}
		}
		public void ShowFinalResult(List<string> rightWords)
		{
			bool allRight = true;

			for (int i = 0; i < SelectedButtonWords.Count; i++)
			{
				SelectedButtonWords[i].CheckWord(rightWords);
				if (!SelectedButtonWords[i].IsRight)
				{
					allRight = false;
				}
			}
			if (allRight)
			{
				_gameController.RightWords();
			}
			else
			{
				_gameController.WrongWords();
			}
		}

		public void ResetSide()
		{
			foreach (ButtonWord word in WordButtons)
			{
				word.Deselect();
			}
			SelectedButtonWords.Clear();
			SelectCount = 0;
			UnlockSide();
		}
		public void TurnOn()
		{
			foreach (ButtonWord word in WordButtons)
			{
				word.SetUpGO();
			}
		}
		
		public void SetUpSideWords(List<string> words)
		{
			for (int i = 0; i < words.Count; i++)
			{
				WordButtons[i].SetWordText(words[i]);
			}
			TurnOn();
		}
	}
}