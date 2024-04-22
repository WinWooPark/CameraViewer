using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraViewer.Config.SystemConfig
{
    public class HardWareState
    {
        public HardWareState() 
        {
            _isCameraOpen = false;
            _isLightOpen = false;
            _isMotionOpen = false;
        }

        bool _isCameraOpen;
        public bool IsCameraOpen 
        {
            get { return _isCameraOpen; }
            set { _isCameraOpen = value; }
        }

        bool _isLightOpen;
        public bool IsLightOpen
        {
            get { return _isLightOpen; }
            set { _isLightOpen = value; }
        }

        bool _isMotionOpen;
        public bool IsMotionOpen
        {
            get { return _isMotionOpen; }
            set { _isMotionOpen = value; }
        }
    }
}
