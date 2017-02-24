using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_2_point_proecting
{
    class PoliceStation
    {
        int m = 0;
        Coordinates coords;
        Random rnd = new Random();
        List<Policeman> Stuff = new List<Policeman>();
        List<Crime> Crimes = new List<Crime>();
        public PoliceStation()
        {
            coords = new Coordinates(0, 0, 0);//по стандарту, потом их определит SetCoords
            Stuff.Add(new Policeman(1));
            Stuff.Add(new Policeman(2));
            Stuff.Add(new Policeman(3));
        }
        public void Calculate(int scale, Graphics g, Del dl, Planet[] pl)
        {
            foreach (Policeman stuff in Stuff)//первый, тк задает начальные условия полисменов
                stuff.Calculate(coords, scale, g, dl);
            Determiner();
            CrimesSet();
        }
        void Determiner()//отправляет на миссию
        {
            foreach (Policeman stuff in Stuff)
            {
                if (GetPatrollPolicemans() < 2 && stuff.GetState() == StateOfPoliceman.onbase && rnd.Next(1, 500) == 200)
                {
                    stuff.missionExist = true;
                    stuff.SetMisson(new Mission(8, 0, 0));
                }
                if (stuff.GetTime() > 300)
                {
                    stuff.missionExist = true;
                }
            }
        }
        void CrimesSet()//задает преступление
        {
            if (rnd.Next(1, 1000) == 300)
            {
                Crimes.Add(new Crime(++m));
            }
        }
        public void SetCoords(Coordinates coords)
        {
            this.coords = coords;
        }//обновляет координаты станции в соответсвии с координатами земли
        public int GetPatrollPolicemans()
        {
            int a = 0;
            foreach (Policeman stuff in Stuff)
                if (stuff.GetState() == StateOfPoliceman.onpatroll || stuff.GetState() == StateOfPoliceman.gopatroll)
                    a++;
            return a;
        }
    }
    class Policeman
    {
        Random rnd = new Random();
        int ID;
        int timeonpatroll;
        Coordinates coords;
        StateOfPoliceman state;
        double angle, speed;
        double orbit;
        public bool missionExist;
        bool xbool, ybool;
        Mission mission;
        int Size, DrawSize;
        public Policeman(int ID)
        {
            this.ID = ID;
            timeonpatroll = 0;
            coords = new Coordinates(0, 0, 0);
            state = StateOfPoliceman.onbase;
            angle = 0;
            speed = Math.PI / 100;
            orbit = rnd.Next(7,10); //по какой орбите будет двигаться;
            xbool = ybool = missionExist = false;
            Size = 50;
        }
        void move()
        {
            timeonpatroll++;
            if (angle > 2 * Math.PI)
                angle = 0;
            angle += speed;
            coords.x = Math.Cos(angle) * orbit;
            coords.y = Math.Sin(angle) * orbit;
        }
        public void Calculate(Coordinates basecoords, int scale, Graphics g, Del dl)
        {
            switch (state)
            {
                case StateOfPoliceman.onbase:
                    if (!missionExist)
                        coords = basecoords;
                    else
                        state = StateOfPoliceman.gopatroll;
                    break;
                case StateOfPoliceman.onpatroll:
                    move();
                    Draw(g, dl, scale);
                    if (missionExist)
                        state = StateOfPoliceman.gobase;
                    break;
                case StateOfPoliceman.gobase:
                    FlyTo(basecoords);
                    Draw(g, dl, scale);
                    if (!missionExist)
                    {
                        state = StateOfPoliceman.onbase;
                        timeonpatroll = 0;
                        xbool = ybool = false;
                    }
                    break;
                case StateOfPoliceman.gopatroll:
                    FlyTo(new Coordinates(mission.x, mission.y, mission.z));
                    Draw(g, dl, scale);
                    if (!missionExist)
                    {
                        state = StateOfPoliceman.onpatroll;
                        xbool = ybool = false;
                    }
                    break;
            }
        }
        public void Draw(Graphics g, Del dl, int scale)
        {
            if (Math.Abs(scale ) <= 3)
                scale = 3;
            DrawSize = Size / scale;
            Point p = dl(new TVector(coords.x, coords.y, coords.z));
            Rectangle rect = new Rectangle(p, new Size(DrawSize, DrawSize));// посмотреть на скейл во всех свитч
            g.FillRectangle(Brushes.Blue, rect);
            g.DrawString("Police №" + ID.ToString(), new Font("Times New Roman", 12), Brushes.White, p);
        }
        public StateOfPoliceman GetState()
        {
            return state;
        }
        public void SetMisson(Mission mission)
        {
            this.mission = mission;
            orbit = Math.Sqrt(mission.x * mission.x + mission.y * mission.y);
        }
        public int GetTime()
        {
            return timeonpatroll;
        }
        void FlyTo(Coordinates place)
        {
            if (Math.Abs(coords.x - place.x) < 0.1 && Math.Abs(coords.y - place.y) < 0.1)
            {
                missionExist = false;
            }
            else
            {
                if (coords.x < place.x)
                    coords.x += 0.1;
                else
                    coords.x -= 0.1;
                if (coords.y < place.y)
                    coords.y += 0.1;
                else
                    coords.y -= 0.1;
            }

            if (xbool && ybool)
                missionExist = false;
            //if (coords.z - place.z < 0.2)
            //{
            //    missionExist = false;
            //}
            //else
            //{
            //    if (coords.z < place.z)
            //        coords.z += 0.1;
            //    else
            //        coords.z -= 0.1;
            //}
        }
        void AngleCalc()
        {
            angle = Math.Atan(coords.y / coords.x);
            while (angle > 2 * Math.PI)
                angle -= 2 * Math.PI;
        }
    }
    class Crime
    {
        int CrimeId;
        int PlantetId;
        public Crime(int CrimeId)
        {
            this.CrimeId = CrimeId;
        }
    }
}
