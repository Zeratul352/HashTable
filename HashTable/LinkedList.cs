using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class LinkedList
    {
        public int key { get; set; }
        public List<double> data { get; set; }
        public LinkedList next { get; set; }
        public static LinkedList Create(int k, List<double> dat)
        {
            LinkedList linkedList = new LinkedList();
            linkedList.key = k;
            linkedList.data = dat;
            linkedList.next = null;
            return linkedList;
        }
        public static LinkedList InsertFirst(LinkedList obj, LinkedList first)
        {
            obj.next = first;
            return obj;
        }
        public static int Find(LinkedList root, List<double> search)
        {
            LinkedList newroot = root;
            int i = 0;
            while(newroot != null)
            {
                i++;
                if(newroot.data[0] == search[0] && newroot.data[1] == search[1] && newroot.data[2] == search[2])
                {
                    return i;
                }
                else
                {
                    newroot = newroot.next;
                }
            }
            return i * -1;         
        }
        public static LinkedList FindAndRemove(LinkedList root, List<double> search)
        {
            LinkedList newroot = root;
            if(newroot == null)
            {
                return null;
            }
            if(newroot.data == search)
            {
                return root.next;
            }
            while(newroot.next != null)
            {
                if(newroot.next.data == search)
                {
                    newroot.next = newroot.next.next;
                }
            }
            return root;
        }
        public static int Length(LinkedList list)
        {
            int a = 1;
            LinkedList linked = list;
            if(linked == null)
            {
                return 0;
            }
            while(linked.next != null)
            {
                a++;
                linked = linked.next;
            }
            return a;
        }
        
    }
}
/*
 public class LinkedList<T> where T:IComparable
    {
        public int key { get; set; }
        public T data { get; set; }
        public LinkedList<T> next { get; set; }
        public static LinkedList<T> Create(int k, T dat)
        {
            LinkedList<T> linkedList = new LinkedList<T>();
            linkedList.key = k;
            linkedList.data = dat;
            linkedList.next = null;
            return linkedList;
        }
        public static LinkedList<T> InsertFirst(LinkedList<T> obj, LinkedList<T> first)
        {
            obj.next = first;
            return obj;
        }
        public static LinkedList<T> Find(LinkedList<T> root, T search)
        {
            LinkedList<T> newroot = root;
            while(newroot.next != null)
            {
                if(newroot.data.CompareTo(search) == search.CompareTo(newroot.data))
                {
                    return newroot;
                }
                else
                {
                    newroot = newroot.next;
                }
            }
            return null;         
        }
        public static LinkedList<T> FindAndRemove(LinkedList<T> root, T search)
        {
            LinkedList<T> newroot = root;
            if(newroot.data.CompareTo(search) == search.CompareTo(newroot.data))
            {
                return root.next;
            }
            while(newroot.next != null)
            {
                if(newroot.next.data.CompareTo(search) == search.CompareTo(newroot.next.data))
                {
                    newroot.next = newroot.next.next;
                }
            }
            return root;
        }
        public static int Length(LinkedList<T> list)
        {
            int a = 0;
            LinkedList<T> linked = list;
            while(linked.next != null)
            {
                a++;
                linked = linked.next;
            }
            return a;
        }
        
    }
 */
