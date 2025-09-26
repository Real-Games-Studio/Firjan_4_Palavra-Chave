using UnityEngine;

namespace _1._Project.Scripts.Button
{
	[RequireComponent(typeof(UnityEngine.UI.Button))]
	public abstract class ButtonFunctionBase : MonoBehaviour, IButtonFunction
	{
		public ButtonFunctionName ButtonButtonFunction;
		private UnityEngine.UI.Button _button;
		
		
		public virtual void OnClick()
		{
			Debug.Log(ButtonButtonFunction.ToString());
			ButtonActions.OnClick?.Invoke(ButtonButtonFunction);
		}

		public virtual void SetUp()
		{
			_button = GetComponent<UnityEngine.UI.Button>();
			_button.onClick.AddListener(OnClick);
		}
	}


	public enum ButtonFunctionName
	{
		StartGame,
		ChooseWord,
		EndGame,
		RestartGame
	}
}