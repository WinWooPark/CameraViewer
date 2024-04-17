using Basler.Pylon;

namespace BaslerVision
{
    public class BaslerCamera
    {
        Camera? _baslerCamera = null;
        int _exposureTime;
        int _grabTimeOut;

        public BaslerCamera(Action<byte[], int, int> grabCallBack)
        {
            _grabCallBack = grabCallBack;
        }

        Action<byte[], int, int> _grabCallBack;



        public bool CameraOpen(int ExposureTime , int TimeOut) 
        {
            bool bRet = false;
            try
            {
                _baslerCamera = new Camera(CameraSelectionStrategy.FirstFound);

                if (_baslerCamera == null) return bRet;

                //카메라 모드 설정 "소프트웨어 트리거 모드"
                _baslerCamera.CameraOpened += Configuration.SoftwareTrigger;

                //Camera 오픈
                _baslerCamera.Open();
                bRet = _baslerCamera.IsConnected;

                //False 일경우 return;
                if (!bRet) return bRet;

                if (_baslerCamera.CanWaitForFrameTriggerReady)
                {
                    //카메라 노출 시간 세팅
                    _baslerCamera.Parameters[PLCamera.ExposureTime].SetValue(ExposureTime);

                    //Grab 타임 아웃 세팅
                    _grabTimeOut = TimeOut;

                    _baslerCamera.StreamGrabber.ImageGrabbed += OnImageGrabbed;

                    _baslerCamera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
                }
            }
            catch (Exception e)
            {
                bRet = false;
            }

            return bRet;
        }

        public void CloseCamera()
        {
            if (_baslerCamera == null) return;

            if (_baslerCamera.CanWaitForFrameTriggerReady)
                _baslerCamera.StreamGrabber.Stop();

            _baslerCamera.Close();
        }

        public void OnImageGrabbed(Object sender, ImageGrabbedEventArgs e) 
        {
            IGrabResult grabResult = e.GrabResult;
            // Image grabbed successfully?
            if (grabResult.GrabSucceeded)
            {
                int ImageHeight = grabResult.Height;
                int ImageWidth= grabResult.Width;
                PixelType Type = grabResult.PixelTypeValue;

                byte[] buffer = grabResult.PixelData as byte[];

                _grabCallBack(buffer, ImageHeight, ImageWidth);
            }
            else
            {
                Console.WriteLine("Error: {0} {1}", grabResult.ErrorCode, grabResult.ErrorDescription);
            }
        }

        public void ExecuteSoftwareTrigger() 
        {
            if (_baslerCamera == null) return;

            if (_baslerCamera.CanWaitForFrameTriggerReady)
            {
                if (_baslerCamera.WaitForFrameTriggerReady(_grabTimeOut, TimeoutHandling.ThrowException))
                    _baslerCamera.ExecuteSoftwareTrigger();
            }
        }

        public void StopGrab()
        {
            if (_baslerCamera == null) return;

            if (_baslerCamera.CanWaitForFrameTriggerReady)
            {
                _baslerCamera.StreamGrabber.Stop();
            }
        }
    }
}
