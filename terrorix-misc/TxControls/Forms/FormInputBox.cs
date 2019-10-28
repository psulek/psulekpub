using System.Drawing;
using System.Windows.Forms;

public partial class FormInputBox : Form
{
	public const int DEFAULT_WIDTH = 370;

	public FormInputBox()
	{
		InitializeComponent();
	}

	public static bool DialogShow(string caption, string message, ref string value)
	{
		return DialogShow(caption, message, DEFAULT_WIDTH, ref value);
	}

	public static bool DialogShow(string caption, string message, int width, ref string value)
	{
		FormInputBox form = new FormInputBox();
		form.Size = new Size(width, form.Size.Height);
		form.Text = caption;
		form.lbMessage.Text = message;
		form.edValue.Text = value;

		if (form.ShowDialog() == DialogResult.OK)
		{
			value = form.edValue.Text;
			return true;
		}

		return false;
	}
}
