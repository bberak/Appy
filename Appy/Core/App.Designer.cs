namespace Appy
{
    partial class App
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
            this.BrowserContainer = new System.Windows.Forms.Panel();
            this.Canvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResizeButton
            // 
            this.ResizeButton.BackColor = System.Drawing.Color.White;
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Canvas.Controls.Add(this.BrowserContainer);
            this.Canvas.Size = new System.Drawing.Size(1096, 646);
            this.Canvas.Controls.SetChildIndex(this.TitleBarPanel, 0);
            this.Canvas.Controls.SetChildIndex(this.StatusBarPanel, 0);
            this.Canvas.Controls.SetChildIndex(this.BrowserContainer, 0);
            // 
            // StatusBarPanel
            // 
            this.StatusBarPanel.Location = new System.Drawing.Point(0, 620);
            this.StatusBarPanel.Size = new System.Drawing.Size(1096, 26);
            // 
            // TitleBarPanel
            // 
            this.TitleBarPanel.Size = new System.Drawing.Size(1096, 42);
            // 
            // BrowserContainer
            // 
            this.BrowserContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowserContainer.Location = new System.Drawing.Point(12, 48);
            this.BrowserContainer.Name = "BrowserContainer";
            this.BrowserContainer.Size = new System.Drawing.Size(1071, 566);
            this.BrowserContainer.TabIndex = 5;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.MinimumSize = new System.Drawing.Size(480, 400);
            this.Name = "App";
            this.Text = "App";
            this.Canvas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BrowserContainer;

    }
}