namespace UoM_Chemistry_Stores
{
    partial class TermsAndConditionsVC
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
            this.termsBox = new System.Windows.Forms.RichTextBox();
            this.agreeButton = new System.Windows.Forms.Button();
            this.disagreeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // termsBox
            // 
            this.termsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.termsBox.Location = new System.Drawing.Point(12, 12);
            this.termsBox.Name = "termsBox";
            this.termsBox.ReadOnly = true;
            this.termsBox.Size = new System.Drawing.Size(776, 850);
            this.termsBox.TabIndex = 0;
            this.termsBox.Text = "";
            // 
            // agreeButton
            // 
            this.agreeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.agreeButton.Location = new System.Drawing.Point(12, 868);
            this.agreeButton.Name = "agreeButton";
            this.agreeButton.Size = new System.Drawing.Size(300, 34);
            this.agreeButton.TabIndex = 1;
            this.agreeButton.Text = "Agree";
            this.agreeButton.UseVisualStyleBackColor = true;
            this.agreeButton.Click += new System.EventHandler(this.agreeButton_Click);
            // 
            // disagreeButton
            // 
            this.disagreeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.disagreeButton.Location = new System.Drawing.Point(488, 868);
            this.disagreeButton.Name = "disagreeButton";
            this.disagreeButton.Size = new System.Drawing.Size(300, 34);
            this.disagreeButton.TabIndex = 2;
            this.disagreeButton.Text = "Disagree";
            this.disagreeButton.UseVisualStyleBackColor = true;
            this.disagreeButton.Click += new System.EventHandler(this.disagreeButton_Click);
            // 
            // TermsAndConditionsVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 914);
            this.Controls.Add(this.disagreeButton);
            this.Controls.Add(this.agreeButton);
            this.Controls.Add(this.termsBox);
            this.Name = "TermsAndConditionsVC";
            this.Text = "About";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox termsBox;
        private System.Windows.Forms.Button agreeButton;
        private System.Windows.Forms.Button disagreeButton;
    }
}