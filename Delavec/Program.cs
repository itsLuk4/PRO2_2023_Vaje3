using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delavec
{

    class Delavec
    {
        //lastnosti
        private string imeDelavca;
        public string ImeDelavca
        {
            get { return imeDelavca; }
            set { imeDelavca = value; }
        }
        //priv je privzeti konstruktor
        public Delavec()
        {
            ImeDelavca = "N/A";
        }
        //parametrični konstruktor
        public Delavec (string ime)
        {
            ImeDelavca = ime;
        }
        // kopirni kosntruktor
        public Delavec(Delavec del)
        {
            ImeDelavca = del.ImeDelavca;
        }
        //ni potrebno pri nalogi ampak smo vseen dodali konstruktor "Izpisi"
        public void Izpisi()
        {
            Console.WriteLine("Delavec: {0}", ImeDelavca);
        }

        public virtual double izracunajPlaco()
        {
            return 0;
        }
    }

    //avtomatično podedovanje od "Delavec", kjer smo ustvarili začasnega delavca
    class ZacasniDelavec : Delavec
    {
        private double urnaPostavka;
        private int steviloUr;

        public double UrnaPostavka
        {
            get { return urnaPostavka; }
            set { if (value >= 0) urnaPostavka = value; }
        }

        public int SteviloUr
        {
            get { return steviloUr; }
            set { if ( value >= 0) steviloUr = value; }
        }

        public override double izracunajPlaco()
        {
            return UrnaPostavka * SteviloUr;
        }
        public ZacasniDelavec()
        {
            UrnaPostavka = 20;
            SteviloUr = 10;
        }
        //(pomen "base" dalje) pri klicu konstruktorja mi poklici se parameter iz privezetega/nadrejenega razreda
        public ZacasniDelavec(string ime, double postavka, int ure) : base(ime) 
        {
            UrnaPostavka = postavka;
            SteviloUr = ure;
        }

        //zadnji del naloge
        public ZacasniDelavec(ZacasniDelavec zacdel) : base(zacdel)
        {
            this.UrnaPostavka = zacdel.UrnaPostavka;
            this.SteviloUr = zacdel.SteviloUr;
        }

    }
    // druga polovica naloge kjer smo rabili ustvariti stalnega delavca
    class StalniDelavec : Delavec
    {
        private double letnaPlaca;
        public double LetnaPlaca
        {
            get { return letnaPlaca; }
            set { if (value >= 0) letnaPlaca = value; }
        }
        public override double izracunajPlaco()
        {
            return LetnaPlaca / 12;
        }

        public StalniDelavec()
        {
            LetnaPlaca = 12000;
        }
        public StalniDelavec(string ime, double letna) : base(ime)
        {
            LetnaPlaca = letna;
        }

        //imamo dva različna načina ki se lahko lotimo reševat
        //1. Način
     /* public StalniDelavec(StalniDelavec sd)
        {
            this.ImeDelavca = sd.ImeDelavca;
            this.LetnaPlaca = sd.LetnaPlaca;
        }
     */
        //2. Način
        public StalniDelavec(StalniDelavec sd) : base(sd)
        {
            //this.ImeDelavca = sd.ImeDelavca;
            this.LetnaPlaca = sd.LetnaPlaca;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //vzamemo privzetnega konstruktorja
            Delavec del1 = new Delavec();
            //parametričnega konstruktorja
            Delavec del2 = new Delavec("Janez Novak");
            //kopirnega konstruktorja
            Delavec del3 = new Delavec(del2);

            //preverimo če deluje z izpisi
            del1.Izpisi();
            del2.Izpisi();
            del3.Izpisi();

            Console.WriteLine("Plača je {0}.", del2.izracunajPlaco());
            //preverimo za "ZacasneiDelavec"
            ZacasniDelavec zacdel1 = new ZacasniDelavec();
            zacdel1.Izpisi();
            zacdel1.UrnaPostavka = 20;
            zacdel1.SteviloUr = 30;
            Console.WriteLine("Plača je {0}.", zacdel1.izracunajPlaco());

            // ko smo dodali dva ZacasniDelavec konstruktorja
            ZacasniDelavec zacdel2 = new ZacasniDelavec("Muca Copatarica", 30, 40);
            zacdel2.Izpisi();
            Console.WriteLine("Plača je {0}.", zacdel2.izracunajPlaco());

            //pri zadnjem delu naloge smo vrinili tega ZacasnegaDelavca
            ZacasniDelavec zacdel3 = new ZacasniDelavec(zacdel2);
            zacdel3.Izpisi();
            Console.WriteLine("Plača je {0}", zacdel3.izracunajPlaco());

            //z privzetim konstruktorjem
            StalniDelavec stadel1 = new StalniDelavec();
            stadel1.Izpisi();
            Console.WriteLine("Plača je {0}.", stadel1.izracunajPlaco());

            //z parametričnim konstruktorjem
            StalniDelavec stadel2 = new StalniDelavec("Špela Vesela", 30000);
            stadel1.Izpisi();
            Console.WriteLine("Plača je {0}.", stadel2.izracunajPlaco());

            //s kopirnim konstruktorjem
            StalniDelavec stadel3 = new StalniDelavec(stadel2);
            stadel3.Izpisi();
            Console.WriteLine("Plača je {0}.", stadel3.izracunajPlaco());
        }
    }
}
