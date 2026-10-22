namespace task4.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView gridBooks;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.GroupBox grpEditor;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.DateTimePicker dtPublishDate;
        private System.Windows.Forms.CheckBox chkHasPublishDate;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.NumericUpDown numStock;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gridBooks = new System.Windows.Forms.DataGridView();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpEditor = new System.Windows.Forms.GroupBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtIsbn = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.dtPublishDate = new System.Windows.Forms.DateTimePicker();
            this.chkHasPublishDate = new System.Windows.Forms.CheckBox();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridBooks)).BeginInit();
            this.grpEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(12, 12);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(300, 25);
            this.txtKeyword.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(318, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 28);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(414, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 28);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gridBooks
            // 
            this.gridBooks.AllowUserToAddRows = false;
            this.gridBooks.AllowUserToDeleteRows = false;
            this.gridBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBooks.Location = new System.Drawing.Point(12, 46);
            this.gridBooks.MultiSelect = false;
            this.gridBooks.Name = "gridBooks";
            this.gridBooks.ReadOnly = true;
            this.gridBooks.RowHeadersVisible = false;
            this.gridBooks.RowTemplate.Height = 27;
            this.gridBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridBooks.Size = new System.Drawing.Size(640, 510);
            this.gridBooks.TabIndex = 3;
            this.gridBooks.SelectionChanged += new System.EventHandler(this.gridBooks_SelectionChanged);
            // 
            // Columns
            // 
            var colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.FillWeight = 20;
            var colIsbn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colIsbn.DataPropertyName = "Isbn";
            colIsbn.HeaderText = "ISBN";
            var colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTitle.DataPropertyName = "Title";
            colTitle.HeaderText = "书名";
            var colAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colAuthor.DataPropertyName = "Author";
            colAuthor.HeaderText = "作者";
            var colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colStock.DataPropertyName = "Stock";
            colStock.HeaderText = "库存";
            colStock.FillWeight = 30;
            this.gridBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colId, colIsbn, colTitle, colAuthor, colStock });

            // 
            // grpEditor
            // 
            this.grpEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEditor.Controls.Add(new System.Windows.Forms.Label() { Text = "ID", Location = new System.Drawing.Point(16, 30), AutoSize = true });
            this.grpEditor.Controls.Add(this.txtId);
            this.grpEditor.Controls.Add(new System.Windows.Forms.Label() { Text = "ISBN*", Location = new System.Drawing.Point(16, 65), AutoSize = true });
            this.grpEditor.Controls.Add(this.txtIsbn);
            this.grpEditor.Controls.Add(new System.Windows.Forms.Label() { Text = "书名*", Location = new System.Drawing.Point(16, 100), AutoSize = true });
            this.grpEditor.Controls.Add(this.txtTitle);
            this.grpEditor.Controls.Add(new System.Windows.Forms.Label() { Text = "作者", Location = new System.Drawing.Point(16, 135), AutoSize = true });
            this.grpEditor.Controls.Add(this.txtAuthor);
            this.grpEditor.Controls.Add(new System.Windows.Forms.Label() { Text = "出版社", Location = new System.Drawing.Point(16, 170), AutoSize = true });
            this.grpEditor.Controls.Add(this.txtPublisher);
            this.grpEditor.Controls.Add(this.chkHasPublishDate);
            this.grpEditor.Controls.Add(this.dtPublishDate);
            this.grpEditor.Controls.Add(new System.Windows.Forms.Label() { Text = "价格", Location = new System.Drawing.Point(16, 245), AutoSize = true });
            this.grpEditor.Controls.Add(this.numPrice);
            this.grpEditor.Controls.Add(new System.Windows.Forms.Label() { Text = "库存", Location = new System.Drawing.Point(16, 280), AutoSize = true });
            this.grpEditor.Controls.Add(this.numStock);
            this.grpEditor.Controls.Add(this.btnAdd);
            this.grpEditor.Controls.Add(this.btnUpdate);
            this.grpEditor.Controls.Add(this.btnDelete);
            this.grpEditor.Controls.Add(this.btnClear);
            this.grpEditor.Location = new System.Drawing.Point(668, 12);
            this.grpEditor.Name = "grpEditor";
            this.grpEditor.Size = new System.Drawing.Size(320, 544);
            this.grpEditor.TabIndex = 4;
            this.grpEditor.TabStop = false;
            this.grpEditor.Text = "图书信息";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(88, 27);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(210, 25);
            this.txtId.TabIndex = 10;
            // 
            // txtIsbn
            // 
            this.txtIsbn.Location = new System.Drawing.Point(88, 62);
            this.txtIsbn.Name = "txtIsbn";
            this.txtIsbn.Size = new System.Drawing.Size(210, 25);
            this.txtIsbn.TabIndex = 11;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(88, 97);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(210, 25);
            this.txtTitle.TabIndex = 12;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(88, 132);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(210, 25);
            this.txtAuthor.TabIndex = 13;
            // 
            // txtPublisher
            // 
            this.txtPublisher.Location = new System.Drawing.Point(88, 167);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(210, 25);
            this.txtPublisher.TabIndex = 14;
            // 
            // chkHasPublishDate
            // 
            this.chkHasPublishDate.AutoSize = true;
            this.chkHasPublishDate.Location = new System.Drawing.Point(18, 210);
            this.chkHasPublishDate.Name = "chkHasPublishDate";
            this.chkHasPublishDate.Size = new System.Drawing.Size(89, 19);
            this.chkHasPublishDate.TabIndex = 15;
            this.chkHasPublishDate.Text = "出版日期";
            this.chkHasPublishDate.UseVisualStyleBackColor = true;
            // 
            // dtPublishDate
            // 
            this.dtPublishDate.Location = new System.Drawing.Point(113, 206);
            this.dtPublishDate.Name = "dtPublishDate";
            this.dtPublishDate.Size = new System.Drawing.Size(185, 25);
            this.dtPublishDate.TabIndex = 16;
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(88, 243);
            this.numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(210, 25);
            this.numPrice.TabIndex = 17;
            // 
            // numStock
            // 
            this.numStock.Location = new System.Drawing.Point(88, 278);
            this.numStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(210, 25);
            this.numStock.TabIndex = 18;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(18, 330);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 32);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(168, 330);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 32);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(18, 372);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 32);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(168, 372);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(130, 32);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 568);
            this.Controls.Add(this.grpEditor);
            this.Controls.Add(this.gridBooks);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtKeyword);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图书管理系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBooks)).EndInit();
            this.grpEditor.ResumeLayout(false);
            this.grpEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
