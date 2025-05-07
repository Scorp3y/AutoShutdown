using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AutoShutdown
{
    public partial class AutoShutdown : Form
    {

        [DllImport("powrprof.dll", SetLastError = true)]
        static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);

        public AutoShutdown()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int minutes))
            {
                int milliseconds = minutes * 60 * 1000;
                MessageBox.Show($"Компьютер перейдёт в спящий режим через {minutes} мин.");
                await Task.Delay(milliseconds);
                SetSuspendState(false, true, true);
            }
            
        }
    }
}
