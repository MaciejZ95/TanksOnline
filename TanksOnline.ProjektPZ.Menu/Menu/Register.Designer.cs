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
            this.create = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nick = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.returnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // create
            // 
            this.create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.create.Location = new System.Drawing.Point(147, 216);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(181, 41);
            this.create.TabIndex = 0;
            this.create.Text = "Stwórz nowe konto";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(143, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nick";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(142, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "E-mail";
            // 
            // nick
            // 
            this.nick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nick.Location = new System.Drawing.Point(147, 118);
            this.nick.Name = "nick";
            this.nick.Size = new System.Drawing.Size(181, 26);
            this.nick.TabIndex = 7;
            // 
            // email
            // 
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.email.Location = new System.Drawing.Point(147, 66);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(181, 26);
            this.email.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(142, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Hasło";
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.password.Location = new System.Drawing.Point(147, 170);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(181, 26);
            this.password.TabIndex = 11;
            this.password.UseSystemPasswordChar = true;
            // 
            // returnButton
            // 
            this.returnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.returnButton.Location = new System.Drawing.Point(147, 263);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(181, 41);
            this.returnButton.TabIndex = 14;
            this.returnButton.Text = "Powrót";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 396);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nick);
            this.Controls.Add(this.email);
            this.Controls.Add(this.create);
            this.Name = "Register";
            this.Text = "Czołgi Online - Rejestracja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nick;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button returnButton;
    }
}