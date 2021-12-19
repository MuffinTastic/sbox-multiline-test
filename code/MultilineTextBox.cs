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
		public ButtonPanel Buttons { get; protected set; }

		public event System.Action<string> SubmitListeners;

		public MultilineTextBox()
		{
			AddChild( new Header( "Multiline Text Entry" ) );

			Input = Add.TextEntry( "" );
			Input.AddEventListener( "onsubmit", () => Submit() );
			Input.AddEventListener( "onblur", () => Close() );
			Input.AcceptsFocus = true;
			Input.Multiline = true;

			Sandbox.Hooks.Chat.OnOpenChat += Open;

			Buttons = AddChild<ButtonPanel>();
			Buttons.Clear.AddEventListener( "onclick", () => Input.Text = "" );
			Buttons.Submit.AddEventListener( "onclick", () => Submit() );
		}

		void Open()
		{
			Input.Focus();
		}

		void Close()
		{
			Input.Blur();
		}

		void Submit()
		{
			var txt = Input.Text.Trim();
			Input.Text = "";

			if ( string.IsNullOrWhiteSpace( txt ) )
				return;

			SubmitListeners( txt );
		}
	}

	public partial class ButtonPanel : Panel
	{
		public Button Clear { get; protected set; }
		public Button Submit { get; protected set; }

		public ButtonPanel()
		{
			Clear = Add.Button( "Clear" );
			Clear.AddClass( "clear" );
			Submit = Add.Button( "Submit" );
		}
	}
}
