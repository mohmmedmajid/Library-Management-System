namespace LibrarySystem.WinForms.UserControls
{
    partial class StatusBadgeControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // UserControl
            this.Size = new System.Drawing.Size(100, 28);
            this.BackColor = System.Drawing.Color.FromArgb(220, 245, 230);

            // lblStatus
            this.lblStatus.Text = "● Active";
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;

            this.Controls.Add(this.lblStatus);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblStatus;
    }
}