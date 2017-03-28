namespace Menu
{
    partial class UserPanel
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
            this.newGame = new System.Windows.Forms.Button();
            this.setting = new System.Windows.Forms.Button();
            this.ranking = new System.Windows.Forms.Button();
            this.nick = new System.Windows.Forms.Label();
            this.logOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newGame
            // 
            this.newGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.newGame.Location = new System.Drawing.Point(12, 22);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(155, 46);
            this.newGame.TabIndex = 0;
            this.newGame.Text = "Nowa gra";
            this.newGame.UseVisualStyleBackColor = true;
            // 
            // setting
            // 
            this.setting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setting.Location = new System.Drawing.Point(12, 92);
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(155, 46);
            this.setting.TabIndex = 1;
            this.setting.Text = "Ustawienia konta";
            this.setting.UseVisualStyleBackColor = true;
            // 
            // ranking
            // 
            this.ranking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ranking.Location = new System.Drawing.Point(12, 164);
            this.ranking.Name = "ranking";
            this.ranking.Size = new System.Drawing.Size(155, 46);
            this.ranking.TabIndex = 2;
            this.ranking.Text = "Ranking graczy";
            this.ranking.UseVisualStyleBackColor = true;
            // 
            // nick
            // 
            this.nick.AutoSize = true;
            this.nick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nick.Location = new System.Drawing.Point(319, 15);
            this.nick.Name = "nick";
            this.nick.Size = new System.Drawing.Size(51, 20);
            this.nick.TabIndex = 3;
            this.nick.Text = "label1";
            // 
            // logOut
            // 
            this.logOut.Location = new System.Drawing.Point(494, 12);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(75, 23);
            this.logOut.TabIndex = 4;
            this.logOut.Text = "Wyloguj się";
            this.logOut.UseVisualStyleBackColor = true;
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // UserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 405);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.nick);
            this.Controls.Add(this.ranking);
            this.Controls.Add(this.setting);
            this.Controls.Add(this.newGame);
            this.Name = "UserPanel";
            this.Text = "Panel Gracza";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newGame;
        private System.Windows.Forms.Button setting;
        private System.Windows.Forms.Button ranking;
        private System.Windows.Forms.Label nick;
        private System.Windows.Forms.Button logOut;
    }
}