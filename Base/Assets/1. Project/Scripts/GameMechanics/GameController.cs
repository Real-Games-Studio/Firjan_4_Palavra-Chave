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
		public int LevelCount;

		public float TimeToReset = 3f;
		public TextMeshProUGUI CountText;
		public FinalPoints FinalPoints;
		private List<int> _availableBoards = new List<int>{1,2,3,4,5,6,7};
		private List<int> _allBoards = new List<int>{1,2,3,4,5,6,7};
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
				case 4:
					CountText.text = $"Tema: {Group4Words.Category} \nAcertos: {RightCount}  Erros: {WrongCount}";
					break;
				case 5:
					CountText.text = $"Tema: {Group5Words.Category} \nAcertos: {RightCount}  Erros: {WrongCount}";
					break;
				case 6:
					CountText.text = $"Tema: {Group6Words.Category} \nAcertos: {RightCount}  Erros: {WrongCount}";
					break;
				case 7:
					CountText.text = $"Tema: {Group7Words.Category} \nAcertos: {RightCount}  Erros: {WrongCount}";
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
					case 4:
						BoardSide.ShowFinalResult(Group4Words.Words);
						break;
					case 5:
						BoardSide.ShowFinalResult(Group5Words.Words);
						break;
					case 6:
						BoardSide.ShowFinalResult(Group6Words.Words);
						break;
					case 7:
						BoardSide.ShowFinalResult(Group7Words.Words);
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

		public void FillFirstBoard()
		{
			RightCount = 0;
			WrongCount = 0;
			LevelCount = 0;
			_availableBoards.Clear();
			_availableBoards.AddRange(_allBoards);
			GetRandomBoard();
		}
		public void FillNextBoard()
		{
			WrongCount = 0;
			LevelCount++;
			switch (LevelCount)
			{
				case 1:
					GetRandomBoard();
					break;
				case 2:
					GetRandomBoard();
					break;
				case 3:
					GameOver();
					break;
			}
		}

		private void GetRandomBoard()
		{
			_availableBoards.Shuffle();
			int nextBoard = _availableBoards[0];
			switch (nextBoard)
			{
				case 1:
					FillBoard1();
					break;
				case 2:
					FillBoard2();
					break;
				case 3:
					FillBoard3();
					break;
				case 4:
					FillBoard4();
					break;
				case 5:
					FillBoard5();
					break;
				case 6:
					FillBoard6();
					break;
				case 7:
					FillBoard7();
					break;
			}
			_availableBoards.Remove(nextBoard);
		}
		private void GameOver()
		{
			ButtonActions.OnClick?.Invoke(ButtonFunctionName.EndGame);
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
		public void FillBoard4()
		{
			AtualBoard = 4;
			var allWords = new List<string>();
			allWords.AddRange(Group4Words.Words);
			allWords.Add(Group2Words.Words[0]);
			allWords.Add(Group2Words.Words[1]);
			allWords.Add(Group3Words.Words[1]);
			allWords.Add(Group5Words.Words[0]);
			allWords.Add(Group1Words.Words[0]);
			allWords.Add(Group3Words.Words[0]);
			allWords.Add(Group6Words.Words[1]);
			allWords.Add(Group7Words.Words[1]);
			allWords.Add(Group5Words.Words[1]);
			allWords.Add(Group6Words.Words[0]);
			allWords.Add(Group7Words.Words[0]);
			allWords.Add(Group1Words.Words[1]);
			allWords.Shuffle();
			BoardSide.SetUpSideWords(allWords);
		}
		
		public void FillBoard5()
		{
			AtualBoard = 5;
			var allWords = new List<string>();
			allWords.AddRange(Group5Words.Words);
			allWords.Add(Group2Words.Words[0]);
			allWords.Add(Group2Words.Words[1]);
			allWords.Add(Group4Words.Words[1]);
			allWords.Add(Group3Words.Words[0]);
			allWords.Add(Group1Words.Words[0]);
			allWords.Add(Group4Words.Words[0]);
			allWords.Add(Group6Words.Words[1]);
			allWords.Add(Group7Words.Words[1]);
			allWords.Add(Group3Words.Words[1]);
			allWords.Add(Group6Words.Words[0]);
			allWords.Add(Group7Words.Words[0]);
			allWords.Add(Group1Words.Words[1]);
			allWords.Shuffle();
			BoardSide.SetUpSideWords(allWords);
		}
		
		public void FillBoard6()
		{
			AtualBoard = 6;
			var allWords = new List<string>();
			allWords.AddRange(Group6Words.Words);
			allWords.Add(Group2Words.Words[0]);
			allWords.Add(Group2Words.Words[1]);
			allWords.Add(Group4Words.Words[1]);
			allWords.Add(Group5Words.Words[0]);
			allWords.Add(Group1Words.Words[0]);
			allWords.Add(Group4Words.Words[0]);
			allWords.Add(Group3Words.Words[1]);
			allWords.Add(Group7Words.Words[1]);
			allWords.Add(Group5Words.Words[1]);
			allWords.Add(Group3Words.Words[0]);
			allWords.Add(Group7Words.Words[0]);
			allWords.Add(Group1Words.Words[1]);
			allWords.Shuffle();
			BoardSide.SetUpSideWords(allWords);
		}
		public void FillBoard7()
		{
			AtualBoard = 7;
			var allWords = new List<string>();
			allWords.AddRange(Group7Words.Words);
			allWords.Add(Group2Words.Words[0]);
			allWords.Add(Group2Words.Words[1]);
			allWords.Add(Group4Words.Words[1]);
			allWords.Add(Group5Words.Words[0]);
			allWords.Add(Group1Words.Words[0]);
			allWords.Add(Group4Words.Words[0]);
			allWords.Add(Group6Words.Words[1]);
			allWords.Add(Group3Words.Words[1]);
			allWords.Add(Group5Words.Words[1]);
			allWords.Add(Group6Words.Words[0]);
			allWords.Add(Group3Words.Words[0]);
			allWords.Add(Group1Words.Words[1]);
			allWords.Shuffle();
			BoardSide.SetUpSideWords(allWords);
		}
		
	}
}