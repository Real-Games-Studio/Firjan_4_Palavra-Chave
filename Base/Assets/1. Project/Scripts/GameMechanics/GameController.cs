using System;
using System.Collections;
using System.Collections.Generic;
using _1._Project.Scripts.Button;
using _1._Project.Scripts.CanvasScreen;
using _1._Project.Scripts.GameModels;
using TMPro;
using UnityEngine;

namespace _1._Project.Scripts.GameMechanics
{
	public class GameController : MonoBehaviour
	{
		public ErrorUI ErrorUI;
		public WordsModel WordsGroup1;
		public WordsModel WordsGroup2;
		public WordsModel WordsGroup3;
		public WordsModel WordsGroup4;
		
		public SideController SideController;
		public FinalPoints FinalPoints;
		
		public bool IsFinished;

		public int RightCount;
		public int WrongCount;

		private float _timeToReset = 3f;
		private int _currentLang;

		private void Awake()
		{
			FillLists();
		}

		public void StartGame(int lang)
		{
			_currentLang = lang;
			ResetCounters();
			FillBoard();
		}

		public void CheckIfFinished()
		{
			if (SideController.IsFinished())
			{
				IsFinished = true;
				if (SideController.IsSelectedSameGroup())
				{
					RightCount += 1;
					SideController.ShowRight();
				}
				else
				{
					WrongCount += 1;
					SideController.ShowWrong();
					ErrorUI.TurnOnError(WrongCount);
				}
			}

			if (WrongCount>=3)
			{
				StartCoroutine(ShowLostFeedBackAndOver());
			}

			if (RightCount >=4)
			{
				StartCoroutine(ShowWonFeedBackAndOver());
			}
		}

		private IEnumerator ShowWonFeedBackAndOver()
		{
			yield return new WaitForSecondsRealtime(5f);
			ButtonActions.OnClick?.Invoke(ButtonFunctionName.EndGame);
		}

		private IEnumerator ShowLostFeedBackAndOver()
		{
			yield return new WaitForSecondsRealtime(1.1f);
			SideController.ShowAllGroups();
			yield return new WaitForSecondsRealtime(5f);
			ButtonActions.OnClick?.Invoke(ButtonFunctionName.EndGame);
		}

		private void ResetCounters()
		{
			RightCount = 0;
			WrongCount = 0;
			ErrorUI.ResetErrors();
		}
		private void FillLists()
		{
			
			if (_currentLang ==0)
			{
				WordsGroup1 = JsonSystem.Instance.JsonModel.WordsPT.WordsGroup1;
				WordsGroup2 = JsonSystem.Instance.JsonModel.WordsPT.WordsGroup2;
				WordsGroup3 = JsonSystem.Instance.JsonModel.WordsPT.WordsGroup3;
				WordsGroup4 = JsonSystem.Instance.JsonModel.WordsPT.WordsGroup4;
			}

			if (_currentLang == 1)
			{
				WordsGroup1 = JsonSystem.Instance.JsonModel.WordsEN.WordsGroup1;
				WordsGroup2 = JsonSystem.Instance.JsonModel.WordsEN.WordsGroup2;
				WordsGroup3 = JsonSystem.Instance.JsonModel.WordsEN.WordsGroup3;
				WordsGroup4 = JsonSystem.Instance.JsonModel.WordsEN.WordsGroup4;
			}
		}


		private void FillBoard()
		{
			var AllWords = new List<WordAndGroupModel>();
			for (int i = 0; i < WordsGroup1.Words.Count; i++)
			{
				AllWords.Add(new WordAndGroupModel(){Word = WordsGroup1.Words[i],  Group = 1});
			}
			for (int i = 0; i < WordsGroup2.Words.Count; i++)
			{
				AllWords.Add(new WordAndGroupModel(){Word = WordsGroup2.Words[i],  Group = 2});
			}
			for (int i = 0; i < WordsGroup3.Words.Count; i++)
			{
				AllWords.Add(new WordAndGroupModel(){Word = WordsGroup3.Words[i],  Group = 3});
			}
			for (int i = 0; i < WordsGroup4.Words.Count; i++)
			{
				AllWords.Add(new WordAndGroupModel(){Word = WordsGroup4.Words[i],  Group = 4});
			}
			AllWords.Shuffle();
			SideController.SetUpSideWordsAndGroup(AllWords);
		}
		
	}
}