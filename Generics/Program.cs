using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class GenericLists<T>
    {
        public void Add(T value)
        {
            
        }

        public T this[int index]
        {
            get { throw new NotImplementedException();}
        }
    }

    public class GenericDictionary<TKey, TValue>
    {
        public void Add(TKey key, TValue value)
        {
            
        }
        
    }

    public class Book : Product
    {
        public int Isbn { get; set; }
    }

    // where T : IComparable - implement a certain interface
    // where T : Product - implement a given type
    // where T : struct - implement a value 
    // where T : class - implement a reference type
    // where T : new() - default constructor constraint
    public class Utilities<T> where T : IComparable, new()
    {
        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        //public T Max<T>(T a, T b)
        //{
        //    return a.CompareTo(b) > 0 ? a : b;
        //}

        public void DoSomething(T value)
        {
            var obj = new T();
        }
    }

    public class Product
    {
        public float Price { get; set; }
        public string Title { get; set; }
        
    }

    public class DiscountCalculator<TProduct> where TProduct : Product
    {
        public float CalculateDiscout(TProduct product)
        {
            return product.Price;
        }
    }

    public class Nullable<T> where T : struct
    {
        private object _value;

        public Nullable()
        {
            
        }
        public Nullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            get { return _value != null;}
        }

        public T GetValueOrDefault()
        {
            if (HasValue)
                return (T)_value;

            return default(T);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new GenericLists<int>();
            numbers.Add(10);

            var books = new GenericLists<Book>();
            books.Add(new Book());

            var dictionary = new GenericDictionary<string, Book>();
            dictionary.Add("1234", new Book());

            var numbernew = new Nullable<int>();
            Console.WriteLine("Has value? " + numbernew.HasValue);
            Console.WriteLine("Value: " + numbernew.GetValueOrDefault());

        }
    }
}
