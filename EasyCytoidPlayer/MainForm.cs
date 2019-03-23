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
            UpdateUI();
        }
        
        private void UpdateUI()
        {
            #region Update enable
            bool enabled = optionsform.Use_C2_Player ? optionsform.C2_Player_path != "" : optionsform.Cytoid_Player_path != "";
            Chart_folderTextBox.Enabled = Chart_folder_browseButton.Enabled = enabled;
            ChartComboBox.Enabled = enabled ? ChartComboBoxEnabled() : false;
            OpenButton.Enabled = enabled ? OpenButtonEnabled() : false;
            #endregion

            OpenButton.Text = "Open in " + (optionsform.Use_C2_Player ? "Cytus 2" : "Cytoid") + " Player";
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
            UpdateUI();
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

        private string GetChartAudio(JSON.Level level, int chart)
        {
            string music = level.charts[chart].music_override.path;
            if (music == "") music = level.music.path;
            if (music.Split('.').Last() == "mp3")
            {
                return music.Substring(0, music.Length - 3) + "wav";
            }
            return music;
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (optionsform.Use_C2_Player)
            {
                #region Cytus 2
                #region Get directory
                string[] c2_directory_split = optionsform.C2_Player_path.Split('\\');
                string c2_directory = c2_directory_split.SubArray(0, c2_directory_split.Length - 1).Stitch('\\');
                #endregion

                #region Create new settings.txt
                string backup_settings_txt = File.ReadAllText(c2_directory + "\\Settings.txt", Encoding.UTF8);
                JSON.C2Level level = JSON.C2Level.Load(c2_directory + "\\Settings.txt");
                level.Name = current_level.title;
                level.DiffName = (string)ChartComboBox.SelectedItem;
                level.DiffNumber = current_level.charts[ChartComboBox.SelectedIndex].difficulty;
                level.Musicpath = Chart_folderTextBox.Text + '\\' + GetChartAudio(current_level, ChartComboBox.SelectedIndex);
                level.Backgroundpath = Chart_folderTextBox.Text + '\\' + current_level.background.path;
                level.Chartpath = Chart_folderTextBox.Text + '\\' + current_level.charts[ChartComboBox.SelectedIndex].path;

                #region Determine chart type
                string chart = File.ReadAllText(level.Chartpath).Trim();
                if (chart[0] == '{')
                    level.useOldFormat = false;
                else
                    level.useOldFormat = true;
                #endregion

                level.Save(c2_directory + "\\Settings.txt");
                #endregion

                #region Create wav file
                bool generated_wav = false;
                if (!File.Exists(level.Musicpath))
                {
                    CacheWav cache = null;
                    string cachefile_path = level.Musicpath.Substring(0, level.Musicpath.Length - 3) + "mp3.cachewav";
                    if (File.Exists(cachefile_path))
                    {
                        cache = CacheWav.Load(cachefile_path);
                    }
                    else
                    {
                        cache = new CacheWav(cachefile_path.Substring(0, cachefile_path.Length - 9));
                    }
                    File.WriteAllBytes(level.Musicpath, cache.GetWav());
                    cache.Save();
                    generated_wav = true;
                }
                #endregion

                #region Launch Cytus 2 Player
                string cwd = Environment.CurrentDirectory;
                Environment.CurrentDirectory = c2_directory;
                Process c2p_process = new Process();
                c2p_process.StartInfo = new ProcessStartInfo("PlayerDemo.exe");
                c2p_process.Start();
                c2p_process.WaitForExit();
                #endregion

                #region Clean up
                Environment.CurrentDirectory = cwd;
                File.WriteAllText(c2_directory + "\\Settings.txt", backup_settings_txt, Encoding.UTF8);
                if (generated_wav)
                    File.Delete(level.Musicpath);
                #endregion
                #endregion
            }
            else
            {
                #region Cytoid
                #region Copy level to play directory
                if (!Directory.Exists(play_directory))
                    Directory.CreateDirectory(play_directory);
                Directory.Delete(play_directory, true);
                ATEMMethods.CopyDirectory(Chart_folderTextBox.Text, play_directory);
                JSON.Level level = current_level.Clone();
                level.charts = new JSON.Chart[] { level.charts[ChartComboBox.SelectedIndex] };
                level.charts[0].music_override = new JSON.File() { path = GetChartAudio(level, 0) };
                level.Save(play_directory + "\\level.json");
                #endregion

                #region Create wav file
                if (!File.Exists(play_directory + '\\' + level.charts[0].music_override.path))
                {
                    CacheWav cache = null;
                    string cachefile_path = Chart_folderTextBox.Text + '\\' + level.charts[0].music_override.path.Substring(0, level.charts[0].music_override.path.Length - 3) + "mp3.cachewav";
                    if (File.Exists(cachefile_path))
                    {
                        cache = CacheWav.Load(cachefile_path);
                    }
                    else
                    {
                        cache = new CacheWav(cachefile_path.Substring(0, cachefile_path.Length - 9));
                    }
                    File.WriteAllBytes(play_directory + '\\' + level.charts[0].music_override.path, cache.GetWav());
                    cache.Save();
                }
                #endregion

                #region Launch Cytoid Player
                Process cp_process = new Process();
                cp_process.StartInfo = new ProcessStartInfo(optionsform.Cytoid_Player_path);
                cp_process.Start();
                cp_process.WaitForExit();
                #endregion
                #endregion
            }
        }
    }
}
