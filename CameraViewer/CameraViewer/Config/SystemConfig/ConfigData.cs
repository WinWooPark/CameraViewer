using CameraViewer.Utile.Define;
using Newtonsoft.Json;
using System.IO;
using System.Windows;


namespace CameraViewer.Config.SystemConfig
{
    public class ConfigFileManager : FileManeger
    {
        public ConfigFileManager() { }

        SystemData _systemData;
        public SystemData SystemData { get { return _systemData;}}

        public override void LoadFile()
        {
            bool flag = false;
            string DirectoryPath = string.Format("{0}\\{1}", CommonDefine.ConfigFilePath, CommonDefine.SystemConfigFilePath);
            
            flag = CheckDirectory(DirectoryPath);
            if(!flag) Directory.CreateDirectory(DirectoryPath);

            string FilePath = string.Format("{0}\\{1}", DirectoryPath, CommonDefine.SystemConfigFileName);
            flag = CheckFile(FilePath);

            if (!flag)
            {
                _systemData = new SystemData();
                return;                
            }

            string jsonData = File.ReadAllText(FilePath);

            _systemData = JsonConvert.DeserializeObject<SystemData>(jsonData);

            return;
        }

        public override void SaveFile() 
        {
            bool flag = false;
            string DirectoryPath = string.Format("{ 0}\\{1}", CommonDefine.ConfigFilePath, CommonDefine.SystemConfigFilePath);

            flag = CheckDirectory(DirectoryPath);
            if (!flag) Directory.CreateDirectory(DirectoryPath);

            string FilePath = string.Format("{0}\\{1}", DirectoryPath, CommonDefine.SystemConfigFileName);
            flag = CheckFile(FilePath);

            string jsonData = JsonConvert.SerializeObject(_systemData);

            File.WriteAllText(FilePath, jsonData);

            return;
        }

        public void ApplyConfigData()
        {
            SaveFile();
            LoadFile();

            MessageBox.Show("Apply Success");
        }
    }
}
