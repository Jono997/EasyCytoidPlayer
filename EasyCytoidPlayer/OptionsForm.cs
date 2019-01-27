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
        int CurrentSettingFileVersion = 2;
        public string Cytoid_Player_path;
        public string C2_Player_path;
        public bool Use_C2_Player;
        public enum SettingLine
        {
            setting_file_version = 0,
            cytoid_player_path = 1,
            c2_player_path = 2,
            use_c2_player = 3
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
            C2_Player_path = "";
            Use_C2_Player = false;
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
                        case SettingLine.c2_player_path:
                            C2_Player_path = settings[i];
                            break;
                        case SettingLine.use_c2_player:
                            Use_C2_Player = settings[i] == "1";
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
            if (old_settings[0] == "1")
            {
                return new string[] { "2", old_settings[1], "", "0" };
            }
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
                    case SettingLine.c2_player_path:
                        settings[i] = C2_Player_path;
                        break;
                    case SettingLine.use_c2_player:
                        settings[i] = Use_C2_Player ? "1" : "0";
                        break;
                }
            }
            File.WriteAllLines(setting_file_path, settings, Encoding.UTF8);
        }
        #endregion

        public void Refresh_UI()
        {
            Cytoid_PlayerTextBox.Text = Cytoid_Player_path;
            C2_PlayerTextBox.Text = C2_Player_path;
            Cytoid_PlayerRadioButton.Checked = !Use_C2_Player;
            C2_PlayerRadioButton.Checked = Use_C2_Player;
        }

        private void Cytoid_Player_browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Cytoid_PlayerTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void C2_PlayerButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                C2_PlayerTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Cytoid_Player_path = Cytoid_PlayerTextBox.Text;
            C2_Player_path = C2_PlayerTextBox.Text;
            Use_C2_Player = C2_PlayerRadioButton.Checked;

            Save_Settings();
            Close();
        }
    }
}
