using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WellColumn
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Point m_CurrPos = new Point() { X = 0, Y = 0 };
        
        public MainWindow()
        {
            InitializeComponent();
            InitalizeColumns();
        }

        private void InitalizeColumns()
        {
            Random rdm = new Random();
            
            int nCount = 100;
             int numPoints = 2000;
             int xinterval = 50;
             int yinterval = 5;
             this.canvas.Children.Add(new Rectangle() { Width = nCount * xinterval, Height = numPoints * yinterval, Fill = new SolidColorBrush() { Color = Colors.WhiteSmoke } });
            for (int i = 0; i < nCount; i++)
            {
                Path p = new Path();
                PathGeometry pg = new PathGeometry();
                PathFigure pf = new PathFigure();
                PolyLineSegment ps = new PolyLineSegment();
                LinearGradientBrush lgb = new LinearGradientBrush() { StartPoint = new Point(0, 0), EndPoint = new Point(0, 1) };

                double offsetx = i * xinterval;
                pf.StartPoint = new Point() { X = offsetx, Y = 0 };
                lgb.GradientStops.Add(new GradientStop() { Color = Colors.White, Offset=0});
                for (int j = 0; j < numPoints; j++)
                {
                    Point pt = new Point() { X = rdm.Next(0, 20) + offsetx, Y = j * yinterval };
                    ps.Points.Add(pt);
                    lgb.GradientStops.Add(new GradientStop() { Color = Color.FromRgb((byte)rdm.Next(0, 255), (byte)rdm.Next(0, 255), (byte)rdm.Next(0, 255)), Offset=(double)j/numPoints });
                }
                ps.Points.Add(new Point() { X = offsetx, Y = numPoints * yinterval });
                lgb.GradientStops.Add(new GradientStop() { Color = Colors.White , Offset=1});
                pf.Segments.Add(ps);
                pf.IsClosed = true;
                pg.Figures.Add(pf);
                
                p.Data = pg;

                p.Fill = lgb;
                p.Stroke = new SolidColorBrush() { Color = Colors.Black };
                this.canvas.Children.Add(p);
            }

            
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            m_CurrPos = e.GetPosition(this);
            this.canvas.CaptureMouse();
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            m_CurrPos = new Point() { X = 0, Y = 0 };
            this.canvas.ReleaseMouseCapture();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton==MouseButtonState.Pressed)
            {
                Point mp = e.GetPosition(this);
                Vector offset = mp - m_CurrPos;
                m_CurrPos = mp;
                if (offset.X != 0 && offset.Y != 0)
                {
                    TranslateTransform tt = new TranslateTransform() { X = offset.X, Y = offset.Y };
                    Transform t = this.canvas.RenderTransform;
                    TransformGroup tg = new TransformGroup();
                    tg.Children.Add(t);
                    tg.Children.Add(tt);
                    this.canvas.RenderTransform = tg;
                }

            }
        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScaleTransform st = new ScaleTransform();
            st.CenterX = e.GetPosition(this).X;
            st.CenterY=e.GetPosition(this).Y;
            if (e.Delta>0)
            {
                st.ScaleX = 1.1;
                st.ScaleY = 1.1;
            }
            else
            {
                st.ScaleX = 0.9;
                st.ScaleY = 0.9;
            }
            Transform t = this.canvas.RenderTransform;
            TransformGroup tg = new TransformGroup();
            tg.Children.Add(t);
            tg.Children.Add(st);
            this.canvas.RenderTransform = tg;
            
        }
    }
}
