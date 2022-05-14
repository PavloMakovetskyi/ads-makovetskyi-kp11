using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace Lab06_ADS
{
    class Program
    {
        static ArrayStack srcstack;
        
        public static void Main(string[] args)
        {
            while (true)
            {
                WriteLine("Welcome to the Hanoi Tower Game!");
                Write("How many disks would you like to play with?: ");
                int numDisks = int.Parse(ReadLine());
                ArrayStack stackA = new ArrayStack(numDisks); FillStack(stackA);
                ArrayStack stackB = new ArrayStack(numDisks); srcstack = new ArrayStack(numDisks);
                ArrayStack stackC = new ArrayStack(numDisks); FillStack(srcstack);                
                HanoiTowers(stackA, stackB, stackC);
                Write("Would you like to play again? (y/n): ");
                if (ReadLine().ToLower() == "n") break;
            }
            
            
            
        }

        static void FillStack(ArrayStack stack)
        {
            int count = stack._size;

            while (count > 0)
            {
                stack.Push(count);
                --count;
            }
        }

        static bool isSolved(ArrayStack srcstack, ArrayStack deststack)
        {
            int count = 0;
            
            for (int i = 0; i < srcstack._size; i++)
            {
                if (srcstack._items[i] == deststack._items[i])
                {
                    count++;
                }
              
            }

            if (count == 3)
            {
                return true;
            }
            else
            {
                count = 0;
            }
            return false;
        }

        static void HanoiTowers(ArrayStack A, ArrayStack B, ArrayStack C)
        {

            
            void MoveDisk(ArrayStack A,  ArrayStack B)
            {
                if (!A.IsEmpty())
                {
                    if (B.IsEmpty() || B.Peek() > A.Peek())
                    {
                        B.Push(A.Pop());
                    }
                    else
                        WriteLine("Can't to this");
                }
                else
                    WriteLine("Wrong action");
            }

            while (true)
            {
                WriteLine("1. From A to B | 2. From A to C | 3. From B to C | 4. From B to A | 5. From C to B | 6. From C to A |");
                Write("Choose an action: "); int action = Convert.ToInt32(ReadLine());

                switch (action)
                {
                    case 1:
                        WriteLine("A -> B");
                        MoveDisk(A, B);
                        break;
                    case 2:
                        WriteLine("A -> C");
                        MoveDisk(A, C);
                        break;
                    case 3:
                        WriteLine("B -> C");
                        MoveDisk(B, C);
                        break;
                    case 4:
                        WriteLine("B -> A");
                        MoveDisk(B, A);
                        break;
                    case 5:
                        WriteLine("C -> B");
                        MoveDisk(C, B);
                        break;
                    case 6:
                        WriteLine("C -> A");
                        MoveDisk(C, A);
                        break;
                }

                isSolved(srcstack, C);

                if (isSolved(srcstack, C))
                {
                    WriteLine("Solved");
                    break;
                }


                Print(A); WriteLine(); Print(B); WriteLine(); Print(C);

                ReadKey(); Clear();
            }


            void Print(ArrayStack st)
            {
                for (int i = 1; i <= st._size; i++)
                {
                    if (st._items[^i] == 0)
                    {
                        for (int space = 1; space < st._size; space++)
                            Console.Write(" ");
                        Console.WriteLine("|");
                    }
                    else
                    {
                        for (int space = 1; space <= (st._size - (i - (i - 1))); space++)
                            Console.Write(" ");
                        Write(String.Concat(Enumerable.Repeat("*", st._items[^i])));
                        Console.WriteLine();
                    }
                }
            }
        }

        class ArrayStack
        {
            public int[] _items;
            public int _size;
            public int _top;

            public ArrayStack(int size)
            {
                _items = new int[size];
                _size = size;
                _top = -1;
            }

            public void Push(int item)
            {
                if (_top == _size - 1)
                {
                    throw new Exception("Stack is full");
                }
                _top++;
                _items[_top] = item;
            }

            public int Pop()
            {
                if (_top == -1)
                {
                    throw new Exception("Stack is empty");
                }
                int item = _items[_top];
                _items[_top] = 0;
                _top--;
                return item;
            }

            public int Peek()
            {
                if (_top == -1)
                {
                    throw new Exception("Stack is empty");
                }
                return _items[_top];
            }

            public bool IsEmpty()
            {
                return _top == -1;
            }
        }
    }
}

