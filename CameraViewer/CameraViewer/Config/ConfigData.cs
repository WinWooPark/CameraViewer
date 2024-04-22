using CameraViewer.Utile.Define;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;


namespace CameraViewer.Config
{
    public class ConfigData
    {
        public ConfigData() { }

        SystemData _systemData;
        public SystemData SystemData { get { return _systemData; }}

        public void LoadConfigData() 
        {
            string DirectoryPath = string.Format("{ 0}\\{1}", CommonDefine.ConfigFilePath, CommonDefine.SystemConfigFilePath);
            CheckConfigDirectory(DirectoryPath);

            LoadConfigFile(DirectoryPath);

            LoadRecipeFile(DirectoryPath);

            return;
        }

        void CheckConfigDirectory(string Path) 
        {
            if (Directory.Exists(Path)) return;

            Directory.CreateDirectory(Path);
        }

        bool CheckConfigDataFile(string Path) 
        {
            if (File.Exists(Path)) return true;
            else return false;
        }

        void LoadConfigFile(string DirectoryPath) 
        {
            string Path = string.Format("{0}\\{1}", DirectoryPath, CommonDefine.SystemConfigFileName);
            bool bFileIsExist = CheckConfigDataFile(Path);

            if (bFileIsExist == true)
            {
                string jsonData = File.ReadAllText(Path);

                _systemData = JsonConvert.DeserializeObject<SystemData>(jsonData);
            }
            else
            {
                _systemData = new SystemData();
            }
        }

        void LoadRecipeFile(string DirectoryPath)
        {
            string Path = string.Format("{0}\\{1}", DirectoryPath, CommonDefine.RecipeConfigFileName);
            bool bFileIsExist = CheckConfigDataFile(Path);

            if (bFileIsExist == true)
            {
                string jsonData = File.ReadAllText(Path);

                _systemData = JsonConvert.DeserializeObject<SystemData>(jsonData);
            }
            else
            {
                _systemData = new SystemData();
            }
        }

        void SaveConfigFile(string DirectoryPath)
        {
            string Path = string.Format("{0}//{1}", DirectoryPath, CommonDefine.SystemConfigFileName);
            bool bFileIsExist = CheckConfigDataFile(Path);

            string jsonData = JsonConvert.SerializeObject(_systemData);

            File.WriteAllText(Path, jsonData);
        }

        void SaveRecipeFile(string DirectoryPath)
        {
            string Path = string.Format("{0}//{1}", DirectoryPath, CommonDefine.RecipeConfigFileName);
            bool bFileIsExist = CheckConfigDataFile(Path);

            string jsonData = JsonConvert.SerializeObject(_systemData);

            File.WriteAllText(Path, jsonData);

         
        }

        public void SaveConfigData()
        {
            string DirectoryPath = string.Format("{ 0}\\{1}", CommonDefine.ConfigFilePath, CommonDefine.SystemConfigFilePath);
            CheckConfigDirectory(DirectoryPath);

            SaveConfigFile(DirectoryPath);

            SaveRecipeFile(DirectoryPath);

            MessageBox.Show("Save Success");
        }

        public void ApplyConfigData()
        {
            SaveConfigData();
            LoadConfigData();
            MessageBox.Show("Apply Success");
        }
    }
}
