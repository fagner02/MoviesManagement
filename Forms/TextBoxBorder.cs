using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms {
    public partial class TextBoxBorder : UserControl {

        [Browsable(true)]
        public event EventHandler _TextChanged;

        protected override void OnTextChanged(EventArgs e) {
            _TextChanged?.Invoke(this, e);
            //Console.WriteLine(Text);
        }

        private Color color = Color.White;
        private int borderSize = 1;
        public override Color BackColor { get => base.BackColor;
            set {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }
        public string text {
            get => base.Text;
            set {
                this.Text = value;
                this.textBox1.Text = value;
            }
        }
        public void m(string n) {
            
            //this.textBox1.Text = this.Text;
        }
        [Browsable(true)]
        public Color Color { get => color; set { color = value; this.Invalidate(); } }
        [Browsable(true)]
        public int BorderSize { get => borderSize; set { borderSize = value; this.Invalidate(); } }

        public TextBoxBorder() {
            InitializeComponent();        }

        
        protected override void OnPaint(PaintEventArgs args) {
            base.OnPaint(args);
            Graphics graph = args.Graphics;

            using (Pen pen = new Pen(Color, BorderSize)) {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                graph.DrawRectangle(pen, 0, 0, this.Width - 0.5f, this.Height - 0.5f);
            }
        }
        
        
        private void textBox1_TextChanged(object sender, EventArgs e) {
            Text = textBox1.Text;
        }


    }

    class Counter {
        private int threshold;
        private int total;

        public Counter(int passedThreshold) {
            threshold = passedThreshold;
        }

        public void Add(int x) {
            total += x;
            if (total >= threshold) {
                //ThresholdReached?.Invoke(this, EventArgs.Empty);
            }
        }

        
    }
}
