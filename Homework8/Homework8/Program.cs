namespace Homework8
{
    public class AgileLinkedList<T>
    {
        public Node<T> First {  get; set; }
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

        public override string ToString()
        {
            return $"first = {First.Data} last = {Last.Data} count = {Count}";
        }

    }

    internal class Program
    {
        static void Main()
        {
            
        }
    }
}
