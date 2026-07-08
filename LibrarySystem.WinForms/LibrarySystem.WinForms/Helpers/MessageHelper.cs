using System.Windows.Forms;

namespace LibrarySystem.WinForms.Helpers
{
    public static class MessageHelper
    {

        public static void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }


        public static bool ShowConfirm(string message)
        {
            var result = MessageBox.Show(message, "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}