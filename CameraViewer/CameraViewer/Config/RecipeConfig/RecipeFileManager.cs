using CameraViewer.Config.SystemConfig;
using CameraViewer.Utile.Define;
using Newtonsoft.Json;

using System.IO;


namespace CameraViewer.Config.RecipeConfig
{
    public class RecipeFileManager : FileManeger
    {
        RecipeData _recipeData;
        public RecipeData RecipeData { get { return _recipeData; } }

        public override void LoadFile()
        {
            bool flag = false;
            string DirectoryPath = string.Format("{0}\\{1}", CommonDefine.ConfigFilePath, CommonDefine.SystemConfigFilePath);

            flag = CheckDirectory(DirectoryPath);
            if (!flag) Directory.CreateDirectory(DirectoryPath);

            string FilePath = string.Format("{0}\\{1}", DirectoryPath, CommonDefine.SystemConfigFileName);
            flag = CheckFile(FilePath);

            if (!flag)
            {
                _recipeData = new RecipeData();
                return;
            }

            string jsonData = File.ReadAllText(FilePath);

            _recipeData = JsonConvert.DeserializeObject<RecipeData>(jsonData);

            return;
        }

        public override void SaveFile()
        {
            bool flag = false;
            string DirectoryPath = string.Format("{ 0}\\{1}", CommonDefine.ConfigFilePath, CommonDefine.SystemConfigFilePath);

            flag = CheckDirectory(DirectoryPath);
            if (!flag) Directory.CreateDirectory(DirectoryPath);

            string FilePath = string.Format("{0}\\{1}", DirectoryPath, CommonDefine.SystemConfigFileName);
            CheckFile(FilePath);

            string jsonData = JsonConvert.SerializeObject(RecipeData);

            File.WriteAllText(FilePath, jsonData);

            return;
        }
    }
}
