using Sandbox;

namespace MultilineTest
{
	public partial class MultilineTest : Sandbox.Game
	{
		public static UI UI;

		public MultilineTest()
		{
			CreateUI();
		}

		[Event.Hotload]
		public static void CreateUI()
		{
			if ( Host.IsServer )
			{
				if ( UI is not null )
				{
					UI.Delete();
				}

				UI = new UI();
			}
		}
	}
}
