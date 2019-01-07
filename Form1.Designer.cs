namespace DOANCUOIKI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlBanCo = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pctAvatar = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btLAN = new System.Windows.Forms.Button();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.picConCo = new System.Windows.Forms.PictureBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.proTime = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newgameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctAvatar)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConCo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBanCo
            // 
            this.pnlBanCo.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBanCo.Location = new System.Drawing.Point(12, 27);
            this.pnlBanCo.Name = "pnlBanCo";
            this.pnlBanCo.Size = new System.Drawing.Size(518, 425);
            this.pnlBanCo.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.pctAvatar);
            this.panel2.Location = new System.Drawing.Point(536, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(211, 239);
            this.panel2.TabIndex = 1;
            // 
            // pctAvatar
            // 
            this.pctAvatar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pctAvatar.Image = global::Cocaro.Properties.Resources._1;
            this.pctAvatar.Location = new System.Drawing.Point(0, 3);
            this.pctAvatar.Name = "pctAvatar";
            this.pctAvatar.Size = new System.Drawing.Size(211, 233);
            this.pctAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctAvatar.TabIndex = 0;
            this.pctAvatar.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.btLAN);
            this.panel3.Controls.Add(this.tbIP);
            this.panel3.Controls.Add(this.picConCo);
            this.panel3.Controls.Add(this.tbName);
            this.panel3.Controls.Add(this.proTime);
            this.panel3.Location = new System.Drawing.Point(536, 269);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(211, 161);
            this.panel3.TabIndex = 2;
            // 
            // btLAN
            // 
            this.btLAN.Font = new System.Drawing.Font("Elephant", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLAN.Location = new System.Drawing.Point(0, 111);
            this.btLAN.Name = "btLAN";
            this.btLAN.Size = new System.Drawing.Size(211, 50);
            this.btLAN.TabIndex = 5;
            this.btLAN.Text = "Chơi";
            this.btLAN.UseVisualStyleBackColor = true;
            this.btLAN.Click += new System.EventHandler(this.btLAN_Click);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(0, 72);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 20);
            this.tbIP.TabIndex = 3;
            // 
            // picConCo
            // 
            this.picConCo.Location = new System.Drawing.Point(101, 0);
            this.picConCo.Name = "picConCo";
            this.picConCo.Size = new System.Drawing.Size(110, 105);
            this.picConCo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picConCo.TabIndex = 2;
            this.picConCo.TabStop = false;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(0, 3);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 1;
            // 
            // proTime
            // 
            this.proTime.Location = new System.Drawing.Point(3, 45);
            this.proTime.Name = "proTime";
            this.proTime.Size = new System.Drawing.Size(97, 10);
            this.proTime.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(751, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newgameToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newgameToolStripMenuItem
            // 
            this.newgameToolStripMenuItem.Name = "newgameToolStripMenuItem";
            this.newgameToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.newgameToolStripMenuItem.Text = "Newgame";
            this.newgameToolStripMenuItem.Click += new System.EventHandler(this.newgameToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click_1);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 449);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlBanCo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "GameCaro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctAvatar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConCo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBanCo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pctAvatar;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.PictureBox picConCo;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ProgressBar proTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newgameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btLAN;
    }
}

