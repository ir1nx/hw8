using System;

namespace Homework8
{
    public class AgileLinkedList<T>
    {
        public Node<T> First { get; set; }
        public Node<T> Last { get; set; }
        int Count { get; set; }
        public class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Next { get; set; }
            public Node<T> Prev { get; set; }
            public Node(T data, Node<T> prev, Node<T> next)
            {
                Data = data;
                Prev = prev;
                Next = next;
            }

        }

        public AgileLinkedList(IEnumerable<T> a)
        {
            foreach (var item in a)
                AddLast(item);
        }

        public override string ToString()
        {
            return $"first = {First.Data} last = {Last.Data} count = {Count}";
        }

        public void AddFirst(T x)
        {
            var p = new Node<T>(x, null, First);
            if (First != null)
                First.Prev = p;
            First = p;
            if (Last == null)
                Last = p;

            Count++;
        }
        public void AddLast(T x)
        {
            var p = new Node<T>(x, Last, null);
            if (Last != null)
                Last.Next = p;
            Last = p;
            if (First == null)
                First = p;

            Count++;
        }

        public void RemoveFirst()
        {
            if (First == null)
                throw new InvalidOperationException();
            First = First.Next;
            if (First == null)
                Last = null;
            else First.Prev = null;

            Count--;
        }

        public void RemoveLast()
        {
            if (Last == null)
                throw new InvalidOperationException();
            Last = Last.Prev;
            if (Last == null)
                First = null;
            else Last.Next = null;

            Count--;
        }

        public void Remove(int n)
        {
            if (n < 0 || (Count != -1 && n >= Count))
                throw new ArgumentOutOfRangeException();

            if (First == null)
                throw new InvalidOperationException();

            if (n == 0)
            {
                RemoveFirst();
                return;
            }

            if (Count != -1 && n == Count - 1)
            {
                RemoveLast();
                return;
            }

            Node<T> elem = First;
            for (int i = 0; i < n; i++)
            {
                elem = elem.Next;
                if (elem == null)
                    throw new ArgumentOutOfRangeException();
            }

            elem.Prev.Next = elem.Next;
            if (elem.Next != null)
                elem.Next.Prev = elem.Prev;

            if (Count != -1)
                Count--;
        }

        public void AddBefore(int n, T x)
        {
            if (n < 0 || (Count != -1 && n >= Count))
                throw new ArgumentOutOfRangeException();

            if (First == null)
                throw new InvalidOperationException();

            if (n == 0)
            {
                AddFirst(x);
                return;
            }

            if (Count != -1 && n == Count - 1)
            {
                AddLast(x);
                return;
            }

            Node<T> elem = First;
            for (int i = 0; i < n; i++)
            {
                elem = elem.Next;
                if (elem == null)
                    throw new ArgumentOutOfRangeException();
            }

            elem.Next = new Node<T>(x, elem, elem.Next);
            Count++;


        }
        public void CircleShift(int n)
        {
            if (First == null || First == Last || n == 0)
                return;

            n = n % Count;
            for (int i = 0; i < n; i++)
            {
                Node<T> newFirst = First.Next;

                Last.Next = First;
                First.Prev = Last;
                First.Next = null;

                Last = First;
                First = newFirst;
                First.Prev = null;
            }
        }
        public bool IsPalindorom()
        {
            if (Count == 0 || Count == 1) return true;

            return Traversal(First, Last);

            bool Traversal(Node<T> first, Node<T> last)
            {
                if (!first.Data.Equals(last.Data)) return false;
                if (first.Next == last || first == last) return true;
                return Traversal(first.Next, last.Prev);
            }
        }

        public void Print()
        {
            for (var item = First; item != null; item = item.Next)
                Console.Write($"{item.Data} ");
            Console.WriteLine();
        }


    }

    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Task2");
            var lst = new AgileLinkedList<int>([1, 2, 3, 2, 1]);
            lst.Print();
            Console.WriteLine($"lst.IsPalindorom() -> {lst.IsPalindorom()}");

            Console.WriteLine("Task3");
            lst.Print();
            lst.Remove(2);
            lst.Print();

            lst.AddBefore(2, 7);
            lst.Print();

            Console.WriteLine("Task4");
            lst.Print();
            lst.CircleShift(2);
            lst.Print();
            

        }
    }
}
