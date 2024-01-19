
namespace DenominationRoutine
{
    internal class Program
    {
        private static string currency = "EUR";

        static void Main()
        {
            List<int> atmDenominations = new() { 10, 50, 100 };

            Console.WriteLine("Please enter valid amount with multiples of 10 (eg: 10, 50, 100):");

            if (int.TryParse(Console.ReadLine(), out int x))
            {
                var possibleDenominations = CalculatePossibleDenominations(x, atmDenominations);
                PrintAllDenominations(x, possibleDenominations);
            }
            else
                Console.WriteLine($"The entered value is invalid. Please enter valid amount with multiples of 10 (eg: 10, 50, 100)\n");

            Console.ReadLine();
        }

        static List<List<int>>? CalculatePossibleDenominations(int amountToBeWithdrawn, List<int> atmDenominations)
        {
            int minimumCartdidgeType = atmDenominations.Min();
            if (amountToBeWithdrawn <= 0 || amountToBeWithdrawn < minimumCartdidgeType)
            {
                Console.WriteLine($"The amount '{amountToBeWithdrawn} {currency}' is invalid. The minimum possible amount and denomination which can be dispensed is {minimumCartdidgeType}.\n");
                return null;
            }

            var result = new List<List<int>>();

            CalculatePossibleRecursiveDenominations(result, atmDenominations, amountToBeWithdrawn, 0, new List<int>());

            return result;
        }

        static void CalculatePossibleRecursiveDenominations(List<List<int>> allDenominations, List<int> cartridgeTypes, int amountToBeDispensed, int index, List<int> currentDenomination)
        {
            if (amountToBeDispensed is 0)
            {
                allDenominations.Add(new List<int>(currentDenomination));
                return;
            }

            for (int i = index; i < cartridgeTypes.Count; i++)
            {
                if ((amountToBeDispensed - cartridgeTypes[i]) >= 0)
                {
                    currentDenomination.Add(cartridgeTypes[i]);
                    CalculatePossibleRecursiveDenominations(allDenominations, cartridgeTypes, amountToBeDispensed - cartridgeTypes[i], i, currentDenomination);
                    currentDenomination.Remove(cartridgeTypes[i]);
                }
            }
        }

        static void PrintAllDenominations(int amount, List<List<int>> possibleDenominations)
        {
            if (possibleDenominations is not null)
            {
                Console.WriteLine($"The amount '{amount} {currency}' can be dispensed in following possible ways:");

                Parallel.ForEach(possibleDenominations, combination =>
                {
                    var groupedDenominations = combination.GroupBy(x => x)
                       .Select(x => new { Note = x.Key, Count = x.Count() })
                       .ToList();

                    var res = string.Join(" + ", groupedDenominations.Select(x => $"{x.Count} X {x.Note} EUR"));
                    Console.WriteLine(res);
                });
                Console.WriteLine();
            }
        }
    }
}