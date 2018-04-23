using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsApplication1
{
	internal sealed class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		private Program()
		{
		}
		[STAThread]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}