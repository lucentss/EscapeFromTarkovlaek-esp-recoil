using System;
using System.Windows.Forms;

namespace X_RAY
{
	// Token: 0x02000006 RID: 6
	internal static class Program
	{
		// Token: 0x06000028 RID: 40 RVA: 0x000021CC File Offset: 0x000005CC
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Login());
		}

		// Token: 0x0400002D RID: 45
		public static string GameFolder;
	}
}
