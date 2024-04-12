using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;
using System.Windows;
using ImageWatch.ManagementSystem;
using ImageWatch.ViewModel;

namespace ImageWatch.Behaviors
{
    internal class ImageSizeBehavior : Behavior<Image>
    {
        MainSystem _mainSystem;
        ImageWatchViewModel _imageWatchViewModel;

        public ImageSizeBehavior()
        {
           
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

            Image image = sender as Image;
            _imageWatchViewModel = image.DataContext as ImageWatchViewModel;
            _mainSystem = _imageWatchViewModel.MainSystem;

            _mainSystem.GetImageControlSize(Width, Height);
        }
    }

    public class CanvasSizeBehavior : Behavior<Canvas>
    {
        MainSystem _mainSystem;
        ImageWatchViewModel _imageWatchViewModel;

        public CanvasSizeBehavior()
        {
           
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

            Canvas canvas = sender as Canvas;
            _imageWatchViewModel = canvas.DataContext as ImageWatchViewModel;
            _mainSystem = _imageWatchViewModel.MainSystem;

            _mainSystem.GetCanvasControlSize(Width, Height);
        }
    }
}
