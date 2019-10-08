using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;



namespace Listification.Models
{
    public class Listify : IEnumerable<int>
    {
        int _start = 0;
        int _end = 0;
        public Listify(int start, int end)
        {
            _start = start;
            _end = end;
        }

        public int this[int index]
        {
            get
            {
                var a = Enumerable.Range(_start, _end);
                return a.ElementAt(index);
            }
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (var current = _start; current < _end; ++current)
            {
                yield return current;
            }
        }
    }

    public static class MyExtensions
    {
        public static int Should(this int number)
        {
            return number;
        }

        public static bool Equal(this int number, int newNumber)
        {
            return number.Equals(newNumber);

        }
    }
}