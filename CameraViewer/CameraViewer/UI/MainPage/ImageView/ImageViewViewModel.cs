using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using ImageWatch;

namespace CameraViewer.UI.MainPage.ImageView
{
    public class ImageViewViewModel
    {
        private ImageWatchAPI _mainApi;
        


        public ImageViewViewModel()
        {

            
        }

        public void InitMMainViewAPI(object obj)
        {
            _mainApi = new ImageWatchAPI(obj);

            _mainApi.InitImageView(3780, 3780);

            Mat Image = Cv2.ImRead("E:\\5. Project_Test\\3. WPF_ImageViewer\\ImageViewer\\TEST.bmp");

            _mainApi.UpdateUIImage(OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(Image));
        }
    }
}
