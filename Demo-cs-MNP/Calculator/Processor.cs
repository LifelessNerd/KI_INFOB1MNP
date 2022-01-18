namespace Calculator
{
    class Processor
    {
        private long waarde, vorige;
        private char oper;
        private string scherm;

        public Processor()
        {   this.Schoon();
        }

        public string Scherm
        {   get { return scherm; }
        }
        
        public void Schoon()
        {   waarde = 0;
            vorige = 0;
            oper = '+';
            scherm = "0";
        }

        public void Reken()
        {   switch(oper)
            {
                case '+': vorige += waarde; break;
                case '-': vorige -= waarde; break;
                case '*': vorige *= waarde; break;
                case '/': vorige /= waarde; break;
            }
            scherm = vorige.ToString();
            waarde = 0;
        }

        public void Cijfer(int n)
        {
            waarde = 10 * waarde + n;
            scherm = waarde.ToString();
        }

        public void Operatie(char c)
        {   this.Reken();
            oper = c;
        }
    }
}