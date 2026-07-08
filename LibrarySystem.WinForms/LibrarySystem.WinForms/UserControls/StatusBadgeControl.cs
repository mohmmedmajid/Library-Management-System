using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.UserControls
{
    public partial class StatusBadgeControl : UserControl
    {
        private bool _isActive = true;

        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                UpdateStatus();
            }
        }

        public StatusBadgeControl()
        {
            InitializeComponent();
        }

        private void UpdateStatus()
        {
            if (_isActive)
            {
                lblStatus.Text = "● Active";
                lblStatus.ForeColor = Color.FromArgb(40, 160, 100);
                this.BackColor = Color.FromArgb(220, 245, 230);
            }
            else
            {
                lblStatus.Text = "● Inactive";
                lblStatus.ForeColor = Color.FromArgb(180, 50, 50);
                this.BackColor = Color.FromArgb(245, 220, 220);
            }
        }
    }
}