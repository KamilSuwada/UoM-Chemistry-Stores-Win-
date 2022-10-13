
namespace UoM_Chemistry_Stores
{
    partial class UoMChemistryStores
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.categoriesTreeView = new System.Windows.Forms.TreeView();
            this.orderLogsButton = new System.Windows.Forms.Button();
            this.favouriteButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.plusButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.itemListView = new System.Windows.Forms.ListView();
            this.minusButtonForBasket = new System.Windows.Forms.Button();
            this.orderUsualButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.plusButtonForBasket = new System.Windows.Forms.Button();
            this.updateDetailsButton = new System.Windows.Forms.Button();
            this.totalAmmountLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.setUsualButton = new System.Windows.Forms.Button();
            this.orderButton = new System.Windows.Forms.Button();
            this.basketListView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.minusButtonForBasket);
            this.splitContainer1.Panel2.Controls.Add(this.orderUsualButton);
            this.splitContainer1.Panel2.Controls.Add(this.clearButton);
            this.splitContainer1.Panel2.Controls.Add(this.plusButtonForBasket);
            this.splitContainer1.Panel2.Controls.Add(this.updateDetailsButton);
            this.splitContainer1.Panel2.Controls.Add(this.totalAmmountLabel);
            this.splitContainer1.Panel2.Controls.Add(this.totalLabel);
            this.splitContainer1.Panel2.Controls.Add(this.setUsualButton);
            this.splitContainer1.Panel2.Controls.Add(this.orderButton);
            this.splitContainer1.Panel2.Controls.Add(this.basketListView);
            this.splitContainer1.Size = new System.Drawing.Size(1308, 691);
            this.splitContainer1.SplitterDistance = 787;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.categoriesTreeView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.orderLogsButton);
            this.splitContainer2.Panel2.Controls.Add(this.favouriteButton);
            this.splitContainer2.Panel2.Controls.Add(this.settingsButton);
            this.splitContainer2.Panel2.Controls.Add(this.minusButton);
            this.splitContainer2.Panel2.Controls.Add(this.plusButton);
            this.splitContainer2.Panel2.Controls.Add(this.searchBox);
            this.splitContainer2.Panel2.Controls.Add(this.itemListView);
            this.splitContainer2.Size = new System.Drawing.Size(787, 691);
            this.splitContainer2.SplitterDistance = 181;
            this.splitContainer2.TabIndex = 0;
            // 
            // categoriesTreeView
            // 
            this.categoriesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesTreeView.Location = new System.Drawing.Point(0, 0);
            this.categoriesTreeView.Name = "categoriesTreeView";
            this.categoriesTreeView.Size = new System.Drawing.Size(181, 691);
            this.categoriesTreeView.TabIndex = 0;
            this.categoriesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.categoriesTreeView_AfterSelect);
            // 
            // orderLogsButton
            // 
            this.orderLogsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.orderLogsButton.Location = new System.Drawing.Point(410, 656);
            this.orderLogsButton.Name = "orderLogsButton";
            this.orderLogsButton.Size = new System.Drawing.Size(75, 23);
            this.orderLogsButton.TabIndex = 12;
            this.orderLogsButton.Text = "Order Logs";
            this.orderLogsButton.UseVisualStyleBackColor = true;
            this.orderLogsButton.Click += new System.EventHandler(this.orderLogsButton_Click);
            // 
            // favouriteButton
            // 
            this.favouriteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.favouriteButton.Location = new System.Drawing.Point(164, 656);
            this.favouriteButton.Name = "favouriteButton";
            this.favouriteButton.Size = new System.Drawing.Size(75, 23);
            this.favouriteButton.TabIndex = 11;
            this.favouriteButton.Text = "Favourite";
            this.favouriteButton.UseVisualStyleBackColor = true;
            this.favouriteButton.Click += new System.EventHandler(this.favouriteButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.Location = new System.Drawing.Point(491, 656);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(85, 23);
            this.settingsButton.TabIndex = 10;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // minusButton
            // 
            this.minusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.minusButton.Location = new System.Drawing.Point(84, 656);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(75, 23);
            this.minusButton.TabIndex = 9;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.minusButton_Click);
            // 
            // plusButton
            // 
            this.plusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.plusButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.plusButton.Location = new System.Drawing.Point(3, 656);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(75, 23);
            this.plusButton.TabIndex = 8;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Location = new System.Drawing.Point(3, 3);
            this.searchBox.Name = "searchBox";
            this.searchBox.PlaceholderText = "Search for...";
            this.searchBox.Size = new System.Drawing.Size(574, 23);
            this.searchBox.TabIndex = 1;
            this.searchBox.TextChanged += new System.EventHandler(this.searchTextDidChange);
            this.searchBox.Enter += new System.EventHandler(this.searchBox_Enter);
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBox_KeyDown);
            // 
            // itemListView
            // 
            this.itemListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemListView.HideSelection = false;
            this.itemListView.Location = new System.Drawing.Point(3, 29);
            this.itemListView.Name = "itemListView";
            this.itemListView.Size = new System.Drawing.Size(574, 621);
            this.itemListView.TabIndex = 0;
            this.itemListView.UseCompatibleStateImageBehavior = false;
            this.itemListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.itemListView_KeyUp);
            this.itemListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.itemListView_MouseClick);
            this.itemListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.itemListView_MouseDoubleClick);
            // 
            // minusButtonForBasket
            // 
            this.minusButtonForBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.minusButtonForBasket.Location = new System.Drawing.Point(41, 656);
            this.minusButtonForBasket.Name = "minusButtonForBasket";
            this.minusButtonForBasket.Size = new System.Drawing.Size(32, 23);
            this.minusButtonForBasket.TabIndex = 14;
            this.minusButtonForBasket.Text = "-";
            this.minusButtonForBasket.UseVisualStyleBackColor = true;
            this.minusButtonForBasket.Click += new System.EventHandler(this.minusButtonForBasket_Click);
            // 
            // orderUsualButton
            // 
            this.orderUsualButton.Location = new System.Drawing.Point(164, 3);
            this.orderUsualButton.Name = "orderUsualButton";
            this.orderUsualButton.Size = new System.Drawing.Size(100, 23);
            this.orderUsualButton.TabIndex = 11;
            this.orderUsualButton.Text = "Order Usual";
            this.orderUsualButton.UseVisualStyleBackColor = true;
            this.orderUsualButton.Click += new System.EventHandler(this.orderUsualButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearButton.Location = new System.Drawing.Point(78, 656);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 12;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // plusButtonForBasket
            // 
            this.plusButtonForBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.plusButtonForBasket.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.plusButtonForBasket.Location = new System.Drawing.Point(3, 656);
            this.plusButtonForBasket.Name = "plusButtonForBasket";
            this.plusButtonForBasket.Size = new System.Drawing.Size(32, 23);
            this.plusButtonForBasket.TabIndex = 13;
            this.plusButtonForBasket.Text = "+";
            this.plusButtonForBasket.UseVisualStyleBackColor = true;
            this.plusButtonForBasket.Click += new System.EventHandler(this.plusButtonForBasket_Click);
            // 
            // updateDetailsButton
            // 
            this.updateDetailsButton.Location = new System.Drawing.Point(84, 3);
            this.updateDetailsButton.Name = "updateDetailsButton";
            this.updateDetailsButton.Size = new System.Drawing.Size(75, 23);
            this.updateDetailsButton.TabIndex = 7;
            this.updateDetailsButton.Text = "Details";
            this.updateDetailsButton.UseVisualStyleBackColor = true;
            this.updateDetailsButton.Click += new System.EventHandler(this.updateDetailsButton_Click);
            // 
            // totalAmmountLabel
            // 
            this.totalAmmountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalAmmountLabel.AutoSize = true;
            this.totalAmmountLabel.Location = new System.Drawing.Point(432, 11);
            this.totalAmmountLabel.Name = "totalAmmountLabel";
            this.totalAmmountLabel.Size = new System.Drawing.Size(55, 15);
            this.totalAmmountLabel.TabIndex = 6;
            this.totalAmmountLabel.Text = "£ 5643.21";
            // 
            // totalLabel
            // 
            this.totalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(346, 11);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(85, 15);
            this.totalLabel.TabIndex = 5;
            this.totalLabel.Text = "Total in Basket:";
            // 
            // setUsualButton
            // 
            this.setUsualButton.Location = new System.Drawing.Point(3, 3);
            this.setUsualButton.Name = "setUsualButton";
            this.setUsualButton.Size = new System.Drawing.Size(75, 23);
            this.setUsualButton.TabIndex = 5;
            this.setUsualButton.Text = "Set Usual";
            this.setUsualButton.UseVisualStyleBackColor = true;
            this.setUsualButton.Click += new System.EventHandler(this.setUsualButton_Click);
            // 
            // orderButton
            // 
            this.orderButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.orderButton.Location = new System.Drawing.Point(159, 656);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(332, 23);
            this.orderButton.TabIndex = 4;
            this.orderButton.Text = "Order!";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.Click += new System.EventHandler(this.orderButton_Click);
            // 
            // basketListView
            // 
            this.basketListView.AllowDrop = true;
            this.basketListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.basketListView.HideSelection = false;
            this.basketListView.Location = new System.Drawing.Point(3, 29);
            this.basketListView.Name = "basketListView";
            this.basketListView.Size = new System.Drawing.Size(488, 621);
            this.basketListView.TabIndex = 0;
            this.basketListView.UseCompatibleStateImageBehavior = false;
            this.basketListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.basketListView_DragDrop);
            this.basketListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.basketListView_DragEnter);
            this.basketListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.basketListView_KeyUp);
            this.basketListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.basketListView_MouseClick);
            this.basketListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.basketListView_MouseDoubleClick);
            // 
            // UoMChemistryStores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 691);
            this.Controls.Add(this.splitContainer1);
            this.Name = "UoMChemistryStores";
            this.Text = "UoM Chemistry Stores";
            this.MaximizedBoundsChanged += new System.EventHandler(this.UoMChemistryStores_MaximizedBoundsChanged);
            this.MaximumSizeChanged += new System.EventHandler(this.UoMChemistryStores_MaximumSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UoMChemistryStores_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.UoMChemistryStores_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.UoMChemistryStores_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.UoMChemistryStores_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.UoMChemistryStores_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView categoriesTreeView;
        private System.Windows.Forms.ListView basketListView;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ListView itemListView;
        private System.Windows.Forms.Button setUsualButton;
        private System.Windows.Forms.Button orderButton;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label totalAmmountLabel;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button orderUsualButton;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Button updateDetailsButton;
        private System.Windows.Forms.Button minusButtonForBasket;
        private System.Windows.Forms.Button plusButtonForBasket;
        private System.Windows.Forms.Button favouriteButton;
        private System.Windows.Forms.Button orderLogsButton;
    }
}

