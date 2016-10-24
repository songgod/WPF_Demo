using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPF_MVVM.Interface;
using WPF_MVVM.Utility;

namespace WPF_MVVM.Views
{
    public class VLayer : Canvas
    {
        public VLayer()
        {

        }

        private void ObjectsSource_OnCleared()
        {
            this.Children.Clear();
        }

        private void ObjectsSource_OnItemReplaced(int aIndex, IObject aOldItem, IObject aNewItem)
        {
            ContentControl child = this.Children[aIndex] as ContentControl;
            if (child == null)
                throw new Exception("Child is not ContentControl");

            child.Content = aNewItem;
        }

        private void ObjectsSource_OnItemRemoved(int aIndex, IObject aItem)
        {
            this.Children.RemoveAt(aIndex);
        }

        private void ObjectsSource_OnItemMoved(int aOldIndex, int aNewIndex, IObject aItem)
        {
            UIElement oldlyrcanvas = this.Children[aOldIndex];
            this.Children.RemoveAt(aOldIndex);
            this.Children.Insert(aNewIndex, oldlyrcanvas);
        }

        private void ObjectsSource_OnItemAdded(int aIndex, IObject aItem)
        {
            InsertObject(aIndex, aItem);
        }

        private void InsertObject(int index, IObject obj)
        {
            if (obj == null)
                throw new Exception("InsertObject para obj invalid");
            ContentControl child = new ContentControl() { Content = obj };
            child.SetBinding(Canvas.LeftProperty, new Binding("Left") { Source = obj });
            child.SetBinding(Canvas.RightProperty, new Binding("Right") { Source = obj });
            this.Children.Insert(index, child);
        }

        private static void OnObjectSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            VLayer layer = (VLayer)d;
            layer.Children.Clear();
            if (layer.ObjectsSource != null)
            {
                layer.ObjectsSource.OnItemAdded += layer.ObjectsSource_OnItemAdded;
                layer.ObjectsSource.OnItemMoved += layer.ObjectsSource_OnItemMoved;
                layer.ObjectsSource.OnItemRemoved += layer.ObjectsSource_OnItemRemoved;
                layer.ObjectsSource.OnItemReplaced += layer.ObjectsSource_OnItemReplaced;
                layer.ObjectsSource.OnCleared += layer.ObjectsSource_OnCleared;
                for (int i = 0; i < layer.ObjectsSource.Count; i++)
                {
                    layer.InsertObject(i, layer.ObjectsSource[i]);
                }
            }
        }

        public ObservedCollection<IObject> ObjectsSource
        {
            get { return (ObservedCollection<IObject>)GetValue(ObjectsSourceProperty); }
            set { SetValue(ObjectsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ObjectsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ObjectsSourceProperty =
            DependencyProperty.Register("ObjectsSource", typeof(ObservedCollection<IObject>), typeof(VLayer),new FrameworkPropertyMetadata(null, new PropertyChangedCallback(VLayer.OnObjectSourceChanged)));
    }
}
