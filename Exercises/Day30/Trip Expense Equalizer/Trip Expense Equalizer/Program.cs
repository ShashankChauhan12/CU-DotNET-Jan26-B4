namespace Trip_Expense_Equalizer
{
    internal class Program
    {
        static List<string> ExpenseShare(Dictionary<string, int> d)
        {
            var settlement = new List<string>();

            Queue<KeyValuePair<string, int>> receivers = new Queue<KeyValuePair<string, int>>();
            Queue<KeyValuePair<string, int>> payers = new Queue<KeyValuePair<string, int>>();

            var total = d.Values.Sum();
            var persons = d.Count();
            var avg = total / persons;
            foreach (var person in d)
            {
                if (person.Value > avg)
                {
                    receivers.Enqueue(new KeyValuePair<string, int>(person.Key, person.Value - avg));
                }
                else if (person.Value < avg)
                {
                    payers.Enqueue(new KeyValuePair<string, int>(person.Key, Math.Abs(person.Value - avg)));
                }
            }

            while (payers.Count > 0 && receivers.Count > 0)
            {
                var payer = payers.Dequeue();
                var receiver = receivers.Dequeue();
                var amount = Math.Min(payer.Value, receiver.Value);

                settlement.Add($"{payer.Key} {receiver.Key} {amount}");
                if (payer.Value > amount)
                    payers.Enqueue(new KeyValuePair<string, int>(payer.Key, Math.Abs(amount - payer.Value)));
                if (receiver.Value > amount)
                    receivers.Enqueue(new KeyValuePair<string, int>(receiver.Key, Math.Abs(amount - receiver.Value)));
            }

            return settlement;
        }

        static void Main(string[] args)
        {
            Dictionary<string, int> d = new Dictionary<string, int>()
            {
                {"A",700},
                {"B",900},
                {"C",2000},
                {"D",5000},
                {"E",7000}
            };
            List<string> settlement = ExpenseShare(d);

            foreach (var payment in settlement)
                Console.WriteLine(payment);
        }
    }
}
