using System;
using System.IO;

class Grep
{
    private static void bewerk(String patroon, String filenaam )
    {
        TextReader reader;
        String regel;
                
        try
        {
            if (filenaam == "")
                reader = Console.In;
            else
                reader = new StreamReader(filenaam);
                        
            for (int nr=1; (regel=reader.ReadLine()) != null; nr++)
                if (regel.Contains(patroon))
                    Console.WriteLine( filenaam + ", line " + nr + ": " + regel );
          }
          catch (Exception e)
          {   Console.WriteLine( filenaam + ": " + e );
          }
    }   

    static void Main(string[] args)
    {
        switch (args.Length)
        {
        case 0:  Console.WriteLine("Usage: Grep pattern [files]");
                 break;
        case 1:  Grep.bewerk( args[0], "" );
                 break;
        default: for (int i=1; i<args.Length; i++)
                    Grep.bewerk( args[0], args[i] );
                 break;
        }
    }
}
