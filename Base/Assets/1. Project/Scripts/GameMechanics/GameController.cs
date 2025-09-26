using System;
using System.Collections;
using System.Collections.Generic;
using _1._Project.Scripts.Button;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace _1._Project.Scripts.GameMechanics
{
	public class GameController : MonoBehaviour
	{
		[FormerlySerializedAs("BlueSide")] public SideController BoardSide;

		public List<string> Group1Words;
		public List<string> Group2Words;
		public List<string> Group3Words;
		public List<string> Group4Words;
		public List<string> Group5Words;
		public List<string> Group6Words;
		public List<string> Group7Words;
		public bool IsFinished;

		public int RightCount;
		public int WrongCount;
		public int AtualBoard;

		public float TimeToReset = 3f;
		public TextMeshProUGUI CountText;
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
			CountText.text = $"Acertos: {RightCount}  Erros: {WrongCount}";
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
						BoardSide.ShowFinalResult(Group1Words);
						break;
					case 2:
						BoardSide.ShowFinalResult(Group2Words);
						break;
					case 3:
						BoardSide.ShowFinalResult(Group3Words);
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
			Group1Words = JsonSystem.JsonModel.wordsModel.Group1;
			Group2Words = JsonSystem.JsonModel.wordsModel.Group2;
			Group3Words = JsonSystem.JsonModel.wordsModel.Group3;
			Group4Words = JsonSystem.JsonModel.wordsModel.Group4;
			Group5Words = JsonSystem.JsonModel.wordsModel.Group5;
			Group6Words = JsonSystem.JsonModel.wordsModel.Group6;
			Group7Words = JsonSystem.JsonModel.wordsModel.Group7;
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
		}

		public void FillBoard1()
		{
			RightCount = 0;
			WrongCount = 0;
			AtualBoard = 1;
			var allWords = new List<string>();
			allWords.AddRange(Group1Words);
			allWords.Add(Group2Words[0]);
			allWords.Add(Group2Words[1]);
			allWords.Add(Group3Words[0]);
			allWords.Add(Group3Words[1]);
			allWords.Add(Group4Words[0]);
			allWords.Add(Group4Words[1]);
			allWords.Add(Group5Words[0]);
			allWords.Add(Group5Words[1]);
			allWords.Add(Group6Words[0]);
			allWords.Add(Group6Words[1]);
			allWords.Add(Group7Words[0]);
			allWords.Add(Group7Words[1]);
			allWords.Shuffle();
			BoardSide.SetUpSideWords(allWords);
		}
		public void FillBoard2()
		{
			AtualBoard = 2;
			var allWords = new List<string>();
			allWords.AddRange(Group2Words);
			allWords.Add(Group3Words[0]);
			allWords.Add(Group3Words[1]);
			allWords.Add(Group4Words[1]);
			allWords.Add(Group5Words[0]);
			allWords.Add(Group1Words[0]);
			allWords.Add(Group4Words[0]);
			allWords.Add(Group6Words[1]);
			allWords.Add(Group7Words[1]);
			allWords.Add(Group5Words[1]);
			allWords.Add(Group6Words[0]);
			allWords.Add(Group7Words[0]);
			allWords.Add(Group1Words[1]);
			allWords.Shuffle();
			BoardSide.SetUpSideWords(allWords);
		}
		public void FillBoard3()
		{
			AtualBoard = 3;
			var allWords = new List<string>();
			allWords.AddRange(Group3Words);
			allWords.Add(Group2Words[0]);
			allWords.Add(Group2Words[1]);
			allWords.Add(Group4Words[1]);
			allWords.Add(Group5Words[0]);
			allWords.Add(Group1Words[0]);
			allWords.Add(Group4Words[0]);
			allWords.Add(Group6Words[1]);
			allWords.Add(Group7Words[1]);
			allWords.Add(Group5Words[1]);
			allWords.Add(Group6Words[0]);
			allWords.Add(Group7Words[0]);
			allWords.Add(Group1Words[1]);
			allWords.Shuffle();
			BoardSide.SetUpSideWords(allWords);
		}
		
	}
}