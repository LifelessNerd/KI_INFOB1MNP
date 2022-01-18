namespace CirkelKlikker
{
    public class ArrayBieb
    {
        public static int Kleinste(int[] a, int n)
        {
            int res = a[0];
            for (int t = 1; t < n; t++)
                if (a[t] < res)
                    res = a[t];
            return res;
        }
        public static int Grootste(int[] a, int n)
        {
            int res = a[0];
            for (int t = 1; t < n; t++)
                if (a[t] > res)
                    res = a[t];
            return res;
        }
        public static int Kleinste(int[] a)
        {
            return ArrayBieb.Kleinste(a, a.Length);
        }
        public static int Grootste(int[] a)
        {
            return ArrayBieb.Grootste(a, a.Length);
        }
    }
}
