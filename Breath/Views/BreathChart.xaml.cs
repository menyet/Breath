using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Graphics.Canvas.UI.Xaml;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Breath.Views
{
    public sealed partial class BreathChart : UserControl
    {
        public BreathChart()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof (double), typeof (BreathChart), new PropertyMetadata(default(double)));

        public double Value
        {
            get { return (double) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty Duration1Property = DependencyProperty.Register(
            "Duration1", typeof (double), typeof (BreathChart), new PropertyMetadata(default(double), DurationChanged));

        public double Duration1
        {
            get { return (double) GetValue(Duration1Property); }
            set { SetValue(Duration1Property, value); }
        }

        public static readonly DependencyProperty Duration2Property = DependencyProperty.Register(
            "Duration2", typeof (double), typeof (BreathChart), new PropertyMetadata(default(double), DurationChanged));

        private static void DurationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as BreathChart;

            c.DurationChanged();
        }

        private void DurationChanged()
        {
            CanvasControl.Invalidate();
        }

        public double Duration2
        {
            get { return (double) GetValue(Duration2Property); }
            set { SetValue(Duration2Property, value); }
        }

        public static readonly DependencyProperty Duration3Property = DependencyProperty.Register(
            "Duration3", typeof (double), typeof (BreathChart), new PropertyMetadata(default(double), DurationChanged));

        public double Duration3
        {
            get { return (double) GetValue(Duration3Property); }
            set { SetValue(Duration3Property, value); }
        }

        private void CanvasControl_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            var width = (float)sender.ActualWidth;
            var height = (float)sender.ActualHeight;
           

            var ratio = width/ (Duration1 + Duration2 + Duration3);

            var x1 = (float)(Duration1*ratio);
            var x2 = (float)((Duration1 + Duration2)*ratio);

            args.DrawingSession.DrawLine(0, height, x1, height - 50, Colors.White, 2);
            args.DrawingSession.DrawLine(x1, height - 50, x2, height - 50, Colors.White, 2);
            args.DrawingSession.DrawLine(x2, height - 50, width, height, Colors.White, 2);

            args.DrawingSession.DrawEllipse(155, 115, 80, 30, Colors.Black, 3);
            args.DrawingSession.DrawText(
                string.Format("Hello, world! 1: {0} 2: {1} 3: {2}", Duration1, Duration2, Duration3), 100, 100,
                Colors.Yellow);
        }
    }
}
