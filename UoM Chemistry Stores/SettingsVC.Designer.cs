namespace UoM_Chemistry_Stores
{
    partial class SettingsVC
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
            this.saveButton = new System.Windows.Forms.Button();
            this.ordersAsLists = new System.Windows.Forms.CheckBox();
            this.ordersAsListLabel = new System.Windows.Forms.Label();
            this.textSizeLabel = new System.Windows.Forms.Label();
            this.minusButton = new System.Windows.Forms.Button();
            this.plusButton = new System.Windows.Forms.Button();
            this.biggerImageButton = new System.Windows.Forms.Button();
            this.fontSizeLabel = new System.Windows.Forms.Label();
            this.smallerImageButton = new System.Windows.Forms.Button();
            this.currentImageSizeLabel = new System.Windows.Forms.Label();
            this.imageSizeLabel = new System.Windows.Forms.Label();
            this.dropDownBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(8, 217);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(236, 20);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save!";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // ordersAsLists
            // 
            this.ordersAsLists.AutoSize = true;
            this.ordersAsLists.Location = new System.Drawing.Point(13, 16);
            this.ordersAsLists.Margin = new System.Windows.Forms.Padding(2);
            this.ordersAsLists.Name = "ordersAsLists";
            this.ordersAsLists.Size = new System.Drawing.Size(216, 19);
            this.ordersAsLists.TabIndex = 1;
            this.ordersAsLists.Text = "Prefer orders to be displayed as lists.";
            this.ordersAsLists.UseVisualStyleBackColor = true;
            this.ordersAsLists.CheckedChanged += new System.EventHandler(this.ordersAsLists_CheckedChanged);
            // 
            // ordersAsListLabel
            // 
            this.ordersAsListLabel.AutoSize = true;
            this.ordersAsListLabel.Location = new System.Drawing.Point(8, 10);
            this.ordersAsListLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ordersAsListLabel.Name = "ordersAsListLabel";
            this.ordersAsListLabel.Size = new System.Drawing.Size(0, 15);
            this.ordersAsListLabel.TabIndex = 2;
            // 
            // textSizeLabel
            // 
            this.textSizeLabel.AutoSize = true;
            this.textSizeLabel.Location = new System.Drawing.Point(115, 181);
            this.textSizeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textSizeLabel.Name = "textSizeLabel";
            this.textSizeLabel.Size = new System.Drawing.Size(19, 15);
            this.textSizeLabel.TabIndex = 3;
            this.textSizeLabel.Text = "10";
            // 
            // minusButton
            // 
            this.minusButton.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.minusButton.Location = new System.Drawing.Point(10, 178);
            this.minusButton.Margin = new System.Windows.Forms.Padding(2);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(78, 20);
            this.minusButton.TabIndex = 4;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.minusButton_Click);
            // 
            // plusButton
            // 
            this.plusButton.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.plusButton.Location = new System.Drawing.Point(166, 178);
            this.plusButton.Margin = new System.Windows.Forms.Padding(2);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(78, 20);
            this.plusButton.TabIndex = 5;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            // 
            // biggerImageButton
            // 
            this.biggerImageButton.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.biggerImageButton.Location = new System.Drawing.Point(166, 122);
            this.biggerImageButton.Margin = new System.Windows.Forms.Padding(2);
            this.biggerImageButton.Name = "biggerImageButton";
            this.biggerImageButton.Size = new System.Drawing.Size(78, 20);
            this.biggerImageButton.TabIndex = 6;
            this.biggerImageButton.Text = "+";
            this.biggerImageButton.UseVisualStyleBackColor = true;
            this.biggerImageButton.Click += new System.EventHandler(this.biggerImageButton_Click);
            // 
            // fontSizeLabel
            // 
            this.fontSizeLabel.AutoSize = true;
            this.fontSizeLabel.Location = new System.Drawing.Point(13, 161);
            this.fontSizeLabel.Name = "fontSizeLabel";
            this.fontSizeLabel.Size = new System.Drawing.Size(57, 15);
            this.fontSizeLabel.TabIndex = 7;
            this.fontSizeLabel.Text = "Font Size:";
            // 
            // smallerImageButton
            // 
            this.smallerImageButton.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.smallerImageButton.Location = new System.Drawing.Point(11, 122);
            this.smallerImageButton.Margin = new System.Windows.Forms.Padding(2);
            this.smallerImageButton.Name = "smallerImageButton";
            this.smallerImageButton.Size = new System.Drawing.Size(78, 20);
            this.smallerImageButton.TabIndex = 8;
            this.smallerImageButton.Text = "-";
            this.smallerImageButton.UseVisualStyleBackColor = true;
            this.smallerImageButton.Click += new System.EventHandler(this.smallerImageButton_Click);
            // 
            // currentImageSizeLabel
            // 
            this.currentImageSizeLabel.AutoSize = true;
            this.currentImageSizeLabel.Location = new System.Drawing.Point(115, 127);
            this.currentImageSizeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentImageSizeLabel.Name = "currentImageSizeLabel";
            this.currentImageSizeLabel.Size = new System.Drawing.Size(19, 15);
            this.currentImageSizeLabel.TabIndex = 9;
            this.currentImageSizeLabel.Text = "10";
            // 
            // imageSizeLabel
            // 
            this.imageSizeLabel.AutoSize = true;
            this.imageSizeLabel.Location = new System.Drawing.Point(13, 105);
            this.imageSizeLabel.Name = "imageSizeLabel";
            this.imageSizeLabel.Size = new System.Drawing.Size(66, 15);
            this.imageSizeLabel.TabIndex = 10;
            this.imageSizeLabel.Text = "Image Size:";
            // 
            // dropDownBox
            // 
            this.dropDownBox.FormattingEnabled = true;
            this.dropDownBox.Location = new System.Drawing.Point(13, 67);
            this.dropDownBox.Name = "dropDownBox";
            this.dropDownBox.Size = new System.Drawing.Size(216, 23);
            this.dropDownBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "List Type:    (app restart required)";
            // 
            // SettingsVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 245);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dropDownBox);
            this.Controls.Add(this.imageSizeLabel);
            this.Controls.Add(this.currentImageSizeLabel);
            this.Controls.Add(this.smallerImageButton);
            this.Controls.Add(this.fontSizeLabel);
            this.Controls.Add(this.biggerImageButton);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.textSizeLabel);
            this.Controls.Add(this.ordersAsListLabel);
            this.Controls.Add(this.ordersAsLists);
            this.Controls.Add(this.saveButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SettingsVC";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox ordersAsLists;
        private System.Windows.Forms.Label ordersAsListLabel;
        private System.Windows.Forms.Label textSizeLabel;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Button biggerImageButton;
        private System.Windows.Forms.Label fontSizeLabel;
        private System.Windows.Forms.Button smallerImageButton;
        private System.Windows.Forms.Label currentImageSizeLabel;
        private System.Windows.Forms.Label imageSizeLabel;
        private System.Windows.Forms.ComboBox dropDownBox;
        private System.Windows.Forms.Label label1;
    }
}