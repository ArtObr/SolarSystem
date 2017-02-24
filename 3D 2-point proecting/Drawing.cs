using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _3D_2_point_proecting
{
    class MainWorld
    {
        Player plr = new Player();
        CommonMethods CM = new CommonMethods();
        public WorldView WrldV = new WorldView();
        Planet[] pl;
        PoliceStation PS = new PoliceStation();
        Bitmap btm1 = new System.Drawing.Bitmap(Properties.Resources.Falcon);
        Bitmap btm = new Bitmap(850, 650);
        //
        public double spd;
        public double speed
        {
            set { spd = value; }
            get { return spd; }
        }
        private void PlanetFilling()
        {
            //sun
            //if (pl.Length == 10)
            // Planet[] pl = new Planet[9];
            pl = new Planet[9];
            pl[0] = new Planet(0, 0, 0,
                new TextureBrush(Properties.Resources.sun, new Rectangle(0, 0,
                Properties.Resources.sun.Size.Width, Properties.Resources.sun.Size.Height)),
                "sun", 800, 0);

            pl[1] = new Planet(0, 2, 0,
                new TextureBrush(Properties.Resources.mercury, new Rectangle(0, 0,
                Properties.Resources.mercury.Size.Width, Properties.Resources.mercury.Size.Height)),
                "mercury", 150, Math.PI / 100);

            pl[2] = new Planet(0, 3, 0,
                new TextureBrush(Properties.Resources.venus, new Rectangle(0, 0,
                Properties.Resources.venus.Size.Width, Properties.Resources.venus.Size.Height)),
                "venus", 300, Math.PI / 130);

            pl[3] = new Planet(0, 6, 0,
                new TextureBrush(Properties.Resources.earth, new Rectangle(0, 0,
                Properties.Resources.earth.Size.Width, Properties.Resources.earth.Size.Height)),
                "earth", 320, Math.PI / 150);

            pl[4] = new Planet(0, 12, 0,
               new TextureBrush(Properties.Resources.mars, new Rectangle(0, 0,
               Properties.Resources.mars.Size.Width, Properties.Resources.mars.Size.Height)),
               "mars", 180, Math.PI / 170);

            pl[5] = new Planet(0, 17, 0,
               new TextureBrush(Properties.Resources.jupiter, new Rectangle(0, 0,
               Properties.Resources.jupiter.Size.Width, Properties.Resources.jupiter.Size.Height)),
               "jupiter", 600, Math.PI / 200);

            pl[6] = new Planet(0, 23, 0,
              new TextureBrush(Properties.Resources.saturn, new Rectangle(0, 0,
              Properties.Resources.saturn.Size.Width, Properties.Resources.saturn.Size.Height)),
              "saturn", 500, Math.PI / 220);

            pl[7] = new Planet(0, 27, 0,
              new TextureBrush(Properties.Resources.uranus, new Rectangle(0, 0,
              Properties.Resources.uranus.Size.Width, Properties.Resources.uranus.Size.Height)),
              "uranus", 400, Math.PI / 240);

            pl[8] = new Planet(0, 31, 0,
              new TextureBrush(Properties.Resources.neptun, new Rectangle(0, 0,
              Properties.Resources.neptun.Size.Width, Properties.Resources.neptun.Size.Height)),
              "neptun", 430, Math.PI / 250);
        }
        public MainWorld()
        {
            PlanetFilling();
            spd = 1;
            btm1.MakeTransparent(Color.White);
        }
        //--------------------------------------------------
        public Image Draw()
        {

            using (Graphics g = Graphics.FromImage(btm))
            {
                g.Clear(Color.Black);
                CM.Sort(pl);
                foreach (var planet in pl)
                {
                    planet.Calculate(WrldV.GetScale(), spd);
                    
                    planet.DrawPlanet(g, WrldV.IJPlanet);
                }
                DrawCoordLines(g);
            }

            return btm;
        }
        void DrawFalcon(Graphics g)
        {
            g.DrawImage(btm1, 300, 400);
        }
        void DrawCoordLines(Graphics g)
        {
            Point P0, P1;
            TVector P; 
            P = new TVector(0, 0, 0); P0 = WrldV.IJ(P); // *00
            P = new TVector(3, 0, 0); P1 = WrldV.IJ(P);
            g.DrawLine(Pens.White, P0, P1);
            g.DrawString("X", new Font("Times New Roman", 12), Brushes.Red, P1);

            P = new TVector(0, 0, 0); P0 = WrldV.IJ(P); // 0*0
            P = new TVector(0, 3, 0); P1 = WrldV.IJ(P);
            g.DrawLine(Pens.White, P0, P1);
            g.DrawString("Y", new Font("Times New Roman", 12), Brushes.Red, P1);

            P = new TVector(0, 0, 0); P0 = WrldV.IJ(P); // 00*
            P = new TVector(0, 0, 3); P1 = WrldV.IJ(P);
            g.DrawLine(Pens.White, P0, P1);
            g.DrawString("Z", new Font("Times New Roman", 12), Brushes.Red, P1);
        }

    }
}
