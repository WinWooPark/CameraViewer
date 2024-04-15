using System.Windows.Controls;
using ImageWatch;

namespace CameraViewer.UI.MainPage.ImageView
{
    /// <summary>
    /// ImageView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ImageView : UserControl
    {
        ImageViewViewModel _imageViewViewModel;

        public ImageView()
        {
            _imageViewViewModel = new ImageViewViewModel(App.MainSystem);
            InitializeComponent();
            DataContext = _imageViewViewModel;
         
        }
    }
}
