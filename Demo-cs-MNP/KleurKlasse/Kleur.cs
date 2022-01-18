namespace KleurKlasse
{
    public class Kleur
    {
        public byte Rood, Groen, Blauw;
        public static byte Maximaal = 255;

        public Kleur()
        {
            Rood = Maximaal; Groen = Maximaal; Blauw = Maximaal;
        }
        public Kleur(byte x)
        {
            Rood = x; Groen = x; Blauw = x;
        }
        public Kleur(byte r, byte g, byte b)
        {
            Rood = r; Groen = g; Blauw = b;
        }
        public Kleur(Kleur orig)
        {
            Rood = orig.Rood; Groen = orig.Groen; Blauw = orig.Blauw;
        }
        public Kleur(string s)
        {
            string[] velden = s.Split(' ');
            Rood = byte.Parse(velden[0]);
            Groen = byte.Parse(velden[1]);
            Blauw = byte.Parse(velden[2]);
        }
        public override string ToString()
        {
            return $"{Rood} {Groen} {Blauw}";
        }
        public byte Grijswaarde()
        {
            return (byte)(0.3 * Rood + 0.6 * Groen + 0.1 * Blauw);
        }
        public void MaakDonkerder()
        {   Rood = (byte)(Rood * 0.9);
            Groen = (byte)(Groen * 0.9);
            Blauw = (byte)(Blauw * 0.9);
        }
        public Kleur DonkerdereVersie()
        {   Kleur res = new Kleur(this);
            res.MaakDonkerder();
            return res;
        }
        public static Kleur Zwart = new Kleur(0, 0, 0);
        public static Kleur Geel = new Kleur(Maximaal, Maximaal, 0);

        public static Kleur Parse(string s)
        {
            return new Kleur(s);
        }
    }
}