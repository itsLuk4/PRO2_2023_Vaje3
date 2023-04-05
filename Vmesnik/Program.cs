using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vmesnik
{
    //vmesnik ali drugače interface
    interface Film
    {
        public string Naziv
        {
            set;
            get;
        }
        public int Trajanje
        {
            set;
            get;
        }
    }
    interface Komedija : Film
    {
        public int MinuteSmeha
        {
            set;
            get;
        }
    }
    interface Grozljivka : Film
    {
        public int SteviloTrupel
        {
            get;
            set;
        }
    }

    class Netflix : Film
    {
        private string naziv;
        private int trajanje;
        public string Naziv
        {
            set { naziv = value; }
            get { return "Netflix Original: " + naziv; }
        }
        public int Trajanje
        {
            set { if (value >= 0) trajanje = value; }
            get { return trajanje; }
        }
        private string drzava;
        public string Drzava
        {
            set { drzava = value; }
            get { return drzava; }
        }
        public Netflix(string n, int t, string d)
        {
            this.Naziv = n;
            this.Trajanje = t;
            this.Drzava = d;
        }
        public void Izpisi()
        { Console.WriteLine("naziv: {0} trajanje: {1} država: {2}", Naziv, Trajanje, Drzava); }
    }
    class HorrorKomedija : Grozljivka, Komedija
    {
        private int stevilo;
        private int minute;
        public int SteviloTrupel
        {
            get { return stevilo; }
            set { stevilo = value; }
        }
        public int MinuteSmeha
        {
            set { minute = value; }
            get { return minute; }
        }
        private string naziv;
        private int trajanje;
        public string Naziv
        {
            set { naziv = value; }
            get { return naziv; }
        }
        public int Trajanje
        {
            set { if (value >= 0) trajanje = value; }
            get { return trajanje; }
        }
        public HorrorKomedija(string n, int t, int st, int ms)
        {
            this.Naziv = n;
            this.Trajanje = t;
            this.SteviloTrupel = st;
            this.MinuteSmeha = ms;
        }
        public void Izpisi()
        { Console.WriteLine("naziv: {0} trajanje: {1} Trupla: {2} Smeha: {3}", Naziv, Trajanje, SteviloTrupel, MinuteSmeha); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Netflix f1 = new Netflix("Na zahodu nič novega", 120, "Nemčija");
            //f1.Naziv = "Na zahodu nič novega";
            //f1.Trajanje = 120;
            //f1.Drzava = "Nemčija";
            f1.Izpisi();

            HorrorKomedija hk1 = new HorrorKomedija("Titanik", 180, 2000, 20);
            //hk1.Naziv = "Titanik";
            //hk1.Trajanje = 180;
            //hk1.SteviloTrupel = 2000;
            //hk1.MinuteSmeha = 20;
            hk1.Izpisi();
        }
    }
}
