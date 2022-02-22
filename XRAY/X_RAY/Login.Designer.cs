namespace X_RAY
{
	// Token: 0x02000005 RID: 5
	public partial class Login : global::System.Windows.Forms.Form
	{
		// Token: 0x06000025 RID: 37 RVA: 0x000021A7 File Offset: 0x000005A7
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000035E8 File Offset: 0x000019E8
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::X_RAY.Login));
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.RgstrBtn = new global::System.Windows.Forms.Button();
			this.LoginBtn = new global::System.Windows.Forms.Button();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.license = new global::System.Windows.Forms.TextBox();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.password = new global::System.Windows.Forms.TextBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.username = new global::System.Windows.Forms.TextBox();
			this.bunifuDragControl1 = new global::Bunifu.Framework.UI.BunifuDragControl(this.components);
			this.bunifuDragControl2 = new global::Bunifu.Framework.UI.BunifuDragControl(this.components);
			this.bunifuDragControl3 = new global::Bunifu.Framework.UI.BunifuDragControl(this.components);
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(30, 30, 30);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(800, 75);
			this.panel1.TabIndex = 53;
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(95, 75);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 41;
			this.pictureBox1.TabStop = false;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Verdana", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.label5.ForeColor = global::System.Drawing.Color.White;
			this.label5.Location = new global::System.Drawing.Point(368, 285);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(34, 16);
			this.label5.TabIndex = 79;
			this.label5.Text = "Key";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Verdana", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.label4.ForeColor = global::System.Drawing.Color.White;
			this.label4.Location = new global::System.Drawing.Point(348, 221);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(77, 16);
			this.label4.TabIndex = 78;
			this.label4.Text = "Password";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Verdana", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.label3.ForeColor = global::System.Drawing.Color.White;
			this.label3.Location = new global::System.Drawing.Point(348, 160);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(81, 16);
			this.label3.TabIndex = 77;
			this.label3.Text = "Username";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.FromArgb(51, 65, 255);
			this.label2.Location = new global::System.Drawing.Point(12, 426);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(27, 15);
			this.label2.TabIndex = 76;
			this.label2.Text = "Exit";
			this.label2.Click += new global::System.EventHandler(this.label2_Click);
			this.RgstrBtn.BackColor = global::System.Drawing.Color.FromArgb(35, 35, 35);
			this.RgstrBtn.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.RgstrBtn.FlatAppearance.BorderColor = global::System.Drawing.Color.FromArgb(51, 65, 255);
			this.RgstrBtn.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.RgstrBtn.Font = new global::System.Drawing.Font("Verdana", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.RgstrBtn.ForeColor = global::System.Drawing.Color.White;
			this.RgstrBtn.Location = new global::System.Drawing.Point(689, 372);
			this.RgstrBtn.Name = "RgstrBtn";
			this.RgstrBtn.Size = new global::System.Drawing.Size(99, 28);
			this.RgstrBtn.TabIndex = 75;
			this.RgstrBtn.Text = "Register";
			this.RgstrBtn.UseVisualStyleBackColor = false;
			this.RgstrBtn.Click += new global::System.EventHandler(this.RgstrBtn_Click);
			this.LoginBtn.BackColor = global::System.Drawing.Color.FromArgb(35, 35, 35);
			this.LoginBtn.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.LoginBtn.FlatAppearance.BorderColor = global::System.Drawing.Color.FromArgb(51, 65, 255);
			this.LoginBtn.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.LoginBtn.Font = new global::System.Drawing.Font("Verdana", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.LoginBtn.ForeColor = global::System.Drawing.Color.White;
			this.LoginBtn.Location = new global::System.Drawing.Point(689, 410);
			this.LoginBtn.Name = "LoginBtn";
			this.LoginBtn.Size = new global::System.Drawing.Size(99, 28);
			this.LoginBtn.TabIndex = 74;
			this.LoginBtn.Text = "Login";
			this.LoginBtn.UseVisualStyleBackColor = false;
			this.LoginBtn.Click += new global::System.EventHandler(this.LoginBtn_Click);
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(51, 65, 255);
			this.panel4.Location = new global::System.Drawing.Point(288, 322);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(200, 1);
			this.panel4.TabIndex = 73;
			this.license.BackColor = global::System.Drawing.Color.FromArgb(27, 27, 27);
			this.license.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.license.Font = new global::System.Drawing.Font("Verdana", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.license.ForeColor = global::System.Drawing.SystemColors.MenuBar;
			this.license.Location = new global::System.Drawing.Point(288, 304);
			this.license.Name = "license";
			this.license.Size = new global::System.Drawing.Size(188, 16);
			this.license.TabIndex = 72;
			this.panel3.BackColor = global::System.Drawing.Color.FromArgb(51, 65, 255);
			this.panel3.Location = new global::System.Drawing.Point(288, 258);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(200, 1);
			this.panel3.TabIndex = 71;
			this.password.BackColor = global::System.Drawing.Color.FromArgb(27, 27, 27);
			this.password.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.password.Font = new global::System.Drawing.Font("Verdana", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.password.ForeColor = global::System.Drawing.SystemColors.MenuBar;
			this.password.Location = new global::System.Drawing.Point(288, 240);
			this.password.Name = "password";
			this.password.Size = new global::System.Drawing.Size(188, 16);
			this.password.TabIndex = 70;
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(51, 65, 255);
			this.panel2.Location = new global::System.Drawing.Point(288, 197);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(200, 1);
			this.panel2.TabIndex = 69;
			this.username.BackColor = global::System.Drawing.Color.FromArgb(27, 27, 27);
			this.username.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.username.Font = new global::System.Drawing.Font("Verdana", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.username.ForeColor = global::System.Drawing.SystemColors.MenuBar;
			this.username.Location = new global::System.Drawing.Point(288, 179);
			this.username.Name = "username";
			this.username.Size = new global::System.Drawing.Size(188, 16);
			this.username.TabIndex = 68;
			this.bunifuDragControl1.Fixed = true;
			this.bunifuDragControl1.Horizontal = true;
			this.bunifuDragControl1.TargetControl = this;
			this.bunifuDragControl1.Vertical = true;
			this.bunifuDragControl2.Fixed = true;
			this.bunifuDragControl2.Horizontal = true;
			this.bunifuDragControl2.TargetControl = this.panel1;
			this.bunifuDragControl2.Vertical = true;
			this.bunifuDragControl3.Fixed = true;
			this.bunifuDragControl3.Horizontal = true;
			this.bunifuDragControl3.TargetControl = this.pictureBox1;
			this.bunifuDragControl3.Vertical = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(27, 27, 27);
			base.ClientSize = new global::System.Drawing.Size(800, 450);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.RgstrBtn);
			base.Controls.Add(this.LoginBtn);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.license);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.password);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.username);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Login";
			this.Text = "Логин";
			base.Load += new global::System.EventHandler(this.Логин_Load);
			this.panel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400001B RID: 27
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.Button RgstrBtn;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.Button LoginBtn;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.TextBox license;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.TextBox password;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.TextBox username;

		// Token: 0x0400002A RID: 42
		private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;

		// Token: 0x0400002B RID: 43
		private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;

		// Token: 0x0400002C RID: 44
		private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl3;
	}
}
