using ImageWatch;
using OpenCvSharp;

namespace CameraViewer.UI.MainPage
{
    public class MainPageViewModel
    {

        public ImageWatchAPI ImageWatchAPI1 { get; set; }
        public ImageWatchAPI ImageWatchAPI2 { get; set; }
        
        public MainPageViewModel()
        {
            ImageWatchAPI1 = new ImageWatchAPI();
            ImageWatchAPI2 = new ImageWatchAPI();

            ImageWatchAPI1.InitImageView(3780,3780);
            ImageWatchAPI2.InitImageView(3780, 3780);

            Mat Image1 = Cv2.ImRead("E:\\5. Project_Test\\3. WPF_ImageViewer\\ImageViewer\\TEST.bmp");
            Mat Image2 = Cv2.ImRead("E:\\5. Project_Test\\3. WPF_ImageViewer\\ImageViewer\\TEST.bmp");

            ImageWatchAPI1.UpdateUIImage(OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(Image1));
            ImageWatchAPI2.UpdateUIImage(OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(Image2));
        }


    }
}
