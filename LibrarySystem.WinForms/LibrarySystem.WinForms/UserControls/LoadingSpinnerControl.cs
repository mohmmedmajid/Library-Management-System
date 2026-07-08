using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.UserControls
{
    public partial class LoadingSpinnerControl : UserControl
    {
        private Timer _timer;
        private int _angle = 0;

        public LoadingSpinnerControl()
        {
            InitializeComponent();
            _timer = new Timer();
            _timer.Interval = 30;
            _timer.Tick += (s, e) =>
            {
                _angle = (_angle + 10) % 360;
                this.Invalidate();
            };
        }

        public void Start()
        {
            this.Visible = true;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
            this.Visible = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int size = Math.Min(this.Width, this.Height) - 10;
            int x = (this.Width - size) / 2;
            int y = (this.Height - size) / 2;

            using (var pen = new Pen(Color.FromArgb(220, 220, 220), 4))
            {
                g.DrawEllipse(pen, x, y, size, size);
            }

            using (var pen = new Pen(Color.FromArgb(30, 100, 180), 4))
            {
                g.DrawArc(pen, x, y, size, size, _angle, 270);
            }
        }
    }
}