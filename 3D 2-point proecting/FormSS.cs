using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace _3D_2_point_proecting
{
    public partial class FormSS : Form
    {
        
        MainWorld dr = new MainWorld();
        Graphics g;
        public FormSS()
        {
            InitializeComponent();
        }

        private void Drawing()
        {
            g.DrawImage(dr.Draw(), 0, 0);
            
            
        }

        private void Form_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            FPS.Start();
            this.MouseWheel += new MouseEventHandler(FormSS_MouseWheel);
            
        }

        void FormSS_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                dr.WrldV.ChangeDistance(Direction.down);
            if (e.Delta < 0)
                dr.WrldV.ChangeDistance(Direction.up);
        }

        private void FormSS_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        
                        dr.WrldV.ChangeView(Direction.down);
                    }
                    break;
                case Keys.Down:
                    {
                        dr.WrldV.ChangeView(Direction.up);
                    }
                    break;
                case Keys.Left:
                    {
                        dr.WrldV.ChangeView(Direction.right);
                    }
                    break;
                case Keys.Right:
                    {
                        
                        dr.WrldV.ChangeView(Direction.left);
                    }
                    break;
                case Keys.Space:
                    {
                        if (FPS.Enabled)
                            FPS.Stop();
                        else
                            FPS.Start();
                    }
                    break;
                case Keys.W:
                    {
                        
                        dr.spd += 0.05;
                    }
                    break;
                case Keys.S:
                    {
                        if (dr.spd > 0)
                            dr.spd -= 0.05;
                    }
                    break;
            }
        }

        private void FPS_Tick(object sender, EventArgs e)
        {
            Drawing();
            //FPS.Stop();
        }
        
    }
}
