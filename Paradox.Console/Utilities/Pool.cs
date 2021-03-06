﻿using System.Collections.Generic;

namespace Varus.Paradox.Console.Utilities
{
    internal class Pool<T> where T : class
    {
        private int _capacity;
        private readonly Queue<T> _queue;
        private readonly IFactory<T> _factory;

        public Pool(IFactory<T> factory, int initialCapacity = 4)
        {
            Check.ArgumentNotNull(factory, "factory");
            Check.ArgumentNotLessThan(initialCapacity, 1, "initialCapacity");            

            _factory = factory;
            _capacity = initialCapacity;
            _queue = new Queue<T>(initialCapacity);
            IncreasePool();
        }

        public T Fetch()
        {
            if (_queue.Count <= 0)
            {
                IncreasePool();
            }
            return _queue.Dequeue();
        }

        public void Release(T item)
        {
            _queue.Enqueue(item);
        }

        private void IncreasePool()
        {
            for (int i = 0; i < _capacity; ++i)
                _queue.Enqueue(_factory.New());
            _capacity *= 2;
        }
    }
}
