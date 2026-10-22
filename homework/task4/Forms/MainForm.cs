using System;
using System.Globalization;
using System.Windows.Forms;
using task4.Data.Models;
using task4.Data.Repositories;
using task4.Infrastructure;

namespace task4.Forms
{
    public partial class MainForm : Form
    {
        private readonly BookRepository _repo = new BookRepository();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtKeyword.Text = string.Empty;
            RefreshGrid();
        }

        private void gridBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (gridBooks.CurrentRow == null) return;
            var b = gridBooks.CurrentRow.DataBoundItem as Book;
            if (b == null) return;

            txtId.Text = b.Id.ToString(CultureInfo.InvariantCulture);
            txtIsbn.Text = b.Isbn;
            txtTitle.Text = b.Title;
            txtAuthor.Text = b.Author;
            txtPublisher.Text = b.Publisher;
            dtPublishDate.Value = b.PublishDate ?? DateTime.Today;
            chkHasPublishDate.Checked = b.PublishDate.HasValue;
            numPrice.Value = b.Price < 0 ? 0 : (b.Price > numPrice.Maximum ? numPrice.Maximum : b.Price);
            numStock.Value = b.Stock;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var book = ReadBookFromEditor(requireId: false);
                var id = _repo.Add(book);
                Logger.Info("Book added: " + book.Title + " (" + book.Isbn + ") id=" + id);
                RefreshGrid();
                SelectRowById(id);
            }
            catch (Exception ex)
            {
                Logger.Error("Add book failed", ex);
                MessageBox.Show(ex.Message, "新增失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var book = ReadBookFromEditor(requireId: true);
                _repo.Update(book);
                Logger.Info("Book updated: id=" + book.Id);
                RefreshGrid();
                SelectRowById(book.Id);
            }
            catch (Exception ex)
            {
                Logger.Error("Update book failed", ex);
                MessageBox.Show(ex.Message, "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("请先选择要删除的图书。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                long id;
                if (!long.TryParse(txtId.Text, out id))
                {
                    MessageBox.Show("ID 格式不正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("确认删除该图书？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                _repo.Delete(id);
                Logger.Info("Book deleted: id=" + id);
                RefreshGrid();
                ClearEditor();
            }
            catch (Exception ex)
            {
                Logger.Error("Delete book failed", ex);
                MessageBox.Show(ex.Message, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearEditor();
        }

        private void RefreshGrid()
        {
            try
            {
                var list = _repo.Search(txtKeyword.Text);
                gridBooks.AutoGenerateColumns = false;
                gridBooks.DataSource = list;
            }
            catch (Exception ex)
            {
                Logger.Error("Query books failed", ex);
                MessageBox.Show("查询失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Book ReadBookFromEditor(bool requireId)
        {
            if (requireId)
            {
                long id;
                if (!long.TryParse(txtId.Text, out id) || id <= 0)
                    throw new InvalidOperationException("请先在列表中选择一本图书再进行修改。");
            }

            var isbn = (txtIsbn.Text ?? string.Empty).Trim();
            var title = (txtTitle.Text ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(isbn))
                throw new InvalidOperationException("ISBN 不能为空。");
            if (string.IsNullOrWhiteSpace(title))
                throw new InvalidOperationException("书名不能为空。");

            var b = new Book
            {
                Isbn = isbn,
                Title = title,
                Author = (txtAuthor.Text ?? string.Empty).Trim(),
                Publisher = (txtPublisher.Text ?? string.Empty).Trim(),
                PublishDate = chkHasPublishDate.Checked ? (DateTime?)dtPublishDate.Value.Date : null,
                Price = numPrice.Value,
                Stock = (int)numStock.Value
            };

            long parsedId;
            if (long.TryParse(txtId.Text, out parsedId)) b.Id = parsedId;
            return b;
        }

        private void ClearEditor()
        {
            txtId.Text = string.Empty;
            txtIsbn.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            txtPublisher.Text = string.Empty;
            chkHasPublishDate.Checked = false;
            dtPublishDate.Value = DateTime.Today;
            numPrice.Value = 0;
            numStock.Value = 0;
        }

        private void SelectRowById(long id)
        {
            foreach (DataGridViewRow row in gridBooks.Rows)
            {
                var b = row.DataBoundItem as Book;
                if (b != null && b.Id == id)
                {
                    row.Selected = true;
                    gridBooks.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }
    }
}
