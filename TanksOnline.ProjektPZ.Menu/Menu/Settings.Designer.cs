namespace Menu
{
    partial class Settings
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Konto");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Ustawienia");
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.viewsList = new System.Windows.Forms.ListView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.emailInput = new System.Windows.Forms.TextBox();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.passwordconfirmInput = new System.Windows.Forms.TextBox();
            this.passwordconfirmLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.avatarLabel = new System.Windows.Forms.Label();
            this.tankSelect = new System.Windows.Forms.DomainUpDown();
            this.tankPB = new System.Windows.Forms.PictureBox();
            this.nicknameInput = new System.Windows.Forms.TextBox();
            this.avatarPB = new System.Windows.Forms.PictureBox();
            this.nicknameLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tankPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPB)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.90909F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.09091F));
            this.tableLayoutPanel1.Controls.Add(this.viewsList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 437F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 437F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(660, 437);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // viewsList
            // 
            this.viewsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewsList.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.viewsList.Cursor = System.Windows.Forms.Cursors.Default;
            this.viewsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.viewsList.FullRowSelect = true;
            this.viewsList.HideSelection = false;
            listViewItem1.Tag = "";
            this.viewsList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.viewsList.Location = new System.Drawing.Point(3, 3);
            this.viewsList.MultiSelect = false;
            this.viewsList.Name = "viewsList";
            this.viewsList.Size = new System.Drawing.Size(230, 396);
            this.viewsList.TabIndex = 0;
            this.viewsList.UseCompatibleStateImageBehavior = false;
            this.viewsList.View = System.Windows.Forms.View.List;
            this.viewsList.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.17275F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.82725F));
            this.tableLayoutPanel2.Controls.Add(this.emailLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.passwordLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.passwordconfirmLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.passwordconfirmInput, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.passwordInput, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.emailInput, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 338F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(411, 425);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // emailInput
            // 
            this.emailInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.emailInput.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.emailInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emailInput.Location = new System.Drawing.Point(163, 4);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(173, 22);
            this.emailInput.TabIndex = 2;
            this.emailInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // passwordInput
            // 
            this.passwordInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.passwordInput.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.passwordInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordInput.Location = new System.Drawing.Point(163, 34);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(139, 22);
            this.passwordInput.TabIndex = 3;
            this.passwordInput.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // passwordconfirmInput
            // 
            this.passwordconfirmInput.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.passwordconfirmInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordconfirmInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordconfirmInput.Location = new System.Drawing.Point(163, 63);
            this.passwordconfirmInput.Name = "passwordconfirmInput";
            this.passwordconfirmInput.Size = new System.Drawing.Size(139, 22);
            this.passwordconfirmInput.TabIndex = 5;
            this.passwordconfirmInput.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // passwordconfirmLabel
            // 
            this.passwordconfirmLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.passwordconfirmLabel.AutoSize = true;
            this.passwordconfirmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordconfirmLabel.Location = new System.Drawing.Point(3, 67);
            this.passwordconfirmLabel.Name = "passwordconfirmLabel";
            this.passwordconfirmLabel.Size = new System.Drawing.Size(154, 16);
            this.passwordconfirmLabel.TabIndex = 4;
            this.passwordconfirmLabel.Text = "Potwierdzenie hasła:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordLabel.Location = new System.Drawing.Point(3, 37);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 16);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "Hasło:";
            // 
            // emailLabel
            // 
            this.emailLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emailLabel.Location = new System.Drawing.Point(3, 8);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(85, 13);
            this.emailLabel.TabIndex = 0;
            this.emailLabel.Text = "E-mail:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(411, 428);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.nicknameLabel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.avatarPB, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.nicknameInput, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.tankPB, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tankSelect, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.avatarLabel, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.76423F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.23577F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 258F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(411, 425);
            this.tableLayoutPanel3.TabIndex = 0;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // avatarLabel
            // 
            this.avatarLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.avatarLabel.AutoSize = true;
            this.avatarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.avatarLabel.Location = new System.Drawing.Point(3, 11);
            this.avatarLabel.Name = "avatarLabel";
            this.avatarLabel.Size = new System.Drawing.Size(55, 16);
            this.avatarLabel.TabIndex = 0;
            this.avatarLabel.Text = "Awatar";
            // 
            // tankSelect
            // 
            this.tankSelect.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.tankSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tankSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tankSelect.Location = new System.Drawing.Point(208, 169);
            this.tankSelect.Name = "tankSelect";
            this.tankSelect.Size = new System.Drawing.Size(120, 22);
            this.tankSelect.TabIndex = 5;
            this.tankSelect.Text = "domainUpDown1";
            // 
            // tankPB
            // 
            this.tankPB.Location = new System.Drawing.Point(3, 169);
            this.tankPB.Name = "tankPB";
            this.tankPB.Size = new System.Drawing.Size(199, 200);
            this.tankPB.TabIndex = 4;
            this.tankPB.TabStop = false;
            // 
            // nicknameInput
            // 
            this.nicknameInput.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.nicknameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nicknameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nicknameInput.Location = new System.Drawing.Point(208, 41);
            this.nicknameInput.Name = "nicknameInput";
            this.nicknameInput.Size = new System.Drawing.Size(128, 22);
            this.nicknameInput.TabIndex = 3;
            // 
            // avatarPB
            // 
            this.avatarPB.Location = new System.Drawing.Point(3, 41);
            this.avatarPB.Name = "avatarPB";
            this.avatarPB.Size = new System.Drawing.Size(100, 100);
            this.avatarPB.TabIndex = 2;
            this.avatarPB.TabStop = false;
            // 
            // nicknameLabel
            // 
            this.nicknameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nicknameLabel.AutoSize = true;
            this.nicknameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nicknameLabel.Location = new System.Drawing.Point(208, 11);
            this.nicknameLabel.Name = "nicknameLabel";
            this.nicknameLabel.Size = new System.Drawing.Size(54, 16);
            this.nicknameLabel.TabIndex = 1;
            this.nicknameLabel.Text = "Nazwa";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Location = new System.Drawing.Point(239, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 396);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.5311F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.4689F));
            this.tableLayoutPanel4.Controls.Add(this.okButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cancelButton, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(239, 405);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(418, 29);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.okButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(181, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(114, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cancelButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(301, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(114, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "ANULUJ";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ustawienia";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tankPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPB)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView viewsList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label nicknameLabel;
        private System.Windows.Forms.PictureBox avatarPB;
        private System.Windows.Forms.TextBox nicknameInput;
        private System.Windows.Forms.PictureBox tankPB;
        private System.Windows.Forms.DomainUpDown tankSelect;
        private System.Windows.Forms.Label avatarLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label passwordconfirmLabel;
        private System.Windows.Forms.TextBox passwordconfirmInput;
        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.TextBox emailInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}