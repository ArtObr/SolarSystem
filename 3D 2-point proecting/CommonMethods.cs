using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _3D_2_point_proecting
{
    delegate Point Del(TVector vec);
    delegate TVector Deleg(TVector vec);
    public struct TVector
    {
        public double x, y, z;
        public TVector(double x, double y, double z)
        {
            this.x = x; this.y = y; this.z = z;
        }
    }
    public struct DoubleInt
    {
        public double distance;
        public int index, quarter;
    }
    public struct Coordinates
    {
        public double x;
        public double y;
        public double z;
        public Coordinates(double x, double y, double z)
        {
            this.x = x; this.y = y; this.z = z;
        }
    }
    public struct Mission
    {
        public double x, y, z;
        public Mission(double x, double y, double z)
        {
            this.x = x; this.y = y; this.z = z;
        }
    }
    public enum Direction
    {
        up, down, left, right
    };
    public enum StateOfPoliceman
    {
        onbase, onpatroll, gobase, gopatroll
    }
    
    class CommonMethods
    {
        
        //-----------------------------------------------------------------------
        
        public Planet[] Sort(Planet[] pl)
        {
            
            Planet[] Newpl = new Planet[pl.Length];
            int i = 0;
            foreach (var Planet in pl.OrderBy(pl1 => pl1.GetScreenZ()))
            {
                Newpl[i++] = Planet;
            }
            return Newpl;
            //
            //DoubleInt[] mas = new DoubleInt[pl.Length];
            //    int a = 0;
            ////if (Bet > 4.7 && Bet < 1.6)
            ////{
            //    if (Alf < 4.8 && Alf > 3.1)//1
            //    {
            //        a = 1;
            //    }
            //    if (Alf < 3.2 && Alf > 1.5)//2
            //    {
            //        a = 2;
            //    }
            //    if (Alf < 1.6 && Alf > 0)//3
            //    {
            //        a = 3;
            //    }
            //if (Alf < 0.1 && Alf > 4.7)//4
            //{
            //    a = 4;
            //}
            //for (int i = 0; i < mas.Length; i++)
            //{
            //    double x = 0, y = 0;

            //    switch (a)
            //    {
            //        case 1:
            //            x = pl[i].X();
            //            y = pl[i].Y();
            //            break;
            //        case 2:
            //            x = -pl[i].X();
            //            y = pl[i].Y();
            //            break;
            //        case 3:
            //            x = -pl[i].X();
            //            y = -pl[i].Y();
            //            break;
            //        case 4:
            //            x = pl[i].X();
            //            y = -pl[i].Y();
            //            break;
            //    }
            //    if (x == 0 && y == 0)
            //        mas[i].quarter = 2;
            //    else
            //    {
            //        if (x > 0)
            //        {
            //            if (y > 0)
            //                mas[i].quarter = 2;
            //            else
            //                mas[i].quarter = 1;
            //        }
            //        else
            //        {
            //            if (y > 0)
            //                mas[i].quarter = 1;
            //            else
            //                mas[i].quarter = 0;
            //        }
            //    }
            //    mas[i].distance = Math.Abs(x * y);
            //    mas[i].index = pl[i].GetIndex();
            //}
            //int k = 0;
            //foreach (var p in mas.OrderBy(mas1 => mas1.quarter).ThenBy(mas1 => mas1.distance))
            // {
            //    Newpl[k] = pl[FindPlanet(pl, p.index)];
            //    k++;
            //}
            //return Newpl;
        }
        public int FindPlanet(Planet[] pl, string name)
        {
            for (int i = 0; i < pl.Length; i++)
            {
                if (pl[i].GetName() == name)
                    return i;
            }
            return -1;
        }
    }
    
}
