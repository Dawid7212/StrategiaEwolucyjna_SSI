using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace StrategiaEwolucyjna_SSI
{
    public partial class Form1 : Form
    {
        public int µ = 4;
        public int λ = 10;
        public int turniej_rozmiar = 2;
        public double mutacja_poziom = 10;
        public int iteracje_liczba = 20;
        public List<Osobnik> PulaRodzicielska = new List<Osobnik>();
        public int minPrzedzialZmiennosci = 0;
        public int maxPrzedzialZmiennosci = 100;
        public Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            StworzPopulacje(µ);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public double FunkcjaPrzystosowania(double x1, double x2)
        {
            return Math.Sin(x1 * 0.05) + Math.Sin(x2 * 0.05) + (0.4 * Math.Sin(x1 * 0.15) * Math.Sin(x2 * 0.15));
        }
        public double LosujLiczbeDouble(double minPrzedzialu, double maxPrzedzialu)
        {
            return minPrzedzialu + rand.NextDouble() * (maxPrzedzialu - minPrzedzialu);
        }
        public int LosujLiczbeInt(int minPrzedzialu, int maxPrzedzialu)
        {
            return rand.Next(minPrzedzialu, maxPrzedzialu);
        }
        public void StworzPopulacje(int N)
        {
            for (int i = 0; i < N; i++)
            {
                double x1 = LosujLiczbeDouble(minPrzedzialZmiennosci, maxPrzedzialZmiennosci);
                double x2 = LosujLiczbeDouble(minPrzedzialZmiennosci, maxPrzedzialZmiennosci);
                Osobnik Nowy = new Osobnik(x1, x2);
                PulaRodzicielska.Add(Nowy);
            }
        }
        public Osobnik Turniej(List<Osobnik> Pula, int rozmiarTurnieju)
        {
            List<Osobnik> oss_turniej = new List<Osobnik>();
            for (int i = 0; i < rozmiarTurnieju; i++)
            {
                int losowyOsobnik = LosujLiczbeInt(0, Pula.Count);
                oss_turniej.Add(Pula[losowyOsobnik]);
            }
            return WyborNajlepszegoOsobnika(oss_turniej).Clone();
        }
        public Osobnik WyborNajlepszegoOsobnika(List<Osobnik> Pula)
        {
            Osobnik najlepszy = Pula[0];

            for (int i = 1; i < Pula.Count; i++)
            {
                if (Pula[i].ocena > najlepszy.ocena)
                {
                    najlepszy = Pula[i];
                }
            }

            return najlepszy;
        }
        public void Mutacja(Osobnik mutowany)
        {
            double wylosowanyPoziom = LosujLiczbeDouble(-mutacja_poziom, mutacja_poziom);
            mutowany.x1 += wylosowanyPoziom;
            mutowany.x2 += wylosowanyPoziom;
        }
        public void PetlaGlowna(int iteracje_liczba)
        {
            for (int i = 0; i < iteracje_liczba; i++)
            {
                foreach (Osobnik sztuka in PulaRodzicielska)
                {
                    sztuka.ocena = FunkcjaPrzystosowania(sztuka.x1, sztuka.x2);
                }
                List<Osobnik> PulaPotomna = new List<Osobnik>();
                for (int j = 0; j < λ; j++)
                {
                    Osobnik os_n = Turniej(PulaRodzicielska, turniej_rozmiar);
                    Mutacja(os_n);
                    os_n.ocena = FunkcjaPrzystosowania(os_n.x1, os_n.x2);
                    PulaPotomna.Add(os_n);
                }

                List<Osobnik> µλ = new List<Osobnik>();
                foreach (Osobnik os in PulaPotomna)
                {
                    µλ.Add(os.Clone());
                }
                foreach (Osobnik os in PulaRodzicielska)
                {
                    µλ.Add(os.Clone());
                }
                PulaRodzicielska.Clear();
                for (int j = 0; j < µ; j++)
                {
                    Osobnik naj = WyborNajlepszegoOsobnika(µλ);
                    PulaRodzicielska.Add(naj);
                    µλ.Remove(naj);
                }

            }
        }

        private void BTN1_Click(object sender, EventArgs e)
        {
            PetlaGlowna(iteracje_liczba);
            Osobnik Najlepszy = WyborNajlepszegoOsobnika(PulaRodzicielska);
            RTB1.AppendText("Najlepszy osobnik \n X1:" + Najlepszy.x1 + "\nX2: " + Najlepszy.x2 + "\nOcena:" + FunkcjaPrzystosowania(Najlepszy.x1, Najlepszy.x2) + "\n\n");
        }
    }
}
