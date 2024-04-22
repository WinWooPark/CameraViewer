using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraViewer.Config.RecipeConfig
{
    public class RecipeData
    {
        public RecipeData()
        {
            _resolution = 0.3;
            _threshold = 100;
            _limitShiftX = 3;
            _limitShiftY = 3;
            _limitTheta = 3;
        }

        double _resolution;
        public double Resolution
        {
            get { return _resolution; } 
            set {  _resolution = value; } 
        }

        double _threshold;
        public double Threshold
        { 
            get { return _threshold; } 
            set { _threshold = value; } 
        }

        double _limitShiftX;
        public double LimitShiftX 
        {
            get { return _limitShiftX; }
            set { _limitShiftX = value; }
        }

        double _limitShiftY;
        public double LimitShiftY
        {
            get { return _limitShiftY; }
            set { _limitShiftY = value; }
        }

        double _limitTheta;
        public double LimitTheta
        {
            get { return _limitTheta; }
            set { _limitTheta = value; }
        }
    }
}
