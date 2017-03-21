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
            this.TankPreview = new TanksOnline.ProjektPZ.Game.Controls.TankPreview();
            this.Blue = new System.Windows.Forms.TextBox();
            this.Green = new System.Windows.Forms.TextBox();
            this.Red = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TankPreview
            // 
            this.TankPreview.BLUE = ((byte)(0));
            this.TankPreview.GREEN = ((byte)(0));
            this.TankPreview.Location = new System.Drawing.Point(12, 12);
            this.TankPreview.Name = "TankPreview";
            this.TankPreview.RED = ((byte)(0));
            this.TankPreview.Size = new System.Drawing.Size(150, 150);
            this.TankPreview.TabIndex = 0;
            // 
            // Blue
            // 
            this.Blue.Location = new System.Drawing.Point(12, 429);
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(150, 20);
            this.Blue.TabIndex = 1;
            this.Blue.TextChanged += new System.EventHandler(this.Blue_TextChanged);
            // 
            // Green
            // 
            this.Green.Location = new System.Drawing.Point(12, 403);
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(150, 20);
            this.Green.TabIndex = 2;
            this.Green.TextChanged += new System.EventHandler(this.Green_TextChanged);
            // 
            // Red
            // 
            this.Red.Location = new System.Drawing.Point(12, 377);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(150, 20);
            this.Red.TabIndex = 3;
            this.Red.TextChanged += new System.EventHandler(this.Red_TextChanged);
            // 
            // TestWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.Red);
            this.Controls.Add(this.Green);
            this.Controls.Add(this.Blue);
            this.Controls.Add(this.TankPreview);
            this.Name = "TestWindow";
            this.Text = "TestWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TankPreview TankPreview;
        private System.Windows.Forms.TextBox Blue;
        private System.Windows.Forms.TextBox Green;
        private System.Windows.Forms.TextBox Red;
    }
}