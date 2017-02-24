using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _3D_2_point_proecting
{
    class Planet
    {
        string name;
        Brush br;
        double x, y, z;
        int r, orbit;
        int DrawR;
        double angle, speed;
        int ScreenZ = 0;
        bool isCrime = false;
        public Planet(int x, int y, int z, TextureBrush br, string name, int r, double speed)
        {
            this.x = x;
            this.y = orbit = y;
            this.z = z;
            this.br = br;
            this.name = name;
            this.r = r;
            this.speed = speed;
            angle = 0;
        }
        public void DrawPlanet(Graphics g, Deleg dl)
        {
            //IJ(new TVector(x, y, z))
            TVector A = dl(new TVector(x, y, z));
            Point p = new Point((int)A.x, (int)A.y);
            Rectangle rect = new Rectangle(p, new Size(DrawR, DrawR));
            rect.X -= DrawR/2;
            rect.Y -= DrawR/2;
            ScreenZ = (int)A.z;
            g.FillEllipse(br, rect);
            g.DrawString(name, new Font("Times New Roman", 12), Brushes.White, p);
        }
        public void Calculate(int scale, double speed)
        {
            if (scale == 0)
                scale = 10;
            if (name == "sun")
            {
                
                DrawR = r / scale;
            }
            else
            {

                if (angle > 2 * Math.PI)
                    angle = 0;
                angle += this.speed * speed;
                DrawR = r / scale;
                x = Math.Cos(angle) * orbit;
                y = Math.Sin(angle) * orbit;
            }
        }
        public double GetDistance()
        {
            return x * y;
        }
        public string GetName()
        {
            return name;
        }
        public double X()
        {
            return x;
        }
        public double Y()
        {
            return y;
        }
        public Coordinates GetCoords()
        {
            return new Coordinates(x, y, z);
        }
        public int GetScreenZ()
        {
            return ScreenZ;
        }
    }
}
