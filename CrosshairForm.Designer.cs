namespace My_Macro
{
    partial class CrosshairForm
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
            this.CrosshairImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CrosshairImage)).BeginInit();
            this.SuspendLayout();
            // 
            // CrosshairImage
            // 
            this.CrosshairImage.BackColor = System.Drawing.Color.Transparent;
            this.CrosshairImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CrosshairImage.Image = global::My_Macro.Properties.Resources.crosshair;
            this.CrosshairImage.Location = new System.Drawing.Point(0, 0);
            this.CrosshairImage.Name = "CrosshairImage";
            this.CrosshairImage.Size = new System.Drawing.Size(67, 60);
            this.CrosshairImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CrosshairImage.TabIndex = 0;
            this.CrosshairImage.TabStop = false;
            // 
            // CrosshairForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(67, 60);
            this.Controls.Add(this.CrosshairImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrosshairForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CrosshairForm";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.CrosshairImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CrosshairImage;
    }
}