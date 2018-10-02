namespace WinFormsApp
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
            this.UserName = new System.Windows.Forms.TextBox();
            this.Hello = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(37, 52);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(175, 20);
            this.UserName.TabIndex = 0;
            this.UserName.Text = "Enter user name";
            // 
            // Hello
            // 
            this.Hello.Location = new System.Drawing.Point(137, 107);
            this.Hello.Name = "Hello";
            this.Hello.Size = new System.Drawing.Size(75, 23);
            this.Hello.TabIndex = 1;
            this.Hello.Text = "Hello";
            this.Hello.UseVisualStyleBackColor = true;
            this.Hello.Click += new System.EventHandler(this.Hello_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 164);
            this.Controls.Add(this.Hello);
            this.Controls.Add(this.UserName);
            this.Name = "Form1";
            this.Text = "Hello";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Button Hello;
    }
}

