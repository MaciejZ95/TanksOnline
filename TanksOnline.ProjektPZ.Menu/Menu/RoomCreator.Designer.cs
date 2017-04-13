namespace Menu
{
    partial class RoomCreator
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
            this.enterToGameButton = new System.Windows.Forms.Button();
            this.addPlayerButton = new System.Windows.Forms.Button();
            this.leaveRoomButton = new System.Windows.Forms.Button();
            this.addFriendText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.friendListText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // enterToGameButton
            // 
            this.enterToGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.enterToGameButton.Location = new System.Drawing.Point(12, 23);
            this.enterToGameButton.Name = "enterToGameButton";
            this.enterToGameButton.Size = new System.Drawing.Size(208, 38);
            this.enterToGameButton.TabIndex = 0;
            this.enterToGameButton.Text = "Wejdź do gry";
            this.enterToGameButton.UseVisualStyleBackColor = true;
            // 
            // addPlayerButton
            // 
            this.addPlayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addPlayerButton.Location = new System.Drawing.Point(240, 55);
            this.addPlayerButton.Name = "addPlayerButton";
            this.addPlayerButton.Size = new System.Drawing.Size(208, 38);
            this.addPlayerButton.TabIndex = 1;
            this.addPlayerButton.Text = "Dodaj nowego gracza";
            this.addPlayerButton.UseVisualStyleBackColor = true;
            // 
            // leaveRoomButton
            // 
            this.leaveRoomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.leaveRoomButton.Location = new System.Drawing.Point(470, 427);
            this.leaveRoomButton.Name = "leaveRoomButton";
            this.leaveRoomButton.Size = new System.Drawing.Size(200, 38);
            this.leaveRoomButton.TabIndex = 2;
            this.leaveRoomButton.Text = "Opuść pokój";
            this.leaveRoomButton.UseVisualStyleBackColor = true;
            // 
            // addFriendText
            // 
            this.addFriendText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addFriendText.Location = new System.Drawing.Point(240, 23);
            this.addFriendText.Name = "addFriendText";
            this.addFriendText.Size = new System.Drawing.Size(208, 26);
            this.addFriendText.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Wpisz nick gracza";
            // 
            // friendListText
            // 
            this.friendListText.Location = new System.Drawing.Point(470, 23);
            this.friendListText.Multiline = true;
            this.friendListText.Name = "friendListText";
            this.friendListText.ReadOnly = true;
            this.friendListText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.friendListText.Size = new System.Drawing.Size(200, 198);
            this.friendListText.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(467, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lista graczy";
            // 
            // RoomCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 477);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.friendListText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addFriendText);
            this.Controls.Add(this.leaveRoomButton);
            this.Controls.Add(this.addPlayerButton);
            this.Controls.Add(this.enterToGameButton);
            this.Name = "RoomCreator";
            this.Text = "Tworzenie pokoju gracza";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enterToGameButton;
        private System.Windows.Forms.Button addPlayerButton;
        private System.Windows.Forms.Button leaveRoomButton;
        private System.Windows.Forms.TextBox addFriendText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox friendListText;
        private System.Windows.Forms.Label label2;
    }
}