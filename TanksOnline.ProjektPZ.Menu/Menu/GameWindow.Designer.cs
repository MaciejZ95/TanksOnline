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
            this.AirSpeed = new System.Windows.Forms.TextBox();
            this.Mass = new System.Windows.Forms.TextBox();
            this.Speed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Gravity = new System.Windows.Forms.TextBox();
            this.PauseMenu = new TanksOnline.ProjektPZ.Game.Controls.PauseMenu();
            this.SFMLRenderControl = new TanksOnline.ProjektPZ.Game.Controls.SFMLRenderControl();
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
            // AirSpeed
            // 
            this.AirSpeed.Location = new System.Drawing.Point(672, 12);
            this.AirSpeed.Name = "AirSpeed";
            this.AirSpeed.Size = new System.Drawing.Size(100, 20);
            this.AirSpeed.TabIndex = 6;
            this.AirSpeed.Text = "1";
            // 
            // Mass
            // 
            this.Mass.Location = new System.Drawing.Point(672, 38);
            this.Mass.Name = "Mass";
            this.Mass.Size = new System.Drawing.Size(100, 20);
            this.Mass.TabIndex = 7;
            this.Mass.Text = "10";
            // 
            // Speed
            // 
            this.Speed.Location = new System.Drawing.Point(672, 64);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(100, 20);
            this.Speed.TabIndex = 8;
            this.Speed.Text = "35";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(561, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "SIła oporu powietrza";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(606, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Masa ciała";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(553, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Prędkość początkowa";
            // 
            // Gravity
            // 
            this.Gravity.Location = new System.Drawing.Point(672, 90);
            this.Gravity.Name = "Gravity";
            this.Gravity.Size = new System.Drawing.Size(100, 20);
            this.Gravity.TabIndex = 12;
            this.Gravity.Text = "5";
            // 
            // PauseMenu
            // 
            this.PauseMenu.DisplayText = "Pause Menu";
            this.PauseMenu.Location = new System.Drawing.Point(237, 172);
            this.PauseMenu.Name = "PauseMenu";
            this.PauseMenu.Size = new System.Drawing.Size(313, 167);
            this.PauseMenu.TabIndex = 5;
            this.PauseMenu.Visible = false;
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
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.Gravity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.Mass);
            this.Controls.Add(this.AirSpeed);
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
        private System.Windows.Forms.TextBox AirSpeed;
        private System.Windows.Forms.TextBox Mass;
        private System.Windows.Forms.TextBox Speed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Gravity;
    }
}

