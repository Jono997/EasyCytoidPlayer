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
            this.SaveButton.Location = new System.Drawing.Point(12, 38);
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
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 98);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.Cytoid_Player_browseButton);
            this.Controls.Add(this.Cytoid_PlayerLabel);
            this.Controls.Add(this.Cytoid_PlayerTextBox);
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Cytoid_PlayerTextBox;
        private System.Windows.Forms.Label Cytoid_PlayerLabel;
        private System.Windows.Forms.Button Cytoid_Player_browseButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}