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
            this.cboHero1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPlayer1 = new System.Windows.Forms.ComboBox();
            this.grpBattle = new System.Windows.Forms.GroupBox();
            this.cboBattles = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreateBattle = new System.Windows.Forms.Button();
            this.grpHero = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDoAttack = new System.Windows.Forms.Button();
            this.lstPlayedCards = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPlayCards = new System.Windows.Forms.Button();
            this.lstDrawnCards = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtHeroEnergy = new System.Windows.Forms.TextBox();
            this.txtHeroHealth = new System.Windows.Forms.TextBox();
            this.txtCardDeck = new System.Windows.Forms.TextBox();
            this.txtHeroName = new System.Windows.Forms.TextBox();
            this.btnDrawCards = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpBattle.SuspendLayout();
            this.grpHero.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboHero1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboPlayer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.MinimumSize = new System.Drawing.Size(10, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(782, 90);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Hero";
            // 
            // cboHero1
            // 
            this.cboHero1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboHero1.FormattingEnabled = true;
            this.cboHero1.Location = new System.Drawing.Point(110, 54);
            this.cboHero1.Name = "cboHero1";
            this.cboHero1.Size = new System.Drawing.Size(660, 21);
            this.cboHero1.TabIndex = 12;
            this.cboHero1.SelectedIndexChanged += new System.EventHandler(this.cboHero1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Select Hero";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select Player";
            // 
            // cboPlayer1
            // 
            this.cboPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPlayer1.FormattingEnabled = true;
            this.cboPlayer1.Location = new System.Drawing.Point(110, 23);
            this.cboPlayer1.Name = "cboPlayer1";
            this.cboPlayer1.Size = new System.Drawing.Size(660, 21);
            this.cboPlayer1.TabIndex = 9;
            this.cboPlayer1.SelectedIndexChanged += new System.EventHandler(this.cboPlayer1_SelectedIndexChanged);
            // 
            // grpBattle
            // 
            this.grpBattle.Controls.Add(this.cboBattles);
            this.grpBattle.Controls.Add(this.label3);
            this.grpBattle.Controls.Add(this.btnCreateBattle);
            this.grpBattle.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBattle.Location = new System.Drawing.Point(0, 90);
            this.grpBattle.Name = "grpBattle";
            this.grpBattle.Size = new System.Drawing.Size(782, 59);
            this.grpBattle.TabIndex = 9;
            this.grpBattle.TabStop = false;
            this.grpBattle.Text = "Battle";
            // 
            // cboBattles
            // 
            this.cboBattles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBattles.FormattingEnabled = true;
            this.cboBattles.Items.AddRange(new object[] {
            "<New Battle>"});
            this.cboBattles.Location = new System.Drawing.Point(110, 23);
            this.cboBattles.Name = "cboBattles";
            this.cboBattles.Size = new System.Drawing.Size(460, 21);
            this.cboBattles.TabIndex = 12;
            this.cboBattles.Text = "<New Battle>";
            this.cboBattles.SelectedIndexChanged += new System.EventHandler(this.cboBattles_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Select Battle";
            // 
            // btnCreateBattle
            // 
            this.btnCreateBattle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateBattle.Location = new System.Drawing.Point(579, 23);
            this.btnCreateBattle.Name = "btnCreateBattle";
            this.btnCreateBattle.Size = new System.Drawing.Size(191, 21);
            this.btnCreateBattle.TabIndex = 6;
            this.btnCreateBattle.Text = "Create Battle";
            this.btnCreateBattle.UseVisualStyleBackColor = true;
            this.btnCreateBattle.Click += new System.EventHandler(this.btnCreateBattle_Click);
            // 
            // grpHero
            // 
            this.grpHero.Controls.Add(this.groupBox2);
            this.grpHero.Controls.Add(this.panel2);
            this.grpHero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHero.Location = new System.Drawing.Point(0, 149);
            this.grpHero.Name = "grpHero";
            this.grpHero.Size = new System.Drawing.Size(782, 454);
            this.grpHero.TabIndex = 10;
            this.grpHero.TabStop = false;
            this.grpHero.Text = "Hero";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitter1);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 346);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cards";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(386, 16);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 327);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDoAttack);
            this.panel3.Controls.Add(this.lstPlayedCards);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(386, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(387, 327);
            this.panel3.TabIndex = 1;
            // 
            // btnDoAttack
            // 
            this.btnDoAttack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoAttack.Location = new System.Drawing.Point(306, 5);
            this.btnDoAttack.Name = "btnDoAttack";
            this.btnDoAttack.Size = new System.Drawing.Size(75, 23);
            this.btnDoAttack.TabIndex = 14;
            this.btnDoAttack.Text = "Attack";
            this.btnDoAttack.UseVisualStyleBackColor = true;
            this.btnDoAttack.Click += new System.EventHandler(this.btnDoAttack_Click);
            // 
            // lstPlayedCards
            // 
            this.lstPlayedCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPlayedCards.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lstPlayedCards.Location = new System.Drawing.Point(3, 33);
            this.lstPlayedCards.Name = "lstPlayedCards";
            this.lstPlayedCards.Size = new System.Drawing.Size(384, 294);
            this.lstPlayedCards.TabIndex = 12;
            this.lstPlayedCards.UseCompatibleStateImageBehavior = false;
            this.lstPlayedCards.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            this.columnHeader6.Width = 114;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Value";
            this.columnHeader7.Width = 44;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Type";
            this.columnHeader8.Width = 74;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Energy";
            this.columnHeader9.Width = 51;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Return Energy";
            this.columnHeader10.Width = 83;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Played";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPlayCards);
            this.panel1.Controls.Add(this.lstDrawnCards);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 327);
            this.panel1.TabIndex = 0;
            // 
            // btnPlayCards
            // 
            this.btnPlayCards.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlayCards.Location = new System.Drawing.Point(302, 5);
            this.btnPlayCards.Name = "btnPlayCards";
            this.btnPlayCards.Size = new System.Drawing.Size(75, 23);
            this.btnPlayCards.TabIndex = 13;
            this.btnPlayCards.Text = "Play";
            this.btnPlayCards.UseVisualStyleBackColor = true;
            this.btnPlayCards.Click += new System.EventHandler(this.btnPlayCards_Click);
            // 
            // lstDrawnCards
            // 
            this.lstDrawnCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDrawnCards.CheckBoxes = true;
            this.lstDrawnCards.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstDrawnCards.Location = new System.Drawing.Point(0, 33);
            this.lstDrawnCards.Name = "lstDrawnCards";
            this.lstDrawnCards.Size = new System.Drawing.Size(383, 294);
            this.lstDrawnCards.TabIndex = 12;
            this.lstDrawnCards.UseCompatibleStateImageBehavior = false;
            this.lstDrawnCards.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 114;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 44;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 56;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Energy";
            this.columnHeader4.Width = 48;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Return Energy";
            this.columnHeader5.Width = 83;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Drawn";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblResult);
            this.panel2.Controls.Add(this.txtHeroEnergy);
            this.panel2.Controls.Add(this.txtHeroHealth);
            this.panel2.Controls.Add(this.txtCardDeck);
            this.panel2.Controls.Add(this.txtHeroName);
            this.panel2.Controls.Add(this.btnDrawCards);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 89);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txtHeroEnergy
            // 
            this.txtHeroEnergy.Location = new System.Drawing.Point(107, 61);
            this.txtHeroEnergy.Name = "txtHeroEnergy";
            this.txtHeroEnergy.Size = new System.Drawing.Size(188, 20);
            this.txtHeroEnergy.TabIndex = 8;
            // 
            // txtHeroHealth
            // 
            this.txtHeroHealth.Location = new System.Drawing.Point(107, 35);
            this.txtHeroHealth.Name = "txtHeroHealth";
            this.txtHeroHealth.Size = new System.Drawing.Size(188, 20);
            this.txtHeroHealth.TabIndex = 8;
            // 
            // txtCardDeck
            // 
            this.txtCardDeck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCardDeck.Location = new System.Drawing.Point(411, 11);
            this.txtCardDeck.Name = "txtCardDeck";
            this.txtCardDeck.Size = new System.Drawing.Size(354, 20);
            this.txtCardDeck.TabIndex = 8;
            // 
            // txtHeroName
            // 
            this.txtHeroName.Location = new System.Drawing.Point(107, 11);
            this.txtHeroName.Name = "txtHeroName";
            this.txtHeroName.Size = new System.Drawing.Size(188, 20);
            this.txtHeroName.TabIndex = 8;
            // 
            // btnDrawCards
            // 
            this.btnDrawCards.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrawCards.Location = new System.Drawing.Point(674, 57);
            this.btnDrawCards.Name = "btnDrawCards";
            this.btnDrawCards.Size = new System.Drawing.Size(93, 26);
            this.btnDrawCards.TabIndex = 7;
            this.btnDrawCards.Text = "Draw Cards";
            this.btnDrawCards.UseVisualStyleBackColor = true;
            this.btnDrawCards.Click += new System.EventHandler(this.btnDrawCards_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Energy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Health";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(328, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Card Deck";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Name";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(268, 7);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(248, 78);
            this.lblResult.TabIndex = 9;
            this.lblResult.Text = "label10";
            this.lblResult.Visible = false;
            // 
            // frmBattle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 603);
            this.Controls.Add(this.grpHero);
            this.Controls.Add(this.grpBattle);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(500, 453);
            this.Name = "frmBattle";
            this.Text = "Battle";
            this.Load += new System.EventHandler(this.frmBattle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpBattle.ResumeLayout(false);
            this.grpBattle.PerformLayout();
            this.grpHero.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboHero1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPlayer1;
        private System.Windows.Forms.GroupBox grpBattle;
        private System.Windows.Forms.ComboBox cboBattles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreateBattle;
        private System.Windows.Forms.GroupBox grpHero;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDrawCards;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstPlayedCards;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ListView lstDrawnCards;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox txtHeroEnergy;
        private System.Windows.Forms.TextBox txtHeroHealth;
        private System.Windows.Forms.TextBox txtHeroName;
        private System.Windows.Forms.TextBox txtCardDeck;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPlayCards;
        private System.Windows.Forms.Button btnDoAttack;
        private System.Windows.Forms.Label lblResult;
    }
}