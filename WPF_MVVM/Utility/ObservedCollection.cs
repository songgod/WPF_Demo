﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM.Utility
{
    public class ObservedCollection<T> : ObservableCollection<T>
    {
        public ObservedCollection()
        {
            this.CollectionChanged += ObservedCollection_CollectionChanged;
        }

        public delegate void ObservedCollectionAddDelegate(int aIndex, T aItem);
        public event ObservedCollectionAddDelegate OnItemAdded;

        public delegate void ObservedCollectionMoveDelegate(int aOldIndex, int aNewIndex, T aItem);
        public event ObservedCollectionMoveDelegate OnItemMoved;

        public delegate void ObservedCollectionRemoveDelegate(int aIndex, T aItem);
        public event ObservedCollectionRemoveDelegate OnItemRemoved;

        public delegate void ObservedCollectionReplaceDelegate(int aIndex, T aOldItem, T aNewItem);
        public event ObservedCollectionReplaceDelegate OnItemReplaced;

        public delegate void ObservedCollectionResetDelegate();
        public event ObservedCollectionResetDelegate OnCleared;

        private void ObservedCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (OnItemAdded!=null) OnItemAdded(e.NewStartingIndex, (T)e.NewItems[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    if (OnItemRemoved!=null) OnItemRemoved(e.OldStartingIndex, (T)e.OldItems[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    if (OnItemReplaced!=null) OnItemReplaced(e.OldStartingIndex, (T)e.OldItems[0], (T)e.NewItems[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    if (OnItemMoved != null) OnItemMoved(e.OldStartingIndex, e.NewStartingIndex, (T)e.NewItems[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    if (OnCleared!=null) OnCleared();
                    break;
                default:
                    break;
            }
        }
    }
}
