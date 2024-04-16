using Microsoft.Win32;
using OpenCvSharp;
using CameraViewer.Utile.Define;
using System.Windows.Media.Imaging;
using CameraViewer.ManagementSystem;

namespace CameraViewer.ManagementSystem
{
    public class MainSystem : ViewModels
    {
        IntegratedClass _integratedClass;
        
        public MainSystem()
        {
            
        }

        public void InitMainSystem() 
        {
            _integratedClass = IntegratedClass.Instance;
            _integratedClass.MainSystem = this;
        }

        public void MainViewImageFit()
        {
            _integratedClass.ImageWatchAPI.ImageWatchFit();
        }

        public void MainViewImageLoad()
        {

            //시스템 내부에서는 Mat으로 가지고 다니다가 Image를 띄울때만 바꿔서 띄운다.
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Image";
            dlg.Filter = "*.bmp | *.BMP";

            if (dlg.ShowDialog() == true)
            {
                Mat Image = Cv2.ImRead(dlg.FileName);

                if (Image.Empty() == true ||
                    Image.Width != CommonDefine.ImageSizeWidth ||
                    Image.Height != CommonDefine.ImageSizeHeiget)
                    return;

                BitmapSource Bitmap = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(Image);
                _integratedClass.ImageWatchAPI.UpdateUIImage(Bitmap);
            }
        }

        public void MainViewImageSave()
        {


        }

        public void MainViewImageGrab() 
        {
            _integratedClass.ExecuteSoftwareTrigger();
        }

        public void MainViewImageLive()
        {
            _integratedClass.liveMode = true;
            _integratedClass.ExecuteSoftwareTrigger();
        }

        public void MainViewImageStop()
        {
            _integratedClass.liveMode = false;
        }

        public void ProgrameExit()
        {
            if (_integratedClass.liveMode == true) _integratedClass.liveMode = false;

            _integratedClass.ExitIntegratedClass();
        }

    }

   
}
