using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoShutdown
{
    public partial class AutoShutdown : Form
    {
        public AutoShutdown()
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            base.OnPaint(e);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            bool validHours = int.TryParse(textBox1.Text, out int hours);
            bool validMinutes = int.TryParse(textBox2.Text, out int minutes);
            if (validMinutes || validHours)
            {
                int totalMilliseconds = (hours * 60 + minutes) * 60 * 1000;
                MessageBox.Show($"Компьютер будет выключен через {hours} ч. {minutes} мин.");
                await Task.Delay(totalMilliseconds);
                System.Diagnostics.Process.Start("shutdown", "/s /t 0");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("shutdown", "/a");
            MessageBox.Show("Авто-выключение отменено.");
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        }
    }
}
