using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using OpenCvSharp;

namespace ImageProcessor
{
    public class ImageProcessor
    {
        public enum ImageBuffer { MainImage = 0 , BilateralImage, ThresholdImage,BufferCount }

        public ImageProcessor(int Width, int Height, int channels, Action CallBack)
        {
            CreateBuffers(Width, Height, channels);

            _InspDoneEvent += CallBack;

            //Thread 관련 함수
            _threadSync = new AutoResetEvent(false);
            _threadDispose = new AutoResetEvent(false);
            _processorThread = new Thread(Run);
            _isprocessorThreadRun = true;
            _processorThread.Start();

        }

        Thread _processorThread;
        bool _isprocessorThreadRun = false;
        AutoResetEvent _threadSync;
        AutoResetEvent _threadDispose;

        ConcurrentQueue<Mat> _bufferQueue;
        Mat[] _buffers;
        event Action _InspDoneEvent;

        public void SetImageBuffer(byte[] buffer, int Width, int Height, int channels) 
        {
            Mat mat = new Mat(Height, Width, MatType.CV_8UC(channels));

            Marshal.Copy(buffer, 0, mat.Data, buffer.Length);

            _bufferQueue.Enqueue(mat);

            _threadSync.Set();
        }

        void CreateBuffers(int Width, int Height, int channels) 
        {
            _buffers = new Mat[(int)ImageBuffer.BufferCount];

            for(int i = 0; i < (int)ImageBuffer.BufferCount; ++i)
                _buffers[i] = new Mat(Height, Width, MatType.CV_8UC(channels));
        }

        void DeleteBuffers() 
        {
            for (int i = 0; i < (int)ImageBuffer.BufferCount; ++i) 
            {
                if(_buffers[i] != null && _buffers[i].Empty() == true)
                    _buffers[i].Dispose();
            }
        }

        public void DisposeImageProcessor() 
        {
            //Thread 종료
            _isprocessorThreadRun = false;
            _bufferQueue.Clear();
            bool flag = _threadDispose.WaitOne(1000);

            if (!flag) _processorThread.Abort();

            //사용된 버퍼 종료
            DeleteBuffers();

            return;
        }

        void Run()
        {
            Mat Image = null;
            
            while (_isprocessorThreadRun) 
            {
                _threadSync.WaitOne();

                if(_bufferQueue.IsEmpty) continue;

                _bufferQueue.TryDequeue(out Image);

                if (Image == null ||Image.Empty() ) continue;

                ProecssAlign(Image);

                _InspDoneEvent?.Invoke();
            }

            _threadDispose.Set();
            return;
        }

        void ProecssAlign(Mat Image) 
        {
            Cv2.BilateralFilter(Image, _buffers[(int)ImageBuffer.BilateralImage], 5, 250, 10);

            Cv2.Threshold(_buffers[(int)ImageBuffer.BilateralImage], _buffers[(int)ImageBuffer.ThresholdImage], 10, 255, ThresholdTypes.Binary);

            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchyIndex;

            //Blob의 외곽선 추출
            Cv2.FindContours(_buffers[(int)ImageBuffer.ThresholdImage], out contours, out hierarchyIndex, RetrievalModes.External, ContourApproximationModes.ApproxNone);
        }
    }
}
