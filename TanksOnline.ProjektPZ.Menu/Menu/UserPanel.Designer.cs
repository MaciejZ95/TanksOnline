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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPanel));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.avatarPB = new System.Windows.Forms.PictureBox();
            this.nicknameLabel = new System.Windows.Forms.Label();
            this.settingsButton = new System.Windows.Forms.Button();
            this.addfriendButton = new System.Windows.Forms.Button();
            this.friendsList = new System.Windows.Forms.ListView();
            this.startButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPB)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.addfriendButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.friendsList, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.startButton, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 414F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 537);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.DarkGray;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.Controls.Add(this.avatarPB, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.nicknameLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.settingsButton, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(254, 54);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // avatarPB
            // 
            this.avatarPB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.avatarPB.BackColor = System.Drawing.Color.Gray;
            this.avatarPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.avatarPB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avatarPB.Location = new System.Drawing.Point(3, 3);
            this.avatarPB.Name = "avatarPB";
            this.avatarPB.Size = new System.Drawing.Size(44, 48);
            this.avatarPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarPB.TabIndex = 0;
            this.avatarPB.TabStop = false;
            this.avatarPB.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // nicknameLabel
            // 
            this.nicknameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nicknameLabel.AutoSize = true;
            this.nicknameLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nicknameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nicknameLabel.Location = new System.Drawing.Point(53, 15);
            this.nicknameLabel.Name = "nicknameLabel";
            this.nicknameLabel.Size = new System.Drawing.Size(66, 24);
            this.nicknameLabel.TabIndex = 1;
            this.nicknameLabel.TabStop = true;
            this.nicknameLabel.Text = "label1";
            this.nicknameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Image = global::Menu.Properties.Resources.settings;
            this.settingsButton.Location = new System.Drawing.Point(203, 3);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(48, 48);
            this.settingsButton.TabIndex = 2;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // addfriendButton
            // 
            this.addfriendButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.addfriendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addfriendButton.ForeColor = System.Drawing.Color.Lime;
            this.addfriendButton.Image = global::Menu.Properties.Resources.plus;
            this.addfriendButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addfriendButton.Location = new System.Drawing.Point(3, 509);
            this.addfriendButton.Name = "addfriendButton";
            this.addfriendButton.Size = new System.Drawing.Size(119, 24);
            this.addfriendButton.TabIndex = 2;
            this.addfriendButton.Text = "Dodaj znajomego";
            this.addfriendButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.addfriendButton.UseVisualStyleBackColor = false;
            this.addfriendButton.Click += new System.EventHandler(this.addfriendButton_Click);
            // 
            // friendsList
            // 
            this.friendsList.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.friendsList.FullRowSelect = true;
            this.friendsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.friendsList.Location = new System.Drawing.Point(3, 95);
            this.friendsList.Name = "friendsList";
            this.friendsList.Size = new System.Drawing.Size(254, 408);
            this.friendsList.TabIndex = 1;
            this.friendsList.UseCompatibleStateImageBehavior = false;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.startButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Location = new System.Drawing.Point(3, 63);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(254, 26);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Wejdź do gry";
            this.startButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // UserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(284, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Czołgi Online";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox avatarPB;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.ListView friendsList;
        private System.Windows.Forms.Button addfriendButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label nicknameLabel;
    }
}

