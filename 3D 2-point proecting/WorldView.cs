using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_2_point_proecting
{
    class WorldView
    {
        double Alf;
        double Bet;
        public double fxc;
        public double fyc;
        public double fzc;
        int Xmin;
        int Xmax;
        int Ymin;
        int Ymax;
        int I2;
        int J2;
        int K2;
        public WorldView()
        {
            Alf = Math.PI;
            Bet = Math.PI;
            fxc = 0;
            fyc = 0;
            fzc = 0;
            Xmin = -10;
            Xmax = 10;
            Ymin = -10;
            Ymax = 10;
            I2 = 650;//bitmap width
            J2 = 850;//bitmap heigh
            K2 = 1000;
        } //конструктор
        public void SetScale(double x, double y, double z)
        {
            double l = Math.Sqrt(x * x + y * y + z * z);
            Xmin = Ymin = (int)-l;
            Xmax = Ymax = (int)l;
        }
        public Point IJ(TVector P)
        {
            double Xn = (P.x - fxc) * Math.Cos(Alf) - (P.y - fyc) * Math.Sin(Alf);
            double Yn = ((P.x - fxc) * Math.Sin(Alf) + (P.y - fyc) * Math.Cos(Alf)) * Math.Cos(Bet) - (P.z - fzc) * Math.Sin(Bet);
            double Zn = ((P.x - fxc) * Math.Sin(Alf) + (P.y - fyc) * Math.Cos(Alf)) * Math.Sin(Bet) + (P.z - fzc) * Math.Cos(Bet);
            int X = (int)Math.Round(I2 * (Xn - Xmin) / (Xmax - Xmin));
            int Y = (int)Math.Round(J2 * (Yn - Ymax) / (Ymin - Ymax));
            int Z = (int)Math.Round(K2 * Zn);

            return new Point(X, Y);
        }
        public TVector IJPlanet(TVector P)
        {
            double Xn = (P.x - fxc) * Math.Cos(Alf) - (P.y - fyc) * Math.Sin(Alf);
            double Yn = ((P.x - fxc) * Math.Sin(Alf) + (P.y - fyc) * Math.Cos(Alf)) * Math.Cos(Bet) - (P.z - fzc) * Math.Sin(Bet);
            double Zn = ((P.x - fxc) * Math.Sin(Alf) + (P.y - fyc) * Math.Cos(Alf)) * Math.Sin(Bet) + (P.z - fzc) * Math.Cos(Bet);
            int X = (int)Math.Round(I2 * (Xn - Xmin) / (Xmax - Xmin));
            int Y = (int)Math.Round(J2 * (Yn - Ymax) / (Ymin - Ymax));
            int Z = (int)Math.Round(K2 * Zn);
            return new TVector(X, Y, Z);
        }
        public void ChangeView(Direction drt, double step = 0.05)//изменяет угол обзора (alf, bet)
        {
            switch (drt)
            {
                case Direction.down:
                    if (Bet >= 2* Math.PI)
                        Bet = 0;
                    Bet += Math.PI/50;
                    break;
                case Direction.up:
                    if (Bet <= 0)
                        Bet = 2* Math.PI;
                    Bet -= Math.PI/50;
                    break;
                case Direction.left:
                    if (Alf >= 2* Math.PI)
                        Alf = 0;
                    Alf += Math.PI/50;
                    break;
                case Direction.right:
                    if (Alf <= 0)
                        Alf = 2* Math.PI;
                    Alf -= Math.PI/50;
                    break;
            }
        }
        public void ChangeDistance(Direction drt)//контролирует приближение/отдаление
        {
            switch (drt)
            {
                case Direction.down:
                    if (Xmax > 1)
                    {
                        Xmin = Ymin += 1;
                        Xmax = Ymax -= 1;
                    }
                    break;
                case Direction.up:
                    Xmin = Ymin -= 1;
                    Xmax = Ymax += 1;
                    break;
            }
        }
        public int GetScale()
        {
            return Xmax;
        }
        public double GetAlf()
        {
            return Alf;
        }
        public double GetBet()
        {
            return Bet;
        }
        
    }
}
