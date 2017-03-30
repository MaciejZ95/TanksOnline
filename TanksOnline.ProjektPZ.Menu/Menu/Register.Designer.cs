namespace Menu
{
    partial class Register
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
            this.createButton = new System.Windows.Forms.Button();
            this.nicknameLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.nicknameInput = new System.Windows.Forms.TextBox();
            this.emailInput = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.returnButton = new System.Windows.Forms.Button();
            this.emailconfirmLabel = new System.Windows.Forms.Label();
            this.emailconfirmInput = new System.Windows.Forms.TextBox();
            this.passwordconfirmLabel = new System.Windows.Forms.Label();
            this.passwordconfirmInput = new System.Windows.Forms.TextBox();
            this.separatorline = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.createButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.createButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.createButton.Location = new System.Drawing.Point(343, 300);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(150, 30);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "STWÓRZ NOWE KONTO";
            this.createButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // nicknameLabel
            // 
            this.nicknameLabel.AutoSize = true;
            this.nicknameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nicknameLabel.Location = new System.Drawing.Point(12, 113);
            this.nicknameLabel.Name = "nicknameLabel";
            this.nicknameLabel.Size = new System.Drawing.Size(157, 18);
            this.nicknameLabel.TabIndex = 9;
            this.nicknameLabel.Text = "Nazwa użytkownika";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emailLabel.Location = new System.Drawing.Point(12, 9);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(56, 18);
            this.emailLabel.TabIndex = 8;
            this.emailLabel.Text = "E-mail";
            // 
            // nicknameInput
            // 
            this.nicknameInput.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.nicknameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nicknameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nicknameInput.Location = new System.Drawing.Point(12, 136);
            this.nicknameInput.Name = "nicknameInput";
            this.nicknameInput.Size = new System.Drawing.Size(260, 24);
            this.nicknameInput.TabIndex = 7;
            // 
            // emailInput
            // 
            this.emailInput.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.emailInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emailInput.Location = new System.Drawing.Point(12, 32);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(260, 24);
            this.emailInput.TabIndex = 6;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordLabel.Location = new System.Drawing.Point(12, 165);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(52, 18);
            this.passwordLabel.TabIndex = 13;
            this.passwordLabel.Text = "Hasło";
            // 
            // passwordInput
            // 
            this.passwordInput.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.passwordInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordInput.Location = new System.Drawing.Point(12, 188);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(260, 24);
            this.passwordInput.TabIndex = 11;
            this.passwordInput.UseSystemPasswordChar = true;
            // 
            // returnButton
            // 
            this.returnButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.returnButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.returnButton.Location = new System.Drawing.Point(12, 300);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(150, 30);
            this.returnButton.TabIndex = 14;
            this.returnButton.Text = "WSTECZ";
            this.returnButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.returnButton.UseVisualStyleBackColor = false;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // emailconfirmLabel
            // 
            this.emailconfirmLabel.AutoSize = true;
            this.emailconfirmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emailconfirmLabel.Location = new System.Drawing.Point(12, 61);
            this.emailconfirmLabel.Name = "emailconfirmLabel";
            this.emailconfirmLabel.Size = new System.Drawing.Size(181, 18);
            this.emailconfirmLabel.TabIndex = 16;
            this.emailconfirmLabel.Text = "Potwierdź adres e-mail";
            // 
            // emailconfirmInput
            // 
            this.emailconfirmInput.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.emailconfirmInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailconfirmInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emailconfirmInput.Location = new System.Drawing.Point(12, 84);
            this.emailconfirmInput.Name = "emailconfirmInput";
            this.emailconfirmInput.Size = new System.Drawing.Size(260, 24);
            this.emailconfirmInput.TabIndex = 15;
            // 
            // passwordconfirmLabel
            // 
            this.passwordconfirmLabel.AutoSize = true;
            this.passwordconfirmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordconfirmLabel.Location = new System.Drawing.Point(12, 217);
            this.passwordconfirmLabel.Name = "passwordconfirmLabel";
            this.passwordconfirmLabel.Size = new System.Drawing.Size(117, 18);
            this.passwordconfirmLabel.TabIndex = 18;
            this.passwordconfirmLabel.Text = "Powtórz hasło";
            // 
            // passwordconfirmInput
            // 
            this.passwordconfirmInput.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.passwordconfirmInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordconfirmInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordconfirmInput.Location = new System.Drawing.Point(12, 240);
            this.passwordconfirmInput.Name = "passwordconfirmInput";
            this.passwordconfirmInput.Size = new System.Drawing.Size(260, 24);
            this.passwordconfirmInput.TabIndex = 17;
            this.passwordconfirmInput.UseSystemPasswordChar = true;
            // 
            // separatorline
            // 
            this.separatorline.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.separatorline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.separatorline.Location = new System.Drawing.Point(1, 284);
            this.separatorline.Name = "separatorline";
            this.separatorline.Size = new System.Drawing.Size(505, 2);
            this.separatorline.TabIndex = 19;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(505, 342);
            this.Controls.Add(this.separatorline);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.passwordconfirmLabel);
            this.Controls.Add(this.passwordconfirmInput);
            this.Controls.Add(this.emailconfirmLabel);
            this.Controls.Add(this.emailconfirmInput);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordInput);
            this.Controls.Add(this.nicknameLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.nicknameInput);
            this.Controls.Add(this.emailInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Czołgi Online - Rejestracja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label nicknameLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox nicknameInput;
        private System.Windows.Forms.TextBox emailInput;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Label emailconfirmLabel;
        private System.Windows.Forms.TextBox emailconfirmInput;
        private System.Windows.Forms.Label passwordconfirmLabel;
        private System.Windows.Forms.TextBox passwordconfirmInput;
        private System.Windows.Forms.Label separatorline;
    }
}