using Sandbox.UI;
using Sandbox.UI.Construct;

namespace MultilineTest
{
	public partial class OutputPanel : Panel
	{
		public Panel Canvas { get; protected set; }
		public Button Clear { get; protected set; }

		public OutputPanel()
		{
			AddChild( new Header( "Output" ) );
			
			Canvas = Add.Panel( "canvas" );
			Canvas.PreferScrollToBottom = true;

			Clear = Add.Button( "Clear" );
			Clear.AddEventListener( "onclick", () => Canvas.DeleteChildren() );
		}

		public void AddEntry( string text )
		{
			Log.Info( text );
			var entry = Canvas.AddChild<OutputEntry>();
			entry.Text.Text = text;
		}
	}

	public partial class OutputEntry : Panel
	{
		public Label Text { get; protected set; }

		public OutputEntry()
		{
			Text = Add.Label();
		}
	}
}
