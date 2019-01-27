namespace EasyCytoidPlayer
{
    partial class OptionsForm
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
            this.Cytoid_PlayerTextBox = new System.Windows.Forms.TextBox();
            this.Cytoid_PlayerLabel = new System.Windows.Forms.Label();
            this.Cytoid_Player_browseButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.C2_PlayerButton = new System.Windows.Forms.Button();
            this.C2_PlayerLabel = new System.Windows.Forms.Label();
            this.C2_PlayerTextBox = new System.Windows.Forms.TextBox();
            this.PlayerGroupBox = new System.Windows.Forms.GroupBox();
            this.Cytoid_PlayerRadioButton = new System.Windows.Forms.RadioButton();
            this.C2_PlayerRadioButton = new System.Windows.Forms.RadioButton();
            this.PlayerGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cytoid_PlayerTextBox
            // 
            this.Cytoid_PlayerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cytoid_PlayerTextBox.Location = new System.Drawing.Point(141, 12);
            this.Cytoid_PlayerTextBox.Name = "Cytoid_PlayerTextBox";
            this.Cytoid_PlayerTextBox.Size = new System.Drawing.Size(460, 20);
            this.Cytoid_PlayerTextBox.TabIndex = 0;
            // 
            // Cytoid_PlayerLabel
            // 
            this.Cytoid_PlayerLabel.AutoSize = true;
            this.Cytoid_PlayerLabel.Location = new System.Drawing.Point(12, 15);
            this.Cytoid_PlayerLabel.Name = "Cytoid_PlayerLabel";
            this.Cytoid_PlayerLabel.Size = new System.Drawing.Size(123, 13);
            this.Cytoid_PlayerLabel.TabIndex = 1;
            this.Cytoid_PlayerLabel.Text = "Cytoid Player executable";
            // 
            // Cytoid_Player_browseButton
            // 
            this.Cytoid_Player_browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cytoid_Player_browseButton.Location = new System.Drawing.Point(607, 10);
            this.Cytoid_Player_browseButton.Name = "Cytoid_Player_browseButton";
            this.Cytoid_Player_browseButton.Size = new System.Drawing.Size(25, 23);
            this.Cytoid_Player_browseButton.TabIndex = 2;
            this.Cytoid_Player_browseButton.Text = "...";
            this.Cytoid_Player_browseButton.UseVisualStyleBackColor = true;
            this.Cytoid_Player_browseButton.Click += new System.EventHandler(this.Cytoid_Player_browseButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(12, 121);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(620, 48);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Executable files|*.exe|All files|*.*";
            // 
            // C2_PlayerButton
            // 
            this.C2_PlayerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.C2_PlayerButton.Location = new System.Drawing.Point(607, 39);
            this.C2_PlayerButton.Name = "C2_PlayerButton";
            this.C2_PlayerButton.Size = new System.Drawing.Size(25, 23);
            this.C2_PlayerButton.TabIndex = 6;
            this.C2_PlayerButton.Text = "...";
            this.C2_PlayerButton.UseVisualStyleBackColor = true;
            this.C2_PlayerButton.Click += new System.EventHandler(this.C2_PlayerButton_Click);
            // 
            // C2_PlayerLabel
            // 
            this.C2_PlayerLabel.AutoSize = true;
            this.C2_PlayerLabel.Location = new System.Drawing.Point(12, 44);
            this.C2_PlayerLabel.Name = "C2_PlayerLabel";
            this.C2_PlayerLabel.Size = new System.Drawing.Size(129, 13);
            this.C2_PlayerLabel.TabIndex = 5;
            this.C2_PlayerLabel.Text = "Cytus 2 Player executable";
            // 
            // C2_PlayerTextBox
            // 
            this.C2_PlayerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.C2_PlayerTextBox.Location = new System.Drawing.Point(141, 41);
            this.C2_PlayerTextBox.Name = "C2_PlayerTextBox";
            this.C2_PlayerTextBox.Size = new System.Drawing.Size(460, 20);
            this.C2_PlayerTextBox.TabIndex = 4;
            // 
            // PlayerGroupBox
            // 
            this.PlayerGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerGroupBox.Controls.Add(this.C2_PlayerRadioButton);
            this.PlayerGroupBox.Controls.Add(this.Cytoid_PlayerRadioButton);
            this.PlayerGroupBox.Location = new System.Drawing.Point(12, 67);
            this.PlayerGroupBox.Name = "PlayerGroupBox";
            this.PlayerGroupBox.Size = new System.Drawing.Size(620, 46);
            this.PlayerGroupBox.TabIndex = 7;
            this.PlayerGroupBox.TabStop = false;
            this.PlayerGroupBox.Text = "Player to use";
            // 
            // Cytoid_PlayerRadioButton
            // 
            this.Cytoid_PlayerRadioButton.AutoSize = true;
            this.Cytoid_PlayerRadioButton.Checked = true;
            this.Cytoid_PlayerRadioButton.Location = new System.Drawing.Point(6, 19);
            this.Cytoid_PlayerRadioButton.Name = "Cytoid_PlayerRadioButton";
            this.Cytoid_PlayerRadioButton.Size = new System.Drawing.Size(86, 17);
            this.Cytoid_PlayerRadioButton.TabIndex = 0;
            this.Cytoid_PlayerRadioButton.TabStop = true;
            this.Cytoid_PlayerRadioButton.Text = "Cytoid Player";
            this.Cytoid_PlayerRadioButton.UseVisualStyleBackColor = true;
            // 
            // C2_PlayerRadioButton
            // 
            this.C2_PlayerRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.C2_PlayerRadioButton.AutoSize = true;
            this.C2_PlayerRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.C2_PlayerRadioButton.Location = new System.Drawing.Point(522, 19);
            this.C2_PlayerRadioButton.Name = "C2_PlayerRadioButton";
            this.C2_PlayerRadioButton.Size = new System.Drawing.Size(92, 17);
            this.C2_PlayerRadioButton.TabIndex = 1;
            this.C2_PlayerRadioButton.Text = "Cytus 2 Player";
            this.C2_PlayerRadioButton.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 181);
            this.Controls.Add(this.PlayerGroupBox);
            this.Controls.Add(this.C2_PlayerButton);
            this.Controls.Add(this.C2_PlayerLabel);
            this.Controls.Add(this.C2_PlayerTextBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.Cytoid_Player_browseButton);
            this.Controls.Add(this.Cytoid_PlayerLabel);
            this.Controls.Add(this.Cytoid_PlayerTextBox);
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.PlayerGroupBox.ResumeLayout(false);
            this.PlayerGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Cytoid_PlayerTextBox;
        private System.Windows.Forms.Label Cytoid_PlayerLabel;
        private System.Windows.Forms.Button Cytoid_Player_browseButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button C2_PlayerButton;
        private System.Windows.Forms.Label C2_PlayerLabel;
        private System.Windows.Forms.TextBox C2_PlayerTextBox;
        private System.Windows.Forms.GroupBox PlayerGroupBox;
        private System.Windows.Forms.RadioButton C2_PlayerRadioButton;
        private System.Windows.Forms.RadioButton Cytoid_PlayerRadioButton;
    }
}