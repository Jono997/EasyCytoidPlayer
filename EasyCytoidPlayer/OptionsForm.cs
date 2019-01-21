using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EasyCytoidPlayer
{
    public partial class OptionsForm : Form
    {
        #region Options file
        int CurrentSettingFileVersion = 1;
        public string Cytoid_Player_path;
        public enum SettingLine
        {
            setting_file_version = 0,
            cytoid_player_path = 1
        }
        #endregion

        string setting_file_path;

        public OptionsForm()
        {
            string exepath = Environment.GetCommandLineArgs()[0];
            setting_file_path = exepath.Substring(0, exepath.Length - exepath.Split('\\').Last().Length) + "settings.txt";
            Load_Settings();
            InitializeComponent();
        }

        #region Settings loading/saving functions
        private void Initialise_Settings()
        {
            Cytoid_Player_path = "";
        }

        private void Load_Settings()
        {
            if (File.Exists(setting_file_path))
            {
                string[] settings = File.ReadAllLines(setting_file_path, Encoding.UTF8);
                if (settings[0] != CurrentSettingFileVersion.ToString())
                {
                    settings = Convert_Settings(settings);
                }
                for (int i = 1; i < settings.Length; i++)
                {
                    switch ((SettingLine)i)
                    {
                        case SettingLine.cytoid_player_path:
                            Cytoid_Player_path = settings[i];
                            break;
                    }
                }
            }
            else
            {
                Initialise_Settings();
            }
        }

        private string[] Convert_Settings(string[] old_settings)
        {
            return old_settings;
        }

        private void Save_Settings()
        {
            int length = Enum.GetNames(typeof(SettingLine)).Length;
            string[] settings = new string[length];
            for (int i = 0; i < length; i++)
            {
                switch ((SettingLine)i)
                {
                    case SettingLine.setting_file_version:
                        settings[i] = CurrentSettingFileVersion.ToString();
                        break;
                    case SettingLine.cytoid_player_path:
                        settings[i] = Cytoid_Player_path;
                        break;
                }
            }
            File.WriteAllLines(setting_file_path, settings, Encoding.UTF8);
        }
        #endregion

        public void Refresh_UI()
        {
            Cytoid_PlayerTextBox.Text = Cytoid_Player_path;
        }

        private void Cytoid_Player_browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Cytoid_PlayerTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Cytoid_Player_path = Cytoid_PlayerTextBox.Text;

            Save_Settings();
            Close();
        }
    }
}
