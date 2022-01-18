using System;

namespace KleurKlasse
{
    class Voorbeeld
    {
        static void Main()
        {
            Kleur wit, paars, oranje, lichtgrijs, donkergrijs;

            wit = new Kleur();
            paars = new Kleur(255, 0, 255);
            oranje = new Kleur(255, 128, 0);
            lichtgrijs = new Kleur(180);
            donkergrijs = new Kleur(60);

            byte x = oranje.Grijswaarde();
            Kleur oranjeInZwartwit = new Kleur(x);

            oranje.MaakDonkerder();
            string s = oranje.ToString();

            Kleur donkerPaars = paars.DonkerdereVersie();
            Kleur donkerGeel = Kleur.Geel.DonkerdereVersie();

            Console.WriteLine($"DonkerOranje: {oranje}");
            Console.WriteLine($"DonkerPaars: {donkerPaars}");
            Console.WriteLine($"DonkerGeel: {donkerGeel}");
            Console.ReadLine();
        }
    }
}
