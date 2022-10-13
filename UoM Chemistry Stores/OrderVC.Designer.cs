namespace UoM_Chemistry_Stores
{
    partial class OrderVC
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
            this.orderBox = new System.Windows.Forms.RichTextBox();
            this.copyOrderButton = new System.Windows.Forms.Button();
            this.logOrder = new System.Windows.Forms.CheckBox();
            this.shareOrderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // orderBox
            // 
            this.orderBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderBox.DetectUrls = false;
            this.orderBox.Location = new System.Drawing.Point(8, 7);
            this.orderBox.Margin = new System.Windows.Forms.Padding(2);
            this.orderBox.Name = "orderBox";
            this.orderBox.ReadOnly = true;
            this.orderBox.Size = new System.Drawing.Size(619, 485);
            this.orderBox.TabIndex = 0;
            this.orderBox.Text = "";
            // 
            // copyOrderButton
            // 
            this.copyOrderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.copyOrderButton.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.copyOrderButton.Location = new System.Drawing.Point(8, 521);
            this.copyOrderButton.Margin = new System.Windows.Forms.Padding(2);
            this.copyOrderButton.Name = "copyOrderButton";
            this.copyOrderButton.Size = new System.Drawing.Size(406, 40);
            this.copyOrderButton.TabIndex = 1;
            this.copyOrderButton.Text = "Copy Order!";
            this.copyOrderButton.UseVisualStyleBackColor = true;
            this.copyOrderButton.Click += new System.EventHandler(this.copyOrderButton_Click);
            // 
            // logOrder
            // 
            this.logOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logOrder.AutoSize = true;
            this.logOrder.Location = new System.Drawing.Point(13, 497);
            this.logOrder.Name = "logOrder";
            this.logOrder.Size = new System.Drawing.Size(77, 19);
            this.logOrder.TabIndex = 2;
            this.logOrder.Text = "Log order";
            this.logOrder.UseVisualStyleBackColor = true;
            // 
            // shareOrderButton
            // 
            this.shareOrderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.shareOrderButton.Location = new System.Drawing.Point(419, 521);
            this.shareOrderButton.Name = "shareOrderButton";
            this.shareOrderButton.Size = new System.Drawing.Size(208, 40);
            this.shareOrderButton.TabIndex = 3;
            this.shareOrderButton.Text = "Share Order";
            this.shareOrderButton.UseVisualStyleBackColor = true;
            this.shareOrderButton.Click += new System.EventHandler(this.shareOrderButton_Click);
            // 
            // OrderVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 568);
            this.Controls.Add(this.shareOrderButton);
            this.Controls.Add(this.logOrder);
            this.Controls.Add(this.copyOrderButton);
            this.Controls.Add(this.orderBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "OrderVC";
            this.Text = "Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox orderBox;
        private System.Windows.Forms.Button copyOrderButton;
        private System.Windows.Forms.CheckBox logOrder;
        private System.Windows.Forms.Button shareOrderButton;
    }
}