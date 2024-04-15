using CameraViewer.Utile.Define;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Windows;


namespace CameraViewer.Config
{
    public class ConfigData
    {
        public ConfigData()
        {
            
        }

        SystemData _systemData;
        public SystemData SystemData 
        {
            get { return _systemData; }
        }
       FileStream _fileStream;

        public void LoadConfigData() 
        {
            CheckConfigDirectory(CommonDefine.ConfigFilePath);

            string Path = string.Format("{0}\\{1}", CommonDefine.ConfigFilePath, CommonDefine.ConfigFileName);
            bool bFileIsExist =  CheckConfigDataFile(Path);

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

        public void SaveConfigData()
        {
            CheckConfigDirectory(CommonDefine.ConfigFilePath);

            string Path = string.Format("{0}//{1}", CommonDefine.ConfigFilePath, CommonDefine.ConfigFileName);
            bool bFileIsExist = CheckConfigDataFile(Path);

            string jsonData = JsonConvert.SerializeObject(_systemData);

            File.WriteAllText(Path, jsonData);

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
