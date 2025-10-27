 using _1._Project.Scripts.GameMechanics;
 using UnityEngine.Serialization;

 namespace _1._Project.Scripts.CanvasScreen
{
	public class GameCanvasScreen : global::CanvasScreen
	{
		[FormerlySerializedAs("GameController")] public GameController_Old GameControllerOld;
		public GameController GameController;
		public int Lang;

		public override void TurnOn()
		{
			GameController.StartGame(Lang);
			//GameControllerOld.FillFirstBoard(Lang);
			base.TurnOn();
		}
	}
}