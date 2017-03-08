namespace TanksOnline.ProjektPZ.Game.Views
{
    partial class TestWindow
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
            this.FooValueC = new System.Windows.Forms.TrackBar();
            this.FooValueB = new System.Windows.Forms.TrackBar();
            this.FooValueA = new System.Windows.Forms.TrackBar();
            this.sfmlRenderControl1 = new TanksOnline.ProjektPZ.Game.Controls.SFMLRenderControl();
            this.ResultFoo = new System.Windows.Forms.Label();
            this.UpdateFoo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FooValueC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FooValueB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FooValueA)).BeginInit();
            this.SuspendLayout();
            // 
            // FooValueC
            // 
            this.FooValueC.Location = new System.Drawing.Point(12, 404);
            this.FooValueC.Name = "FooValueC";
            this.FooValueC.Size = new System.Drawing.Size(190, 45);
            this.FooValueC.TabIndex = 1;
            // 
            // FooValueB
            // 
            this.FooValueB.Location = new System.Drawing.Point(12, 353);
            this.FooValueB.Name = "FooValueB";
            this.FooValueB.Size = new System.Drawing.Size(190, 45);
            this.FooValueB.TabIndex = 2;
            // 
            // FooValueA
            // 
            this.FooValueA.Location = new System.Drawing.Point(12, 302);
            this.FooValueA.Name = "FooValueA";
            this.FooValueA.Size = new System.Drawing.Size(190, 45);
            this.FooValueA.TabIndex = 3;
            // 
            // sfmlRenderControl1
            // 
            this.sfmlRenderControl1.Location = new System.Drawing.Point(12, 12);
            this.sfmlRenderControl1.Name = "sfmlRenderControl1";
            this.sfmlRenderControl1.Size = new System.Drawing.Size(960, 437);
            this.sfmlRenderControl1.TabIndex = 0;
            // 
            // ResultFoo
            // 
            this.ResultFoo.AutoSize = true;
            this.ResultFoo.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ResultFoo.Location = new System.Drawing.Point(320, 404);
            this.ResultFoo.Name = "ResultFoo";
            this.ResultFoo.Size = new System.Drawing.Size(300, 32);
            this.ResultFoo.TabIndex = 4;
            this.ResultFoo.Text = "(1) * x^2 - (1) * x";
            // 
            // UpdateFoo
            // 
            this.UpdateFoo.Location = new System.Drawing.Point(209, 404);
            this.UpdateFoo.Name = "UpdateFoo";
            this.UpdateFoo.Size = new System.Drawing.Size(75, 32);
            this.UpdateFoo.TabIndex = 5;
            this.UpdateFoo.Text = "Update";
            this.UpdateFoo.UseVisualStyleBackColor = true;
            this.UpdateFoo.Click += new System.EventHandler(this.UpdateFoo_Click);
            // 
            // TestWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.UpdateFoo);
            this.Controls.Add(this.ResultFoo);
            this.Controls.Add(this.FooValueA);
            this.Controls.Add(this.FooValueB);
            this.Controls.Add(this.FooValueC);
            this.Controls.Add(this.sfmlRenderControl1);
            this.Name = "TestWindow";
            this.Text = "TestWindow";
            ((System.ComponentModel.ISupportInitialize)(this.FooValueC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FooValueB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FooValueA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.SFMLRenderControl sfmlRenderControl1;
        private System.Windows.Forms.TrackBar FooValueC;
        private System.Windows.Forms.TrackBar FooValueB;
        private System.Windows.Forms.TrackBar FooValueA;
        private System.Windows.Forms.Label ResultFoo;
        private System.Windows.Forms.Button UpdateFoo;
    }
}