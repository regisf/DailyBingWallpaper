namespace DailyBingWallpaper  
{
    partial class Preferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.searchPathButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.fetchUsingServerTimeRadioButton = new System.Windows.Forms.RadioButton();
            this.launchOnWindowsStarts = new System.Windows.Forms.CheckBox();
            this.fetchOnProgramStartsRadioButton = new System.Windows.Forms.RadioButton();
            this.fetchManuallyRadioButton = new System.Windows.Forms.RadioButton();
            this.applyButton = new System.Windows.Forms.Button();
            this.deleteImageCheckBox = new System.Windows.Forms.CheckBox();
            this.allowMetricsSendCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.languageSelect = new System.Windows.Forms.ComboBox();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.resetButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(397, 229);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(316, 229);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // searchPathButton
            // 
            this.searchPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchPathButton.Location = new System.Drawing.Point(460, 19);
            this.searchPathButton.Name = "searchPathButton";
            this.searchPathButton.Size = new System.Drawing.Size(75, 23);
            this.searchPathButton.TabIndex = 3;
            this.searchPathButton.Text = "...";
            this.searchPathButton.UseVisualStyleBackColor = true;
            this.searchPathButton.Click += new System.EventHandler(this.SearchPathButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pathTextBox);
            this.groupBox1.Controls.Add(this.searchPathButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 55);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image save path";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathTextBox.Location = new System.Drawing.Point(7, 20);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(447, 20);
            this.pathTextBox.TabIndex = 4;
            // 
            // fetchUsingServerTimeRadioButton
            // 
            this.fetchUsingServerTimeRadioButton.AutoSize = true;
            this.fetchUsingServerTimeRadioButton.Location = new System.Drawing.Point(13, 156);
            this.fetchUsingServerTimeRadioButton.Name = "fetchUsingServerTimeRadioButton";
            this.fetchUsingServerTimeRadioButton.Size = new System.Drawing.Size(137, 17);
            this.fetchUsingServerTimeRadioButton.TabIndex = 6;
            this.fetchUsingServerTimeRadioButton.Text = "Use server change time";
            this.fetchUsingServerTimeRadioButton.UseVisualStyleBackColor = true;
            // 
            // launchOnWindowsStarts
            // 
            this.launchOnWindowsStarts.AutoSize = true;
            this.launchOnWindowsStarts.Location = new System.Drawing.Point(13, 179);
            this.launchOnWindowsStarts.Name = "launchOnWindowsStarts";
            this.launchOnWindowsStarts.Size = new System.Drawing.Size(155, 17);
            this.launchOnWindowsStarts.TabIndex = 7;
            this.launchOnWindowsStarts.Text = "Launch  on Windows starts";
            this.launchOnWindowsStarts.UseVisualStyleBackColor = true;
            // 
            // fetchOnProgramStartsRadioButton
            // 
            this.fetchOnProgramStartsRadioButton.AutoSize = true;
            this.fetchOnProgramStartsRadioButton.Location = new System.Drawing.Point(156, 156);
            this.fetchOnProgramStartsRadioButton.Name = "fetchOnProgramStartsRadioButton";
            this.fetchOnProgramStartsRadioButton.Size = new System.Drawing.Size(159, 17);
            this.fetchOnProgramStartsRadioButton.TabIndex = 8;
            this.fetchOnProgramStartsRadioButton.Text = "Each time the program starts";
            this.fetchOnProgramStartsRadioButton.UseVisualStyleBackColor = true;
            // 
            // fetchManuallyRadioButton
            // 
            this.fetchManuallyRadioButton.AutoSize = true;
            this.fetchManuallyRadioButton.Location = new System.Drawing.Point(321, 156);
            this.fetchManuallyRadioButton.Name = "fetchManuallyRadioButton";
            this.fetchManuallyRadioButton.Size = new System.Drawing.Size(67, 17);
            this.fetchManuallyRadioButton.TabIndex = 9;
            this.fetchManuallyRadioButton.Text = "Manually";
            this.fetchManuallyRadioButton.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(478, 229);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 11;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // deleteImageCheckBox
            // 
            this.deleteImageCheckBox.AutoSize = true;
            this.deleteImageCheckBox.Location = new System.Drawing.Point(175, 179);
            this.deleteImageCheckBox.Name = "deleteImageCheckBox";
            this.deleteImageCheckBox.Size = new System.Drawing.Size(144, 17);
            this.deleteImageCheckBox.TabIndex = 12;
            this.deleteImageCheckBox.Text = "Delete image after usage";
            this.deleteImageCheckBox.UseVisualStyleBackColor = true;
            // 
            // allowMetricsSendCheckBox
            // 
            this.allowMetricsSendCheckBox.AutoSize = true;
            this.allowMetricsSendCheckBox.Location = new System.Drawing.Point(326, 179);
            this.allowMetricsSendCheckBox.Name = "allowMetricsSendCheckBox";
            this.allowMetricsSendCheckBox.Size = new System.Drawing.Size(113, 17);
            this.allowMetricsSendCheckBox.TabIndex = 13;
            this.allowMetricsSendCheckBox.Text = "Allow metrics send";
            this.allowMetricsSendCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.languageSelect);
            this.groupBox2.Location = new System.Drawing.Point(12, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(541, 71);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Language";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the Bing language you want. (Note: this is not the application language)";
            // 
            // languageSelect
            // 
            this.languageSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.languageSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageSelect.Location = new System.Drawing.Point(6, 36);
            this.languageSelect.Name = "languageSelect";
            this.languageSelect.Size = new System.Drawing.Size(528, 21);
            this.languageSelect.TabIndex = 0;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(13, 229);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 15;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 264);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.allowMetricsSendCheckBox);
            this.Controls.Add(this.deleteImageCheckBox);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.fetchManuallyRadioButton);
            this.Controls.Add(this.fetchOnProgramStartsRadioButton);
            this.Controls.Add(this.launchOnWindowsStarts);
            this.Controls.Add(this.fetchUsingServerTimeRadioButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Preferences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preferences";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button searchPathButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.RadioButton fetchUsingServerTimeRadioButton;
        private System.Windows.Forms.CheckBox launchOnWindowsStarts;
        private System.Windows.Forms.RadioButton fetchOnProgramStartsRadioButton;
        private System.Windows.Forms.RadioButton fetchManuallyRadioButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.CheckBox deleteImageCheckBox;
        private System.Windows.Forms.CheckBox allowMetricsSendCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox languageSelect;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button resetButton;
    }
}