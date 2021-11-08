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

        static List<Movie> movies = new List<Movie>() {
            new Movie("The Shawshank Redemption", "Adventure", 10, new DateTime(2000, 4, 5), "Frank Darabont", new List<string>{"Nicole Kidman"}, "Crime, Drama", new TimeSpan(2, 56, 0)),

            new Movie("Bulsula de ouro", "Adventure", 10, new DateTime(2000, 4, 5), "Frank Darabont", new List<string>{"Nicole Kidman"}, "Crime, Drama", new TimeSpan(2, 40, 0))
        };

        public Form1() {
            InitializeComponent();
            this.Padding = new Padding(2);
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void addMovie(object sender, EventArgs e) {
            Movie temp = new Movie();
            Form2 form = new Form2(temp);
            form.ShowDialog();
            Console.WriteLine(temp.title + "title");
            textBoxBorder1.text = temp.ToString();
            movies.Add(temp);
        }

        public void listMovies() {
            string temp = "";
            foreach(Movie movie in movies) {
                temp += movie.title + "\r\n";
            }
            this.textBoxBorder1.text = temp;
        }

        private void move(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void close(object sender, EventArgs e) {
            this.Close();
        }

        private void listMovies(object sender, EventArgs e) {
            listMovies();
        }
    }
}
