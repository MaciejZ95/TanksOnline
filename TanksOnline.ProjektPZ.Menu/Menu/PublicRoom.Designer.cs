namespace Menu
{
    partial class PublicRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PublicRoom));
            this.label3 = new System.Windows.Forms.Label();
            this.leaveRoomButton = new System.Windows.Forms.Button();
            this.enterToGameButton = new System.Windows.Forms.Button();
            this.playerListLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Lista graczy w pokoju";
            // 
            // leaveRoomButton
            // 
            this.leaveRoomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.leaveRoomButton.Location = new System.Drawing.Point(316, 406);
            this.leaveRoomButton.Name = "leaveRoomButton";
            this.leaveRoomButton.Size = new System.Drawing.Size(200, 38);
            this.leaveRoomButton.TabIndex = 12;
            this.leaveRoomButton.Text = "Opuść pokój";
            this.leaveRoomButton.UseVisualStyleBackColor = true;
            this.leaveRoomButton.Click += new System.EventHandler(this.leaveRoomButton_Click);
            // 
            // enterToGameButton
            // 
            this.enterToGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.enterToGameButton.Location = new System.Drawing.Point(12, 39);
            this.enterToGameButton.Name = "enterToGameButton";
            this.enterToGameButton.Size = new System.Drawing.Size(208, 38);
            this.enterToGameButton.TabIndex = 11;
            this.enterToGameButton.Text = "Wejdź do gry";
            this.enterToGameButton.UseVisualStyleBackColor = true;
            this.enterToGameButton.Click += new System.EventHandler(this.enterToGameButton_Click);
            // 
            // playerListLabel
            // 
            this.playerListLabel.Location = new System.Drawing.Point(313, 33);
            this.playerListLabel.Name = "playerListLabel";
            this.playerListLabel.Size = new System.Drawing.Size(203, 207);
            this.playerListLabel.TabIndex = 14;
            this.playerListLabel.Text = "playerListLabel";
            // 
            // PublicRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 456);
            this.ControlBox = false;
            this.Controls.Add(this.playerListLabel);
            this.Controls.Add(this.leaveRoomButton);
            this.Controls.Add(this.enterToGameButton);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PublicRoom";
            this.Text = "PublicRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button leaveRoomButton;
        private System.Windows.Forms.Button enterToGameButton;
        private System.Windows.Forms.Label playerListLabel;
    }
}