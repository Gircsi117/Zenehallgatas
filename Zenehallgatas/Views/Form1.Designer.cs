namespace Zenehallgatas
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
            this.borderPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.menuComp = new Zenehallgatas.Components.MenuComponent();
            this.SuspendLayout();
            // 
            // borderPanel
            // 
            this.borderPanel.BackColor = System.Drawing.Color.Red;
            this.borderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.borderPanel.Location = new System.Drawing.Point(0, 37);
            this.borderPanel.Name = "borderPanel";
            this.borderPanel.Size = new System.Drawing.Size(784, 1);
            this.borderPanel.TabIndex = 1;
            // 
            // contentPanel
            // 
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 38);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(784, 423);
            this.contentPanel.TabIndex = 2;
            // 
            // menuComp
            // 
            this.menuComp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.menuComp.Location = new System.Drawing.Point(0, 0);
            this.menuComp.Name = "menuComp";
            this.menuComp.Padding = new System.Windows.Forms.Padding(8);
            this.menuComp.Size = new System.Drawing.Size(784, 37);
            this.menuComp.TabIndex = 0;
            this.menuComp.Text = "menuComponent1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.borderPanel);
            this.Controls.Add(this.menuComp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Zenehallgatás";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel borderPanel;
        private Components.MenuComponent menuComp;
        private System.Windows.Forms.Panel contentPanel;
    }
}

