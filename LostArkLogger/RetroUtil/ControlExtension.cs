using System.Windows.Forms;

namespace LostArkLogger
{
	public static class ControlExtension
	{
		/// <summary>
		/// Calls action on control, invokes if required.
		/// </summary>
		/// <param name="control"></param>
		/// <param name="action"></param>
		public static void InvokeIfRequired(this Control control, MethodInvoker action)
		{
			if (control.InvokeRequired)
				control.Invoke(action);
			else
				action();
		}
	}
}
