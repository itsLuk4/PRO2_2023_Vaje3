using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krog
{

    class Krog
    {
        //lastnost
        private double premer;

        public double Premer
        {
            get { return premer; }
            set { if (value >= 0) premer = value; }
        }
        // metoda povrsina
        public virtual double Povrsina()
        {
            return Math.PI * (Premer / 2) * (Premer / 2);
        }
        // primer objektne metode
        public void Povecaj(int faktor)
        {
            this.Premer = this.Premer * faktor;
        }
        //privzeti konstruktor
        public Krog()
        {
            Premer = 0;
        }
        public Krog(double _premer)
        {
            Premer = _premer;
        }

        public Krog(Krog k)
        {
            this.Premer = k.Premer;
        }

    }

    //podrajeni razred
    class Krogla : Krog
    {
        public override double Povrsina()
        {
            return 4 * Math.PI * (Premer / 2) * (Premer / 2);
        }
        public double Prostornina()
        {
            return (4 / 3) * Math.PI * Math.Pow((Premer / 2), 3);
        }
        public Krogla()
        { 
            Premer = 0;
        }
        public Krogla(double _premer) : base(_premer)
        {
        
        }
        public Krogla(Krogla k) : base(k)
        { 
        
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Krog k1 = new Krog();
            Console.WriteLine("Površina je: {0}", k1.Povrsina());

            Krog k2 = new Krog(10);
            Console.WriteLine("Površina je: {0}", k2.Povrsina());

            Krogla kr1 = new Krogla();
            Console.WriteLine("Površina je: {0}", kr1.Povrsina());
            Console.WriteLine("Prostornina je: {0}", kr1.Prostornina());

            Krogla kr2 = new Krogla(20);
            Console.WriteLine("Površina je: {0}", kr2.Povrsina());
            Console.WriteLine("Prostornina je: {0}", kr2.Prostornina());


            k2.Povecaj(3);
        }
    }
}
