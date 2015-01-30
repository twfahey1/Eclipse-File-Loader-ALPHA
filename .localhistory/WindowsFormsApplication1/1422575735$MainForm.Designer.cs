namespace EclipseFileManagerPlus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.findEclipseFilesOnThisPCButton = new System.Windows.Forms.Button();
            this.currentSelectedFileLabel = new System.Windows.Forms.Label();
            this.transferToQuickPickComboBox = new System.Windows.Forms.ComboBox();
            this.chooseAvailableDriveLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SetDestinationButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.destinationText = new System.Windows.Forms.TextBox();
            this.thisPCEclipseINIinfoLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.loadingText = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.transferProgressLabel = new System.Windows.Forms.Label();
            this.transferProgressBar = new System.Windows.Forms.ProgressBar();
            this.availableJobsCheckedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.chooseUserPanel = new System.Windows.Forms.Panel();
            this.currentUsersDropdown = new System.Windows.Forms.ComboBox();
            this.chooseUserLabel = new System.Windows.Forms.Label();
            this.restorePanel = new System.Windows.Forms.Panel();
            this.RestoreEssentialFilesOnlyButton = new System.Windows.Forms.Button();
            this.RestoreAllFilesButton = new System.Windows.Forms.Button();
            this.backupPanel = new System.Windows.Forms.Panel();
            this.BackupAllFilesButton = new System.Windows.Forms.Button();
            this.destinationLabel = new System.Windows.Forms.Label();
            this.BackupEssentialFilesOnlyButton = new System.Windows.Forms.Button();
            this.loadEclipseFilesButton = new System.Windows.Forms.Button();
            this.fileInfoView = new System.Windows.Forms.TreeView();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            this.chooseUserPanel.SuspendLayout();
            this.restorePanel.SuspendLayout();
            this.backupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // findEclipseFilesOnThisPCButton
            // 
            this.findEclipseFilesOnThisPCButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findEclipseFilesOnThisPCButton.Location = new System.Drawing.Point(183, 3);
            this.findEclipseFilesOnThisPCButton.Name = "findEclipseFilesOnThisPCButton";
            this.findEclipseFilesOnThisPCButton.Size = new System.Drawing.Size(149, 59);
            this.findEclipseFilesOnThisPCButton.TabIndex = 1;
            this.findEclipseFilesOnThisPCButton.Text = "Backup Eclipse User";
            this.findEclipseFilesOnThisPCButton.UseVisualStyleBackColor = true;
            this.findEclipseFilesOnThisPCButton.Click += new System.EventHandler(this.BackupEclipseUserButton_Click);
            // 
            // currentSelectedFileLabel
            // 
            this.currentSelectedFileLabel.AutoSize = true;
            this.currentSelectedFileLabel.Location = new System.Drawing.Point(317, 66);
            this.currentSelectedFileLabel.Name = "currentSelectedFileLabel";
            this.currentSelectedFileLabel.Size = new System.Drawing.Size(0, 13);
            this.currentSelectedFileLabel.TabIndex = 4;
            // 
            // transferToQuickPickComboBox
            // 
            this.transferToQuickPickComboBox.FormattingEnabled = true;
            this.transferToQuickPickComboBox.Location = new System.Drawing.Point(14, 97);
            this.transferToQuickPickComboBox.Name = "transferToQuickPickComboBox";
            this.transferToQuickPickComboBox.Size = new System.Drawing.Size(39, 24);
            this.transferToQuickPickComboBox.TabIndex = 7;
            this.transferToQuickPickComboBox.SelectedIndexChanged += new System.EventHandler(this.transferToComboBox_SelectedIndexChanged);
            // 
            // chooseAvailableDriveLabel
            // 
            this.chooseAvailableDriveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseAvailableDriveLabel.Location = new System.Drawing.Point(10, 79);
            this.chooseAvailableDriveLabel.Name = "chooseAvailableDriveLabel";
            this.chooseAvailableDriveLabel.Size = new System.Drawing.Size(108, 15);
            this.chooseAvailableDriveLabel.TabIndex = 8;
            this.chooseAvailableDriveLabel.Text = "External Drives:";
            // 
            // SetDestinationButton
            // 
            this.SetDestinationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetDestinationButton.Location = new System.Drawing.Point(13, 49);
            this.SetDestinationButton.Name = "SetDestinationButton";
            this.SetDestinationButton.Size = new System.Drawing.Size(97, 24);
            this.SetDestinationButton.TabIndex = 11;
            this.SetDestinationButton.Text = "Browse...";
            this.SetDestinationButton.UseVisualStyleBackColor = true;
            this.SetDestinationButton.Click += new System.EventHandler(this.SetDestinationButton_Click_1);
            // 
            // ExitButton
            // 
            this.ExitButton.AutoSize = true;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(-1, 344);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(336, 30);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // destinationText
            // 
            this.destinationText.Location = new System.Drawing.Point(13, 21);
            this.destinationText.Name = "destinationText";
            this.destinationText.Size = new System.Drawing.Size(141, 22);
            this.destinationText.TabIndex = 17;
            // 
            // thisPCEclipseINIinfoLabel
            // 
            this.thisPCEclipseINIinfoLabel.AutoSize = true;
            this.thisPCEclipseINIinfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thisPCEclipseINIinfoLabel.Location = new System.Drawing.Point(204, -19);
            this.thisPCEclipseINIinfoLabel.Name = "thisPCEclipseINIinfoLabel";
            this.thisPCEclipseINIinfoLabel.Size = new System.Drawing.Size(129, 16);
            this.thisPCEclipseINIinfoLabel.TabIndex = 19;
            this.thisPCEclipseINIinfoLabel.Text = "This PC\'s Eclipse.ini";
            this.thisPCEclipseINIinfoLabel.Visible = false;
            // 
            // refreshButton
            // 
            this.refreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Location = new System.Drawing.Point(59, 97);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(63, 38);
            this.refreshButton.TabIndex = 24;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.loadingText);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.transferProgressLabel);
            this.panel2.Controls.Add(this.transferProgressBar);
            this.panel2.Controls.Add(this.availableJobsCheckedListBox1);
            this.panel2.Controls.Add(this.chooseUserPanel);
            this.panel2.Controls.Add(this.restorePanel);
            this.panel2.Controls.Add(this.backupPanel);
            this.panel2.Controls.Add(this.loadEclipseFilesButton);
            this.panel2.Controls.Add(this.thisPCEclipseINIinfoLabel);
            this.panel2.Controls.Add(this.fileInfoView);
            this.panel2.Controls.Add(this.findEclipseFilesOnThisPCButton);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(-1, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 342);
            this.panel2.TabIndex = 32;
            // 
            // loadingText
            // 
            this.loadingText.AutoSize = true;
            this.loadingText.Location = new System.Drawing.Point(13, 64);
            this.loadingText.Name = "loadingText";
            this.loadingText.Size = new System.Drawing.Size(233, 16);
            this.loadingText.TabIndex = 43;
            this.loadingText.Text = "Loading Eclipse Files.... Please wait....";
            this.loadingText.Visible = false;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(183, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(149, 20);
            this.button3.TabIndex = 42;
            this.button3.Text = "Browse For Eclipse Folder...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // transferProgressLabel
            // 
            this.transferProgressLabel.AutoSize = true;
            this.transferProgressLabel.Location = new System.Drawing.Point(305, 323);
            this.transferProgressLabel.Name = "transferProgressLabel";
            this.transferProgressLabel.Size = new System.Drawing.Size(27, 16);
            this.transferProgressLabel.TabIndex = 35;
            this.transferProgressLabel.Text = "0%";
            this.transferProgressLabel.Visible = false;
            // 
            // transferProgressBar
            // 
            this.transferProgressBar.Location = new System.Drawing.Point(4, 313);
            this.transferProgressBar.Name = "transferProgressBar";
            this.transferProgressBar.Size = new System.Drawing.Size(295, 26);
            this.transferProgressBar.TabIndex = 36;
            this.transferProgressBar.Click += new System.EventHandler(this.transferProgressBar_Click);
            // 
            // availableJobsCheckedListBox1
            // 
            this.availableJobsCheckedListBox1.FormattingEnabled = true;
            this.availableJobsCheckedListBox1.Location = new System.Drawing.Point(157, 80);
            this.availableJobsCheckedListBox1.Name = "availableJobsCheckedListBox1";
            this.availableJobsCheckedListBox1.Size = new System.Drawing.Size(175, 89);
            this.availableJobsCheckedListBox1.TabIndex = 33;
            // 
            // chooseUserPanel
            // 
            this.chooseUserPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chooseUserPanel.Controls.Add(this.currentUsersDropdown);
            this.chooseUserPanel.Controls.Add(this.chooseUserLabel);
            this.chooseUserPanel.Location = new System.Drawing.Point(4, 93);
            this.chooseUserPanel.Name = "chooseUserPanel";
            this.chooseUserPanel.Size = new System.Drawing.Size(153, 62);
            this.chooseUserPanel.TabIndex = 41;
            this.chooseUserPanel.Visible = false;
            // 
            // currentUsersDropdown
            // 
            this.currentUsersDropdown.FormattingEnabled = true;
            this.currentUsersDropdown.Location = new System.Drawing.Point(3, 26);
            this.currentUsersDropdown.Name = "currentUsersDropdown";
            this.currentUsersDropdown.Size = new System.Drawing.Size(148, 24);
            this.currentUsersDropdown.TabIndex = 35;
            this.currentUsersDropdown.SelectedIndexChanged += new System.EventHandler(this.currentUsersDropdown_SelectedIndexChanged);
            // 
            // chooseUserLabel
            // 
            this.chooseUserLabel.AutoSize = true;
            this.chooseUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseUserLabel.Location = new System.Drawing.Point(10, 7);
            this.chooseUserLabel.Name = "chooseUserLabel";
            this.chooseUserLabel.Size = new System.Drawing.Size(138, 16);
            this.chooseUserLabel.TabIndex = 36;
            this.chooseUserLabel.Text = "Choose Eclipse User:";
            // 
            // restorePanel
            // 
            this.restorePanel.Controls.Add(this.RestoreEssentialFilesOnlyButton);
            this.restorePanel.Controls.Add(this.RestoreAllFilesButton);
            this.restorePanel.Location = new System.Drawing.Point(183, 158);
            this.restorePanel.Name = "restorePanel";
            this.restorePanel.Size = new System.Drawing.Size(135, 162);
            this.restorePanel.TabIndex = 39;
            this.restorePanel.Visible = false;
            // 
            // RestoreEssentialFilesOnlyButton
            // 
            this.RestoreEssentialFilesOnlyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestoreEssentialFilesOnlyButton.Location = new System.Drawing.Point(3, 79);
            this.RestoreEssentialFilesOnlyButton.Name = "RestoreEssentialFilesOnlyButton";
            this.RestoreEssentialFilesOnlyButton.Size = new System.Drawing.Size(126, 68);
            this.RestoreEssentialFilesOnlyButton.TabIndex = 34;
            this.RestoreEssentialFilesOnlyButton.Text = "Click To Restore Essential Files Only";
            this.RestoreEssentialFilesOnlyButton.UseVisualStyleBackColor = true;
            this.RestoreEssentialFilesOnlyButton.Click += new System.EventHandler(this.RestoreEssentialFilesOnlyButton_Click);
            // 
            // RestoreAllFilesButton
            // 
            this.RestoreAllFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestoreAllFilesButton.Location = new System.Drawing.Point(3, 9);
            this.RestoreAllFilesButton.Name = "RestoreAllFilesButton";
            this.RestoreAllFilesButton.Size = new System.Drawing.Size(126, 68);
            this.RestoreAllFilesButton.TabIndex = 33;
            this.RestoreAllFilesButton.Text = "Click To Restore ALL files found To Selected User";
            this.RestoreAllFilesButton.UseVisualStyleBackColor = true;
            this.RestoreAllFilesButton.Click += new System.EventHandler(this.RestoreAllFilesButton_Click);
            // 
            // backupPanel
            // 
            this.backupPanel.Controls.Add(this.BackupAllFilesButton);
            this.backupPanel.Controls.Add(this.destinationLabel);
            this.backupPanel.Controls.Add(this.destinationText);
            this.backupPanel.Controls.Add(this.chooseAvailableDriveLabel);
            this.backupPanel.Controls.Add(this.refreshButton);
            this.backupPanel.Controls.Add(this.SetDestinationButton);
            this.backupPanel.Controls.Add(this.transferToQuickPickComboBox);
            this.backupPanel.Controls.Add(this.BackupEssentialFilesOnlyButton);
            this.backupPanel.Location = new System.Drawing.Point(3, 170);
            this.backupPanel.Name = "backupPanel";
            this.backupPanel.Size = new System.Drawing.Size(296, 139);
            this.backupPanel.TabIndex = 40;
            this.backupPanel.Visible = false;
            // 
            // BackupAllFilesButton
            // 
            this.BackupAllFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupAllFilesButton.Location = new System.Drawing.Point(163, 74);
            this.BackupAllFilesButton.Name = "BackupAllFilesButton";
            this.BackupAllFilesButton.Size = new System.Drawing.Size(105, 58);
            this.BackupAllFilesButton.TabIndex = 33;
            this.BackupAllFilesButton.Text = "Click To Backup ALL Files";
            this.BackupAllFilesButton.UseVisualStyleBackColor = true;
            this.BackupAllFilesButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // destinationLabel
            // 
            this.destinationLabel.AutoSize = true;
            this.destinationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationLabel.Location = new System.Drawing.Point(10, 2);
            this.destinationLabel.Name = "destinationLabel";
            this.destinationLabel.Size = new System.Drawing.Size(78, 16);
            this.destinationLabel.TabIndex = 13;
            this.destinationLabel.Text = "Destination:";
            // 
            // BackupEssentialFilesOnlyButton
            // 
            this.BackupEssentialFilesOnlyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupEssentialFilesOnlyButton.Location = new System.Drawing.Point(163, 10);
            this.BackupEssentialFilesOnlyButton.Name = "BackupEssentialFilesOnlyButton";
            this.BackupEssentialFilesOnlyButton.Size = new System.Drawing.Size(116, 58);
            this.BackupEssentialFilesOnlyButton.TabIndex = 32;
            this.BackupEssentialFilesOnlyButton.Text = "Click To Backup Essential Files Only";
            this.BackupEssentialFilesOnlyButton.UseVisualStyleBackColor = true;
            this.BackupEssentialFilesOnlyButton.Click += new System.EventHandler(this.BackupEssentialFilesOnlyButton_Click);
            // 
            // loadEclipseFilesButton
            // 
            this.loadEclipseFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadEclipseFilesButton.Location = new System.Drawing.Point(4, 3);
            this.loadEclipseFilesButton.Name = "loadEclipseFilesButton";
            this.loadEclipseFilesButton.Size = new System.Drawing.Size(153, 55);
            this.loadEclipseFilesButton.TabIndex = 34;
            this.loadEclipseFilesButton.Text = "Restore Eclipse User";
            this.loadEclipseFilesButton.UseVisualStyleBackColor = true;
            this.loadEclipseFilesButton.Click += new System.EventHandler(this.button7_Click);
            // 
            // fileInfoView
            // 
            this.fileInfoView.Location = new System.Drawing.Point(286, -46);
            this.fileInfoView.Name = "fileInfoView";
            this.fileInfoView.Size = new System.Drawing.Size(44, 43);
            this.fileInfoView.TabIndex = 31;
            this.fileInfoView.Visible = false;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 375);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.currentSelectedFileLabel);
            this.Controls.Add(this.ExitButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Manager+";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.chooseUserPanel.ResumeLayout(false);
            this.chooseUserPanel.PerformLayout();
            this.restorePanel.ResumeLayout(false);
            this.backupPanel.ResumeLayout(false);
            this.backupPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button findEclipseFilesOnThisPCButton;
        private System.Windows.Forms.Label currentSelectedFileLabel;
        private System.Windows.Forms.ComboBox transferToQuickPickComboBox;
        private System.Windows.Forms.Label chooseAvailableDriveLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button SetDestinationButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.TextBox destinationText;
        private System.Windows.Forms.Label thisPCEclipseINIinfoLabel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Panel panel2;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Button RestoreAllFilesButton;
        private System.Windows.Forms.TreeView fileInfoView;
        private System.Windows.Forms.Button BackupEssentialFilesOnlyButton;
        private System.Windows.Forms.Button loadEclipseFilesButton;
        private System.Windows.Forms.ComboBox currentUsersDropdown;
        private System.Windows.Forms.Label chooseUserLabel;
        private System.Windows.Forms.Panel backupPanel;
        private System.Windows.Forms.Label destinationLabel;
        private System.Windows.Forms.Panel restorePanel;
        private System.Windows.Forms.Panel chooseUserPanel;
        private System.Windows.Forms.Button RestoreEssentialFilesOnlyButton;
        private System.Windows.Forms.Button BackupAllFilesButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label transferProgressLabel;
        private System.Windows.Forms.CheckedListBox availableJobsCheckedListBox1;
        private System.Windows.Forms.ProgressBar transferProgressBar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label loadingText;
    }
}

