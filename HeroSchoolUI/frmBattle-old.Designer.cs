namespace HeroSchoolUI
{
    partial class frmBattle
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboPlayer1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboPlayer2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboHero1 = new System.Windows.Forms.ComboBox();
            this.cboHero2 = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnCreateBattle = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.grpHero1 = new System.Windows.Forms.GroupBox();
            this.grpHero2 = new System.Windows.Forms.GroupBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitter1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.MinimumSize = new System.Drawing.Size(677, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 119);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Participating Heroes";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboHero1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboPlayer1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.MinimumSize = new System.Drawing.Size(333, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player 1";
            // 
            // cboPlayer1
            // 
            this.cboPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPlayer1.FormattingEnabled = true;
            this.cboPlayer1.Location = new System.Drawing.Point(101, 22);
            this.cboPlayer1.Name = "cboPlayer1";
            this.cboPlayer1.Size = new System.Drawing.Size(353, 21);
            this.cboPlayer1.TabIndex = 5;
            this.cboPlayer1.SelectedIndexChanged += new System.EventHandler(this.cboPlayer1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Player";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboHero2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cboPlayer2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(463, 16);
            this.groupBox3.MinimumSize = new System.Drawing.Size(333, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(478, 100);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Player 2";
            // 
            // cboPlayer2
            // 
            this.cboPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPlayer2.FormattingEnabled = true;
            this.cboPlayer2.Location = new System.Drawing.Point(100, 22);
            this.cboPlayer2.Name = "cboPlayer2";
            this.cboPlayer2.Size = new System.Drawing.Size(349, 21);
            this.cboPlayer2.TabIndex = 8;
            this.cboPlayer2.SelectedIndexChanged += new System.EventHandler(this.cboPlayer2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Select Player";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select Hero";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Select Hero";
            // 
            // cboHero1
            // 
            this.cboHero1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboHero1.FormattingEnabled = true;
            this.cboHero1.Location = new System.Drawing.Point(101, 58);
            this.cboHero1.Name = "cboHero1";
            this.cboHero1.Size = new System.Drawing.Size(353, 21);
            this.cboHero1.TabIndex = 8;
            // 
            // cboHero2
            // 
            this.cboHero2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboHero2.FormattingEnabled = true;
            this.cboHero2.Location = new System.Drawing.Point(100, 58);
            this.cboHero2.Name = "cboHero2";
            this.cboHero2.Size = new System.Drawing.Size(349, 21);
            this.cboHero2.TabIndex = 12;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(463, 16);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 100);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // btnCreateBattle
            // 
            this.btnCreateBattle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreateBattle.Location = new System.Drawing.Point(0, 119);
            this.btnCreateBattle.Name = "btnCreateBattle";
            this.btnCreateBattle.Size = new System.Drawing.Size(944, 34);
            this.btnCreateBattle.TabIndex = 5;
            this.btnCreateBattle.Text = "Create Battle";
            this.btnCreateBattle.UseVisualStyleBackColor = true;
            this.btnCreateBattle.Click += new System.EventHandler(this.btnCreateBattle_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.splitter2);
            this.groupBox4.Controls.Add(this.grpHero2);
            this.groupBox4.Controls.Add(this.grpHero1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 153);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(944, 300);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Battle";
            // 
            // grpHero1
            // 
            this.grpHero1.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpHero1.Location = new System.Drawing.Point(3, 16);
            this.grpHero1.Name = "grpHero1";
            this.grpHero1.Size = new System.Drawing.Size(460, 281);
            this.grpHero1.TabIndex = 9;
            this.grpHero1.TabStop = false;
            this.grpHero1.Text = "Hero1";
            // 
            // grpHero2
            // 
            this.grpHero2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHero2.Location = new System.Drawing.Point(463, 16);
            this.grpHero2.Name = "grpHero2";
            this.grpHero2.Size = new System.Drawing.Size(478, 281);
            this.grpHero2.TabIndex = 10;
            this.grpHero2.TabStop = false;
            this.grpHero2.Text = "Hero2";
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(463, 16);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 281);
            this.splitter2.TabIndex = 11;
            this.splitter2.TabStop = false;
            // 
            // frmBattle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 510);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCreateBattle);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(693, 453);
            this.Name = "frmBattle";
            this.Text = "Battle";
            this.Load += new System.EventHandler(this.frmBattle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboHero2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPlayer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboHero1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPlayer1;
        private System.Windows.Forms.Button btnCreateBattle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.GroupBox grpHero2;
        private System.Windows.Forms.GroupBox grpHero1;
    }
}