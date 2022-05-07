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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Loding.xaml 的交互逻辑
    /// </summary>
    public partial class Loding : UserControl
    {
        public Loding()
        {
            InitializeComponent();

            sign.BorderBrush = Brushes.Transparent;
        }
        EventArgs Events = null;
        private void UserControl_Initialized(object sender, EventArgs e)
        {
            Events = e;
            for (double i = 0; i < 2.4; i += 0.3)
            {
                rstq.Enqueue(new RotateTransform());
                tsq.Enqueue(TimeSpan.FromSeconds(i + 1));
            }
            sta();


        }
        DoubleAnimation myDoubleAnimation = new DoubleAnimation();

        Queue<RotateTransform> rstq = new Queue<RotateTransform>();
        RotateTransform rst;
        TimeSpan ts;
        Queue<TimeSpan> tsq = new Queue<TimeSpan>();



        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {



        }
        public void sta()
        {
            for (int i = 1; i < 9; i++)
            {
                ts = tsq.Dequeue();
                rst = rstq.Dequeue();


                grids.Children[i].RenderTransform = rst;
                myDoubleAnimation.From = 1.00;
                myDoubleAnimation.To = 360.00;
                myDoubleAnimation.Duration = new Duration(ts);
                rst.BeginAnimation(RotateTransform.AngleProperty, myDoubleAnimation);


                rstq.Enqueue(rst);
                tsq.Enqueue(ts);


            }
            RotateTransform rtf = new RotateTransform();
            DoubleAnimation myDoubleAnimation2 = new DoubleAnimation();

            l9.RenderTransform = rtf;
            myDoubleAnimation2.From = 1.00;
            myDoubleAnimation2.To = 360.00;
            myDoubleAnimation2.Duration = new Duration(TimeSpan.FromSeconds(3.5));
            myDoubleAnimation2.Completed += MyDoubleAnimation_Completed;
            rtf.BeginAnimation(RotateTransform.AngleProperty, myDoubleAnimation2);
        }
        private void MyDoubleAnimation_Completed1(object sender, EventArgs e)
        {

        }

        private void MyDoubleAnimation_Completed(object sender, EventArgs e)
        {
            sta();
            

        }
    }
}
