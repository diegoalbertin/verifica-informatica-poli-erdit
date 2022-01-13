//Albertin Diego    4f  13/01/2022  verifica
using System;

namespace verifica
{
    class Program
    {
        class treno//classe padre treni
        {
            protected int codTreno;//attributi della classe che verranno letti dai figli tramite l'attriburo protected
            protected string tipo;
            protected string nome;
            protected double costo;
            public treno(int codTreno, string tipo, string nome)//costruttore
            {
                this.codTreno = codTreno;
                this.tipo = tipo;
                this.nome = nome;
                costo = 0;
            }
            public virtual double costoMezzoUtilizzato()//metodo per il calcolo del costo del treno
            {
                costo = 100000;
                return costo;
            }
            public virtual double costoMezzoKM(double km)//metodo per il calcolo del costo del treno al km
            {
                return 0;
            }
            public virtual string ToString()//metodo che restituisce i vari attributi 
            {
                return $"codTReno:{codTreno}-tipo:{tipo}-nome:{nome}-costo:{costo}";
            }
        }
        class Passeggeri : treno//classe passeggeri derivata da treno
        {
            protected int numVagoni;//attributi della classe che vengono aggiunti a quelli ottenuti dalla classe padre 
            protected string alimentazione;
            public Passeggeri(int numVagoni, string alimentazione, int codTreno, string tipo, string nome) : base(codTreno, tipo, nome)//costruttore della classe con due aggiunte rispetto al costruttore del padre
            {
                this.numVagoni = numVagoni;
                this.alimentazione = alimentazione;
            }
            public override double costoMezzoUtilizzato()//metodo del padre per il calcolo del costo del treno, su cui viene eseguito l'override
            {
                costo = 100000 * 1.25;
                return costo;
            }
            public override double costoMezzoKM(double km)//metodo del padre per il calcolo del costo al km del treno, su cui viene eseguito l'override
            {
                double costoKm = 150 * km;
                return costoKm;
            }
            public double costoTotale(double km)//metodo per il calcolo del costo totale del treno, su cui viene eseguito l'override
            {
                double costoTotale = costo + 150 * km;
                return costoTotale;
            }
            public override string ToString()//metodo del padre che restituisce i vari attributi del treno, su cui viene eseguito l'override
            {
                return $"codTReno:{codTreno}-tipo:{tipo}-nome:{nome}-numVagoni:{numVagoni}-alimentazione{alimentazione}";
            }
        }
        class merci : treno//classe merci derivata da treno
        {
            protected int numVagoni;//attributi della classe che vengono aggiunti a quelli ottenuti dalla classe padre 
            protected string alimentazione;
            public merci(int numVagoni, string alimentazione, int codTreno, string tipo, string nome) : base(codTreno, tipo, nome)//costruttore della classe con due aggiunte rispetto al costruttore del padre
            {
                this.numVagoni = numVagoni;
                this.alimentazione = alimentazione;
            }
            public override double costoMezzoUtilizzato()//metodo del padre per il calcolo del costo del treno, su cui viene eseguito l'override
            {
                costo = 100000 * 1.35;
                return costo;
            }
            public override double costoMezzoKM(double km)//metodo del padre per il calcolo del costo al km del treno, su cui viene eseguito l'override
            {
                double costoKm = 150 * km;
                return costoKm;
            }
            public double costoTotale(double km)//metodo per il calcolo del costo totale del treno, su cui viene eseguito l'override
            {
                double costoTotale = costo + 100 * km;
                return costoTotale;
            }
            public override string ToString()//metodo del padre che restituisce i vari attributi del treno, su cui viene eseguito l'override
            {
                return $"codTReno:{codTreno}-tipo:{tipo}-nome:{nome}-numVagoni:{numVagoni}-alimentazione:{alimentazione}";
            }
        }
        static void Main(string[] args)
        {
            double km = inserisciKm();//km ottiene il valore di ritorno del metodo inserisciKm
            int numVagoni = inserisciNumVagoni();//numVagoni ottiene il valore di ritorno del metodo inserisciNumVagoni
            Passeggeri trenoPasseggeri = new Passeggeri(numVagoni, "elettrico", 785875, "regionale", "pass");//viene creato un nuovo oggetto della classe passeggeri
            merci trenomerci = new merci(numVagoni, "elettrico", 557441, "regionale", "mer");//viene crerato un nuovo oggetto della classe merci
            Console.WriteLine("" + trenoPasseggeri.ToString());//vengono stampati a schermo i vari attributi e i costi di trenoPasseggeri
            Console.WriteLine("costo: {0}euro", Convert.ToString(trenoPasseggeri.costoMezzoUtilizzato()));
            Console.WriteLine("costo al km: {0}euro", Convert.ToString(trenoPasseggeri.costoMezzoKM(km)));
            Console.WriteLine("costo totale: {0} euro", Convert.ToString(trenoPasseggeri.costoTotale(km)));
            Console.WriteLine("" + trenomerci.ToString());//vengono stampati a schermo i vari attributi e i costi di trenoMerci
            Console.WriteLine("costo: {0}euro", Convert.ToString(trenomerci.costoMezzoUtilizzato()));
            Console.WriteLine("costo al km: {0}euro", Convert.ToString(trenomerci.costoMezzoKM(km)));
            Console.WriteLine("costo totale: {0}euro", Convert.ToString(trenomerci.costoTotale(km)));
            Console.ReadKey();
        }
        public static double inserisciKm()//funzione per l'inserimento dei km
        {
            double km = 0;
            bool success = false;
            while (km == 0 || success == false)
            {
                Console.WriteLine("inserisci i kilometri effettuati dai treni (devono essere un numero maggiore di 0)");
                string strKm = Console.ReadLine();
                success = double.TryParse(strKm, out km);
            }
            return km;
        }
        public static int inserisciNumVagoni()//funzione per l'inserimento del numVagoni
        {
            int numVagoni = 0;
            bool success = false;
            while (numVagoni == 0 || success == false)
            {
                Console.WriteLine("inserisci il numero dei vagoni dei treni");
                string strVagoni = Console.ReadLine();
                success = int.TryParse(strVagoni, out numVagoni);
            }
            return numVagoni;
        }
    }
}
