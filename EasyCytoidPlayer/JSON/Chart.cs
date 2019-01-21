using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCytoidPlayer.JSON
{
    public class Chart : File
    {
        public string type;
        public string name;
        public int difficulty;
        public File storyboard;
        public File music_override;

        public Chart()
        {
            type = name = "";
            difficulty = 1;
            storyboard = new File();
            storyboard.path = "storyboard.json";
            music_override = new File();
        }
    }
}
