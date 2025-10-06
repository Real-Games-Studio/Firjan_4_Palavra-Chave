 using _1._Project.Scripts.GameMechanics;

namespace _1._Project.Scripts.CanvasScreen
{
	public class GameCanvasScreen : global::CanvasScreen
	{
		public GameController GameController;
		public int Lang;

		public override void TurnOn()
		{
			GameController.FillFirstBoard(Lang);
			base.TurnOn();
		}
	}
}