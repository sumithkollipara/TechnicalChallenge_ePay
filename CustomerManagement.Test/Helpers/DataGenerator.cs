using CustomerManagement.Common.Models;

namespace CustomerManagement.Test.Helpers
{
    public static class DataGenerator
    {
        public static List<string> GenerateLastName()
        {
            List<string> lastNames = new()
            {
                "Liberty"
                ,"Ray"
                ,"Harrison"
                ,"Ronan"
                ,"Drew"
                ,"Powell"
                ,"Larsen"
                ,"Chan"
                ,"Anderson"
                ,"Lane"
            };
            return lastNames;
        }
        public static List<string> GenerateFirstName()
        {
            List<string> firstNames = new()
            {
                 "Leia"
                ,"Sadie"
                ,"Jose"
                ,"Sara"
                ,"Frank"
                ,"Dewey"
                ,"Tomas"
                ,"Joel"
                ,"Lukas"
                ,"Carlos"
            };
            return firstNames;
        }
        public static List<CustomerModel> GenerateRandomCustomerObjects(List<string> firstNames, List<string> lastNames)
        {
            List<CustomerModel> lstCustomers = new();

            List<int> randomIndecesFirstName = new();
            List<int> randomIndecesLastName = new();
            Random rnd = new();

            while (randomIndecesFirstName.Count != 10)
            {
                int num = rnd.Next(1, 11);
                if (!randomIndecesFirstName.Contains(num))
                {
                    randomIndecesFirstName.Add(num);
                }
            }

            while (randomIndecesLastName.Count != 10)
            {
                int num = rnd.Next(1, 11);
                if (!randomIndecesLastName.Contains(num))
                {
                    randomIndecesLastName.Add(num);
                }
            }

            for (int i = 0; i < firstNames.Count; i++)
            {
                CustomerModel model = new(firstNames[i], lastNames[i], rnd.Next(19, 50));
                model.Id = i + 1;
                lstCustomers.Add(model);
            }

            return lstCustomers;
        }
    }
}
