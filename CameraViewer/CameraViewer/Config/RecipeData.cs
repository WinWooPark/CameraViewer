using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraViewer.Config
{
    public class RecipeData
    {
        public RecipeData()
        {
            _roiRectPoint = new System.Windows.Point(0, 0);
            RoiRectSize = new System.Windows.Size(0, 0);
        }

        System.Windows.Point _roiRectPoint;
        public System.Windows.Point RoiRectPoint 
        {
            get { return _roiRectPoint; }
            set { _roiRectPoint = value; }
        }

        System.Windows.Size _roiRectSize;
        public System.Windows.Size RoiRectSize
        {
            get { return _roiRectSize; }
            set { _roiRectSize = value; }
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
