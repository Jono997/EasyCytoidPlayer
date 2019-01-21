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
using ATEM;
using System.Diagnostics;

namespace EasyCytoidPlayer
{
    public partial class MainForm : Form
    {
        OptionsForm optionsform;
        string play_directory;
        JSON.Level current_level;

        public MainForm()
        {
            current_level = null;
            play_directory = @"C:\Users\" + Environment.UserName + @"\Appdata\LocalLow\TigerHix\Cytoid\Player";
            optionsform = new OptionsForm();
            InitializeComponent();
            ChartComboBox.Items.Add("");
            ChartComboBox.SelectedIndex = 0;
            UpdateEnable();
        }
        
        private void UpdateEnable()
        {
            bool enabled = optionsform.Cytoid_Player_path != "";
            Chart_folderTextBox.Enabled = Chart_folder_browseButton.Enabled = enabled;
            ChartComboBox.Enabled = enabled ? ChartComboBoxEnabled() : false;
            OpenButton.Enabled = enabled ? OpenButtonEnabled() : false;
        }

        private bool ChartComboBoxEnabled()
        {
            return File.Exists(Chart_folderTextBox.Text + "\\level.json");
        }

        private bool OpenButtonEnabled()
        {
            return (string)ChartComboBox.SelectedItem != "";
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            optionsform.Refresh_UI();
            optionsform.ShowDialog();
            UpdateEnable();
        }

        private void Chart_folder_browseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Chart_folderTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Chart_folderTextBox_TextChanged(object sender, EventArgs e)
        {
            bool enabled = ChartComboBoxEnabled();
            ChartComboBox.Items.Clear();
            ChartComboBox.Enabled = enabled;
            if (enabled)
            {
                current_level = JSON.Level.Load(Chart_folderTextBox.Text + "\\level.json");
                for (int i = 0; i < current_level.charts.Length; i++)
                {
                    string name = current_level.charts[i].name;
                    if (name == "")
                    {
                        name = ("" + current_level.charts[i].type[0]).ToUpper() + current_level.charts[i].type.Substring(1);
                    }
                    ChartComboBox.Items.Add(name);
                }
            }
            else
            {
                ChartComboBox.Items.Add("");
                current_level = null;
            }
            ChartComboBox.SelectedIndex = 0;
        }

        private void ChartComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenButton.Enabled = OpenButtonEnabled();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            #region Copy level to play directory
            if (!Directory.Exists(play_directory))
                Directory.CreateDirectory(play_directory);
            Directory.Delete(play_directory, true);
            ATEMMethods.CopyDirectory(Chart_folderTextBox.Text, play_directory);
            JSON.Level level = current_level.Clone();
            level.charts = new JSON.Chart[] { level.charts[ChartComboBox.SelectedIndex] };
            string music = level.charts[0].music_override.path;
            if (music == "") music = level.music.path;
            if (music.Split('.').Last() == "mp3")
            {
                music = music.Substring(0, music.Length - 3) + "wav";
                level.charts[0].music_override.path = music;
            }
            level.Save(play_directory + "\\level.json");
            #endregion

            #region Launch Cytoid Player
            Process cp_process = new Process();
            cp_process.StartInfo = new ProcessStartInfo(optionsform.Cytoid_Player_path);
            cp_process.Start();
            cp_process.WaitForExit();
            #endregion
        }
    }
}
