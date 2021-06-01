
namespace WinFormsControlSampleTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucSample1 = new WinFormsControlSample.UserControlSample();
            this.ucSample2 = new WinFormsControlSample.UserControlSample();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ucSample1
            // 
            this.ucSample1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ucSample1.HelloMessage = "Hello .NET 5 World.";
            this.ucSample1.Location = new System.Drawing.Point(28, 26);
            this.ucSample1.Name = "ucSample1";
            this.ucSample1.Size = new System.Drawing.Size(731, 611);
            this.ucSample1.TabIndex = 0;
            // 
            // ucSample2
            // 
            this.ucSample2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ucSample2.HelloMessage = "Hello .NET 5 World.";
            this.ucSample2.Location = new System.Drawing.Point(780, 26);
            this.ucSample2.Name = "ucSample2";
            this.ucSample2.Size = new System.Drawing.Size(731, 611);
            this.ucSample2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Yu Gothic UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(81, 684);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(625, 111);
            this.button1.TabIndex = 10;
            this.button1.Text = "Click !";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(780, 684);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(731, 103);
            this.label1.TabIndex = 11;
            this.label1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1586, 857);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ucSample2);
            this.Controls.Add(this.ucSample1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinFormsControlSample.UserControlSample ucSample1;
        private WinFormsControlSample.UserControlSample ucSample2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox label1;
    }
}

