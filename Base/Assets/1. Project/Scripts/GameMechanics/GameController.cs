using System;
using System.Collections;
using System.Collections.Generic;
using _1._Project.Scripts.Button;
using _1._Project.Scripts.CanvasScreen;
using _1._Project.Scripts.GameModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

		public List<GameObject> WinWords;
		public List<GameObject> LoseWords;
		public bool IsFinished;

		public int RightCount;
		public int WrongCount;

		private float _timeToReset = 3f;
		private int _currentLang;


		public int _gameTime = 40;
		private float _currentGameTime;
		private bool _isPlaying;

		public Image SliderTimeBar;
		public TextMeshProUGUI TextTime;
		public AudioSource AudioSource;
		public AudioClip AudioWinClip;
		public AudioClip AudioLoseClip;
		private void Awake()
		{
			FillLists();
		}

		public void StartGame(int lang)
		{
			_currentLang = lang;
			FillLists();
			FillBoard();
			ResetCounters();
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
				_isPlaying = false;
				StartCoroutine(ShowLostFeedBackAndOver());
			}

			if (RightCount >=4)
			{
				_isPlaying = false;
				StartCoroutine(ShowWonFeedBackAndOver());
			}
		}

		private void Update()
		{
			if (_isPlaying)
			{
				if (_currentGameTime > _gameTime)
				{
					GameOverTimeOut();
				}
				else
				{
					SliderTimeBar.fillAmount = 1 - (_currentGameTime / _gameTime);
					TextTime.text = Mathf.CeilToInt(_gameTime - _currentGameTime).ToString();
					_currentGameTime += Time.deltaTime;
				}
			}
		}

		private void GameOverTimeOut()
		{
			_isPlaying = false;
			SideController.LockSide();
			StartCoroutine(ShowLostFeedBackAndOver());
		}

		private IEnumerator ShowWonFeedBackAndOver()
		{
			AudioSource.clip = AudioWinClip;
			AudioSource.Play();
			foreach (var winWord in WinWords)
			{
				winWord.SetActive(true);
			}

			foreach (var loseWord in LoseWords)
			{
				loseWord.SetActive(false);
			}
			yield return new WaitForSecondsRealtime(3f);
			ButtonActions.OnClick?.Invoke(ButtonFunctionName.EndGame);
		}

		private IEnumerator ShowLostFeedBackAndOver()
		{
			AudioSource.clip = AudioLoseClip;
			AudioSource.Play();
			foreach (var winWord in WinWords)
			{
				winWord.SetActive(false);
			}

			foreach (var loseWord in LoseWords)
			{
				loseWord.SetActive(true);
			}
			yield return new WaitForSecondsRealtime(1.1f);
			SideController.ShowAllGroups();
			yield return new WaitForSecondsRealtime(3f);
			ButtonActions.OnClick?.Invoke(ButtonFunctionName.EndGame);
		}

		private void ResetCounters()
		{
			RightCount = 0;
			WrongCount = 0;
			SideController.ResetSide();
			ErrorUI.ResetErrors();
			_isPlaying = true;
			_currentGameTime = 0;
			_gameTime = JsonSystem.Instance.JsonModel.TotalGameplayTime;
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