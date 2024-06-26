﻿
namespace CameraViewer.Config.SystemConfig
{
    public class SystemData
    {
        public SystemData()
        {
            _exposureTime = 15000;
            _timeOut = 1000;
        }

        int _exposureTime;
        public int ExposureTime 
        {
            get { return _exposureTime; }
            set { _exposureTime = value; }
        }

        int _timeOut;
        public int TimeOut 
        {
            get { return _timeOut; }
            set { _timeOut = value; }
        }
    }
}
