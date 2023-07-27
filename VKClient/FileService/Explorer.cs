using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKClient.VKClasses
{
    public static class Explorer
    {
        public static string SaveDialog()
        {
            SaveFileDialog SF = new SaveFileDialog();
            SF.DefaultExt = "xml";
            SF.Filter = "XML Files (*.xml)|*.xml";
            SF.FileName = DateTime.Now.ToString("yyyy-MM-dd") + ".xml";
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            SF.InitialDirectory = Path.GetDirectoryName(location);

            if (SF.ShowDialog() == DialogResult.Cancel)
            {
                return null;
            }
            return SF.FileName;
        }
        public static string[] OpenDialog(bool multiSelect)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Multiselect = multiSelect;
            OPF.Filter = "Файлы xml|*.xml";
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            OPF.InitialDirectory = Path.GetDirectoryName(location);
            
            if (OPF.ShowDialog() == DialogResult.Cancel)
            {
                return null;
            }
            return OPF.FileNames;
        }
        public static string OpenDialog()
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы xml|*.xml";
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            OPF.InitialDirectory = Path.GetDirectoryName(location);

            if (OPF.ShowDialog() == DialogResult.Cancel)
            {
                return null;
            }
            return OPF.FileName;
        }
    }
}
