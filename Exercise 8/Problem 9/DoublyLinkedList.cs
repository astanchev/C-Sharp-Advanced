using System;
using System.Collections.Generic;

namespace _09.CustomLinkedList
{
    public class DoublyLinkedList<T>
    where T : IComparable<T>
    {
        private class LinkNode
        {
            public T Value { get; }

            public LinkNode(T value)
            {
                this.Value = value;
            }

            public LinkNode NextNode { get; set; }

            public LinkNode PreviousNode { get; set; }

        }

        private LinkNode head;
        private LinkNode tail;

        public int Count { get; private set; }
        public void AddFirst(T value)
        {
            LinkNode newHead = new LinkNode(value);

            if (Count == 0)
            {
                this.head = newHead;
                this.tail = newHead;
            }
            else
            {
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }
        public void AddLast(T value)
        {
            LinkNode newTail = new LinkNode(value);

            if (Count == 0)
            {
                this.head = newTail;
                this.tail = newTail;
            }
            else
            {
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }
        public T RemoveFirst()
        {
            CheckIfEmptyThrowException();

            T firstElement = this.head.Value;
            this.head = this.head.NextNode;
            if (this.head == null)
            {
                this.tail = null;
            }
            else
            {
                this.head.PreviousNode = null;
            }

            this.Count--;

            return firstElement;
        }
        public T RemoveLast()
        {
            CheckIfEmptyThrowException();

            T lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;
            if (this.tail == null)
            {
                this.head = null;
            }
            else
            {
                this.tail.NextNode = null;
            }

            this.Count--;

            return lastElement;
        }

        public bool Contains(T value)
        {
            var currentNode = this.head;

            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0)
                {
                    return true;
                }
                currentNode = currentNode.NextNode;
            }

            return false;
        }
        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            var currentNode = this.head;
            int counter = 0;

            while (currentNode != null)
            {
                array[counter++] = currentNode.Value;

                currentNode = currentNode.NextNode;
            }

            return array;
        }

        public List<T> ToList()
        {
            List<T> list = new List<T>(this.Count);

            var currentNode = this.head;

            while (currentNode != null)
            {
                list.Add(currentNode.Value);

                currentNode = currentNode.NextNode;
            }

            return list;
        }

        public void Print(Action<T> action)
        {
            LinkNode currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
            }
        }
        private void CheckIfEmptyThrowException()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("DoublyLinkedList is Empty");
            }

        }


    }
}