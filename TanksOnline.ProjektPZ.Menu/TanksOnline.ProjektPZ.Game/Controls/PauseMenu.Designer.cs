namespace TanksOnline.ProjektPZ.Game.Controls
{
    partial class PauseMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PauseMenuLabel = new System.Windows.Forms.Label();
            this.ExitGame = new System.Windows.Forms.Button();
            this.GoBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PauseMenuLabel
            // 
            this.PauseMenuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PauseMenuLabel.Location = new System.Drawing.Point(0, 0);
            this.PauseMenuLabel.Margin = new System.Windows.Forms.Padding(0);
            this.PauseMenuLabel.Name = "PauseMenuLabel";
            this.PauseMenuLabel.Size = new System.Drawing.Size(313, 87);
            this.PauseMenuLabel.TabIndex = 0;
            this.PauseMenuLabel.Text = "Pause Menu";
            this.PauseMenuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitGame
            // 
            this.ExitGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExitGame.Location = new System.Drawing.Point(5, 90);
            this.ExitGame.Name = "ExitGame";
            this.ExitGame.Size = new System.Drawing.Size(305, 33);
            this.ExitGame.TabIndex = 1;
            this.ExitGame.Text = "Exit Game";
            this.ExitGame.UseVisualStyleBackColor = true;
            this.ExitGame.Click += new System.EventHandler(this.ExitGame_Click);
            // 
            // GoBack
            // 
            this.GoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GoBack.Location = new System.Drawing.Point(5, 129);
            this.GoBack.Name = "GoBack";
            this.GoBack.Size = new System.Drawing.Size(305, 33);
            this.GoBack.TabIndex = 2;
            this.GoBack.Text = "Go Back";
            this.GoBack.UseVisualStyleBackColor = true;
            this.GoBack.Click += new System.EventHandler(this.GoBack_Click);
            // 
            // PauseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GoBack);
            this.Controls.Add(this.ExitGame);
            this.Controls.Add(this.PauseMenuLabel);
            this.Name = "PauseMenu";
            this.Size = new System.Drawing.Size(313, 165);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label PauseMenuLabel;
        private System.Windows.Forms.Button ExitGame;
        private System.Windows.Forms.Button GoBack;
    }
}
