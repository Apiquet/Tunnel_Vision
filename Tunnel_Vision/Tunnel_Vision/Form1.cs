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

        //set ellipse dimension
        private int _dimension = 100;

        //adding key events
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                //dimension manager
                case Keys.Add:
                    _dimension++;
                    break;
                case Keys.Subtract:
                    _dimension--;
                    break;
                
                //Opacity manager
                case Keys.L:
                    Opacity -= 0.05;
                    break;
                case Keys.H:
                    Opacity += 0.05;
                    break;
                case Keys.Space:
                    Opacity = 1;
                    break;
                case Keys.Delete:
                    Opacity = 0;
                    break;

                //exit app
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        //change position of the ellipse on timer event
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
