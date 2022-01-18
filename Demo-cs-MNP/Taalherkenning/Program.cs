using System;
using System.Windows.Forms;

namespace Taalherkenning
{
    static class Program
    {
        static void Main(string[] args)
        {
            string[] defaultwaarden =
            { "Nederlands", "https://nl.wikipedia.org"
            , "Engels",     "https://en.wikipedia.org"
            , "Duits",      "https://de.wikipedia.org"
            , "Frans",      "https://fr.wikipedia.org"
            , "Spaans",     "https://es.wikipedia.org"
            , "Italiaans",  "https://it.wikipedia.org"
            };

            if (args.Length == 0)
                args = defaultwaarden;

            Application.Run(new Taal(args));
        }
    }
}
