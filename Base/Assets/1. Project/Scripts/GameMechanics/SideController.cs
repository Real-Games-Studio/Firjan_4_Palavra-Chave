using System;
using System.Collections;
using System.Collections.Generic;
using _1._Project.Scripts.Button;
using _1._Project.Scripts.GameModels;
using UnityEngine;

namespace _1._Project.Scripts.GameMechanics
{
	public class SideController : MonoBehaviour
	{
		//private GameController_Old _gameControllerOld;
		public GameController _gameController;
		public List<ButtonWord> WordButtons;
		public List<ButtonWord> SelectedButtonWords;
		public int MaxSelectCount = 4;
		public int SelectCount;

		public Color Group1Color;
		public Color Group2Color;
		public Color Group3Color;
		public Color Group4Color;
		private void Awake()
		{
			ButtonActions.OnClickWord += OnClickWordHandler;
		}

		public void SetGameController(GameController_Old gameControllerOld)
		{
			//_gameControllerOld = gameControllerOld;
		}

		public bool IsSelectedSameGroup()
		{
			int i =0;
			foreach (ButtonWord word in SelectedButtonWords)
			{
				if (i== 0)
				{
					i = word.GroupId;
				}
				else
				{
					if (i!= word.GroupId)
					{
						return false;
					}
				}
			}
			return true;
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
			//_gameControllerOld.CheckIfFinished();
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
				//_gameControllerOld.RightWords();
			}
			else
			{
				//_gameControllerOld.WrongWords();
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

		public void ShowRight()
		{
			foreach (var buttonWord in  SelectedButtonWords)
			{
				buttonWord.ShowRight();
			}
			
			SelectedButtonWords.Clear();
			StartCoroutine(ShowFeedBack());
			
		}

		public void ShowWrong()
		{
			foreach (var buttonWord in  SelectedButtonWords)
			{
				buttonWord.ShowWrong();
			}
			
			SelectedButtonWords.Clear();
			StartCoroutine(ShowFeedBack());
		}

		private IEnumerator ShowFeedBack()
		{
			for (int i = 0; i < WordButtons.Count; i++)
			{
				WordButtons[i].Lock();
			}
			yield return new WaitForSecondsRealtime(1f);
			for (int i = 0; i < WordButtons.Count; i++)
			{
				if (!WordButtons[i].IsRight)
				{
					WordButtons[i].Unlock();
				}
			}
		}

		public void ShowAllGroups()
		{
			for (int i = 0; i < WordButtons.Count; i++)
			{
				WordButtons[i].ShowFinalLost();
			}
		}
		public void SetUpSideWordsAndGroup(List<WordAndGroupModel> wordsAndGroups)
		{
			for (int i = 0; i < wordsAndGroups.Count; i++)
			{
				WordButtons[i].SetWordText(wordsAndGroups[i].Word);
				WordButtons[i].GroupId = wordsAndGroups[i].Group;
				switch (wordsAndGroups[i].Group)
				{
					case 1:
						WordButtons[i].BorderGroup = Group1Color;
						break;
					case 2:
						WordButtons[i].BorderGroup = Group2Color;
						break;
					case 3:
						WordButtons[i].BorderGroup = Group3Color;
						break;
					case 4:
						WordButtons[i].BorderGroup = Group4Color;
						break;
				}
			}
			TurnOn();
		}	}
}