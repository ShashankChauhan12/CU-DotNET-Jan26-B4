namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the string: ");
            string s = Console.ReadLine();
            int n = s.Length;
            s = s.ToUpper();

            HashSet<char> guessWords = new HashSet<char>();

            char[] arr = new char[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = '_';
            }

            Console.Write("Word: ");

            int lives = 6;


            while (lives > 0 && arr.Contains('_'))
            {
                Console.WriteLine($"Word: {string.Join(" ", arr)}");
                Console.WriteLine($"Lives left: {lives}");
                Console.WriteLine($"Guessed Letters are: {string.Join(",", guessWords)}");
                Console.Write("Guesses a Letter: ");
                string c = Console.ReadLine().ToUpper();
                Console.WriteLine();

                if (string.IsNullOrEmpty(c))
                {
                    continue;
                }
                else if (c.Length != 1 || !char.IsLetter(c[0]))
                {
                    Console.WriteLine("Please Enter the valid letter");
                    continue;
                }

                if (guessWords.Contains(c[0]))
                {
                    continue;
                }
                guessWords.Add(c[0]);

                if (s.Contains(c[0]))
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (s[i] == c[0])
                        {
                            arr[i] = c[0];
                        }
                    }
                }
                else
                {
                    lives--;
                }
            }
            if (!arr.Contains('_'))
            {
                Console.WriteLine($"\n Well Played! You guessed the word: {s}");
            }
            else
            {
                Console.WriteLine($"\n Hard luck! The correct word was: {s}");
            }
        }
    }
}
