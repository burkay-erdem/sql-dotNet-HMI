using WinFormAnimation;

namespace ConsoleApp3

{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.TextBox();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.circularProgressBar5 = new CircularProgressBar.CircularProgressBar();
            this.password = new System.Windows.Forms.TextBox();
            this.hide = new System.Windows.Forms.PictureBox();
            this.show = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.eng = new System.Windows.Forms.PictureBox();
            this.turk = new System.Windows.Forms.PictureBox();
            this.Error_mes = new System.Windows.Forms.Label();
            this.settings_pnl = new System.Windows.Forms.Panel();
            this.SerttingsPnl = new ConsoleApp3.UserControl1();
            ((System.ComponentModel.ISupportInitialize)(this.hide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.show)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turk)).BeginInit();
            this.settings_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.White;
            this.checkBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox1.Location = new System.Drawing.Point(307, 369);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Remember Me";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(272, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(255, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "User";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.UseMnemonic = false;
            // 
            // user
            // 
            this.user.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.user.Location = new System.Drawing.Point(340, 267);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(189, 20);
            this.user.TabIndex = 1;
            this.user.Text = "  ";
            this.user.KeyDown += new System.Windows.Forms.KeyEventHandler(this.User_KeyDown);
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.materialRaisedButton1.Location = new System.Drawing.Point(454, 370);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(75, 23);
            this.materialRaisedButton1.TabIndex = 4;
            this.materialRaisedButton1.Text = "login";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.MaterialRaisedButton1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // circularProgressBar5
            // 
            this.circularProgressBar5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.circularProgressBar5.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar5.AnimationSpeed = 1500;
            this.circularProgressBar5.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar5.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.circularProgressBar5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBar5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.circularProgressBar5.InnerColor = System.Drawing.Color.White;
            this.circularProgressBar5.InnerMargin = 0;
            this.circularProgressBar5.InnerWidth = 0;
            this.circularProgressBar5.Location = new System.Drawing.Point(307, 67);
            this.circularProgressBar5.MarqueeAnimationSpeed = 1500;
            this.circularProgressBar5.Name = "circularProgressBar5";
            this.circularProgressBar5.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.circularProgressBar5.OuterMargin = -11;
            this.circularProgressBar5.OuterWidth = 8;
            this.circularProgressBar5.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(251)))), ((int)(((byte)(50)))));
            this.circularProgressBar5.ProgressWidth = 14;
            this.circularProgressBar5.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 4.125F);
            this.circularProgressBar5.Size = new System.Drawing.Size(222, 194);
            this.circularProgressBar5.StartAngle = 270;
            this.circularProgressBar5.SubscriptColor = System.Drawing.Color.Gray;
            this.circularProgressBar5.SubscriptMargin = new System.Windows.Forms.Padding(0);
            this.circularProgressBar5.SubscriptText = "";
            this.circularProgressBar5.SuperscriptColor = System.Drawing.Color.Gray;
            this.circularProgressBar5.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            this.circularProgressBar5.SuperscriptText = "";
            this.circularProgressBar5.TabIndex = 11;
            this.circularProgressBar5.Text = "AL-BA Elektronik";
            this.circularProgressBar5.TextMargin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.circularProgressBar5.Value = 75;
            // 
            // password
            // 
            this.password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.password.Location = new System.Drawing.Point(340, 314);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(190, 20);
            this.password.TabIndex = 2;
            this.password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_KeyDown);
            // 
            // hide
            // 
            this.hide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hide.Image = ((System.Drawing.Image)(resources.GetObject("hide.Image")));
            this.hide.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hide.Location = new System.Drawing.Point(505, 314);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(25, 20);
            this.hide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hide.TabIndex = 13;
            this.hide.TabStop = false;
            this.hide.Click += new System.EventHandler(this.Hide_Click);
            // 
            // show
            // 
            this.show.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.show.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.show.Image = ((System.Drawing.Image)(resources.GetObject("show.Image")));
            this.show.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.show.Location = new System.Drawing.Point(505, 314);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(25, 20);
            this.show.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.show.TabIndex = 13;
            this.show.TabStop = false;
            this.show.Click += new System.EventHandler(this.Show_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(504, 267);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Transparent;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Image = ((System.Drawing.Image)(resources.GetObject("button12.Image")));
            this.button12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button12.Location = new System.Drawing.Point(767, 28);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(32, 35);
            this.button12.TabIndex = 15;
            this.button12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.Button12_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Image = ((System.Drawing.Image)(resources.GetObject("button11.Image")));
            this.button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button11.Location = new System.Drawing.Point(729, 28);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(32, 35);
            this.button11.TabIndex = 16;
            this.button11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button11.UseVisualStyleBackColor = false;
            // 
            // eng
            // 
            this.eng.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eng.Image = ((System.Drawing.Image)(resources.GetObject("eng.Image")));
            this.eng.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.eng.Location = new System.Drawing.Point(12, 67);
            this.eng.Name = "eng";
            this.eng.Size = new System.Drawing.Size(68, 53);
            this.eng.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.eng.TabIndex = 18;
            this.eng.TabStop = false;
            this.eng.Click += new System.EventHandler(this.Eng_Click);
            // 
            // turk
            // 
            this.turk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.turk.Image = ((System.Drawing.Image)(resources.GetObject("turk.Image")));
            this.turk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.turk.Location = new System.Drawing.Point(12, 67);
            this.turk.Name = "turk";
            this.turk.Size = new System.Drawing.Size(68, 53);
            this.turk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.turk.TabIndex = 19;
            this.turk.TabStop = false;
            this.turk.Click += new System.EventHandler(this.Turk_Click);
            // 
            // Error_mes
            // 
            this.Error_mes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_mes.BackColor = System.Drawing.Color.White;
            this.Error_mes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Error_mes.Location = new System.Drawing.Point(289, 445);
            this.Error_mes.Name = "Error_mes";
            this.Error_mes.Size = new System.Drawing.Size(255, 16);
            this.Error_mes.TabIndex = 8;
            this.Error_mes.Text = "www.albaelektronik.com";
            this.Error_mes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_mes.UseMnemonic = false;
            // 
            // settings_pnl
            // 
            this.settings_pnl.Controls.Add(this.SerttingsPnl);
            this.settings_pnl.Location = new System.Drawing.Point(588, 57);
            this.settings_pnl.Name = "settings_pnl";
            this.settings_pnl.Size = new System.Drawing.Size(211, 53);
            this.settings_pnl.TabIndex = 17;
            // 
            // SerttingsPnl
            // 
            this.SerttingsPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SerttingsPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SerttingsPnl.Location = new System.Drawing.Point(0, 0);
            this.SerttingsPnl.Name = "SerttingsPnl";
            this.SerttingsPnl.Size = new System.Drawing.Size(211, 53);
            this.SerttingsPnl.TabIndex = 0;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(811, 487);
            this.Controls.Add(this.eng);
            this.Controls.Add(this.turk);
            this.Controls.Add(this.settings_pnl);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.show);
            this.Controls.Add(this.hide);
            this.Controls.Add(this.circularProgressBar5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Error_mes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.user);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.password);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "login";
            this.Text = "AL-BA Elektronik";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.hide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.show)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turk)).EndInit();
            this.settings_pnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox user;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1; 
        private CircularProgressBar.CircularProgressBar circularProgressBar5;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.PictureBox hide;
        private System.Windows.Forms.PictureBox show;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.PictureBox eng;
        private System.Windows.Forms.PictureBox turk;
        private System.Windows.Forms.Panel settings_pnl;
        private UserControl1 SerttingsPnl;
        public System.Windows.Forms.Label Error_mes;
    }
}