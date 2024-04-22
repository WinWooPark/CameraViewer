using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraViewer.Config
{
    public class FileManeger
    {
        public FileManeger() { }

        public bool CheckDirectory(string Path)
        {
            if (File.Exists(Path)) return true;
            else return false;
        }

        public bool CheckFile(string Path)
        {
            if (File.Exists(Path)) return true;
            else return false;
        }

        public virtual void LoadFile() { }

        public virtual void SaveFile() { }
    }
}
