using System;
using System.Collections;
using System.Collections.Generic;

public class Clinic : IEnumerable<Pet>
{
    private int filledCount;

    public Clinic(string name, Pet[] rooms)
    {
        if (rooms.Length % 2 == 0)
            throw new InvalidOperationException("Invalid Operation!");

        this.Name = name;
        this.Rooms = rooms;
        this.filledCount = 0;
    }

    public string Name { get; private set; }

    public Pet[] Rooms { get; private set; }

    public bool Add(Pet pet)
    {
        var iter = new AddIterator(this.Rooms);

        if (iter.MoveNext())
        {
            this.Rooms[iter.Index] = pet;
            this.filledCount++;
            return true;
        }

        return false;
    }

    public bool Release()
    {
        var iter = new ReleaseIterator(this.Rooms);

        if (iter.MoveNext())
        {
            this.Rooms[iter.Index] = null;
            this.filledCount--;
            return true;
        }

        return false;
    }

    public bool HasEmptyRooms => this.filledCount < this.Rooms.Length;

    public string Print(int room)
    {
        Pet pet = this.Rooms[--room];

        if (pet == null) return "Room empty";

        return pet.ToString();
    }

    public IEnumerator<Pet> GetEnumerator()
    {
        foreach (var pet in Rooms)
        {
            yield return pet;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private class AddIterator : IEnumerator<Pet>
    {
        private Pet[] rooms;

        public AddIterator(Pet[] rooms)
        {
            this.rooms = rooms;
            this.Reset();
        }

        public int Index { get; set; }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (this.rooms[this.Index] == null)
            {
                return true;
            }

            int padding = 1;
            bool toLeft = true;
            while (this.Index - padding >= 0 || this.Index + padding < this.rooms.Length)
            {
                if (toLeft)
                {
                    int currentIndex = this.Index - padding;
                    if (AddToIndex(currentIndex))
                    {
                        this.Index = currentIndex;
                        return true;
                    }

                    toLeft = false;
                }
                else
                {
                    int currentIndex = this.Index + padding;
                    if (AddToIndex(currentIndex))
                    {
                        this.Index = currentIndex;
                        return true;
                    }

                    toLeft = true;
                    padding++;
                }
            }

            return false;
        }

        private bool AddToIndex(int index)
        {
            if (index < 0 || index >= this.rooms.Length) return false;

            if (this.rooms[index] == null)
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
            this.Index = this.rooms.Length / 2;
        }

        public Pet Current
        {
            get { return this.rooms[this.Index]; }
        }

        object IEnumerator.Current => this.Current;
    }

    private class ReleaseIterator : IEnumerator<Pet>
    {
        private Pet[] rooms;

        public ReleaseIterator(Pet[] rooms)
        {
            this.rooms = rooms;
            this.Reset();
        }

        public int Index { get; set; }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (this.rooms[this.Index] != null)
            {
                this.rooms[this.Index] = null;
                return true;
            }

            int padding = 1;
            bool toRight = true;
            while (true)
            {
                if (toRight)
                {
                    int currentIndex = this.Index + padding;
                    if (currentIndex >= this.rooms.Length)
                    {
                        toRight = false;
                        continue;
                    }

                    if (Release(currentIndex))
                    {
                        this.Index = currentIndex;
                        return true;
                    }

                    padding++;
                }
                else
                {
                    padding--;
                    int currentIndex = this.Index - padding;
                    if (currentIndex == this.rooms.Length / 2)
                    {
                        return false;
                    }

                    if (Release(currentIndex))
                    {
                        this.Index = currentIndex;
                        return true;
                    }
                }
            }
        }

        private bool Release(int index)
        {
            if (this.rooms[index] != null)
            {
                this.rooms[index] = null;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            this.Index = this.rooms.Length / 2;
        }

        public Pet Current
        {
            get { return this.rooms[this.Index]; }
        }

        object IEnumerator.Current => this.Current;
    }
}