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
using MovieClass;

namespace Forms {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.Padding = new Padding(4);
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void addMovie(object sender, EventArgs e) {
            Movie temp = new Movie();
            Form2 form = new Form2(temp);
            form.Show();
            textBoxBorder1.text = temp.ToString();
        }

        private void move(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void close(object sender, EventArgs e) {
            this.Close();
        }
    }
}
