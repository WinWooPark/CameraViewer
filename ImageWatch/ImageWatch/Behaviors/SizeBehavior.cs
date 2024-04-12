using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;
using System.Windows;
using ImageWatch.ManagementSystem;
using ImageWatch.ViewModel;

namespace ImageWatch.Behaviors
{
    public class ImageSizeBehavior : Behavior<Image>
    {
        public static readonly DependencyProperty CanvasWidthProperty = DependencyProperty.Register("ImageWidth", typeof(double), typeof(CanvasSizeBehavior), new PropertyMetadata(0.0));

        public static readonly DependencyProperty CanvasHeightProperty = DependencyProperty.Register("ImageHeight", typeof(double), typeof(CanvasSizeBehavior), new PropertyMetadata(0.0));

        public double ImageWidth
        {
            get { return (double)GetValue(CanvasWidthProperty); }
            set { SetValue(CanvasWidthProperty, value); }
        }

        public double ImageHeight
        {
            get { return (double)GetValue(CanvasHeightProperty); }
            set { SetValue(CanvasHeightProperty, value); }
        }
        protected override void OnAttached()
        {
            AssociatedObject.SizeChanged += OnSizeChanged;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.SizeChanged -= OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            double Width = AssociatedObject.ActualWidth;
            double Height = AssociatedObject.ActualHeight;

            ImageWidth = AssociatedObject.ActualWidth;
            ImageHeight = AssociatedObject.ActualHeight;
        }
    }

    public class CanvasSizeBehavior : Behavior<Canvas>
    {
        public static readonly DependencyProperty CanvasWidthProperty = DependencyProperty.Register("CanvasWidth", typeof(double), typeof(CanvasSizeBehavior), new PropertyMetadata(0.0));

        public static readonly DependencyProperty CanvasHeightProperty = DependencyProperty.Register("CanvasHeight", typeof(double), typeof(CanvasSizeBehavior), new PropertyMetadata(0.0));

        public double CanvasWidth
        {
            get { return (double)GetValue(CanvasWidthProperty); }
            set { SetValue(CanvasWidthProperty, value); }
        }

        public double CanvasHeight
        {
            get { return (double)GetValue(CanvasHeightProperty); }
            set { SetValue(CanvasHeightProperty, value); }
        }

        protected override void OnAttached()
        {
            AssociatedObject.SizeChanged += OnSizeChanged;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.SizeChanged -= OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            double Width = AssociatedObject.ActualWidth;
            double Height = AssociatedObject.ActualHeight;

            CanvasWidth = Width;
            CanvasHeight = Height;
        }
    }
}
