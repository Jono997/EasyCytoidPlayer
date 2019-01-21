namespace EasyCytoidPlayer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Chart_folderLabel = new System.Windows.Forms.Label();
            this.Chart_folderTextBox = new System.Windows.Forms.TextBox();
            this.Chart_folder_browseButton = new System.Windows.Forms.Button();
            this.ChartComboBox = new System.Windows.Forms.ComboBox();
            this.ChartLabel = new System.Windows.Forms.Label();
            this.OpenButton = new System.Windows.Forms.Button();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // Chart_folderLabel
            // 
            this.Chart_folderLabel.AutoSize = true;
            this.Chart_folderLabel.Location = new System.Drawing.Point(12, 15);
            this.Chart_folderLabel.Name = "Chart_folderLabel";
            this.Chart_folderLabel.Size = new System.Drawing.Size(61, 13);
            this.Chart_folderLabel.TabIndex = 0;
            this.Chart_folderLabel.Text = "Chart folder";
            // 
            // Chart_folderTextBox
            // 
            this.Chart_folderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Chart_folderTextBox.Location = new System.Drawing.Point(79, 12);
            this.Chart_folderTextBox.Name = "Chart_folderTextBox";
            this.Chart_folderTextBox.Size = new System.Drawing.Size(334, 20);
            this.Chart_folderTextBox.TabIndex = 1;
            this.Chart_folderTextBox.TextChanged += new System.EventHandler(this.Chart_folderTextBox_TextChanged);
            // 
            // Chart_folder_browseButton
            // 
            this.Chart_folder_browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Chart_folder_browseButton.Location = new System.Drawing.Point(419, 10);
            this.Chart_folder_browseButton.Name = "Chart_folder_browseButton";
            this.Chart_folder_browseButton.Size = new System.Drawing.Size(27, 23);
            this.Chart_folder_browseButton.TabIndex = 2;
            this.Chart_folder_browseButton.Text = "...";
            this.Chart_folder_browseButton.UseVisualStyleBackColor = true;
            this.Chart_folder_browseButton.Click += new System.EventHandler(this.Chart_folder_browseButton_Click);
            // 
            // ChartComboBox
            // 
            this.ChartComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChartComboBox.Enabled = false;
            this.ChartComboBox.FormattingEnabled = true;
            this.ChartComboBox.Location = new System.Drawing.Point(79, 47);
            this.ChartComboBox.Name = "ChartComboBox";
            this.ChartComboBox.Size = new System.Drawing.Size(367, 21);
            this.ChartComboBox.TabIndex = 4;
            this.ChartComboBox.SelectedIndexChanged += new System.EventHandler(this.ChartComboBox_SelectedIndexChanged);
            // 
            // ChartLabel
            // 
            this.ChartLabel.AutoSize = true;
            this.ChartLabel.Location = new System.Drawing.Point(12, 50);
            this.ChartLabel.Name = "ChartLabel";
            this.ChartLabel.Size = new System.Drawing.Size(32, 13);
            this.ChartLabel.TabIndex = 5;
            this.ChartLabel.Text = "Chart";
            // 
            // OpenButton
            // 
            this.OpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenButton.Enabled = false;
            this.OpenButton.Location = new System.Drawing.Point(12, 74);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(365, 44);
            this.OpenButton.TabIndex = 6;
            this.OpenButton.Text = "Open in Cytoid Player";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // OptionsButton
            // 
            this.OptionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsButton.Location = new System.Drawing.Point(383, 74);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(63, 44);
            this.OptionsButton.TabIndex = 7;
            this.OptionsButton.Text = "Options";
            this.OptionsButton.UseVisualStyleBackColor = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 130);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.ChartLabel);
            this.Controls.Add(this.ChartComboBox);
            this.Controls.Add(this.Chart_folder_browseButton);
            this.Controls.Add(this.Chart_folderTextBox);
            this.Controls.Add(this.Chart_folderLabel);
            this.Name = "MainForm";
            this.Text = "Easy Cytoid Player";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Chart_folderLabel;
        private System.Windows.Forms.TextBox Chart_folderTextBox;
        private System.Windows.Forms.Button Chart_folder_browseButton;
        private System.Windows.Forms.ComboBox ChartComboBox;
        private System.Windows.Forms.Label ChartLabel;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button OptionsButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

