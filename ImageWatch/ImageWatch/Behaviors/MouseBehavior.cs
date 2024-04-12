using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;
using System.Windows;
using ImageWatch.ManagementSystem;
using ImageWatch.Define;
using ImageWatch.ViewModel;


namespace ImageWatch.Behaviors
{
    internal class MouseEventBehavior : Behavior<Image>
    {
        System.Windows.Point _startPoint;
        System.Windows.Point _currentPoint;
        bool _isMouseMove;
        MainSystem _mainSystem;
        ImageWatchViewModel _imageWatchViewModel;

        public MouseEventBehavior()
        {
            _isMouseMove = false;
            
        }

        protected override void OnAttached()
        {
            AssociatedObject.MouseWheel += AssociatedObject_MouseWheel;
            AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLButtomDown;
            AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLButtomUp;
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;
        }


        protected override void OnDetaching()
        {
            AssociatedObject.MouseWheel -= AssociatedObject_MouseWheel;
            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLButtomDown;
            AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLButtomUp;
            AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
        }

        private void AssociatedObject_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            _imageWatchViewModel = AssociatedObject.DataContext as ImageWatchViewModel;
            _mainSystem = _imageWatchViewModel.MainSystem;

            _mainSystem.ImageScaleChange(e.Delta);
        }

        private void AssociatedObject_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_isMouseMove == true)
            {
                _currentPoint = e.GetPosition(e.OriginalSource as IInputElement);

                double offsetX = CommonDefine.MouseSensitivity * (_currentPoint.X - _startPoint.X);
                double offsetY = CommonDefine.MouseSensitivity * (_currentPoint.Y - _startPoint.Y);

                _imageWatchViewModel = AssociatedObject.DataContext as ImageWatchViewModel;
                _mainSystem = _imageWatchViewModel.MainSystem;

                _mainSystem.ImageTranslationChange(offsetX, offsetY);

                _startPoint = _currentPoint;
            }
        }

        private void AssociatedObject_MouseLButtomDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(e.OriginalSource as IInputElement);
            _isMouseMove = true;
        }

        private void AssociatedObject_MouseLButtomUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _isMouseMove = false;
        }
    }
}
