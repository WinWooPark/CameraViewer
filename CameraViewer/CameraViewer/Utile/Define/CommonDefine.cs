using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraViewer.Utile.Define
{
    public static class CommonDefine
    {
        public const string ConfigFilePath = "C:\\CameraViewer\\Config";

        public const string SystemConfigFilePath = "\\SystemConfig";
        public const string RecipeConfigFilePath = "\\RecipeConfig";

        public const string SystemConfigFileName = "\\SystemFile.cfg";
        public const string RecipeConfigFileName = "\\RecipeFile.cfg";

        public const string MainViewName = "Home";
        public const string SetUpViewName = "SetUp";
        public const string RecipeViewName = "Recipe";

        public const int ImageSizeWidth = 2448;

        public const int ImageSizeHeiget = 2048;

        public enum Views { eMainViews = 0, eRecipeViews = 1, eResipeSubViews = 2, ViewsCount = 3 };
    }

    
}
