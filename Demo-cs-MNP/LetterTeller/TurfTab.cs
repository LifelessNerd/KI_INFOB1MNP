namespace LetterTeller
{
    public class TurfTab
    {
        protected int[] tellers;
        protected int totaal;

        public TurfTab()
        {
            tellers = new int[26];
        }
        protected virtual void turf(char ch)
        {
            if (ch>='A' && ch<='Z')
            {   tellers[ch-'A']++;
                totaal++;
            }
            if (ch>='a' && ch<='z')
            {   tellers[ch-'a']++;
                totaal++;
            }
        }
        public void Turf(string s)
        {
            for (int t = 0; t < s.Length; t++)
                this.turf(s[t]);
        }
        public override string ToString()
        {
            string res = "";
            for (int t = 0; t < 26; t++)
                res += (char)(t + 'A') + ": " + tellers[t] + " keer\n";
            res += "totaal: " + totaal;
            return res;
        }
        public int Totaal
        {
            get
            {   return totaal;
            }
        }
        public float Gemiddelde
        {
            get
            {   return (float)totaal / tellers.Length; 
            }
        }
        public int[] Waardes 
        {   get 
            {   return (int[]) tellers.Clone(); 
            } 
        }
    }
}