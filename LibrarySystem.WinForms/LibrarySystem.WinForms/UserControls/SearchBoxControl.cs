using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.UserControls
{
    public partial class SearchBoxControl : UserControl
    {
        public event EventHandler<string> OnSearch;

        public SearchBoxControl()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            OnSearch?.Invoke(this, txtSearch.Text);
        }

        private void txtSearch_GotFocus(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = "Search...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        public void Clear()
        {
            txtSearch.Text = "";
        }

        public string SearchText =>
            txtSearch.Text == "Search..." ? "" : txtSearch.Text;

        private void SearchBoxControl_Load(object sender, EventArgs e)
        {

        }
    }
}