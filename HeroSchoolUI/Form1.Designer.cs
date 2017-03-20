namespace HeroSchoolUI
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
            this.Player1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lstPlayedDefenseCardsP1 = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lstPlayedAttackCardsP1 = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstDefenseCardDeckP1 = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstAttackCardDeckP1 = new System.Windows.Forms.ListBox();
            this.txtPlayer1Value = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Player2 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstPlayedDefenseCardsP2 = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lstPlayedAttackCardsP2 = new System.Windows.Forms.ListBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lstDefenseCardDeckP2 = new System.Windows.Forms.ListBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lstAttackCardDeckP2 = new System.Windows.Forms.ListBox();
            this.txtPlayer2Value = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Player1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Player2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // Player1
            // 
            this.Player1.Controls.Add(this.btnReset);
            this.Player1.Controls.Add(this.groupBox6);
            this.Player1.Controls.Add(this.groupBox5);
            this.Player1.Controls.Add(this.groupBox4);
            this.Player1.Controls.Add(this.groupBox3);
            this.Player1.Controls.Add(this.txtPlayer1Value);
            this.Player1.Controls.Add(this.label2);
            this.Player1.Controls.Add(this.label3);
            this.Player1.Controls.Add(this.label1);
            this.Player1.Location = new System.Drawing.Point(7, 7);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(463, 519);
            this.Player1.TabIndex = 0;
            this.Player1.TabStop = false;
            this.Player1.Text = "Player 1";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(377, 19);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 24);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lstPlayedDefenseCardsP1);
            this.groupBox6.Location = new System.Drawing.Point(13, 400);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(439, 99);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Played Defense Cards";
            // 
            // lstPlayedDefenseCardsP1
            // 
            this.lstPlayedDefenseCardsP1.AllowDrop = true;
            this.lstPlayedDefenseCardsP1.FormattingEnabled = true;
            this.lstPlayedDefenseCardsP1.Location = new System.Drawing.Point(9, 19);
            this.lstPlayedDefenseCardsP1.Name = "lstPlayedDefenseCardsP1";
            this.lstPlayedDefenseCardsP1.Size = new System.Drawing.Size(421, 69);
            this.lstPlayedDefenseCardsP1.TabIndex = 3;
            this.lstPlayedDefenseCardsP1.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstPlayedDefenseCardsP1_DragDrop);
            this.lstPlayedDefenseCardsP1.DragOver += new System.Windows.Forms.DragEventHandler(this.lstPlayedDefenseCardsP1_DragOver);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lstPlayedAttackCardsP1);
            this.groupBox5.Location = new System.Drawing.Point(13, 301);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(439, 99);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Played Attack Cards";
            // 
            // lstPlayedAttackCardsP1
            // 
            this.lstPlayedAttackCardsP1.AllowDrop = true;
            this.lstPlayedAttackCardsP1.FormattingEnabled = true;
            this.lstPlayedAttackCardsP1.Location = new System.Drawing.Point(9, 19);
            this.lstPlayedAttackCardsP1.Name = "lstPlayedAttackCardsP1";
            this.lstPlayedAttackCardsP1.Size = new System.Drawing.Size(421, 69);
            this.lstPlayedAttackCardsP1.TabIndex = 1;
            this.lstPlayedAttackCardsP1.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstPlayedAttackCardsP1_DragDrop);
            this.lstPlayedAttackCardsP1.DragOver += new System.Windows.Forms.DragEventHandler(this.lstPlayedAttackCardsP1_DragOver);
            this.lstPlayedAttackCardsP1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstPlayedAttackCardsP1_MouseDown);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstDefenseCardDeckP1);
            this.groupBox4.Location = new System.Drawing.Point(13, 202);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(439, 99);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Defense Card Deck";
            // 
            // lstDefenseCardDeckP1
            // 
            this.lstDefenseCardDeckP1.AllowDrop = true;
            this.lstDefenseCardDeckP1.FormattingEnabled = true;
            this.lstDefenseCardDeckP1.Location = new System.Drawing.Point(9, 19);
            this.lstDefenseCardDeckP1.Name = "lstDefenseCardDeckP1";
            this.lstDefenseCardDeckP1.Size = new System.Drawing.Size(421, 69);
            this.lstDefenseCardDeckP1.TabIndex = 1;
            this.lstDefenseCardDeckP1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstDefenseCardDeckP1_MouseDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstAttackCardDeckP1);
            this.groupBox3.Location = new System.Drawing.Point(13, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(439, 99);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Attack Card Deck";
            // 
            // lstAttackCardDeckP1
            // 
            this.lstAttackCardDeckP1.AllowDrop = true;
            this.lstAttackCardDeckP1.FormattingEnabled = true;
            this.lstAttackCardDeckP1.Location = new System.Drawing.Point(9, 19);
            this.lstAttackCardDeckP1.Name = "lstAttackCardDeckP1";
            this.lstAttackCardDeckP1.Size = new System.Drawing.Size(421, 69);
            this.lstAttackCardDeckP1.TabIndex = 0;
            this.lstAttackCardDeckP1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstAttackCardDeckP1_MouseDown);
            // 
            // txtPlayer1Value
            // 
            this.txtPlayer1Value.AllowDrop = true;
            this.txtPlayer1Value.Location = new System.Drawing.Point(152, 60);
            this.txtPlayer1Value.Name = "txtPlayer1Value";
            this.txtPlayer1Value.Size = new System.Drawing.Size(100, 20);
            this.txtPlayer1Value.TabIndex = 2;
            this.txtPlayer1Value.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtPlayer1Value_DragDrop);
            this.txtPlayer1Value.DragOver += new System.Windows.Forms.DragEventHandler(this.txtPlayer1Value_DragOver);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rob";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Player value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player Name";
            // 
            // Player2
            // 
            this.Player2.Controls.Add(this.groupBox2);
            this.Player2.Controls.Add(this.groupBox7);
            this.Player2.Controls.Add(this.groupBox8);
            this.Player2.Controls.Add(this.groupBox9);
            this.Player2.Controls.Add(this.txtPlayer2Value);
            this.Player2.Controls.Add(this.label4);
            this.Player2.Controls.Add(this.label5);
            this.Player2.Controls.Add(this.label6);
            this.Player2.Location = new System.Drawing.Point(476, 7);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(463, 519);
            this.Player2.TabIndex = 1;
            this.Player2.TabStop = false;
            this.Player2.Text = "Player 2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstPlayedDefenseCardsP2);
            this.groupBox2.Location = new System.Drawing.Point(13, 400);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(439, 99);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Played Defense Cards";
            // 
            // lstPlayedDefenseCardsP2
            // 
            this.lstPlayedDefenseCardsP2.AllowDrop = true;
            this.lstPlayedDefenseCardsP2.FormattingEnabled = true;
            this.lstPlayedDefenseCardsP2.Location = new System.Drawing.Point(9, 19);
            this.lstPlayedDefenseCardsP2.Name = "lstPlayedDefenseCardsP2";
            this.lstPlayedDefenseCardsP2.Size = new System.Drawing.Size(421, 69);
            this.lstPlayedDefenseCardsP2.TabIndex = 3;
            this.lstPlayedDefenseCardsP2.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstPlayedDefenseCardsP2_DragDrop);
            this.lstPlayedDefenseCardsP2.DragOver += new System.Windows.Forms.DragEventHandler(this.lstPlayedDefenseCardsP2_DragOver);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lstPlayedAttackCardsP2);
            this.groupBox7.Location = new System.Drawing.Point(13, 301);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(439, 99);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Played Attack Cards";
            // 
            // lstPlayedAttackCardsP2
            // 
            this.lstPlayedAttackCardsP2.AllowDrop = true;
            this.lstPlayedAttackCardsP2.FormattingEnabled = true;
            this.lstPlayedAttackCardsP2.Location = new System.Drawing.Point(9, 19);
            this.lstPlayedAttackCardsP2.Name = "lstPlayedAttackCardsP2";
            this.lstPlayedAttackCardsP2.Size = new System.Drawing.Size(421, 69);
            this.lstPlayedAttackCardsP2.TabIndex = 1;
            this.lstPlayedAttackCardsP2.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstPlayedAttackCardsP2_DragDrop);
            this.lstPlayedAttackCardsP2.DragOver += new System.Windows.Forms.DragEventHandler(this.lstPlayedAttackCardsP2_DragOver);
            this.lstPlayedAttackCardsP2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstPlayedAttackCardsP2_MouseDown);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lstDefenseCardDeckP2);
            this.groupBox8.Location = new System.Drawing.Point(13, 202);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(439, 99);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Defense Card Deck";
            // 
            // lstDefenseCardDeckP2
            // 
            this.lstDefenseCardDeckP2.AllowDrop = true;
            this.lstDefenseCardDeckP2.FormattingEnabled = true;
            this.lstDefenseCardDeckP2.Location = new System.Drawing.Point(9, 19);
            this.lstDefenseCardDeckP2.Name = "lstDefenseCardDeckP2";
            this.lstDefenseCardDeckP2.Size = new System.Drawing.Size(421, 69);
            this.lstDefenseCardDeckP2.TabIndex = 1;
            this.lstDefenseCardDeckP2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstDefenseCardDeckP2_MouseDown);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lstAttackCardDeckP2);
            this.groupBox9.Location = new System.Drawing.Point(13, 103);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(439, 99);
            this.groupBox9.TabIndex = 3;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Attack Card Deck";
            // 
            // lstAttackCardDeckP2
            // 
            this.lstAttackCardDeckP2.AllowDrop = true;
            this.lstAttackCardDeckP2.FormattingEnabled = true;
            this.lstAttackCardDeckP2.Location = new System.Drawing.Point(9, 19);
            this.lstAttackCardDeckP2.Name = "lstAttackCardDeckP2";
            this.lstAttackCardDeckP2.Size = new System.Drawing.Size(421, 69);
            this.lstAttackCardDeckP2.TabIndex = 0;
            this.lstAttackCardDeckP2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstAttackCardDeckP2_MouseDown);
            // 
            // txtPlayer2Value
            // 
            this.txtPlayer2Value.AllowDrop = true;
            this.txtPlayer2Value.Location = new System.Drawing.Point(152, 60);
            this.txtPlayer2Value.Name = "txtPlayer2Value";
            this.txtPlayer2Value.Size = new System.Drawing.Size(100, 20);
            this.txtPlayer2Value.TabIndex = 2;
            this.txtPlayer2Value.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtPlayer2Value_DragDrop);
            this.txtPlayer2Value.DragOver += new System.Windows.Forms.DragEventHandler(this.txtPlayer2Value_DragOver);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Alan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Player value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Player Name";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 703);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Player1.ResumeLayout(false);
            this.Player1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.Player2.ResumeLayout(false);
            this.Player2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Player1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListBox lstPlayedDefenseCardsP1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox lstPlayedAttackCardsP1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lstDefenseCardDeckP1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstAttackCardDeckP1;
        private System.Windows.Forms.TextBox txtPlayer1Value;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Player2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstPlayedDefenseCardsP2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ListBox lstPlayedAttackCardsP2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ListBox lstDefenseCardDeckP2;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ListBox lstAttackCardDeckP2;
        private System.Windows.Forms.TextBox txtPlayer2Value;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnReset;
    }
}

