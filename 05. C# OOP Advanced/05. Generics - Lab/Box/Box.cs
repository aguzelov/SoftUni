namespace Box
{
    public class Box<T> : IBox<T>
    {
        private T[] data;
        private readonly int defaultCapacity = 4;
        private readonly int defaultCapacityIncreaser = 2;
        private int capacity;

        public Box()
        {
            this.data = new T[defaultCapacity];
            this.capacity = defaultCapacity;

            this.Count = 0;
        }

        public void Add(T element)
        {
            this.data[this.Count] = element;
            this.Count++;
            if (this.Count == this.capacity)
                IncreaseCapacity();
        }

        private void IncreaseCapacity()
        {
            int newCapacity = this.capacity * defaultCapacityIncreaser;
            T[] newData = new T[newCapacity];
            this.capacity = newCapacity;

            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
        }

        public T Remove()
        {
            T element = this.data[this.Count - 1];
            this.Count--;

            if(this.Count == this.capacity/this.defaultCapacityIncreaser)
                DecreaseCapacity();

            return element;
        }

        private void DecreaseCapacity()
        {
            int newCapacity = this.capacity - (this.capacity / this.defaultCapacity);

            T[] newData = new T[newCapacity];

            for (int i = 0; i < newData.Length; i++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
            this.capacity = newCapacity;
        }

        public int Count { get; private set; }
    }
}