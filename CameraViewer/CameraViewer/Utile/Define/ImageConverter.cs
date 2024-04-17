using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OpenCvSharp;

namespace CameraViewer.Utile.Define
{
    class ImageConverter
    {
        public static Mat ByteArrayToMat(byte[] imageData, int width, int height, int channels) 
        {
            Mat mat = new Mat(height, width, MatType.CV_8UC(channels));

            // 이미지 데이터를 Mat 객체로 복사
            Marshal.Copy(imageData, 0, mat.Data, imageData.Length);

            return mat;
        }

        public static BitmapSource MatToBitmap(Mat Image)
        {
            BitmapSource Bitmap = OpenCvSharp.WpfExtensions.BitmapSourceConverter.ToBitmapSource(Image);

            return Bitmap;
        }

        public static BitmapSource ByteArrayToBitmapSource(byte[] imageData, int width, int height, int channels)
        {
            // 이미지의 픽셀 형식을 RGB 또는 BGR로 결정
            PixelFormat pixelFormat = channels == 3 ? PixelFormats.Bgr24 : PixelFormats.Gray8;

            // 이미지의 스트라이드 계산
            int stride = width * (pixelFormat.BitsPerPixel / 8);

            // BitmapSource 생성
            BitmapSource bitmapSource = BitmapSource.Create(width, height, 96, 96, pixelFormat, null, imageData, stride);

            return bitmapSource;
        }

    }
}
