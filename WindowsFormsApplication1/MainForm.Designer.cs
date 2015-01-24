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
            this.components = new System.ComponentModel.Container();
            this.findEclipseFilesOnThisPCButton = new System.Windows.Forms.Button();
            this.currentSelectedFileLabel = new System.Windows.Forms.Label();
            this.transferToQuickPickComboBox = new System.Windows.Forms.ComboBox();
            this.chooseAvailableDriveLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.BrowseForDestinationButton = new System.Windows.Forms.Button();
            this.destinationLabel = new System.Windows.Forms.Label();
            this.BackupUserFolderButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.destinationText = new System.Windows.Forms.TextBox();
            this.thisPCEclipseINIinfoLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.currentUsersDropdown = new System.Windows.Forms.ComboBox();
            this.chooseUserLabel = new System.Windows.Forms.Label();
            this.TransferToThisComputerButton = new System.Windows.Forms.Button();
            this.eclipseiniInfoListBox = new System.Windows.Forms.ListBox();
            this.loadEclipseFilesButton = new System.Windows.Forms.Button();
            this.BackupEssentialFilesButton = new System.Windows.Forms.Button();
            this.fileInfoView = new System.Windows.Forms.TreeView();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // findEclipseFilesOnThisPCButton
            // 
            this.findEclipseFilesOnThisPCButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findEclipseFilesOnThisPCButton.Location = new System.Drawing.Point(182, 84);
            this.findEclipseFilesOnThisPCButton.Name = "findEclipseFilesOnThisPCButton";
            this.findEclipseFilesOnThisPCButton.Size = new System.Drawing.Size(162, 68);
            this.findEclipseFilesOnThisPCButton.TabIndex = 1;
            this.findEclipseFilesOnThisPCButton.Text = "Find This Computer\'s Eclipse Files";
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
            this.transferToQuickPickComboBox.Location = new System.Drawing.Point(66, 237);
            this.transferToQuickPickComboBox.Name = "transferToQuickPickComboBox";
            this.transferToQuickPickComboBox.Size = new System.Drawing.Size(35, 21);
            this.transferToQuickPickComboBox.TabIndex = 7;
            this.transferToQuickPickComboBox.SelectedIndexChanged += new System.EventHandler(this.transferToComboBox_SelectedIndexChanged);
            // 
            // chooseAvailableDriveLabel
            // 
            this.chooseAvailableDriveLabel.AutoSize = true;
            this.chooseAvailableDriveLabel.Location = new System.Drawing.Point(10, 221);
            this.chooseAvailableDriveLabel.Name = "chooseAvailableDriveLabel";
            this.chooseAvailableDriveLabel.Size = new System.Drawing.Size(120, 13);
            this.chooseAvailableDriveLabel.TabIndex = 8;
            this.chooseAvailableDriveLabel.Text = "Choose Available Drive:";
            // 
            // BrowseForDestinationButton
            // 
            this.BrowseForDestinationButton.Location = new System.Drawing.Point(263, 253);
            this.BrowseForDestinationButton.Name = "BrowseForDestinationButton";
            this.BrowseForDestinationButton.Size = new System.Drawing.Size(68, 35);
            this.BrowseForDestinationButton.TabIndex = 11;
            this.BrowseForDestinationButton.Text = "Browse for destination";
            this.BrowseForDestinationButton.UseVisualStyleBackColor = true;
            this.BrowseForDestinationButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // destinationLabel
            // 
            this.destinationLabel.AutoSize = true;
            this.destinationLabel.Location = new System.Drawing.Point(104, 237);
            this.destinationLabel.Name = "destinationLabel";
            this.destinationLabel.Size = new System.Drawing.Size(63, 13);
            this.destinationLabel.TabIndex = 12;
            this.destinationLabel.Text = "Destination:";
            // 
            // BackupUserFolderButton
            // 
            this.BackupUserFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupUserFolderButton.Location = new System.Drawing.Point(66, 314);
            this.BackupUserFolderButton.Name = "BackupUserFolderButton";
            this.BackupUserFolderButton.Size = new System.Drawing.Size(194, 27);
            this.BackupUserFolderButton.TabIndex = 15;
            this.BackupUserFolderButton.Text = "Backup Entire User Folder";
            this.BackupUserFolderButton.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(-1, 435);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(347, 27);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // destinationText
            // 
            this.destinationText.Location = new System.Drawing.Point(107, 253);
            this.destinationText.Name = "destinationText";
            this.destinationText.Size = new System.Drawing.Size(157, 20);
            this.destinationText.TabIndex = 17;
            // 
            // thisPCEclipseINIinfoLabel
            // 
            this.thisPCEclipseINIinfoLabel.AutoSize = true;
            this.thisPCEclipseINIinfoLabel.Location = new System.Drawing.Point(0, 356);
            this.thisPCEclipseINIinfoLabel.Name = "thisPCEclipseINIinfoLabel";
            this.thisPCEclipseINIinfoLabel.Size = new System.Drawing.Size(101, 13);
            this.thisPCEclipseINIinfoLabel.TabIndex = 19;
            this.thisPCEclipseINIinfoLabel.Text = "This PC\'s Eclipse.ini";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(13, 235);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(55, 23);
            this.refreshButton.TabIndex = 24;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.currentUsersDropdown);
            this.panel2.Controls.Add(this.chooseUserLabel);
            this.panel2.Controls.Add(this.TransferToThisComputerButton);
            this.panel2.Controls.Add(this.eclipseiniInfoListBox);
            this.panel2.Controls.Add(this.loadEclipseFilesButton);
            this.panel2.Controls.Add(this.destinationLabel);
            this.panel2.Controls.Add(this.BackupEssentialFilesButton);
            this.panel2.Controls.Add(this.thisPCEclipseINIinfoLabel);
            this.panel2.Controls.Add(this.transferToQuickPickComboBox);
            this.panel2.Controls.Add(this.BrowseForDestinationButton);
            this.panel2.Controls.Add(this.fileInfoView);
            this.panel2.Controls.Add(this.refreshButton);
            this.panel2.Controls.Add(this.findEclipseFilesOnThisPCButton);
            this.panel2.Controls.Add(this.destinationText);
            this.panel2.Controls.Add(this.BackupUserFolderButton);
            this.panel2.Controls.Add(this.chooseAvailableDriveLabel);
            this.panel2.Location = new System.Drawing.Point(-1, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(347, 430);
            this.panel2.TabIndex = 32;
            // 
            // currentUsersDropdown
            // 
            this.currentUsersDropdown.FormattingEnabled = true;
            this.currentUsersDropdown.Location = new System.Drawing.Point(13, 176);
            this.currentUsersDropdown.Name = "currentUsersDropdown";
            this.currentUsersDropdown.Size = new System.Drawing.Size(157, 21);
            this.currentUsersDropdown.TabIndex = 35;
            // 
            // chooseUserLabel
            // 
            this.chooseUserLabel.AutoSize = true;
            this.chooseUserLabel.Location = new System.Drawing.Point(10, 160);
            this.chooseUserLabel.Name = "chooseUserLabel";
            this.chooseUserLabel.Size = new System.Drawing.Size(108, 13);
            this.chooseUserLabel.TabIndex = 36;
            this.chooseUserLabel.Text = "Choose Eclipse User:";
            // 
            // TransferToThisComputerButton
            // 
            this.TransferToThisComputerButton.Location = new System.Drawing.Point(188, 167);
            this.TransferToThisComputerButton.Name = "TransferToThisComputerButton";
            this.TransferToThisComputerButton.Size = new System.Drawing.Size(143, 30);
            this.TransferToThisComputerButton.TabIndex = 33;
            this.TransferToThisComputerButton.Text = "Transfer to this computer";
            this.TransferToThisComputerButton.UseVisualStyleBackColor = true;
            this.TransferToThisComputerButton.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // eclipseiniInfoListBox
            // 
            this.eclipseiniInfoListBox.FormattingEnabled = true;
            this.eclipseiniInfoListBox.Location = new System.Drawing.Point(3, 371);
            this.eclipseiniInfoListBox.Name = "eclipseiniInfoListBox";
            this.eclipseiniInfoListBox.ScrollAlwaysVisible = true;
            this.eclipseiniInfoListBox.Size = new System.Drawing.Size(164, 56);
            this.eclipseiniInfoListBox.TabIndex = 31;
            // 
            // loadEclipseFilesButton
            // 
            this.loadEclipseFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadEclipseFilesButton.Location = new System.Drawing.Point(3, 84);
            this.loadEclipseFilesButton.Name = "loadEclipseFilesButton";
            this.loadEclipseFilesButton.Size = new System.Drawing.Size(164, 68);
            this.loadEclipseFilesButton.TabIndex = 34;
            this.loadEclipseFilesButton.Text = "Get Eclipse Files To Put On This Computer";
            this.loadEclipseFilesButton.UseVisualStyleBackColor = true;
            this.loadEclipseFilesButton.Click += new System.EventHandler(this.button7_Click);
            // 
            // BackupEssentialFilesButton
            // 
            this.BackupEssentialFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupEssentialFilesButton.Location = new System.Drawing.Point(66, 279);
            this.BackupEssentialFilesButton.Name = "BackupEssentialFilesButton";
            this.BackupEssentialFilesButton.Size = new System.Drawing.Size(194, 29);
            this.BackupEssentialFilesButton.TabIndex = 32;
            this.BackupEssentialFilesButton.Text = "Backup Essential Files";
            this.BackupEssentialFilesButton.UseVisualStyleBackColor = true;
            this.BackupEssentialFilesButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // fileInfoView
            // 
            this.fileInfoView.Location = new System.Drawing.Point(3, 4);
            this.fileInfoView.Name = "fileInfoView";
            this.fileInfoView.Size = new System.Drawing.Size(344, 74);
            this.fileInfoView.TabIndex = 31;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.currentSelectedFileLabel);
            this.Controls.Add(this.ExitButton);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eclipse File Loader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Label destinationLabel;
        private System.Windows.Forms.Button BackupUserFolderButton;
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
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button BackupEssentialFilesButton;
        private System.Windows.Forms.Button loadEclipseFilesButton;
        private System.Windows.Forms.ComboBox currentUsersDropdown;
        private System.Windows.Forms.Label chooseUserLabel;
    }
}

