using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Collections.Generic;

namespace MultilineTest
{
	public partial class MultilineTextBox : Panel
	{
		public Header Header { get; protected set; }
		public TextEntry Input { get; protected set; }
		public Panel Padding { get; protected set; }
		public Button Submit { get; protected set; }

		public event System.Action<string> SubmitListeners;

		public MultilineTextBox()
		{
			AddChild( new Header( "Multiline Text Entry" ) );

			Input = Add.TextEntry( "" );
			Input.AddEventListener( "onblur", () => Close() );
			Input.AcceptsFocus = true;
			Input.Multiline = true;

			Sandbox.Hooks.Chat.OnOpenChat += Open;

			Submit = Add.Button( "Submit" );
			Submit.AddEventListener( "onclick", () => SubmitText() );
		}

		void Open()
		{
			Input.Focus();
		}

		void Close()
		{
			Input.Blur();
		}

		void SubmitText()
		{
			var txt = Input.Text.Trim();
			Input.Text = "";

			if ( string.IsNullOrWhiteSpace( txt ) )
				return;

			SubmitListeners( txt );
		}
	}
}
