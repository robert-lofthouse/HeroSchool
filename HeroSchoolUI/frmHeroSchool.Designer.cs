namespace HeroSchoolUI
{
    partial class frmHeroSchool
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
            this.btnCards = new System.Windows.Forms.Button();
            this.btnPlayers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCards
            // 
            this.btnCards.Location = new System.Drawing.Point(26, 26);
            this.btnCards.Name = "btnCards";
            this.btnCards.Size = new System.Drawing.Size(134, 47);
            this.btnCards.TabIndex = 0;
            this.btnCards.Text = "Cards";
            this.btnCards.UseVisualStyleBackColor = true;
            this.btnCards.Click += new System.EventHandler(this.btnCards_click);
            // 
            // btnPlayers
            // 
            this.btnPlayers.Location = new System.Drawing.Point(26, 93);
            this.btnPlayers.Name = "btnPlayers";
            this.btnPlayers.Size = new System.Drawing.Size(134, 47);
            this.btnPlayers.TabIndex = 0;
            this.btnPlayers.Text = "Players";
            this.btnPlayers.UseVisualStyleBackColor = true;
            this.btnPlayers.Click += new System.EventHandler(this.btnPlayers_Click);
            // 
            // frmHeroSchool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 486);
            this.Controls.Add(this.btnPlayers);
            this.Controls.Add(this.btnCards);
            this.Name = "frmHeroSchool";
            this.Text = "frmHeroSchool";
            this.Load += new System.EventHandler(this.frmHeroSchool_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCards;
        private System.Windows.Forms.Button btnPlayers;
    }
}