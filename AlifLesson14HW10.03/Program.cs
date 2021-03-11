using System;
using System.Collections;
using System.Collections.Generic;

namespace AlifLesson14HW10._03
{
    
    class MyList<T>
    {
        private T[] myList = null;
        private int newIndex = 0;
        private int CountItems = 0;

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < myList.Length)
                    return myList[index];
                else
                {
                    Console.WriteLine(new ArgumentOutOfRangeException().Message);
                    return myList[0];
                }
            }
            set { myList[index] = value; }
        }

        public MyList()
        {
            this.myList = new T[1];
        }

        public MyList(int count)
        {
            this.myList = new T[count];
        }

        public void Add(T item)
        {
            myList[newIndex] = item;
            newIndex++;
            CountItems++;
        }

        public int Capacity
        {
            get { return myList.Length; }

        }
        public int Count
        {
            get { return CountItems; }
        }
        public IEnumerator GetEnumerator()
        {
            return myList.GetEnumerator();
        }
    }
    class MyDictionary<TKey, TValue>
    {
        private int counter = 0;
        private TKey[] Keylist = new TKey[0];
        private TValue[] Valuelist = new TValue[0];
        public int Counter
        {
            get { return this.counter; }
        }

        public MyDictionary()
        {
            TKey[] Keylist = new TKey[0];
            TValue[] Valuelist = new TValue[0];
            this.Keylist = Keylist;
            this.Valuelist = Valuelist;
        }
        public void Add(TKey Key, TValue Value)
        {
            this.counter++;
            Array.Resize(ref Keylist, counter);
            Keylist[counter - 1] = Key;

            Array.Resize(ref Valuelist, counter);
            Valuelist[counter - 1] = Value;
        }
        public TValue this[TKey Key]
        {
            get
            {
                int index = -1;
                for (int i = 0; i < counter; i++)
                {
                    if (Key.Equals(Keylist[i]))
                        index = i;
                }
                if (index == -1)
                {
                    Console.WriteLine(new NullReferenceException().Message);
                    index++;
                }
                return Valuelist[index];
            }
            set
            {
                for (int i = 0; i < counter; i++)
                    if (Key.Equals(Keylist[i]))
                    {
                        Valuelist[i] = value;
                    }
            }
        }
        public IEnumerable GetItems()
        {
            Pair<TKey, TValue> Item;
            for (int i = 0; i < counter; i++)
            {
                Item = new Pair<TKey, TValue>(Keylist[i], Valuelist[i]);
                yield return Item;
            }
        }
    }
    public class Pair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        
        public Pair(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> CityOfUSList = new MyList<string>(22);
            MyDictionary<int, string> CityDictionarList = new MyDictionary<int, string>();
            CityOfUSList.Add("New York");
            CityOfUSList.Add("Dallas");
            CityOfUSList.Add("San Jose");
            CityOfUSList.Add("Minneapolis");
            CityOfUSList.Add("Seattle");
            CityOfUSList.Add("Miami");
            CityOfUSList.Add("Atlanta");
            /*
            Console.WriteLine("--------------- GetItemOfIndex --------------------\n");
            Console.WriteLine("CityOfTajikistanList[2] : {0}",CityOfTajikistanList[2]);
            Console.WriteLine("--------------- GetItems ----------------------\n");
            foreach (var City in CityOfTajikistanList)
            Console.Write("{0}  ",City);
            Console.WriteLine("\n\nЕмкость списка: {0} элемент", CityOfTajikistanList.Capacity);
            Console.WriteLine("Список фактически содержит: {0} элемент", CityOfTajikistanList.Count);*/


            //добавим все элемент из CityOfUSList в CityDictionarList
            for (int i = 0; i < CityOfUSList.Count; i++)
            {
                CityDictionarList.Add(i, CityOfUSList[i]);
            }
            

            for (int i = 0; i < CityDictionarList.Counter; i++)
            {
                Console.WriteLine(CityDictionarList[i]);
            }
            Console.WriteLine("Key  -  Value \n");
            foreach (Pair<int, string> KeyValue in CityDictionarList.GetItems())
                Console.WriteLine(KeyValue.Key + " - " + KeyValue.Value);
            Console.ReadKey();
        }
    }

}
