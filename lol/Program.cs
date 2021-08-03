using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lol
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = { 1, 2, 3, 4, 5, 7, 8, 43, 123, 57, 89, 1, 2 };

            IEnumerator enumerator = integers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                int current = (int)enumerator.Current;
                Console.WriteLine(current);
            }
            enumerator.Reset();

            Week week = new Week();
            foreach (var item in week)
            {
                Console.WriteLine(item);
            }

            Dictionary<int, string> days_of_week = new Dictionary<int, string>()
            {
                [1] = "Monday",
                [2] = "Tuesday",
                [3] = "Wednesday",
                [4] = "Friday",
                [5] = "Saturday",
                [6] = "Sunday"
            };
            foreach (KeyValuePair<int,string> item in days_of_week)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            ObservableCollection<int> collection = new ObservableCollection<int>();
            collection.CollectionChanged += Collection_CollectionChanged;
            collection.Add(19);
        }

        private static void Collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Добавлен обьект в коллекцию ");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Обьект удален");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine("Обьект перемещен");
                    break;
                default:
                    break;
            }
        }
    }
    class Week : IEnumerable
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thrusday", "Friday", "Saturday", "Sunday" };

        public IEnumerator GetEnumerator()//возвращаем обьект IEnumerator для массива
        {
            return days.GetEnumerator();
        }
    }
}

