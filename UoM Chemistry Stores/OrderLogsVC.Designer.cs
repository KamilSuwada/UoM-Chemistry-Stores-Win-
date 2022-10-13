
namespace UoM_Chemistry_Stores
{
    partial class OrderLogsVC
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.reorderButton = new System.Windows.Forms.Button();
            this.dateTreeView = new System.Windows.Forms.TreeView();
            this.ppeCodeLabel = new System.Windows.Forms.Label();
            this.orderLogTotalLabel = new System.Windows.Forms.Label();
            this.codeLabel = new System.Windows.Forms.Label();
            this.labLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.itemsListView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.addButton);
            this.splitContainer1.Panel1.Controls.Add(this.deleteButton);
            this.splitContainer1.Panel1.Controls.Add(this.reorderButton);
            this.splitContainer1.Panel1.Controls.Add(this.dateTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ppeCodeLabel);
            this.splitContainer1.Panel2.Controls.Add(this.orderLogTotalLabel);
            this.splitContainer1.Panel2.Controls.Add(this.codeLabel);
            this.splitContainer1.Panel2.Controls.Add(this.labLabel);
            this.splitContainer1.Panel2.Controls.Add(this.nameLabel);
            this.splitContainer1.Panel2.Controls.Add(this.itemsListView);
            this.splitContainer1.Size = new System.Drawing.Size(576, 568);
            this.splitContainer1.SplitterDistance = 171;
            this.splitContainer1.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(3, 4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 36);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(93, 519);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 37);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // reorderButton
            // 
            this.reorderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.reorderButton.Location = new System.Drawing.Point(3, 519);
            this.reorderButton.Name = "reorderButton";
            this.reorderButton.Size = new System.Drawing.Size(75, 37);
            this.reorderButton.TabIndex = 5;
            this.reorderButton.Text = "Reorder";
            this.reorderButton.UseVisualStyleBackColor = true;
            this.reorderButton.Click += new System.EventHandler(this.reorderButton_Click);
            // 
            // dateTreeView
            // 
            this.dateTreeView.AllowDrop = true;
            this.dateTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTreeView.Location = new System.Drawing.Point(3, 44);
            this.dateTreeView.Name = "dateTreeView";
            this.dateTreeView.Size = new System.Drawing.Size(165, 469);
            this.dateTreeView.TabIndex = 0;
            this.dateTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.dateTreeView_AfterSelect);
            this.dateTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.dateTreeView_DragDrop);
            this.dateTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.dateTreeView_DragEnter);
            // 
            // ppeCodeLabel
            // 
            this.ppeCodeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ppeCodeLabel.AutoSize = true;
            this.ppeCodeLabel.Location = new System.Drawing.Point(195, 25);
            this.ppeCodeLabel.Name = "ppeCodeLabel";
            this.ppeCodeLabel.Size = new System.Drawing.Size(30, 15);
            this.ppeCodeLabel.TabIndex = 4;
            this.ppeCodeLabel.Text = "PPE:";
            // 
            // orderLogTotalLabel
            // 
            this.orderLogTotalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.orderLogTotalLabel.AutoSize = true;
            this.orderLogTotalLabel.Location = new System.Drawing.Point(260, 519);
            this.orderLogTotalLabel.Name = "orderLogTotalLabel";
            this.orderLogTotalLabel.Size = new System.Drawing.Size(114, 15);
            this.orderLogTotalLabel.TabIndex = 8;
            this.orderLogTotalLabel.Text = "Total for order: £0.00";
            // 
            // codeLabel
            // 
            this.codeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(195, 5);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.codeLabel.Size = new System.Drawing.Size(38, 15);
            this.codeLabel.TabIndex = 3;
            this.codeLabel.Text = "Code:";
            // 
            // labLabel
            // 
            this.labLabel.AutoSize = true;
            this.labLabel.Location = new System.Drawing.Point(4, 25);
            this.labLabel.Name = "labLabel";
            this.labLabel.Size = new System.Drawing.Size(38, 15);
            this.labLabel.TabIndex = 2;
            this.labLabel.Text = "From:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(4, 5);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(42, 15);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name:";
            // 
            // itemsListView
            // 
            this.itemsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsListView.HideSelection = false;
            this.itemsListView.Location = new System.Drawing.Point(3, 44);
            this.itemsListView.Name = "itemsListView";
            this.itemsListView.Size = new System.Drawing.Size(395, 469);
            this.itemsListView.TabIndex = 0;
            this.itemsListView.UseCompatibleStateImageBehavior = false;
            // 
            // OrderLogsVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 568);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OrderLogsVC";
            this.Text = "OrderLogsVC";
            this.ResizeEnd += new System.EventHandler(this.OrderLogsVC_ResizeEnd);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView dateTreeView;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ListView itemsListView;
        private System.Windows.Forms.Label ppeCodeLabel;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label labLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button reorderButton;
        private System.Windows.Forms.Label orderLogTotalLabel;
        private System.Windows.Forms.Button addButton;
    }
}