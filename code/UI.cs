using Sandbox;
using Sandbox.UI;

namespace MultilineTest
{
	public partial class UI : Sandbox.HudEntity<RootPanel>
	{
		public UI()
		{
			if ( !Host.IsClient ) return;

			RootPanel.StyleSheet.Load( "UI.scss" );
			var textbox = RootPanel.AddChild<MultilineTextBox>( "textbox" );
			var output = RootPanel.AddChild<OutputPanel>( "output" );
			textbox.SubmitListeners += output.AddEntry;
		}
	}
}
