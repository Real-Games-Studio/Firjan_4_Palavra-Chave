using System;
using System.Collections;
using System.Collections.Generic;
using _1._Project.Scripts.Button;
using _1._Project.Scripts.GameModels;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace _1._Project.Scripts.GameMechanics
{
	public class GameController : MonoBehaviour
	{
		[FormerlySerializedAs("BlueSide")] public SideController BoardSide;

		public WordsModel Group1Words;
		public WordsModel Group2Words;
		public WordsModel Group3Words;
		public WordsModel Group4Words;
		public WordsModel Group5Words;
		public WordsModel Group6Words;
		public WordsModel Group7Words;
		private WordsModel _currentWordsModel;
		public bool IsFinished;

		public int RightCount;
		public int WrongCount;
		public int AtualBoard;

		public float TimeToReset = 3f;
		public TextMeshProUGUI CountText;
		public FinalPoints FinalPoints;
		private void Awake()
		{
			FillLists();
			BoardSide.SetGameController(this);
		}

		public void RightWords()
		{
			RightCount++;
			StartCoroutine(WaitToResetWon());
		}

		public void WrongWords()
		{
			WrongCount++;
			StartCoroutine(WaitToResetLose());
		}

		private void FixedUpdate()
		{
			switch (AtualBoard)
			{
				case 1:
					CountText.text = $"Tema: {Group1Words.Category} \nAcertos: {RightCount}  Erros: {WrongCount}";
					break;
				case 2:
					CountText.text = $"Tema: {Group2Words.Category} \nAcertos: {RightCount}  Erros: {WrongCount}";
					break;
				case 3:
					CountText.text = $"Tema: {Group3Words.Category} \nAcertos: {RightCount}  Erros: {WrongCount}";
					break;
			}
		}

		IEnumerator WaitToResetWon()
		{
			BoardSide.LockSide();
			yield return new WaitForSeconds(TimeToReset);
			
			BoardSide.ResetSide();
			FillNextBoard();
		}
		IEnumerator WaitToResetLose()
		{
			BoardSide.LockSide();
			yield return new WaitForSeconds(TimeToReset);
			
			BoardSide.ResetSide();
			if (WrongCount>=3)
			{
				FillNextBoard();
			}
			
		}
		public void CheckIfFinished()
		{
			if(BoardSide.IsFinished())
			{
				IsFinished = true;
				switch (AtualBoard)
				{
					case 1:
						BoardSide.ShowFinalResult(Group1Words.Words);
						break;
					case 2:
						BoardSide.ShowFinalResult(Group2Words.Words);
						break;
					case 3:
						BoardSide.ShowFinalResult(Group3Words.Words);
						break;
				}
			}
			else
			{
				IsFinished = false;
			}
		}

		private void FillLists()
		{
			Group1Words = JsonSystem.JsonModel.WordsGroup1;
			Group2Words = JsonSystem.JsonModel.WordsGroup2;
			Group3Words = JsonSystem.JsonModel.WordsGroup3;
			Group4Words = JsonSystem.JsonModel.WordsGroup4;
			Group5Words = JsonSystem.JsonModel.WordsGroup5;
			Group6Words = JsonSystem.JsonModel.WordsGroup6;
			Group7Words = JsonSystem.JsonModel.WordsGroup7;
		}
		
		public void FillNextBoard()
		{
			WrongCount = 0;
			switch (AtualBoard)
			{
				case 1:
					FillBoard2();
					break;
				case 2:
					FillBoard3();
					break;
				case 3:
					GameOver();
					break;
			}
		}

		private void GameOver()
		{
			ButtonActions.OnClick?.Invoke(ButtonFunctionName.EndGame);
			FinalPoints.SendPointsToServer(RightCount);
		}

		public void FillBoard1()
		{
			RightCount = 0;
			WrongCount = 0;
			AtualBoard = 1;
			var allWords = new List<string>();
			allWords.AddRange(Group1Words.Words);
			allWords.Add(Group2Words.Words[0]);
			allWords.Add(Group2Words.Words[1]);
			allWords.Add(Group3Words.Words[0]);
			allWords.Add(Group3Words.Words[1]);
			allWords.Add(Group4Words.Words[0]);
			allWords.Add(Group4Words.Words[1]);
			allWords.Add(Group5Words.Words[0]);
			allWords.Add(Group5Words.Words[1]);
			allWords.Add(Group6Words.Words[0]);
			allWords.Add(Group6Words.Words[1]);
			allWords.Add(Group7Words.Words[0]);
			allWords.Add(Group7Words.Words[1]);
			allWords.Shuffle();
			BoardSide.SetUpSideWords(allWords);
		}
		public void FillBoard2()
		{
			AtualBoard = 2;
			var allWords = new List<string>();
			allWords.AddRange(Group2Words.Words);
			allWords.Add(Group3Words.Words[0]);
			allWords.Add(Group3Words.Words[1]);
			allWords.Add(Group4Words.Words[1]);
			allWords.Add(Group5Words.Words[0]);
			allWords.Add(Group1Words.Words[0]);
			allWords.Add(Group4Words.Words[0]);
			allWords.Add(Group6Words.Words[1]);
			allWords.Add(Group7Words.Words[1]);
			allWords.Add(Group5Words.Words[1]);
			allWords.Add(Group6Words.Words[0]);
			allWords.Add(Group7Words.Words[0]);
			allWords.Add(Group1Words.Words[1]);
			allWords.Shuffle();
			BoardSide.SetUpSideWords(allWords);
		}
		public void FillBoard3()
		{
			AtualBoard = 3;
			var allWords = new List<string>();
			allWords.AddRange(Group3Words.Words);
			allWords.Add(Group2Words.Words[0]);
			allWords.Add(Group2Words.Words[1]);
			allWords.Add(Group4Words.Words[1]);
			allWords.Add(Group5Words.Words[0]);
			allWords.Add(Group1Words.Words[0]);
			allWords.Add(Group4Words.Words[0]);
			allWords.Add(Group6Words.Words[1]);
			allWords.Add(Group7Words.Words[1]);
			allWords.Add(Group5Words.Words[1]);
			allWords.Add(Group6Words.Words[0]);
			allWords.Add(Group7Words.Words[0]);
			allWords.Add(Group1Words.Words[1]);
			allWords.Shuffle();
			BoardSide.SetUpSideWords(allWords);
		}
		
	}
}