using System;
using System.Collections.Generic;

namespace Assesment2_BL
{
    /// <summary>
    /// Type Fixed buffer is Wrapper for System.Collections.Generic.Queue
    /// </summary>
    public class FixedBuffer
    {
        private readonly int _size;
        private readonly Queue<string> _buffer;

        /// <summary>
        /// Add Data into Buffer
        /// </summary>
        /// <param name="data"></param>
        public void AddData(string data)
        {
            this._buffer.Enqueue(data);
        }

        // OverWrite the OldestValue
        /// <summary>
        /// Removes the oldest data in buffer and add new data
        /// </summary>
        /// <execption cref="InvalidOperationException"></execption>
        /// <param name="data"> the data which is to be added </param>
        public void OverWriteOldestData(string data)
        {
            RemoveFirstData();
            AddData(data);
        }

        // Remove The Oldest data in buffer
        private void RemoveFirstData()

        {
            try
            {
                this._buffer.Dequeue();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }

        /// <summary>
        /// Get the Oldest Data
        /// </summary>
        /// <execption cref="InvalidOperationException"></execption>
        /// <returns>Oldest Data</returns>
        public string GetOldestData()
        {
            return this._buffer.Peek();
        }

        /// <summary>
        /// Tell Buffer is full or not
        /// </summary>
        /// <returns> boolean value represent buffer is full or not</returns>
        public bool IsBufferFull()
        {
            return this._size == this._buffer.Count;
        }

        /// <summary>
        /// Return the data inside buffer
        /// </summary>
        /// <returns>Array<> of data in buffer</returns>
        public string[] GetBufferData()
        {
            return this._buffer.ToArray();
        }

        /// <summary>
        /// initialize the new instance of Fixed Buffer
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> WHen the argument is negative</exception>
        /// <exception cref="ArgumentOutOfRangeException"> When the argument is 0</exception>
        /// <param name="n"> Represent size of fixed buffer </param>
        public FixedBuffer(int n)
        {
            if (n == 0)
            {
                throw new Exception("The size of buffer cannot be initialiaze to 0");
            }
            this._size = n;
            this._buffer = new Queue<string>(n);
        }
    }
}