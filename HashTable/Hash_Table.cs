using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Hash_Table<T>
    {
        static int HashNumber = 51257;
        static int SecondHashNumber = 17;
        List<LinkedList> table { get; set; }
        public static Hash_Table<T> Init()
        {
            Hash_Table<T> hash_Table = new Hash_Table<T>();
            hash_Table.table = new List<LinkedList>();
            for(int i = 0; i < HashNumber + 1000; i++)
            {
                hash_Table.table.Add(null);
            }
            return hash_Table;
        }
        int GetHash(List<double> data)
        {
            int x = System.Convert.ToInt32(data[0] * 100) * 73856093;
            int y = System.Convert.ToInt32(data[1] * 100) * 19349663;
            int z = System.Convert.ToInt32(data[2] * 100) * 83492791;
            int hash = x ^ y ^ z;
            return Math.Abs(hash % HashNumber);
        }
        int GetSecondHash(List<double> data)
        {
            int x = System.Convert.ToInt32(data[0] * 100) * 73856093;
            int y = System.Convert.ToInt32(data[1] * 100) * 19349663;
            int z = System.Convert.ToInt32(data[2] * 100) * 83492791;
            int hash = x ^ y ^ z;
            return Math.Abs(hash % SecondHashNumber) + 1;
        }
        public void Add(List<double> obj)
        {
            int hash = GetHash(obj);
            //LinkedList list = new LinkedList();
            
            if(table[hash] == null)
            {
                table[hash] = LinkedList.Create(hash, obj);
            }
            else
            {
                table[hash] = LinkedList.InsertFirst(LinkedList.Create(hash, obj), table[hash]);
            }
        }
        public void AddAsLineralZonding(List<double> obj)
        {
            int hash = GetHash(obj);
            int hash1 = hash;
            int hash2 = GetSecondHash(obj);
            while (true)
            {
                if (table[hash] == null)
                {
                    table[hash] = LinkedList.Create(hash1, obj);
                    return;
                }
                else
                {
                    hash = (hash + hash2) % HashNumber;
                }
            }
        }
        /*public List<double> Get(List<double> obj)
        {
            int hash = GetHash(obj);

            if(table[hash] == null)
            {
                throw new Exception("Object not found");
            }
            else
            {
                return LinkedList.Find(table[hash], obj).data;
            }
        }*/
        public void PrintLength()
        {
            foreach(var tuple in table)
            {
                Console.Write(LinkedList.Length(tuple));
                Console.Write("      ");
                //Console.WriteLine(tuple.Value.data);
                if (tuple != null)
                {
                    foreach (double a in tuple.data)
                    {
                        Console.Write("{0}  ", a);
                    }
                }
                Console.WriteLine();
            }
            /*for(int i = 0; i < HashNumber; i++)
            {
                Console.WriteLine(LinkedList.Length(table[i]));
            }*/
        }
        public void CountLength()
        {
            List<int> result = new List<int>();
            for(int i = 0; i < 50; i++)
            {
                result.Add(0);
            }
            foreach(var elem in table)
            {
                int index = LinkedList.Length(elem);
                result[index]++;
            }
            for(int i = 0; i < 50; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
        public int CountFind(List<double> arr)
        {
            int hash = GetHash(arr);
            if(table[hash] == null)
            {
                return 0;
            }
            else
            {
                return LinkedList.Find(table[hash], arr);
            }
        }
        public int LineralFind(List<double> arr)
        {
            int hash = GetHash(arr);
            int hash2 = GetSecondHash(arr);
            int i = 0;
            int hash1 = hash;
            while(table[hash1] != null && table[hash1].key == hash)
            {
                i++;
                int a = LinkedList.Find(table[hash1], arr);
                if(a > 0)
                {
                    return i;
                }
                else
                {
                    hash1 = (hash1 + hash2) % HashNumber;
                }
            }
            return i * -1;
        }
       
    }
}
