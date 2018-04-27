using System;

namespace _01.DataBaseT
{
    public class Database
    {
        private const int ArrayCapacity = 16;
        private string FullMessage = "Array is full!";
        private string EmptyMessage = "Array is empty!";
        private string InvalidOperation = "Invalid operation!";
        private int index;

        private int[] store;

        public int[] Store { get => store; set => store = value; }

        private Database()
        {
            this.Store = new int[ArrayCapacity];
        }
        public Database(params int[] elements)
            :this()
        {
            this.InitializeElements(elements);
            this.index = 0;
        }

        private void InitializeElements(int[] elements)
        {
            try
            {
                foreach (var element in elements)
                {
                    this.Add(element);
                }
            }
            catch (Exception ex)
            {
               throw new InvalidOperationException(FullMessage);
            }
        }

      

        public void Add(int element)
        {
            if (index >= ArrayCapacity)
            {
                throw new InvalidOperationException(FullMessage);
            }
            this.Store[index] = element;
            index++;
        }

        public void Remove()
        {
            if (index == 0)
            {
                throw new InvalidOperationException(EmptyMessage);
            }

            index--;
            this.Store[index] = default(int);
        }

        public int[] FetchMethod()
        {
            var newArray = new int[index];
            Array.Copy(this.Store, newArray, index);

            return newArray;


        }
    }
}
