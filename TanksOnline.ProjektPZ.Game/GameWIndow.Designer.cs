namespace TanksOnline.ProjektPZ.Game
{
    partial class GameWindow
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
            this.SFMLRenderControl = new TanksOnline.ProjektPZ.Game.Infrastructure.SFMLRenderControl();
            this.SuspendLayout();
            // 
            // SFMLRenderControl
            // 
            this.SFMLRenderControl.AccessibleName = "RenderWindow";
            this.SFMLRenderControl.Location = new System.Drawing.Point(0, 0);
            this.SFMLRenderControl.Margin = new System.Windows.Forms.Padding(0);
            this.SFMLRenderControl.Name = "SFMLRenderControl";
            this.SFMLRenderControl.Size = new System.Drawing.Size(785, 560);
            this.SFMLRenderControl.TabIndex = 0;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.SFMLRenderControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameWindow";
            this.Text = "Tanks Online";
            this.ResumeLayout(false);

        }

        #endregion

        private Infrastructure.SFMLRenderControl SFMLRenderControl;
    }
}

