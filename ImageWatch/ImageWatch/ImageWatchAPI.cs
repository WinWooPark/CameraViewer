﻿using ImageWatch.ManagementSystem;
using ImageWatch.ViewModel;
using System.Windows.Media.Imaging;
namespace ImageWatch
{
    public class ImageWatchAPI
    {
        MainSystem _mainSystem;

        public ImageWatchAPI()
        {
            //MainSystem _mainSystem = new MainSystem();
        }

        public void InitImageView(int ImageWidth, int ImageHeight) 
        {
            _mainSystem.ImageWidth = ImageWidth;
            _mainSystem.ImageHeight = ImageHeight;
        }
        
        public void UpdateUIImage(BitmapSource Bitmap) 
        {
            _mainSystem.UpdateImage(Bitmap);
        }
        
        public void AddDrawObjectEllipse(double X, double Y, double Width, double Height, bool Judge)
        {
            _mainSystem.AddDrawObjectEllipse(X, Y, Width, Height, Judge);
        }
        
        public void DrawAllObject()
        {
            _mainSystem.DrawAllObject();
        }

         public void DeleteAllDrawObject()
        {
           _mainSystem.DeleteAllDrawObject();
        }

        public void ImageWatchZoom(int Delta)
        {
            _mainSystem.ImageScaleChange(Delta);
        }

        public void ImageWatchFit()
        {
            _mainSystem.ImageFit();
        }
    }
}
