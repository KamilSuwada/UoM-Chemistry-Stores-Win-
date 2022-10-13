
namespace UoM_Chemistry_Stores
{
    partial class QuantityDialogVC
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
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(12, 12);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(504, 23);
            this.quantityTextBox.TabIndex = 0;
            this.quantityTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.quantityTextBox_KeyUp);
            // 
            // QuantityDialogVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 44);
            this.Controls.Add(this.quantityTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "QuantityDialogVC";
            this.Text = "Edit quantity:";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox quantityTextBox;
    }
}