using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tunnel_Vision
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int _dimension = 100;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Up:
                    _dimension++;
                    break;
                case Keys.Down:
                    _dimension--;
                    break;
                case Keys.Left:
                    Opacity -= 0.05;
                    break;
                case Keys.Right:
                    Opacity += 0.05;
                    break;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            using (var gp = new GraphicsPath())
            {
                gp.AddRectangle(ClientRectangle);
                gp.AddEllipse(Cursor.Position.X - _dimension / 2, Cursor.Position.Y - _dimension / 2, _dimension, _dimension);
                Region = new Region(gp);
            }
            
        }
    }
}
