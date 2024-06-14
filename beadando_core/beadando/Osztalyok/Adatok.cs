using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace beadando.Osztalyok
{
    public class Adatok
    {
        private struct SzemelyiAdat
        {
            public string role;
            public string email;
            public string nem;
            public int kor;
            public string vegzettseg;
        }
        private SzemelyiAdat sz = new SzemelyiAdat();   

        public void setMinden(string[] beadat)
        {
            try
            {
                foreach (var item in beadat)
                {
                    if (item=="")
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                sz.role = beadat[0];
                sz.email = beadat[1];
                sz.nem = beadat[2];
                sz.kor = int.Parse(beadat[3]);
                sz.vegzettseg = beadat[4];
            }
            catch (IndexOutOfRangeException)
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                XMLfunkciok xMLfunkciok= new XMLfunkciok();
                xMLfunkciok.WriteTemlplateXML(path);
                MessageBox.Show("hibás vagy hiányos config.xml fájl");
                Environment.Exit((int)hibakodok.config_hibashianyos);
            }
           
        }
        public void setEmail(string email)
        {
            this.sz.email = email;
        }
        public void setNem(string nem)
        {
            this.sz.nem = nem;
        }
        public void setKor(int kor)
        {
            this.sz.kor = kor; 
        }
        public void setVegzettseg(string vegzettseg)
        {
            this.sz.vegzettseg= vegzettseg;
        }
        public void setRole(string role)
        {
            this.sz.role = role;
        }
        public string getEmail()
        {
            return this.sz.email;
        }
        public string getNem()
        {
            return this.sz.nem;
        }
        public int getKor() 
        { 
            return this.sz.kor;
        }
        public string getVegzettseg()
        {
            return this.sz.vegzettseg;
        }
        public string getRole()
        {
            return this.sz.role;
        }
    }
}
