namespace X_RAY
{
	// Token: 0x02000004 RID: 4
	public partial class Main : global::System.Windows.Forms.Form
	{
		// Token: 0x0600001A RID: 26 RVA: 0x00002174 File Offset: 0x00000574
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002AF4 File Offset: 0x00000EF4
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::X_RAY.Main));
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.label5 = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.Folder = new global::System.Windows.Forms.FolderBrowserDialog();
			this.ActiveUsers = new global::System.Windows.Forms.Timer(this.components);
			this.CheckProcess = new global::System.Windows.Forms.Timer(this.components);
			this.Replacer = new global::System.Windows.Forms.Timer(this.components);
			this.textBox2 = new global::System.Windows.Forms.TextBox();
			this.bunifuDragControl1 = new global::Bunifu.Framework.UI.BunifuDragControl(this.components);
			this.bunifuDragControl2 = new global::Bunifu.Framework.UI.BunifuDragControl(this.components);
			this.bunifuDragControl3 = new global::Bunifu.Framework.UI.BunifuDragControl(this.components);
			this.EFTACTIVE = new global::System.Windows.Forms.Timer(this.components);
			this.panel5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.FromArgb(51, 65, 255);
			this.label4.Location = new global::System.Drawing.Point(584, 259);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(27, 15);
			this.label4.TabIndex = 72;
			this.label4.Text = "Exit";
			this.label4.Click += new global::System.EventHandler(this.label4_Click);
			this.panel6.BackColor = global::System.Drawing.Color.FromArgb(51, 65, 255);
			this.panel6.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.panel6.Location = new global::System.Drawing.Point(24, 274);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(447, 1);
			this.panel6.TabIndex = 71;
			this.panel5.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.panel5.Controls.Add(this.label5);
			this.panel5.Controls.Add(this.pictureBox1);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new global::System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(629, 74);
			this.panel5.TabIndex = 70;
			this.label5.AutoSize = true;
			this.label5.ForeColor = global::System.Drawing.Color.White;
			this.label5.Location = new global::System.Drawing.Point(111, 9);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(0, 13);
			this.label5.TabIndex = 67;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(3, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(102, 68);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 42;
			this.pictureBox1.TabStop = false;
			this.textBox1.BackColor = global::System.Drawing.Color.FromArgb(40, 40, 40);
			this.textBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.textBox1.Font = new global::System.Drawing.Font("Verdana", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.textBox1.ForeColor = global::System.Drawing.Color.White;
			this.textBox1.Location = new global::System.Drawing.Point(24, 259);
			this.textBox1.Name = "textBox1";
			this.textBox1.PasswordChar = '*';
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new global::System.Drawing.Size(449, 16);
			this.textBox1.TabIndex = 68;
			this.button1.BackColor = global::System.Drawing.Color.FromArgb(35, 35, 35);
			this.button1.Enabled = false;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new global::System.Drawing.Font("Verdana", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = global::System.Drawing.Color.White;
			this.button1.Location = new global::System.Drawing.Point(223, 151);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(162, 37);
			this.button1.TabIndex = 67;
			this.button1.Text = "Inject";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button2.BackColor = global::System.Drawing.Color.FromArgb(35, 35, 35);
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new global::System.Drawing.Font("Verdana", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button2.ForeColor = global::System.Drawing.Color.White;
			this.button2.Location = new global::System.Drawing.Point(479, 255);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(99, 24);
			this.button2.TabIndex = 69;
			this.button2.Text = "Set";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.CheckProcess.Interval = 2000;
			this.CheckProcess.Tick += new global::System.EventHandler(this.CheckProcess_Tick);
			this.Replacer.Interval = 2000;
			this.Replacer.Tick += new global::System.EventHandler(this.Replacer_Tick);
			this.textBox2.BackColor = global::System.Drawing.Color.FromArgb(40, 40, 40);
			this.textBox2.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.textBox2.Font = new global::System.Drawing.Font("Verdana", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.textBox2.ForeColor = global::System.Drawing.Color.White;
			this.textBox2.Location = new global::System.Drawing.Point(24, 465);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new global::System.Drawing.Size(449, 16);
			this.textBox2.TabIndex = 73;
			this.textBox2.Visible = false;
			this.bunifuDragControl1.Fixed = true;
			this.bunifuDragControl1.Horizontal = true;
			this.bunifuDragControl1.TargetControl = this;
			this.bunifuDragControl1.Vertical = true;
			this.bunifuDragControl2.Fixed = true;
			this.bunifuDragControl2.Horizontal = true;
			this.bunifuDragControl2.TargetControl = this.panel5;
			this.bunifuDragControl2.Vertical = true;
			this.bunifuDragControl3.Fixed = true;
			this.bunifuDragControl3.Horizontal = true;
			this.bunifuDragControl3.TargetControl = this.pictureBox1;
			this.bunifuDragControl3.Vertical = true;
			this.EFTACTIVE.Tick += new global::System.EventHandler(this.EFTACTIVE_Tick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(27, 27, 27);
			base.ClientSize = new global::System.Drawing.Size(629, 288);
			base.Controls.Add(this.textBox2);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.panel6);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.button2);
			this.ForeColor = global::System.Drawing.Color.White;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Main";
			this.Text = "Главный";
			base.Load += new global::System.EventHandler(this.Main_Load);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000004 RID: 4
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.Button button2;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.FolderBrowserDialog Folder;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Timer ActiveUsers;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Timer CheckProcess;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.Timer Replacer;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.TextBox textBox2;

		// Token: 0x04000012 RID: 18
		private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;

		// Token: 0x04000013 RID: 19
		private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;

		// Token: 0x04000014 RID: 20
		private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl3;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Timer EFTACTIVE;
	}
}
