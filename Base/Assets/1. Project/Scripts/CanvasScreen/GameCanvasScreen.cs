using _1._Project.Scripts.GameMechanics;

namespace _1._Project.Scripts.CanvasScreen
{
	public class GameCanvasScreen : global::CanvasScreen
	{
		public GameController GameController;


		public override void TurnOn()
		{
			GameController.FillBoard1();
			base.TurnOn();
		}
	}
}