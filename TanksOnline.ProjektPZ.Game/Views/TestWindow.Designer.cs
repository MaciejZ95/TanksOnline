namespace TanksOnline.ProjektPZ.Game.Views
{
    partial class TestWindow
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
            this.sfmlRenderControl1 = new TanksOnline.ProjektPZ.Game.Controls.SFMLRenderControl();
            this.SuspendLayout();
            // 
            // sfmlRenderControl1
            // 
            this.sfmlRenderControl1.Location = new System.Drawing.Point(12, 12);
            this.sfmlRenderControl1.Name = "sfmlRenderControl1";
            this.sfmlRenderControl1.Size = new System.Drawing.Size(960, 437);
            this.sfmlRenderControl1.TabIndex = 0;
            // 
            // TestWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.sfmlRenderControl1);
            this.Name = "TestWindow";
            this.Text = "TestWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SFMLRenderControl sfmlRenderControl1;
    }
}