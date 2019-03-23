using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EasyCytoidPlayer.JSON
{
    public class C2Level
    {
        public string Name;
        public string ThemeColor;
        public string DiffName;
        public int DiffNumber;
        public string DiffTextColor;
        public string DiffBackColor;
        public string Iconpath;
        public string Musicpath;
        public string Backgroundpath;
        public string Chartpath;
        public bool useOldFormat;

        public C2Level()
        {
            Name = "I";
            ThemeColor = "#64CFFFFF";
            DiffName = "MXM";
            DiffNumber = 20;
            DiffTextColor = "#FFFFFFFF";
            DiffBackColor = "#00000000";
            Iconpath = "Icon.png";
            Musicpath = "Music.wav";
            Backgroundpath = "bg_gamever.png";
            Chartpath = "output.cyt";
            useOldFormat = false;
        }

        public void Save(string path)
        {
            System.IO.File.WriteAllText(path, new JavaScriptSerializer().Serialize(this), Encoding.UTF8);
        }

        public static C2Level Load(string path)
        {
            return (C2Level)new JavaScriptSerializer().Deserialize(System.IO.File.ReadAllText(path, Encoding.UTF8), typeof(C2Level));
        }
    }
}
