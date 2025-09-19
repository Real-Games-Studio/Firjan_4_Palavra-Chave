using System;
using System.Collections.Generic;
using UnityEngine;

namespace _1._Project.Scripts.GameMechanics
{
	public class GameController : MonoBehaviour
	{
		public SideController BlueSide;
		public SideController RedSide;

		public List<string> RedWallWords;
		public List<string> BlueWallWords;
		public List<string> RandomWords;
		public List<string> RightWordsRed;
		public List<string> RightWordsBlue;
		public bool IsFinished;
		private void Awake()
		{
			FillLists();
			BlueSide.SetGameController(this);
			RedSide.SetGameController(this);
		}

		public void CheckIfFinished()
		{
			if (RedSide.ButtonSelected1 != null 
			    && BlueSide.ButtonSelected1 != null
			    && RedSide.ButtonSelected2 != null 
			    && BlueSide.ButtonSelected2 != null)
			{
				IsFinished = true;
			}
			else
			{
				IsFinished = false;
			}
		}

		public bool CheckIfWordIsRight(SideController side, string word)
		{
			if (side == RedSide)
			{
				return RightWordsRed.Contains(word);
			}
			else
			{
				return RightWordsBlue.Contains(word);
			}
		}
		private void FillLists()
		{
			RedWallWords = JsonSystem.JsonModel.wordsModel.CorrectWordsRed;
			BlueWallWords = JsonSystem.JsonModel.wordsModel.CorrectWordsBlue;
			RandomWords = JsonSystem.JsonModel.wordsModel.AllWords;
		}
		public void GetWordsToSides()
		{
			List<string> wordsToSideRed = new List<string>();
			List<string> wordsToSideBlue = new List<string>();
			for (int i = 0; i < 8; i++)
			{
				wordsToSideRed.Add(RandomWords[i]);
				wordsToSideBlue.Add(RandomWords[i+8]);
			}

			for (int i = 0; i < 2; i++)
			{
				wordsToSideRed.Add(RedWallWords[i]);
				RightWordsRed.Add(RedWallWords[i]);
				RightWordsBlue.Add(BlueWallWords[i]);
				wordsToSideBlue.Add(BlueWallWords[i]);
			}
			
			BlueSide.SetUpSideWords(wordsToSideBlue);
			RedSide.SetUpSideWords(wordsToSideRed);
		}
	}
}