using System.Text;

namespace Vowel_Shift_Cipher
{
    internal class Program
    {
        static string VowelShiftCipher(string s)
        {
            char[] vowel = { 'a', 'e', 'i', 'o', 'u' };
            string a = "bcdfghjklmnpqrstvwxyz";
            char[] cons = a.ToCharArray();

            StringBuilder sb = new StringBuilder(s);

            for (int i = 0; i < sb.Length; i++)
            {
                if (vowel.Contains(sb[i]))
                {
                    int idx = Array.IndexOf(vowel, sb[i]);
                    sb[i] = vowel[(idx + 1) % vowel.Length];
                }

                else if (cons.Contains(sb[i]))
                {
                    int idx = Array.IndexOf(cons, sb[i]);
                    sb[i] = cons[(idx + 1) % cons.Length];
                }
            }
            s = sb.ToString();
            return s;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string :");
            string s = Console.ReadLine();
            Console.WriteLine(VowelShiftCipher(s));
        }
    }
}
