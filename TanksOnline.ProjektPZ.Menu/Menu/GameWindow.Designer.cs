namespace Menu.Views
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.LabelAnchor = new System.Windows.Forms.Label();
            this.LabelTankPos = new System.Windows.Forms.Label();
            this.LabelBulletCnt = new System.Windows.Forms.Label();
            this.SFMLRenderControl = new TanksOnline.ProjektPZ.Game.Controls.SFMLRenderControl();
            this.PauseMenu = new TanksOnline.ProjektPZ.Game.Controls.PauseMenu();
            this.SuspendLayout();
            // 
            // LabelAnchor
            // 
            this.LabelAnchor.AutoSize = true;
            this.LabelAnchor.Location = new System.Drawing.Point(12, 9);
            this.LabelAnchor.Name = "LabelAnchor";
            this.LabelAnchor.Size = new System.Drawing.Size(71, 13);
            this.LabelAnchor.TabIndex = 2;
            this.LabelAnchor.Text = "Turret anchor";
            // 
            // LabelTankPos
            // 
            this.LabelTankPos.AutoSize = true;
            this.LabelTankPos.Location = new System.Drawing.Point(12, 22);
            this.LabelTankPos.Name = "LabelTankPos";
            this.LabelTankPos.Size = new System.Drawing.Size(27, 13);
            this.LabelTankPos.TabIndex = 3;
            this.LabelTankPos.Text = "blah";
            // 
            // LabelBulletCnt
            // 
            this.LabelBulletCnt.AutoSize = true;
            this.LabelBulletCnt.Location = new System.Drawing.Point(12, 35);
            this.LabelBulletCnt.Name = "LabelBulletCnt";
            this.LabelBulletCnt.Size = new System.Drawing.Size(33, 13);
            this.LabelBulletCnt.TabIndex = 4;
            this.LabelBulletCnt.Text = "blah2";
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
            // PauseMenu
            // 
            this.PauseMenu.Location = new System.Drawing.Point(304, 182);
            this.PauseMenu.Name = "PauseMenu";
            this.PauseMenu.Size = new System.Drawing.Size(150, 125);
            this.PauseMenu.TabIndex = 5;
            this.PauseMenu.Visible = false;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.PauseMenu);
            this.Controls.Add(this.LabelBulletCnt);
            this.Controls.Add(this.LabelTankPos);
            this.Controls.Add(this.LabelAnchor);
            this.Controls.Add(this.SFMLRenderControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameWindow";
            this.Text = "Tanks Online";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TanksOnline.ProjektPZ.Game.Controls.SFMLRenderControl SFMLRenderControl;
        private System.Windows.Forms.Label LabelAnchor;
        private System.Windows.Forms.Label LabelTankPos;
        private System.Windows.Forms.Label LabelBulletCnt;
        private TanksOnline.ProjektPZ.Game.Controls.PauseMenu PauseMenu;
    }
}

