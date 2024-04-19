using System.Collections.Concurrent;

namespace ImageProcessor
{
    public class ImageProcessor
    {
        public ImageProcessor()
        {

            //Thread 관련 함수
            _threadSync = new AutoResetEvent(false);
            _processorThread = new Thread(Run);
            _isprocessorThreadRun = true;
            _processorThread.Start();
        }

        Thread _processorThread;
        bool _isprocessorThreadRun = false;
        AutoResetEvent _threadSync;

        void Run()
        {
            while (_isprocessorThreadRun) 
            {
                _threadSync.WaitOne();
            }
        }
    }
}
