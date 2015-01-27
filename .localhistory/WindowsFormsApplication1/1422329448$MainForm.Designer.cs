namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.findEclipseFilesOnThisPCButton = new System.Windows.Forms.Button();
            this.currentSelectedFileLabel = new System.Windows.Forms.Label();
            this.transferToQuickPickComboBox = new System.Windows.Forms.ComboBox();
            this.chooseAvailableDriveLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.BrowseForDestinationButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.destinationText = new System.Windows.Forms.TextBox();
            this.thisPCEclipseINIinfoLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.restorePanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.TransferToThisComputerButton = new System.Windows.Forms.Button();
            this.chooseUserPanel = new System.Windows.Forms.Panel();
            this.currentUsersDropdown = new System.Windows.Forms.ComboBox();
            this.chooseUserLabel = new System.Windows.Forms.Label();
            this.backupPanel = new System.Windows.Forms.Panel();
            this.transferProgressBar = new System.Windows.Forms.ProgressBar();
            this.transferProgressLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.destinationLabel = new System.Windows.Forms.Label();
            this.BackupEssentialFilesButton = new System.Windows.Forms.Button();
            this.eclipseiniInfoListBox = new System.Windows.Forms.ListBox();
            this.loadEclipseFilesButton = new System.Windows.Forms.Button();
            this.fileInfoView = new System.Windows.Forms.TreeView();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.availableJobsCheckedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.restorePanel.SuspendLayout();
            this.chooseUserPanel.SuspendLayout();
            this.backupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // findEclipseFilesOnThisPCButton
            // 
            this.findEclipseFilesOnThisPCButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findEclipseFilesOnThisPCButton.Location = new System.Drawing.Point(13, 10);
            this.findEclipseFilesOnThisPCButton.Name = "findEclipseFilesOnThisPCButton";
            this.findEclipseFilesOnThisPCButton.Size = new System.Drawing.Size(145, 68);
            this.findEclipseFilesOnThisPCButton.TabIndex = 1;
            this.findEclipseFilesOnThisPCButton.Text = "Backup Eclipse User";
            this.findEclipseFilesOnThisPCButton.UseVisualStyleBackColor = true;
            this.findEclipseFilesOnThisPCButton.Click += new System.EventHandler(this.loadButton_Click);
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
            this.transferToQuickPickComboBox.Location = new System.Drawing.Point(93, 100);
            this.transferToQuickPickComboBox.Name = "transferToQuickPickComboBox";
            this.transferToQuickPickComboBox.Size = new System.Drawing.Size(35, 24);
            this.transferToQuickPickComboBox.TabIndex = 7;
            this.transferToQuickPickComboBox.SelectedIndexChanged += new System.EventHandler(this.transferToComboBox_SelectedIndexChanged);
            // 
            // chooseAvailableDriveLabel
            // 
            this.chooseAvailableDriveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseAvailableDriveLabel.Location = new System.Drawing.Point(8, 100);
            this.chooseAvailableDriveLabel.Name = "chooseAvailableDriveLabel";
            this.chooseAvailableDriveLabel.Size = new System.Drawing.Size(68, 42);
            this.chooseAvailableDriveLabel.TabIndex = 8;
            this.chooseAvailableDriveLabel.Text = "External Drives:";
            // 
            // BrowseForDestinationButton
            // 
            this.BrowseForDestinationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseForDestinationButton.Location = new System.Drawing.Point(11, 47);
            this.BrowseForDestinationButton.Name = "BrowseForDestinationButton";
            this.BrowseForDestinationButton.Size = new System.Drawing.Size(97, 24);
            this.BrowseForDestinationButton.TabIndex = 11;
            this.BrowseForDestinationButton.Text = "Browse...";
            this.BrowseForDestinationButton.UseVisualStyleBackColor = true;
            this.BrowseForDestinationButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(-1, 366);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(460, 27);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // destinationText
            // 
            this.destinationText.Location = new System.Drawing.Point(11, 19);
            this.destinationText.Name = "destinationText";
            this.destinationText.Size = new System.Drawing.Size(157, 22);
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
            this.refreshButton.Location = new System.Drawing.Point(145, 100);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(68, 38);
            this.refreshButton.TabIndex = 24;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.availableJobsCheckedListBox1);
            this.panel2.Controls.Add(this.chooseUserPanel);
            this.panel2.Controls.Add(this.restorePanel);
            this.panel2.Controls.Add(this.backupPanel);
            this.panel2.Controls.Add(this.eclipseiniInfoListBox);
            this.panel2.Controls.Add(this.loadEclipseFilesButton);
            this.panel2.Controls.Add(this.thisPCEclipseINIinfoLabel);
            this.panel2.Controls.Add(this.fileInfoView);
            this.panel2.Controls.Add(this.findEclipseFilesOnThisPCButton);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(-1, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(460, 364);
            this.panel2.TabIndex = 32;
            // 
            // restorePanel
            // 
            this.restorePanel.Controls.Add(this.button2);
            this.restorePanel.Controls.Add(this.TransferToThisComputerButton);
            this.restorePanel.Location = new System.Drawing.Point(315, 171);
            this.restorePanel.Name = "restorePanel";
            this.restorePanel.Size = new System.Drawing.Size(145, 162);
            this.restorePanel.TabIndex = 39;
            this.restorePanel.Visible = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(10, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 68);
            this.button2.TabIndex = 34;
            this.button2.Text = "Restore ALL Files";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TransferToThisComputerButton
            // 
            this.TransferToThisComputerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferToThisComputerButton.Location = new System.Drawing.Point(10, 15);
            this.TransferToThisComputerButton.Name = "TransferToThisComputerButton";
            this.TransferToThisComputerButton.Size = new System.Drawing.Size(126, 68);
            this.TransferToThisComputerButton.TabIndex = 33;
            this.TransferToThisComputerButton.Text = "Click To Begin Restoration";
            this.TransferToThisComputerButton.UseVisualStyleBackColor = true;
            this.TransferToThisComputerButton.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // chooseUserPanel
            // 
            this.chooseUserPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chooseUserPanel.Controls.Add(this.currentUsersDropdown);
            this.chooseUserPanel.Controls.Add(this.chooseUserLabel);
            this.chooseUserPanel.Location = new System.Drawing.Point(13, 84);
            this.chooseUserPanel.Name = "chooseUserPanel";
            this.chooseUserPanel.Size = new System.Drawing.Size(154, 62);
            this.chooseUserPanel.TabIndex = 41;
            this.chooseUserPanel.Visible = false;
            // 
            // currentUsersDropdown
            // 
            this.currentUsersDropdown.FormattingEnabled = true;
            this.currentUsersDropdown.Location = new System.Drawing.Point(3, 38);
            this.currentUsersDropdown.Name = "currentUsersDropdown";
            this.currentUsersDropdown.Size = new System.Drawing.Size(148, 24);
            this.currentUsersDropdown.TabIndex = 35;
            // 
            // chooseUserLabel
            // 
            this.chooseUserLabel.AutoSize = true;
            this.chooseUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseUserLabel.Location = new System.Drawing.Point(10, 19);
            this.chooseUserLabel.Name = "chooseUserLabel";
            this.chooseUserLabel.Size = new System.Drawing.Size(138, 16);
            this.chooseUserLabel.TabIndex = 36;
            this.chooseUserLabel.Text = "Choose Eclipse User:";
            // 
            // backupPanel
            // 
            this.backupPanel.Controls.Add(this.transferProgressBar);
            this.backupPanel.Controls.Add(this.transferProgressLabel);
            this.backupPanel.Controls.Add(this.cancelButton);
            this.backupPanel.Controls.Add(this.button1);
            this.backupPanel.Controls.Add(this.destinationLabel);
            this.backupPanel.Controls.Add(this.destinationText);
            this.backupPanel.Controls.Add(this.chooseAvailableDriveLabel);
            this.backupPanel.Controls.Add(this.refreshButton);
            this.backupPanel.Controls.Add(this.BrowseForDestinationButton);
            this.backupPanel.Controls.Add(this.transferToQuickPickComboBox);
            this.backupPanel.Controls.Add(this.BackupEssentialFilesButton);
            this.backupPanel.Location = new System.Drawing.Point(13, 152);
            this.backupPanel.Name = "backupPanel";
            this.backupPanel.Size = new System.Drawing.Size(296, 206);
            this.backupPanel.TabIndex = 40;
            this.backupPanel.Visible = false;
            // 
            // transferProgressBar
            // 
            this.transferProgressBar.Location = new System.Drawing.Point(145, 59);
            this.transferProgressBar.Name = "transferProgressBar";
            this.transferProgressBar.Size = new System.Drawing.Size(148, 26);
            this.transferProgressBar.TabIndex = 35;
            // 
            // transferProgressLabel
            // 
            this.transferProgressLabel.AutoSize = true;
            this.transferProgressLabel.Location = new System.Drawing.Point(203, 40);
            this.transferProgressLabel.Name = "transferProgressLabel";
            this.transferProgressLabel.Size = new System.Drawing.Size(27, 16);
            this.transferProgressLabel.TabIndex = 35;
            this.transferProgressLabel.Text = "0%";
            this.transferProgressLabel.Visible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(229, 163);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(64, 39);
            this.cancelButton.TabIndex = 34;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(125, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 58);
            this.button1.TabIndex = 33;
            this.button1.Text = "Backup ALL Files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // destinationLabel
            // 
            this.destinationLabel.AutoSize = true;
            this.destinationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationLabel.Location = new System.Drawing.Point(8, 0);
            this.destinationLabel.Name = "destinationLabel";
            this.destinationLabel.Size = new System.Drawing.Size(78, 16);
            this.destinationLabel.TabIndex = 13;
            this.destinationLabel.Text = "Destination:";
            // 
            // BackupEssentialFilesButton
            // 
            this.BackupEssentialFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupEssentialFilesButton.Location = new System.Drawing.Point(3, 144);
            this.BackupEssentialFilesButton.Name = "BackupEssentialFilesButton";
            this.BackupEssentialFilesButton.Size = new System.Drawing.Size(116, 58);
            this.BackupEssentialFilesButton.TabIndex = 32;
            this.BackupEssentialFilesButton.Text = "Click To Backup Essential Files Only";
            this.BackupEssentialFilesButton.UseVisualStyleBackColor = true;
            this.BackupEssentialFilesButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // eclipseiniInfoListBox
            // 
            this.eclipseiniInfoListBox.FormattingEnabled = true;
            this.eclipseiniInfoListBox.ItemHeight = 16;
            this.eclipseiniInfoListBox.Location = new System.Drawing.Point(321, 10);
            this.eclipseiniInfoListBox.Name = "eclipseiniInfoListBox";
            this.eclipseiniInfoListBox.ScrollAlwaysVisible = true;
            this.eclipseiniInfoListBox.Size = new System.Drawing.Size(85, 36);
            this.eclipseiniInfoListBox.TabIndex = 31;
            this.eclipseiniInfoListBox.Visible = false;
            // 
            // loadEclipseFilesButton
            // 
            this.loadEclipseFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadEclipseFilesButton.Location = new System.Drawing.Point(164, 10);
            this.loadEclipseFilesButton.Name = "loadEclipseFilesButton";
            this.loadEclipseFilesButton.Size = new System.Drawing.Size(145, 68);
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
            // availableJobsCheckedListBox1
            // 
            this.availableJobsCheckedListBox1.FormattingEnabled = true;
            this.availableJobsCheckedListBox1.Location = new System.Drawing.Point(173, 101);
            this.availableJobsCheckedListBox1.Name = "availableJobsCheckedListBox1";
            this.availableJobsCheckedListBox1.Size = new System.Drawing.Size(278, 55);
            this.availableJobsCheckedListBox1.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(173, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 42;
            this.label1.Text = "Available Jobs:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 393);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.currentSelectedFileLabel);
            this.Controls.Add(this.ExitButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eclipse File Loader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.restorePanel.ResumeLayout(false);
            this.chooseUserPanel.ResumeLayout(false);
            this.chooseUserPanel.PerformLayout();
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
        private System.Windows.Forms.Button BrowseForDestinationButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.TextBox destinationText;
        private System.Windows.Forms.Label thisPCEclipseINIinfoLabel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Panel panel2;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.ListBox eclipseiniInfoListBox;
        private System.Windows.Forms.Button TransferToThisComputerButton;
        private System.Windows.Forms.TreeView fileInfoView;
        private System.Windows.Forms.Button BackupEssentialFilesButton;
        private System.Windows.Forms.Button loadEclipseFilesButton;
        private System.Windows.Forms.ComboBox currentUsersDropdown;
        private System.Windows.Forms.Label chooseUserLabel;
        private System.Windows.Forms.Panel backupPanel;
        private System.Windows.Forms.Label destinationLabel;
        private System.Windows.Forms.Panel restorePanel;
        private System.Windows.Forms.Panel chooseUserPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ProgressBar transferProgressBar;
        private System.Windows.Forms.Label transferProgressLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox availableJobsCheckedListBox1;
    }
}

