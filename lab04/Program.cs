using System.Collections;
using static System.Console;

namespace Lab04_ADS
{
    class Program
    {
        public static void Main(string[] args)
        {
            Write("Enter a number of elements in the list: "); int count = Convert.ToInt32(ReadLine());

            DoublyLinkedList<int> linkedList = GenerateLinkedList(count);

            while (true)
            {
                Clear();
                linkedList.Print();
                int elem; int pos;
                Write("Please enter an operation [Add (To Front, To End, Before/After), [Delete (First, Last, At position], {Special}: ");
                var op = ReadLine().ToLower().Trim();

                switch (op)
                {
                    case "add to front":
                        Write("Enter a value: "); elem = Convert.ToInt32(ReadLine().Trim());
                        linkedList.AddFirst(elem);
                        continue;
                    case "add to end":
                        Write("Enter a value: "); elem = Convert.ToInt32(ReadLine().Trim());
                        linkedList.AddLast(elem);
                        continue;
                    case "add at position":
                        Write("Enter a value: "); elem = Convert.ToInt32(ReadLine().Trim());
                        Write("Enter a position: "); pos = Convert.ToInt32(ReadLine().Trim());
                        linkedList.AddAtPosition(elem, pos);
                        continue;
                    case "delete first":
                        linkedList.DeleteFirst();
                        continue;
                    case "delete last":
                        linkedList.DeleteLast();
                        continue;
                    case "delete at position":
                        Write("Enter a position: "); pos = Convert.ToInt32(ReadLine().Trim());
                        linkedList.DeleteAtPosition(pos);
                        continue;
                    case "special":
                        Write("Enter a value: "); elem = Convert.ToInt32(ReadLine().Trim());
                        linkedList.SpecialOperation(elem);
                        continue;
                    case "exit":
                        WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    

                    
                    default:
                        continue;
                }
            }
        }

        static DoublyLinkedList<int> GenerateLinkedList(int count)
        {
            Random rnd = new Random();

            DoublyLinkedList<int> dbllst = new DoublyLinkedList<int>();

            int n = 0;
            while (n < count)
            {
                dbllst.AddLast(rnd.Next(-100, 100));
                n++;
            }


            return dbllst;
        }
    }

    public class DLNode<T>
    {
        public T Data { get; set; }
        public DLNode<T> next { get; set; }
        public DLNode<T> prev { get; set; }


        public DLNode(T data)
        {
            Data = data;
        }
    }

    public class DoublyLinkedList<T>
    {
        DLNode<T> head;
        DLNode<T> tail;
        int count = 0;

        public void AddFirst(T data)
        {
            DLNode<T> node = new DLNode<T>(data);

            if (count == 0)
            {
                head = tail = node;
            }
            else
            {
                head.prev = node;
                node.next = head;
                head = node;
            }
            head.prev = null;
            count++;

        }

        public void AddLast(T data)
        {
            DLNode<T> node = new DLNode<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.next = node;
                node.prev = tail;
            }
            tail = node;
            tail.next = null;
            count++;
        }

        public void AddAtPosition(T data, int pos)
        {
            if (pos == 1)
            {
                AddFirst(data);
            }
            else
            {
                DLNode<T> node = new DLNode<T>(data);
                DLNode<T> current = head;

                for (int n = 1; n <= pos - 2; n++)
                    current = current.next;

                node.next = current.next;
                current.next = node;
                node.prev = current;
            }
            count++;

        }

        public void AddAfter(T data, int pos)
        {
            if (pos == 0)
            {
                AddFirst(data);
            }
            else if (pos >= count)
            {
                AddLast(data);
            }
            else
            {
                DLNode<T> node = new DLNode<T>(data);
                DLNode<T> current = head;

                for (int n = 0; n < pos - 1; n++)
                    current = current.next;

                node.next = current.next;
                current.next.prev = node;
                current.next = node;
                node.prev = current;
            }
            count++;

        }

        public void AddBefore(T data, int pos)
        {
            if (pos == 1)
            {
                AddFirst(data);
            }
            else if (pos >= count)
            {
                AddLast(data);
            }
            else
            {
                DLNode<T> node = new DLNode<T>(data);
                DLNode<T> current = head;

                for (int n = 0; n < pos - 1; n++)
                    current = current.next;

                node.next = current;
                node.prev = current.prev;
                current.prev.next = node;
            }
            count++;

        }

        public void DeleteFirst()
        {
            head = head.next;
            head.prev = null;
            count--;
        }
        public void DeleteLast()
        {
            tail = tail.prev;
            tail.next = null;
            count--;
        }

        public void DeleteAtPosition(int pos)
        {
            DLNode<T> current = head;

            if (pos >= count)
                DeleteLast();
            else if (pos == 1)
                DeleteFirst();
            else
            {
                for (int n = 0; n < pos - 1; n++)
                    current = current.next;

                current.prev.next = current.next;
                current.next.prev = current.prev;
            }
            count--;
        }

        public void Print()
        {
            DLNode<T> current = head;
            Write(current.Data + " <-> "); current = current.next;

            while (current != null)
            {
                if (current == tail)
                {
                    WriteLine(current.Data);
                    break;
                }
                else
                {
                    Write(current.Data + " <-> ");
                    current = current.next;
                }
            }
        }

        public int MinElem()
        {
            DLNode<T> current = head;
            int min = Convert.ToInt32(current.Data);

            while (current != null)
            {
                if (Convert.ToInt32(current.Data) < min)
                    min = Convert.ToInt32(current.Data);
                current = current.next;
            }

            return min;
        }

        public void SpecialOperation(T data)
        {
            int counter = 1;
            
            DLNode<T> dLNode = new DLNode<T>(data);

            DLNode<T> current = head;

            int min = MinElem();

            while (Convert.ToInt32(current.Data) != min)
            {
                counter++;
                current = current.next;
            }

            if (Convert.ToInt32(dLNode.Data) > min)
                AddAfter(dLNode.Data, counter);
            else
                AddBefore(dLNode.Data, counter);
        }
    }
}