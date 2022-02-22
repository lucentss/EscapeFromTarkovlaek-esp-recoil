using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using KeyAuth;
using XRAY.Properties;

namespace X_RAY
{
	// Token: 0x02000005 RID: 5
	public partial class Login : Form
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00002199 File Offset: 0x00000599
		public Login()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x048F6000 File Offset: 0x048F1C00
		private void Логин_Load(object sender, EventArgs e)
		{
			this.Text = Settings.Default.Login;
			this.username.Text = Settings.Default.Login;
			this.Text = Settings.Default.Password;
			this.password.Text = Settings.Default.Password;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000034B8 File Offset: 0x000018B8
		private void RgstrBtn_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.register(this.username.Text, this.password.Text, this.license.Text);
			MessageBox.Show(string.Concat(new string[]
			{
				"Thanks For Registering \n Key: ",
				this.license.Text,
				"\n Username: ",
				this.username.Text,
				"\n Password: ",
				this.password.Text,
				"\nPlease click OK and Login :) "
			}), "Optic Cheats");
		}

		// Token: 0x0600001F RID: 31 RVA: 0x048F0000 File Offset: 0x048EC400
		private void LoginBtn_Click(object sender, EventArgs e)
		{
			new Main().Show();
			base.Hide();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002A48 File Offset: 0x00000E48
		private void label2_Click(object sender, EventArgs e)
		{
			Process[] processesByName = Process.GetProcessesByName("XRAY");
			for (int i = 0; i < processesByName.Length; i++)
			{
				processesByName[i].Kill();
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002146 File Offset: 0x00000546
		private void button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002146 File Offset: 0x00000546
		private void button1_Click_1(object sender, EventArgs e)
		{
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002146 File Offset: 0x00000546
		private void button1_Click_2(object sender, EventArgs e)
		{
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002146 File Offset: 0x00000546
		private void Changer_Tick(object sender, EventArgs e)
		{
		}

		// Token: 0x04000016 RID: 22
		private static string name = "Proxy XRAY";

		// Token: 0x04000017 RID: 23
		private static string ownerid = "EgG46Xxtnh";

		// Token: 0x04000018 RID: 24
		private static string secret = "988eac121571a56b1dccaba8d03c5596cde33bf1580b0c9a42da17053a755c78";

		// Token: 0x04000019 RID: 25
		private static string version = "2.0";

		// Token: 0x0400001A RID: 26
		public static api KeyAuthApp = new api(Login.name, Login.ownerid, Login.secret, Login.version);
	}
}
