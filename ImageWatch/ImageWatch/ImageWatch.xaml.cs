using ImageWatch.ManagementSystem;
using ImageWatch.ViewModel;
using System.Windows.Controls;

namespace ImageWatch
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ImageWatch : UserControl
    {
        ImageWatchViewModel _imageWatchViewModel;
        MainSystem _mainSystem;

        public ImageWatch()
        {
            _mainSystem = new MainSystem();
            _imageWatchViewModel = new ImageWatchViewModel(_mainSystem);

            InitializeComponent();
            DataContext = _imageWatchViewModel;
        }
    }

}
