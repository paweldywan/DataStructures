﻿using System;

namespace DataStructures
{
    public class ItemDiscardedEventArgs<T> : EventArgs
    {
        public ItemDiscardedEventArgs(T itemDiscarded, T newItem)
        {
            ItemDiscarded = itemDiscarded;
            NewItem = newItem;
        }

        public T ItemDiscarded { get; private set; }
        public T NewItem { get; private set; }
    }
}
