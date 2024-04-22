using Microsoft.Win32;
using OpenCvSharp;
using CameraViewer.Utile.Define;
using System.Windows.Media.Imaging;
using CameraViewer.ManagementSystem;
using System.Windows.Media;
using System.Windows;
using System.Net;
using CameraViewer.Config;

namespace CameraViewer.ManagementSystem
{
    public class MainSystem : ViewModels
    {
        IntegratedClass _integratedClass;
        Mat Image;
        Mat SubImage;

        public MainSystem()
        {
            
        }

        public void InitMainSystem() 
        {
            _integratedClass = IntegratedClass.Instance;
            _integratedClass.MainSystem = this;
        }

        public void ViewerFit(CommonDefine.Views views) 
        {
            int Index = 0;
            switch (views) 
            {
                case CommonDefine.Views.eMainViews:
                    Index = (int)CommonDefine.Views.eMainViews;
                    break;

                case CommonDefine.Views.eRecipeViews:
                    Index = (int)CommonDefine.Views.eRecipeViews;
                    break;

                case CommonDefine.Views.eResipeSubViews:
                    Index = (int)CommonDefine.Views.eResipeSubViews;
                    break;
            }
            _integratedClass.ImageWatch[Index].ImageWatchFit();
        }

        public void ViewerImageLoad(CommonDefine.Views views)
        {

            //시스템 내부에서는 Mat으로 가지고 다니다가 Image를 띄울때만 바꿔서 띄운다.
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Image";
            dlg.Filter = "*.bmp | *.BMP";

            if (dlg.ShowDialog() == true)
            {
                /*Mat */Image = Cv2.ImRead(dlg.FileName);

                if (Image.Empty() == true ||
                    Image.Width != CommonDefine.ImageSizeWidth ||
                    Image.Height != CommonDefine.ImageSizeHeiget) 
                {
                    MessageBox.Show("Image size is different");
                    return;
                }
                    
                int Index = 0;

                switch (views)
                {
                    case CommonDefine.Views.eMainViews:
                        Index = (int)CommonDefine.Views.eMainViews;
                        break;

                    case CommonDefine.Views.eRecipeViews:
                        Index = (int)CommonDefine.Views.eRecipeViews;
                        break;

                    case CommonDefine.Views.eResipeSubViews:
                        Index = (int)CommonDefine.Views.eResipeSubViews;
                        break;
                }

                BitmapSource Bitmap = ImageConverter.MatToBitmap(Image);
                _integratedClass.ImageWatch[Index].UpdateUIImage(Bitmap);
            }
        }

        public void ViewerImageSave(CommonDefine.Views views)
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

            _integratedClass.CloseIntegratedClass();
        }

        public void RightMouseButtomClickEvent(System.Windows.Point startPoint, System.Windows.Point EndPoint)
        {
            _integratedClass.ImageWatch[(int)CommonDefine.Views.eRecipeViews].DeleteAllDrawObject();

            double Width = Math.Abs(EndPoint.X - startPoint.X);
            double Height = Math.Abs(EndPoint.Y - startPoint.Y);

            _integratedClass.ImageWatch[(int)CommonDefine.Views.eRecipeViews].AddDrawObjectRect(startPoint.X, startPoint.Y, Width, Height, Colors.AliceBlue);
            _integratedClass.ImageWatch[(int)CommonDefine.Views.eRecipeViews].DrawAllObject();

            _integratedClass.RecipeData.RoiRectPoint = startPoint;
            _integratedClass.RecipeData.RoiRectSize = new System.Windows.Size(Width, Height);

            //_integratedClass.ImageWatch[(int)CommonDefine.Views.eMainViews].DeleteAllDrawObject();

            //double Width = Math.Abs(EndPoint.X - startPoint.X);
            //double Height = Math.Abs(EndPoint.Y - startPoint.Y);

            //_integratedClass.ImageWatch[(int)CommonDefine.Views.eMainViews].AddDrawObjectRect(startPoint.X, startPoint.Y, Width, Height, Colors.AliceBlue);
            //_integratedClass.ImageWatch[(int)CommonDefine.Views.eMainViews].DrawAllObject();

            //_integratedClass.RecipeData.RoiRectPoint = startPoint;
            //_integratedClass.RecipeData.RoiRectSize = new System.Windows.Size(Width, Height);
        }

        public void ShowSubImage() 
        {

            OpenCvSharp.Point topLeft = new OpenCvSharp.Point(_integratedClass.RecipeData.RoiRectPoint.X, _integratedClass.RecipeData.RoiRectPoint.Y); // 좌상단 좌표
            OpenCvSharp.Size bottomRight = new OpenCvSharp.Size(_integratedClass.RecipeData.RoiRectSize.Width, _integratedClass.RecipeData.RoiRectSize.Height); // 우하단 좌표

            Mat SubImage = Image.SubMat(new OpenCvSharp.Rect(topLeft, bottomRight));

            BitmapSource Bitmap = ImageConverter.MatToBitmap(SubImage);
            _integratedClass.ImageWatch[(int)CommonDefine.Views.eResipeSubViews].UpdateUIImage(Bitmap);
        }
    }
}
