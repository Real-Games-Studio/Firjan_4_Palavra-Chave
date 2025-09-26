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
		public ButtonWord ButtonSelected1;
		public ButtonWord ButtonSelected2;
		public ButtonWord ButtonSelected3;
		public ButtonWord ButtonSelected4;
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
			return ButtonSelected1 != null && ButtonSelected2 != null && ButtonSelected3 != null && ButtonSelected4 != null;
		}
		private void OnClickWordHandler(ButtonWord arg1)
		{
			if (!WordButtons.Contains(arg1))
				return;

			if (arg1.IsSelected)
				return;
			
			switch (SelectCount)
			{
				case 0:
					if (ButtonSelected1 != null)
					{
						ButtonSelected1.Deselect();
					}
					ButtonSelected1 = arg1;
					SelectCount++;
					break;
				case 1:
					if (ButtonSelected2 != null)
					{
						ButtonSelected2.Deselect();
					}
					ButtonSelected2 = arg1;
					SelectCount =2;
					break;
				case 2:
					if (ButtonSelected3 != null)
					{
						ButtonSelected3.Deselect();
					}
					ButtonSelected3 = arg1;
					SelectCount =3;
					break;
				case 3:
					if (ButtonSelected4 != null)
					{
						ButtonSelected4.Deselect();
					}
					ButtonSelected4 = arg1;
					SelectCount =0;
					break;
			}
			arg1.Select();
			//arg1.Select(_gameController.CheckIfWordIsRight(arg1.WordText));
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
			ButtonSelected1.CheckWord(rightWords);
			ButtonSelected2.CheckWord(rightWords);
			ButtonSelected3.CheckWord(rightWords);
			ButtonSelected4.CheckWord(rightWords);

			if (ButtonSelected1.IsRight && ButtonSelected2.IsRight && ButtonSelected3.IsRight && ButtonSelected4.IsRight)
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
			ButtonSelected1 = null;
			ButtonSelected2 = null;
			ButtonSelected3 = null;
			ButtonSelected4 = null;
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