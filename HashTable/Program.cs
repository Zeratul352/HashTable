using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            
            Hash_Table<double> hash_Table = Hash_Table<double>.Init();
            for(int i = 1; i <= 50000; i++)
            {
                double x = Math.Round(random.NextDouble() * 2 - 1, 2);
                double y = Math.Round(random.NextDouble() * 2 - 1, 2);
                double z = Math.Round(random.NextDouble() * 2 - 1, 2);
                List<double> point = new List<double> { x, y, z };
                hash_Table.AddAsLineralZonding(point);

            }
            List<int> found = new List<int>();
            List<int> notfound = new List<int>();
            for(int i = 0; i < 10000; i++)
            {
                found.Add(0);
                notfound.Add(0);
            }
            Console.WriteLine("done");
            for (int i = 1; i <= 50000; i++)
            {
                double x = Math.Round(random.NextDouble() * 2 - 1, 2);
                double y = Math.Round(random.NextDouble() * 2 - 1, 2);
                double z = Math.Round(random.NextDouble() * 2 - 1, 2);
                List<double> point = new List<double> { x, y, z };
                int steps = hash_Table.LineralFind(point);
                if(steps > 0)
                {
                    found[steps]++;
                }
                else
                {
                    notfound[Math.Abs(steps)]++;
                }

            }
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(found[i]);
            }
            Console.WriteLine("____________________");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(notfound[i]);
            }
            //hash_Table.CountLength();
            System.Console.ReadKey();
        }
    }
}
