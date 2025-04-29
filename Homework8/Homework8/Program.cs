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
        }
        public void AddLast(T x)
        {
            var p = new Node<T>(x, Last, null);
            if (Last != null)
                Last.Next = p;
            Last = p;
            if (First == null)
                First = p;
        }

        public bool IsPalindorom()
        {
            if (Count == 0 || Count == 1) return true;

            return Traversal(First, Last);

            bool Traversal(Node<T> first, Node<T> last)
            {
                if (!first.Data.Equals(last.Data)) return false;
                if (first.Next == last.Prev || first == last) return true;
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

            var lst = new AgileLinkedList<int>([1, 2, 3, 2, 1]);
            lst.Print();
            Console.WriteLine($"lst.IsPalindorom() -> {lst.IsPalindorom()}");
        }
    }
}
