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
    public class VMap : Canvas
    {
        public VMap()
        {
            
        }

        private void LayersSource_OnCleared()
        {
            this.Children.Clear();
        }

        private void LayersSource_OnItemReplaced(int aIndex, ILayer aOldItem, ILayer aNewItem)
        {
            UpdateLayerSource(aIndex, aNewItem);
        }

        private void LayersSource_OnItemRemoved(int aIndex, ILayer aItem)
        {
            this.Children.RemoveAt(aIndex);
        }

        private void LayersSource_OnItemMoved(int aOldIndex, int aNewIndex, ILayer aItem)
        {
            UIElement oldlyrcanvas = this.Children[aOldIndex];
            this.Children.RemoveAt(aOldIndex);
            this.Children.Insert(aNewIndex, oldlyrcanvas);
        }

        private void LayersSource_OnItemAdded(int aIndex, ILayer aItem)
        {
            InsertLayer(aIndex, aItem);
        }

        private void InsertLayer(int index, ILayer layer)
        {
            if (layer == null)
                throw new Exception("InsertLayer para layer invalid");
            VLayer laycanvas = new VLayer();
            this.Children.Insert(index, laycanvas);
            UpdateLayerSource(index, layer);            
        }

        private void UpdateLayerSource(int index, ILayer layer)
        {
            if (layer == null)
                throw new Exception("UpdateLayerSource para newlayer invalid");

            VLayer oldlyrcanvas = this.Children[index] as VLayer;
            if (oldlyrcanvas==null)
                throw new Exception("UpdateLayerSource para child is not VLayer");
            
            Binding binding = new Binding("Objects") { Source = layer };
            BindingOperations.SetBinding(oldlyrcanvas, VLayer.ObjectsSourceProperty, binding);
            Binding bdname = new Binding("Name") { Source = layer };
            BindingOperations.SetBinding(oldlyrcanvas, FrameworkElement.NameProperty, binding);
        }
        
        private static void OnLayerSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            VMap map = (VMap)d;
            map.Children.Clear();
            if (map.LayersSource != null)
            {
                map.LayersSource.OnItemAdded += map.LayersSource_OnItemAdded;
                map.LayersSource.OnItemMoved += map.LayersSource_OnItemMoved;
                map.LayersSource.OnItemRemoved += map.LayersSource_OnItemRemoved;
                map.LayersSource.OnItemReplaced += map.LayersSource_OnItemReplaced;
                map.LayersSource.OnCleared += map.LayersSource_OnCleared;
                for (int i = 0; i < map.LayersSource.Count; i++)
                {
                    map.InsertLayer(i, map.LayersSource[i]);
                }
            }
        }

        public ObservedCollection<ILayer> LayersSource
        {
            get { return (ObservedCollection<ILayer>)GetValue(LayersSourceProperty); }
            set { SetValue(LayersSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LayersSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LayersSourceProperty =
            DependencyProperty.Register("LayersSource", typeof(ObservedCollection<ILayer>), typeof(VMap), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(VMap.OnLayerSourceChanged)));
    }
}
