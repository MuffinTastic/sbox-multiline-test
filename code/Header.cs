using Sandbox.UI;
using Sandbox.UI.Construct;

namespace MultilineTest
{
	public partial class Header : Panel
	{
		public Label Label { get; protected set; }

		public Header( string text )
		{
			Label = Add.Label( text );
		}
	}
}
