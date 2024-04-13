using ImageWatch;
using OpenCvSharp;

namespace CameraViewer.UI.MainPage
{
    public class MainPageViewModel
    {

        public ImageWatchAPI MainIamgeView { get; set; }
        public ImageWatchAPI ImageWatchAPI2 { get; set; }
        
        public MainPageViewModel()
        {
            MainIamgeView = new ImageWatchAPI();
            
            MainIamgeView.InitImageView(3780,3780);
            
            Mat Image1 = Cv2.ImRead("D:\\Project\\CameraViewer\\CameraViewer\\TEST.bmp");
           
            MainIamgeView.UpdateUIImage(OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(Image1));
            
        }


    }
}
