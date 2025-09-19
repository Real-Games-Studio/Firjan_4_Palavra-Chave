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
		public int SelectCount;
		private void Awake()
		{
			ButtonActions.OnClickWord += OnClickWordHandler;
		}

		public void SetGameController(GameController gameController)
		{
			_gameController = gameController;
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
					SelectCount =0;
					break;
			}

			arg1.Select(_gameController.CheckIfWordIsRight(this,arg1.WordText));
			_gameController.CheckIfFinished();

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