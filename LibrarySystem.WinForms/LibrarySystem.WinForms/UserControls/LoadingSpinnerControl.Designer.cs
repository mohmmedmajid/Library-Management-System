namespace LibrarySystem.WinForms.UserControls
{
    partial class LoadingSpinnerControl
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
            this.SuspendLayout();

            this.Size = new System.Drawing.Size(50, 50);
            this.BackColor = System.Drawing.Color.Transparent;
            this.Visible = false;

            this.ResumeLayout(false);
        }
    }
}