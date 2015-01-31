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
            this.currentSelectedFileLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ExitButton = new System.Windows.Forms.Button();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backupPanel = new System.Windows.Forms.Panel();
            this.BackupAllFilesButton = new System.Windows.Forms.Button();
            this.BackupEssentialFilesOnlyButton = new System.Windows.Forms.Button();
            this.destinationLabel = new System.Windows.Forms.Label();
            this.destinationText = new System.Windows.Forms.TextBox();
            this.chooseAvailableDriveLabel = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.TransferToComboBox = new System.Windows.Forms.ComboBox();
            this.ShowAllFilesButton = new System.Windows.Forms.Button();
            this.ShowRecentFilesButton = new System.Windows.Forms.Button();
            this.restorePanel = new System.Windows.Forms.Panel();
            this.RestoreEssentialFilesOnlyButton = new System.Windows.Forms.Button();
            this.RestoreAllFilesButton = new System.Windows.Forms.Button();
            this.chooseUserPanel = new System.Windows.Forms.Panel();
            this.currentUsersDropdown = new System.Windows.Forms.ComboBox();
            this.chooseUserLabel = new System.Windows.Forms.Label();
            this.availableJobsCheckedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.TransferStatusPanel = new System.Windows.Forms.Panel();
            this.transferProgressBar = new System.Windows.Forms.ProgressBar();
            this.TransferStatusFileAndDestinationLabel = new System.Windows.Forms.Label();
            this.ShowJustThisUserJobsButton = new System.Windows.Forms.Button();
            this.InteractWithFilesFoundPanel = new System.Windows.Forms.Panel();
            this.loadingText = new System.Windows.Forms.Label();
            this.BrowseForEclipseUserFolderButton = new System.Windows.Forms.Button();
            this.RestoreEclipseUserButton = new System.Windows.Forms.Button();
            this.findEclipseFilesOnThisPCButton = new System.Windows.Forms.Button();
            this.RestoreJobPanel = new System.Windows.Forms.Panel();
            this.RestoreAllJobsButton = new System.Windows.Forms.Button();
            this.RestoreSelectedJobButton = new System.Windows.Forms.Button();
            this.backupPanel.SuspendLayout();
            this.restorePanel.SuspendLayout();
            this.chooseUserPanel.SuspendLayout();
            this.TransferStatusPanel.SuspendLayout();
            this.InteractWithFilesFoundPanel.SuspendLayout();
            this.RestoreJobPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // currentSelectedFileLabel
            // 
            this.currentSelectedFileLabel.AutoSize = true;
            this.currentSelectedFileLabel.Location = new System.Drawing.Point(344, 66);
            this.currentSelectedFileLabel.Name = "currentSelectedFileLabel";
            this.currentSelectedFileLabel.Size = new System.Drawing.Size(0, 13);
            this.currentSelectedFileLabel.TabIndex = 4;
            // 
            // ExitButton
            // 
            this.ExitButton.AutoSize = true;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(12, 392);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(304, 27);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // backupPanel
            // 
            this.backupPanel.Controls.Add(this.BackupAllFilesButton);
            this.backupPanel.Controls.Add(this.BackupEssentialFilesOnlyButton);
            this.backupPanel.Controls.Add(this.destinationLabel);
            this.backupPanel.Controls.Add(this.destinationText);
            this.backupPanel.Controls.Add(this.chooseAvailableDriveLabel);
            this.backupPanel.Controls.Add(this.RefreshButton);
            this.backupPanel.Controls.Add(this.BrowseButton);
            this.backupPanel.Controls.Add(this.TransferToComboBox);
            this.backupPanel.Location = new System.Drawing.Point(12, 92);
            this.backupPanel.Name = "backupPanel";
            this.backupPanel.Size = new System.Drawing.Size(167, 219);
            this.backupPanel.TabIndex = 40;
            this.backupPanel.Visible = false;
            // 
            // BackupAllFilesButton
            // 
            this.BackupAllFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupAllFilesButton.Location = new System.Drawing.Point(12, 182);
            this.BackupAllFilesButton.Name = "BackupAllFilesButton";
            this.BackupAllFilesButton.Size = new System.Drawing.Size(104, 34);
            this.BackupAllFilesButton.TabIndex = 33;
            this.BackupAllFilesButton.Text = "Click To Backup ALL Files";
            this.BackupAllFilesButton.UseVisualStyleBackColor = true;
            this.BackupAllFilesButton.Click += new System.EventHandler(this.BackupAllFilesButton_Click);
            // 
            // BackupEssentialFilesOnlyButton
            // 
            this.BackupEssentialFilesOnlyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupEssentialFilesOnlyButton.Location = new System.Drawing.Point(11, 148);
            this.BackupEssentialFilesOnlyButton.Name = "BackupEssentialFilesOnlyButton";
            this.BackupEssentialFilesOnlyButton.Size = new System.Drawing.Size(105, 34);
            this.BackupEssentialFilesOnlyButton.TabIndex = 32;
            this.BackupEssentialFilesOnlyButton.Text = "Click To Backup Essential Files Only";
            this.BackupEssentialFilesOnlyButton.UseVisualStyleBackColor = true;
            this.BackupEssentialFilesOnlyButton.Click += new System.EventHandler(this.BackupEssentialFilesOnlyButton_Click);
            // 
            // destinationLabel
            // 
            this.destinationLabel.AutoSize = true;
            this.destinationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationLabel.Location = new System.Drawing.Point(9, 7);
            this.destinationLabel.Name = "destinationLabel";
            this.destinationLabel.Size = new System.Drawing.Size(78, 16);
            this.destinationLabel.TabIndex = 30;
            this.destinationLabel.Text = "Destination:";
            // 
            // destinationText
            // 
            this.destinationText.Location = new System.Drawing.Point(12, 26);
            this.destinationText.Name = "destinationText";
            this.destinationText.Size = new System.Drawing.Size(141, 20);
            this.destinationText.TabIndex = 31;
            // 
            // chooseAvailableDriveLabel
            // 
            this.chooseAvailableDriveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseAvailableDriveLabel.Location = new System.Drawing.Point(9, 76);
            this.chooseAvailableDriveLabel.Name = "chooseAvailableDriveLabel";
            this.chooseAvailableDriveLabel.Size = new System.Drawing.Size(108, 15);
            this.chooseAvailableDriveLabel.TabIndex = 28;
            this.chooseAvailableDriveLabel.Text = "External Drives:";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.Location = new System.Drawing.Point(19, 117);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(63, 27);
            this.RefreshButton.TabIndex = 32;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseButton.Location = new System.Drawing.Point(12, 49);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(97, 24);
            this.BrowseButton.TabIndex = 29;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click_1);
            // 
            // TransferToComboBox
            // 
            this.TransferToComboBox.FormattingEnabled = true;
            this.TransferToComboBox.Location = new System.Drawing.Point(12, 94);
            this.TransferToComboBox.Name = "TransferToComboBox";
            this.TransferToComboBox.Size = new System.Drawing.Size(150, 21);
            this.TransferToComboBox.TabIndex = 27;
            this.TransferToComboBox.SelectedIndexChanged += new System.EventHandler(this.TransferToComboBox_SelectedIndexChanged);
            // 
            // ShowAllFilesButton
            // 
            this.ShowAllFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowAllFilesButton.Location = new System.Drawing.Point(27, 33);
            this.ShowAllFilesButton.Name = "ShowAllFilesButton";
            this.ShowAllFilesButton.Size = new System.Drawing.Size(145, 23);
            this.ShowAllFilesButton.TabIndex = 34;
            this.ShowAllFilesButton.Text = "Show All Jobs Found";
            this.ShowAllFilesButton.UseVisualStyleBackColor = true;
            this.ShowAllFilesButton.Click += new System.EventHandler(this.ShowAllFilesButton_Click_1);
            // 
            // ShowRecentFilesButton
            // 
            this.ShowRecentFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowRecentFilesButton.Location = new System.Drawing.Point(27, 4);
            this.ShowRecentFilesButton.Name = "ShowRecentFilesButton";
            this.ShowRecentFilesButton.Size = new System.Drawing.Size(145, 23);
            this.ShowRecentFilesButton.TabIndex = 33;
            this.ShowRecentFilesButton.Text = "Show Recent Jobs Found";
            this.ShowRecentFilesButton.UseVisualStyleBackColor = true;
            this.ShowRecentFilesButton.Click += new System.EventHandler(this.ShowRecentFilesButton_Click_1);
            // 
            // restorePanel
            // 
            this.restorePanel.Controls.Add(this.RestoreEssentialFilesOnlyButton);
            this.restorePanel.Controls.Add(this.RestoreAllFilesButton);
            this.restorePanel.Location = new System.Drawing.Point(364, 4);
            this.restorePanel.Name = "restorePanel";
            this.restorePanel.Size = new System.Drawing.Size(140, 151);
            this.restorePanel.TabIndex = 39;
            this.restorePanel.Visible = false;
            // 
            // RestoreEssentialFilesOnlyButton
            // 
            this.RestoreEssentialFilesOnlyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestoreEssentialFilesOnlyButton.Location = new System.Drawing.Point(5, 76);
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
            this.RestoreAllFilesButton.Location = new System.Drawing.Point(5, 3);
            this.RestoreAllFilesButton.Name = "RestoreAllFilesButton";
            this.RestoreAllFilesButton.Size = new System.Drawing.Size(126, 68);
            this.RestoreAllFilesButton.TabIndex = 33;
            this.RestoreAllFilesButton.Text = "Click To Restore ALL Files Found";
            this.RestoreAllFilesButton.UseVisualStyleBackColor = true;
            this.RestoreAllFilesButton.Click += new System.EventHandler(this.RestoreAllFilesButton_Click);
            // 
            // chooseUserPanel
            // 
            this.chooseUserPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chooseUserPanel.Controls.Add(this.currentUsersDropdown);
            this.chooseUserPanel.Controls.Add(this.chooseUserLabel);
            this.chooseUserPanel.Location = new System.Drawing.Point(209, 92);
            this.chooseUserPanel.Name = "chooseUserPanel";
            this.chooseUserPanel.Size = new System.Drawing.Size(141, 62);
            this.chooseUserPanel.TabIndex = 41;
            this.chooseUserPanel.Visible = false;
            // 
            // currentUsersDropdown
            // 
            this.currentUsersDropdown.FormattingEnabled = true;
            this.currentUsersDropdown.Location = new System.Drawing.Point(9, 26);
            this.currentUsersDropdown.Name = "currentUsersDropdown";
            this.currentUsersDropdown.Size = new System.Drawing.Size(122, 21);
            this.currentUsersDropdown.TabIndex = 35;
            this.currentUsersDropdown.SelectedIndexChanged += new System.EventHandler(this.currentUsersDropdown_SelectedIndexChanged);
            // 
            // chooseUserLabel
            // 
            this.chooseUserLabel.AutoSize = true;
            this.chooseUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseUserLabel.Location = new System.Drawing.Point(2, 7);
            this.chooseUserLabel.Name = "chooseUserLabel";
            this.chooseUserLabel.Size = new System.Drawing.Size(138, 16);
            this.chooseUserLabel.TabIndex = 36;
            this.chooseUserLabel.Text = "Choose Eclipse User:";
            // 
            // availableJobsCheckedListBox1
            // 
            this.availableJobsCheckedListBox1.FormattingEnabled = true;
            this.availableJobsCheckedListBox1.HorizontalScrollbar = true;
            this.availableJobsCheckedListBox1.Location = new System.Drawing.Point(186, 160);
            this.availableJobsCheckedListBox1.Name = "availableJobsCheckedListBox1";
            this.availableJobsCheckedListBox1.ScrollAlwaysVisible = true;
            this.availableJobsCheckedListBox1.Size = new System.Drawing.Size(328, 139);
            this.availableJobsCheckedListBox1.TabIndex = 33;
            // 
            // TransferStatusPanel
            // 
            this.TransferStatusPanel.Controls.Add(this.transferProgressBar);
            this.TransferStatusPanel.Controls.Add(this.TransferStatusFileAndDestinationLabel);
            this.TransferStatusPanel.Location = new System.Drawing.Point(3, 317);
            this.TransferStatusPanel.Name = "TransferStatusPanel";
            this.TransferStatusPanel.Size = new System.Drawing.Size(328, 69);
            this.TransferStatusPanel.TabIndex = 50;
            this.TransferStatusPanel.Visible = false;
            // 
            // transferProgressBar
            // 
            this.transferProgressBar.Location = new System.Drawing.Point(10, 33);
            this.transferProgressBar.Name = "transferProgressBar";
            this.transferProgressBar.Size = new System.Drawing.Size(295, 26);
            this.transferProgressBar.TabIndex = 53;
            // 
            // TransferStatusFileAndDestinationLabel
            // 
            this.TransferStatusFileAndDestinationLabel.Location = new System.Drawing.Point(9, 9);
            this.TransferStatusFileAndDestinationLabel.Name = "TransferStatusFileAndDestinationLabel";
            this.TransferStatusFileAndDestinationLabel.Size = new System.Drawing.Size(296, 21);
            this.TransferStatusFileAndDestinationLabel.TabIndex = 50;
            this.TransferStatusFileAndDestinationLabel.Text = "File Name To Destination";
            // 
            // ShowJustThisUserJobsButton
            // 
            this.ShowJustThisUserJobsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowJustThisUserJobsButton.Location = new System.Drawing.Point(27, 62);
            this.ShowJustThisUserJobsButton.Name = "ShowJustThisUserJobsButton";
            this.ShowJustThisUserJobsButton.Size = new System.Drawing.Size(145, 23);
            this.ShowJustThisUserJobsButton.TabIndex = 35;
            this.ShowJustThisUserJobsButton.Text = "Show Just This Users Jobs";
            this.ShowJustThisUserJobsButton.UseVisualStyleBackColor = true;
            this.ShowJustThisUserJobsButton.Click += new System.EventHandler(this.ShowJustThisUsersJobsButton_Click);
            // 
            // InteractWithFilesFoundPanel
            // 
            this.InteractWithFilesFoundPanel.Controls.Add(this.ShowJustThisUserJobsButton);
            this.InteractWithFilesFoundPanel.Controls.Add(this.ShowRecentFilesButton);
            this.InteractWithFilesFoundPanel.Controls.Add(this.ShowAllFilesButton);
            this.InteractWithFilesFoundPanel.Location = new System.Drawing.Point(334, 305);
            this.InteractWithFilesFoundPanel.Name = "InteractWithFilesFoundPanel";
            this.InteractWithFilesFoundPanel.Size = new System.Drawing.Size(180, 93);
            this.InteractWithFilesFoundPanel.TabIndex = 34;
            // 
            // loadingText
            // 
            this.loadingText.AutoSize = true;
            this.loadingText.Location = new System.Drawing.Point(10, 65);
            this.loadingText.Name = "loadingText";
            this.loadingText.Size = new System.Drawing.Size(187, 13);
            this.loadingText.TabIndex = 54;
            this.loadingText.Text = "Loading Eclipse Files.... Please wait....";
            this.loadingText.Visible = false;
            // 
            // BrowseForEclipseUserFolderButton
            // 
            this.BrowseForEclipseUserFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseForEclipseUserFolderButton.Location = new System.Drawing.Point(209, 61);
            this.BrowseForEclipseUserFolderButton.Name = "BrowseForEclipseUserFolderButton";
            this.BrowseForEclipseUserFolderButton.Size = new System.Drawing.Size(149, 20);
            this.BrowseForEclipseUserFolderButton.TabIndex = 53;
            this.BrowseForEclipseUserFolderButton.Text = "Browse For Eclipse Folder...";
            this.BrowseForEclipseUserFolderButton.UseVisualStyleBackColor = true;
            this.BrowseForEclipseUserFolderButton.Click += new System.EventHandler(this.BrowseForEclipseUserFolderButton_Click_1);
            // 
            // RestoreEclipseUserButton
            // 
            this.RestoreEclipseUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestoreEclipseUserButton.Location = new System.Drawing.Point(3, 4);
            this.RestoreEclipseUserButton.Name = "RestoreEclipseUserButton";
            this.RestoreEclipseUserButton.Size = new System.Drawing.Size(153, 55);
            this.RestoreEclipseUserButton.TabIndex = 52;
            this.RestoreEclipseUserButton.Text = "Restore Eclipse User";
            this.RestoreEclipseUserButton.UseVisualStyleBackColor = true;
            this.RestoreEclipseUserButton.Click += new System.EventHandler(this.RestoreEclipseUserButton_Click_1);
            // 
            // findEclipseFilesOnThisPCButton
            // 
            this.findEclipseFilesOnThisPCButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findEclipseFilesOnThisPCButton.Location = new System.Drawing.Point(209, 4);
            this.findEclipseFilesOnThisPCButton.Name = "findEclipseFilesOnThisPCButton";
            this.findEclipseFilesOnThisPCButton.Size = new System.Drawing.Size(149, 59);
            this.findEclipseFilesOnThisPCButton.TabIndex = 51;
            this.findEclipseFilesOnThisPCButton.Text = "Backup Eclipse User";
            this.findEclipseFilesOnThisPCButton.UseVisualStyleBackColor = true;
            this.findEclipseFilesOnThisPCButton.Click += new System.EventHandler(this.FindEclipseFilesOnThisPCButton_Click);
            // 
            // RestoreJobPanel
            // 
            this.RestoreJobPanel.Controls.Add(this.RestoreAllJobsButton);
            this.RestoreJobPanel.Controls.Add(this.RestoreSelectedJobButton);
            this.RestoreJobPanel.Location = new System.Drawing.Point(186, 305);
            this.RestoreJobPanel.Name = "RestoreJobPanel";
            this.RestoreJobPanel.Size = new System.Drawing.Size(170, 71);
            this.RestoreJobPanel.TabIndex = 55;
            this.RestoreJobPanel.Visible = false;
            this.RestoreJobPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.RestoreJobPanel_Paint);
            // 
            // RestoreAllJobsButton
            // 
            this.RestoreAllJobsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestoreAllJobsButton.Location = new System.Drawing.Point(13, 39);
            this.RestoreAllJobsButton.Name = "RestoreAllJobsButton";
            this.RestoreAllJobsButton.Size = new System.Drawing.Size(145, 23);
            this.RestoreAllJobsButton.TabIndex = 36;
            this.RestoreAllJobsButton.Text = "Restore All Jobs";
            this.RestoreAllJobsButton.UseVisualStyleBackColor = true;
            // 
            // RestoreSelectedJobButton
            // 
            this.RestoreSelectedJobButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestoreSelectedJobButton.Location = new System.Drawing.Point(14, 12);
            this.RestoreSelectedJobButton.Name = "RestoreSelectedJobButton";
            this.RestoreSelectedJobButton.Size = new System.Drawing.Size(145, 23);
            this.RestoreSelectedJobButton.TabIndex = 35;
            this.RestoreSelectedJobButton.Text = "Restore Selected Job";
            this.RestoreSelectedJobButton.UseVisualStyleBackColor = true;
            this.RestoreSelectedJobButton.Click += new System.EventHandler(this.RestoreSelectedJobButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(521, 427);
            this.Controls.Add(this.RestoreJobPanel);
            this.Controls.Add(this.loadingText);
            this.Controls.Add(this.BrowseForEclipseUserFolderButton);
            this.Controls.Add(this.RestoreEclipseUserButton);
            this.Controls.Add(this.findEclipseFilesOnThisPCButton);
            this.Controls.Add(this.TransferStatusPanel);
            this.Controls.Add(this.InteractWithFilesFoundPanel);
            this.Controls.Add(this.backupPanel);
            this.Controls.Add(this.chooseUserPanel);
            this.Controls.Add(this.restorePanel);
            this.Controls.Add(this.availableJobsCheckedListBox1);
            this.Controls.Add(this.currentSelectedFileLabel);
            this.Controls.Add(this.ExitButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Manager+";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.backupPanel.ResumeLayout(false);
            this.backupPanel.PerformLayout();
            this.restorePanel.ResumeLayout(false);
            this.chooseUserPanel.ResumeLayout(false);
            this.chooseUserPanel.PerformLayout();
            this.TransferStatusPanel.ResumeLayout(false);
            this.InteractWithFilesFoundPanel.ResumeLayout(false);
            this.RestoreJobPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentSelectedFileLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button ExitButton;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel backupPanel;
        private System.Windows.Forms.Button BackupAllFilesButton;
        private System.Windows.Forms.Button BackupEssentialFilesOnlyButton;
        private System.Windows.Forms.Panel restorePanel;
        private System.Windows.Forms.Button RestoreEssentialFilesOnlyButton;
        private System.Windows.Forms.Button RestoreAllFilesButton;
        private System.Windows.Forms.Panel chooseUserPanel;
        private System.Windows.Forms.ComboBox currentUsersDropdown;
        private System.Windows.Forms.Label chooseUserLabel;
        private System.Windows.Forms.CheckedListBox availableJobsCheckedListBox1;
        private System.Windows.Forms.Panel TransferStatusPanel;
        private System.Windows.Forms.ProgressBar transferProgressBar;
        private System.Windows.Forms.Label TransferStatusFileAndDestinationLabel;
        private System.Windows.Forms.Button ShowAllFilesButton;
        private System.Windows.Forms.Button ShowRecentFilesButton;
        private System.Windows.Forms.Label destinationLabel;
        private System.Windows.Forms.TextBox destinationText;
        private System.Windows.Forms.Label chooseAvailableDriveLabel;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.ComboBox TransferToComboBox;
        private System.Windows.Forms.Button ShowJustThisUserJobsButton;
        private System.Windows.Forms.Panel InteractWithFilesFoundPanel;
        private System.Windows.Forms.Label loadingText;
        private System.Windows.Forms.Button BrowseForEclipseUserFolderButton;
        private System.Windows.Forms.Button RestoreEclipseUserButton;
        private System.Windows.Forms.Button findEclipseFilesOnThisPCButton;
        private System.Windows.Forms.Panel RestoreJobPanel;
        private System.Windows.Forms.Button RestoreAllJobsButton;
        private System.Windows.Forms.Button RestoreSelectedJobButton;
    }
}

