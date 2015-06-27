using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NihilKri;

namespace RainbowSquared {
	public partial class Form1 : Form {
		#region Variables
		Graphics gb, gf; Bitmap gi;
		int fx, fx2, fy, fy2;

		#endregion Variables
		public Form1() {InitializeComponent();}
		private void Form1_Load(object sender, EventArgs e) {
			fx2 = (fx = Width) / 2; fy2 = (fy = Height) / 2;
			gb = Graphics.FromImage(gi = new Bitmap(fx, fy));
			gf = CreateGraphics();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			gf.DrawImage(gi, 0, 0);
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			switch(e.KeyCode) {
				case Keys.Escape: Close(); break;
				case Keys.Space: Draw(); break;

			}
		}

		private void Draw() {
			Complex p = new Complex(0, 0, true);
			Complex q = new Complex(0, 0, true);
			double t = 2.0 * Math.PI / (fx / 1.25);
			Color pc, qc, c;
			int r = 0, g = 0, b = 0;
			for(int x = 0 ; x < fx ; x++) {
				p.cis(0.99, t * x);
				pc = Color.FromArgb(p.c);
				for(int y = 0 ; y < fy ; y++) {
					q.cis(0.99, t * y);
					qc = Color.FromArgb(q.c);
					//r = (int)(255.0 * ((pc.R / 255.0) * (qc.R / 255.0)));
					//g = (int)(255.0 * ((pc.G / 255.0) * (qc.G / 255.0)));
					//b = (int)(255.0 * ((pc.B / 255.0) * (qc.B / 255.0)));
					//r = (x > fx / 5 * 2) ? 0 : pc.R ^ qc.R;
					//g = (x < fx / 5 * 1 || x > fx / 5 * 4) ? 0 : pc.G ^ qc.G;
					//b = (x < fx / 5 * 3) ? 0 : pc.B ^ qc.B;
					r = pc.R ^ qc.R;
					g = pc.G ^ qc.G;
					b = pc.B ^ qc.B;
					c = Color.FromArgb(255, r, g, b);
					gi.SetPixel(x, y, c);
				}
				gf.DrawLine(new Pen(pc), x, 0, x, fy);
			}
			gf.DrawImage(gi, 0, 0);
		}
	}
}
