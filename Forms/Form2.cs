using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MovieClass;

namespace Forms {

    
    public partial class Form2 : Form {
        
        public Movie response = new Movie();
        
        public Form2(Movie response) {
            InitializeComponent();
            this.response = response;
        }

        private void addActor(object sender, EventArgs e) {
            TextBoxBorder temp = new TextBoxBorder();
            temp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            temp.BackColor = Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            temp.BorderSize = 1;
            temp.Color = Color.White;
            temp.ForeColor = Color.White;
            temp.Location = new Point(0, 0);
            temp.Margin = new Padding(0, 0, 0, 10);
            //temp.MinimumSize = new System.Drawing.Size(337, 23);
            temp.Name = "actor"+actors.Controls.Count;
            temp.Padding = new Padding(5);
            temp.Size = new Size(237, 23);
            temp.TabIndex = 0;
            temp.text = "";
            actors.Controls.Add(temp);
        }

        private void validateRating(object sender, EventArgs e) {
            string temp = "";
            foreach (Match str in Regex.Matches(ratingText.Text, @"\d+")) {
                temp += str;
            }
            if (temp.Length > 0 && float.Parse(temp) > 10) {
                temp = "10";
            }
            ratingText.text = temp;
        }

        private void validateDuration(object sender, EventArgs e) {
            string temp = "";
            foreach (Match str in Regex.Matches(ratingText.Text, @"\d+")) {
                temp += str;
            }
            ratingText.text = temp;
        }

        private void send(object sender, EventArgs e) {
            response.title = titleText.Text;
            response.genre = genreText.Text;
            response.director = directorText.Text;
            response.releaseDate = releaseDate.Value;
            response.plot = plotText.text;
            if (durationText.Text.Length > 0) {
                response.duration = new TimeSpan(0, int.Parse(durationText.Text), 0);
            }
            if (ratingText.Text.Length > 0) {
                response.rating = int.Parse(ratingText.Text);
            }
            
            foreach (TextBoxBorder actor in actors.Controls) {
                if (actor.Text.Length > 0) {
                    response.actors.Add(actor.Text);
                }
            }
            this.Close();
        }
    }
}
