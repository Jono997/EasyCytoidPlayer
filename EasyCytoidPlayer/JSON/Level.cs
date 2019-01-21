using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using ATEM;

namespace EasyCytoidPlayer.JSON
{
    public class Level
    {
        public int version;
        public int schema_version;

        public string id;

        public string title;
        public string title_localised;

        public string artist;
        public string artist_localised;
        public string artist_source;

        public string illustrator;
        public string illustrator_source;

        public string charter;

        public File music;
        public File music_preview;
        public File background;
        public Chart[] charts;

        public Level()
        {
            version = 1;
            schema_version = 2;
            id = title = title_localised = artist = artist_localised = artist_source = illustrator = illustrator_source = charter = "";
            music = music_preview = background = new File();
            charts = new Chart[] { };
        }

        private string GetJSONRepresentation()
        {
            // Get basic JSON representation
            string json_output = new JavaScriptSerializer().Serialize(this);

            // Remove redundant information
            json_output = json_output.Replace("\"storyboard\":{\"path\":\"storyboard.json\"}", "").Replace(",,", ",")
                                     .Replace("\"music_override\":{\"path\":\"\"}", "").Replace(",,", ",")
                                     .Replace(",}", "}");

            // Split data into lines
            json_output = json_output.Replace("{", "{\n")
                                     .Replace(",", ",\n")
                                     .Replace("}", "\n}")
                                     .Replace(":", ": ")
                                     .Replace("[", "[\n")
                                     .Replace("]", "\n]");

            // Indent lines
            int indentation = 0;
            string[] json_split = json_output.Split('\n');
            for (int i = 0; i < json_split.Length; i++)
            {
                if (json_split[i].Contains('}') || json_split[i].Contains(']')) indentation--;
                for (int i2 = 0; i2 < indentation; i2++)
                {
                    json_split[i] = "  " + json_split[i];
                }
                if (json_split[i].Contains('{') || json_split[i].Contains('[')) indentation++;
            }

            return json_split.Stitch('\n');
        }

        public void Save(string path)
        {
            System.IO.File.WriteAllLines(path, GetJSONRepresentation().Split('\n'), Encoding.UTF8);
        }

        private static Level CreateFromJSON(string json)
        {
            return (Level)new JavaScriptSerializer().Deserialize(json, typeof(Level));
        }

        public static Level Load(string path)
        {
            return CreateFromJSON(System.IO.File.ReadAllText(path, Encoding.UTF8));
        }

        public Level Clone()
        {
            return CreateFromJSON(GetJSONRepresentation());
        }
    }
}
