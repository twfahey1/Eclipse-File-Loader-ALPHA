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
            this.loadButton = new System.Windows.Forms.Button();
            this.currentSelectedFileLabel = new System.Windows.Forms.Label();
            this.transferToComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.backupUserFolderButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.destinationText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.currentUsersDropdown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.eclipseiniListBox = new System.Windows.Forms.ListBox();
            this.button7 = new System.Windows.Forms.Button();
            this.backupEssentialFiles = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadButton.Location = new System.Drawing.Point(142, 84);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(132, 68);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Find This Computer\'s Eclipse Files";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // currentSelectedFileLabel
            // 
            this.currentSelectedFileLabel.AutoSize = true;
            this.currentSelectedFileLabel.Location = new System.Drawing.Point(317, 66);
            this.currentSelectedFileLabel.Name = "currentSelectedFileLabel";
            this.currentSelectedFileLabel.Size = new System.Drawing.Size(0, 13);
            this.currentSelectedFileLabel.TabIndex = 4;
            // 
            // transferToComboBox
            // 
            this.transferToComboBox.FormattingEnabled = true;
            this.transferToComboBox.Location = new System.Drawing.Point(66, 237);
            this.transferToComboBox.Name = "transferToComboBox";
            this.transferToComboBox.Size = new System.Drawing.Size(157, 21);
            this.transferToComboBox.TabIndex = 7;
            this.transferToComboBox.SelectedIndexChanged += new System.EventHandler(this.transferToComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Choose Available Drive:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "Browse for destination";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Destination:";
            // 
            // backupUserFolderButton
            // 
            this.backupUserFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupUserFolderButton.Location = new System.Drawing.Point(29, 302);
            this.backupUserFolderButton.Name = "backupUserFolderButton";
            this.backupUserFolderButton.Size = new System.Drawing.Size(194, 27);
            this.backupUserFolderButton.TabIndex = 15;
            this.backupUserFolderButton.Text = "Backup Entire User Folder";
            this.backupUserFolderButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(-1, 435);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(347, 27);
            this.button3.TabIndex = 16;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // destinationText
            // 
            this.destinationText.Location = new System.Drawing.Point(237, 299);
            this.destinationText.Name = "destinationText";
            this.destinationText.Size = new System.Drawing.Size(157, 20);
            this.destinationText.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 356);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "This PC\'s Eclipse.ini";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(190, 216);
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
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.eclipseiniListBox);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.backupEssentialFiles);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.transferToComboBox);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Controls.Add(this.refreshButton);
            this.panel2.Controls.Add(this.loadButton);
            this.panel2.Controls.Add(this.destinationText);
            this.panel2.Controls.Add(this.backupUserFolderButton);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(-1, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 430);
            this.panel2.TabIndex = 32;
            // 
            // currentUsersDropdown
            // 
            this.currentUsersDropdown.FormattingEnabled = true;
            this.currentUsersDropdown.Location = new System.Drawing.Point(66, 192);
            this.currentUsersDropdown.Name = "currentUsersDropdown";
            this.currentUsersDropdown.Size = new System.Drawing.Size(157, 21);
            this.currentUsersDropdown.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Choose Eclipse User:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(251, 183);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 56);
            this.button4.TabIndex = 33;
            this.button4.Text = "Transfer to this computer";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // eclipseiniListBox
            // 
            this.eclipseiniListBox.FormattingEnabled = true;
            this.eclipseiniListBox.Location = new System.Drawing.Point(3, 371);
            this.eclipseiniListBox.Name = "eclipseiniListBox";
            this.eclipseiniListBox.ScrollAlwaysVisible = true;
            this.eclipseiniListBox.Size = new System.Drawing.Size(164, 56);
            this.eclipseiniListBox.TabIndex = 31;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(3, 84);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(132, 68);
            this.button7.TabIndex = 34;
            this.button7.Text = "Get Eclipse Files To Put On This Computer";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // backupEssentialFiles
            // 
            this.backupEssentialFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupEssentialFiles.Location = new System.Drawing.Point(29, 267);
            this.backupEssentialFiles.Name = "backupEssentialFiles";
            this.backupEssentialFiles.Size = new System.Drawing.Size(194, 29);
            this.backupEssentialFiles.TabIndex = 32;
            this.backupEssentialFiles.Text = "Backup Essential Files";
            this.backupEssentialFiles.UseVisualStyleBackColor = true;
            this.backupEssentialFiles.Click += new System.EventHandler(this.button5_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(3, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(414, 74);
            this.treeView1.TabIndex = 31;
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
            this.ClientSize = new System.Drawing.Size(428, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.currentSelectedFileLabel);
            this.Controls.Add(this.button3);
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

        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label currentSelectedFileLabel;
        private System.Windows.Forms.ComboBox transferToComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button backupUserFolderButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox destinationText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Panel panel2;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.ListBox eclipseiniListBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TreeView treeView1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button backupEssentialFiles;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox currentUsersDropdown;
        private System.Windows.Forms.Label label3;
    }
}

