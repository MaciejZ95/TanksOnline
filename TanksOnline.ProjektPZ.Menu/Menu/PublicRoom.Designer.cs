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
            this.label3 = new System.Windows.Forms.Label();
            this.playerListText = new System.Windows.Forms.TextBox();
            this.leaveRoomButton = new System.Windows.Forms.Button();
            this.enterToGameButton = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
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
            // playerListText
            // 
            this.playerListText.Location = new System.Drawing.Point(316, 39);
            this.playerListText.Multiline = true;
            this.playerListText.Name = "playerListText";
            this.playerListText.ReadOnly = true;
            this.playerListText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.playerListText.Size = new System.Drawing.Size(200, 198);
            this.playerListText.TabIndex = 9;
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
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(407, 243);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(109, 23);
            this.refresh.TabIndex = 13;
            this.refresh.Text = "Odśwież listę";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // PublicRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 456);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.leaveRoomButton);
            this.Controls.Add(this.enterToGameButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.playerListText);
            this.Name = "PublicRoom";
            this.Text = "PublicRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox playerListText;
        private System.Windows.Forms.Button leaveRoomButton;
        private System.Windows.Forms.Button enterToGameButton;
        private System.Windows.Forms.Button refresh;
    }
}