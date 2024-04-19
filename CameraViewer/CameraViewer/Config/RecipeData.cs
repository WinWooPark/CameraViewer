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
    }
}
