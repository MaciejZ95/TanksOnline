namespace TestySignalR_Formsy
{
    partial class Form1
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
            this.SendMessage = new System.Windows.Forms.Button();
            this.TbMessage = new System.Windows.Forms.TextBox();
            this.Messages = new System.Windows.Forms.RichTextBox();
            this.TbUserName = new System.Windows.Forms.TextBox();
            this.LabelUserName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SendMessage
            // 
            this.SendMessage.Location = new System.Drawing.Point(12, 407);
            this.SendMessage.Name = "SendMessage";
            this.SendMessage.Size = new System.Drawing.Size(75, 23);
            this.SendMessage.TabIndex = 0;
            this.SendMessage.Text = "Wyślij";
            this.SendMessage.UseVisualStyleBackColor = true;
            this.SendMessage.Click += new System.EventHandler(this.SendMessage_Click);
            // 
            // TbMessage
            // 
            this.TbMessage.Location = new System.Drawing.Point(93, 409);
            this.TbMessage.Name = "TbMessage";
            this.TbMessage.Size = new System.Drawing.Size(538, 20);
            this.TbMessage.TabIndex = 1;
            // 
            // Messages
            // 
            this.Messages.Location = new System.Drawing.Point(12, 41);
            this.Messages.Name = "Messages";
            this.Messages.Size = new System.Drawing.Size(619, 362);
            this.Messages.TabIndex = 2;
            this.Messages.Text = "";
            // 
            // TbUserName
            // 
            this.TbUserName.Location = new System.Drawing.Point(120, 12);
            this.TbUserName.Name = "TbUserName";
            this.TbUserName.Size = new System.Drawing.Size(181, 20);
            this.TbUserName.TabIndex = 3;
            this.TbUserName.Text = "Wesoły Romek";
            // 
            // LabelUserName
            // 
            this.LabelUserName.AutoSize = true;
            this.LabelUserName.Location = new System.Drawing.Point(12, 15);
            this.LabelUserName.Name = "LabelUserName";
            this.LabelUserName.Size = new System.Drawing.Size(102, 13);
            this.LabelUserName.TabIndex = 4;
            this.LabelUserName.Text = "Nazwa użytkownika";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 441);
            this.Controls.Add(this.LabelUserName);
            this.Controls.Add(this.TbUserName);
            this.Controls.Add(this.Messages);
            this.Controls.Add(this.TbMessage);
            this.Controls.Add(this.SendMessage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendMessage;
        private System.Windows.Forms.TextBox TbMessage;
        private System.Windows.Forms.RichTextBox Messages;
        private System.Windows.Forms.TextBox TbUserName;
        private System.Windows.Forms.Label LabelUserName;
    }
}

