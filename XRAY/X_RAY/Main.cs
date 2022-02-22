using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using XRAY.Properties;

namespace X_RAY
{
	// Token: 0x02000004 RID: 4
	public partial class Main : Form
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00002550 File Offset: 0x00000950
		public Main()
		{
			this.InitializeComponent();
			if (!new WebClient().DownloadString("https://pastebin.com/raw/9u7KJZap").Contains("XRAY1.0"))
			{
				if (MessageBox.Show("Updating wait for an announcment. \nClick OK to Get the updated Link", "XRAY", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
				{
					using (new WebClient())
					{
						Process.Start("https://www.mediafire.com/file/67zp7abbh5wdegh/OPTIC_NR.zip/file");
					}
				}
				Application.Exit();
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000025E4 File Offset: 0x000009E4
		private void button1_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.log("INJECTING");
			DialogResult dialogResult = MessageBox.Show("Closing bsgLauncher as Security Risk Click OK to Continue the Process", "X-RAY", MessageBoxButtons.OKCancel);
			if (dialogResult == DialogResult.OK)
			{
				Process[] processesByName = Process.GetProcessesByName("BsgLauncher");
				Process[] processesByName2 = Process.GetProcessesByName("EscapeFromTarkov");
				if (processesByName.Length != 0)
				{
					Process[] array = processesByName;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].Kill();
					}
					array = processesByName2;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].Kill();
					}
				}
			}
			if (dialogResult == DialogResult.Cancel)
			{
				MessageBox.Show("Exiting Injection");
				Application.Exit();
			}
			Thread.Sleep(2000);
			Console.Beep();
			Console.Beep();
			MessageBox.Show("Click OK and load EFT after");
			base.Hide();
			this.EFTACTIVE.Enabled = true;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002146 File Offset: 0x00000546
		private void button3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000026D8 File Offset: 0x00000AD8
		private void button2_Click(object sender, EventArgs e)
		{
			this.Folder.ShowDialog();
			Program.GameFolder = this.Folder.SelectedPath;
			this.textBox1.Text = this.Folder.SelectedPath + "/EscapeFromTarkov_Data/StreamingAssets/Windows";
			this.textBox2.Text = this.Folder.SelectedPath + "/Logs/";
			if (!File.Exists(Program.GameFolder + "\\EscapeFromTarkov.exe"))
			{
				MessageBox.Show("Error wrong game directory", "X-RAY", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			this.button1.Enabled = true;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002148 File Offset: 0x00000548
		private void CheckProcess_Tick(object sender, EventArgs e)
		{
			if (Process.GetProcessesByName("EscapeFromTarkov").Length != 0)
			{
				this.EFTACTIVE.Enabled = false;
				this.Replacer.Enabled = true;
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002784 File Offset: 0x00000B84
		private void Replacer_Tick(object sender, EventArgs e)
		{
			Login.KeyAuthApp.log("Injected and Playing Tarkov");
			this.CheckProcess.Enabled = true;
			if (Process.GetProcessesByName("EscapeFromTarkov").Length == 0)
			{
				Process[] processesByName = Process.GetProcessesByName("BsgLauncher");
				if (processesByName.Length != 0)
				{
					foreach (Process process in processesByName)
					{
						Login.KeyAuthApp.log("Process Ending Successful");
						process.Kill();
					}
				}
				string text = "bin/shaders";
				string str = this.textBox1.Text + "/";
				File.Delete(this.textBox1.Text + "/shaders");
				File.Copy(text, str + Path.GetFileName(text));
				string text2 = this.textBox2.Text;
				Path.GetTempPath();
				DirectoryInfo directoryInfo = new DirectoryInfo(text2);
				IEnumerable<FileInfo> enumerable = directoryInfo.EnumerateFiles();
				IEnumerable<DirectoryInfo> enumerable2 = directoryInfo.EnumerateDirectories();
				foreach (FileInfo fileInfo in enumerable)
				{
					fileInfo.Delete();
				}
				foreach (DirectoryInfo directoryInfo2 in enumerable2)
				{
					directoryInfo2.Delete(true);
				}
				string userName = Environment.UserName;
				string path = "C:/Users/" + userName + "/AppData/Local/Temp/Battlestate Games";
				Path.GetTempPath();
				DirectoryInfo directoryInfo3 = new DirectoryInfo(path);
				IEnumerable<FileInfo> enumerable3 = directoryInfo3.EnumerateFiles();
				IEnumerable<DirectoryInfo> enumerable4 = directoryInfo3.EnumerateDirectories();
				foreach (FileInfo fileInfo2 in enumerable3)
				{
					fileInfo2.Delete();
				}
				foreach (DirectoryInfo directoryInfo4 in enumerable4)
				{
					directoryInfo4.Delete(true);
				}
				Process[] processesByName2 = Process.GetProcessesByName("BsgLauncher");
				if (processesByName2.Length != 0)
				{
					Process[] array = processesByName2;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].Kill();
					}
				}
				Thread.Sleep(2000);
				Login.KeyAuthApp.log("Application Exiting");
				Application.Exit();
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002A48 File Offset: 0x00000E48
		private void label4_Click(object sender, EventArgs e)
		{
			Process[] processesByName = Process.GetProcessesByName("XRAY");
			for (int i = 0; i < processesByName.Length; i++)
			{
				processesByName[i].Kill();
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002146 File Offset: 0x00000546
		private void button3_Click_1(object sender, EventArgs e)
		{
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002146 File Offset: 0x00000546
		private void Main_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002A80 File Offset: 0x00000E80
		private void EFTACTIVE_Tick(object sender, EventArgs e)
		{
			if (Process.GetProcessesByName("EscapeFromTarkov").Length != 0)
			{
				File.WriteAllBytes(Path.Combine(this.textBox1.Text, "shaders"), Resources.shaders);
				Thread.Sleep(1000);
				this.button1.Enabled = false;
				this.CheckProcess.Enabled = true;
				Console.Beep();
				this.EFTACTIVE.Enabled = false;
			}
		}
	}
}
