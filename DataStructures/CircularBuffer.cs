using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface IBuffer<T> : IEnumerable<T>
    {
        bool IsEmpty { get; }
        void Write(T value);
        T Read();
    }

    public class Buffer<T> : IBuffer<T>
    {
        protected Queue<T> _queue = new Queue<T>();

        public virtual bool IsEmpty
        {
            get { return _queue.Count == 0; }
        }

        public virtual void Write(T value)
        {
            _queue.Enqueue(value);
        }

        public virtual T Read()
        {
            return _queue.Dequeue();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _queue)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class CircularBuffer<T> : Buffer<T>
    {
        int _capacity;

        public CircularBuffer(int capacity = 10)
        {
            _capacity = capacity;
        }

        public override void Write(T value)
        {
            base.Write(value);

            if(_queue.Count > _capacity)
            {
                _queue.Dequeue();
            }
        }

        public bool IsFull => _queue.Count == _capacity;
    }

    //public class CircularBuffer<T> : IBuffer<T>
    //{
    //    private T[] _buffer;
    //    private int _start;
    //    private int _end;

    //    public CircularBuffer() : this(capacity: 10)
    //    {
    //    }

    //    public CircularBuffer(int capacity)
    //    {
    //        _buffer = new T[capacity + 1];
    //        _start = 0;
    //        _end = 0;
    //    }

    //    public void Write(T value)
    //    {
    //        _buffer[_end] = value;
    //        _end = (_end + 1) % _buffer.Length;

    //        if (_end == _start)
    //        {
    //            _start = (_start + 1) % _buffer.Length;
    //        }
    //    }

    //    public T Read()
    //    {
    //        T result = _buffer[_start];
    //        _start = (_start + 1) % _buffer.Length;

    //        return result;
    //    }

    //    public int Capacity
    //    {
    //        get { return _buffer.Length; }
    //    }

    //    public bool IsEmpty
    //    {
    //        get { return _end == _start; }
    //    }

    //    public bool IsFull
    //    {
    //        get { return (_end + 1) % _buffer.Length == _start; }
    //    }
    //}
}
