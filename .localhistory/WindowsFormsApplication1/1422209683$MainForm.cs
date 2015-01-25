@@ -159,7 +159,8 @@ public bool RestoreEclipseFilesToLocalPC(EclipseObject iniObject)
        {
            writeINIbackup(CURRENT_MAINDIRECTORY5 + "\\" + iniObject.INI_JOB_FOLDER + ".ini", iniObject.INI_INFO_ARRAY);
            string[] filePathArray = iniObject.FILE_PATH.Split('\\');
            string copyFolder = iniObject.FILE_PATH.TrimEnd(iniObject.FILE_NAME.ToCharArray());
            //string copyFolder = iniObject.FILE_PATH.TrimEnd(iniObject.FILE_NAME.ToCharArray());
            string copyFolder = iniObject.FILE_PATH.TrimEnd(iniObject.FILE_NAME.ToCharArray()) + "\\" + iniObject.INI_JOB_FOLDER;
            string destination = CURRENT_MAINDIRECTORY5 + "\\" + iniObject.INI_JOB_FOLDER;
            string CurrentINILocation;
            DirectoryCopy(copyFolder, destination, true);
@@ -516,9 +517,9 @@ public void backupEssentialUserFiles(EclipseObject userIniObject, string destina
            string[] filePathArray = new string[] { userIniObject.INI_MAIN_DICTIONARY, userIniObject.INI_SPELL_DIX, userIniObject.INI_BLOCK_PATH };
            foreach (string i in filePathArray)
            {
                copyFile(i, userIniObject.INI_JOB_PATH, destination);
                copyFile(i, userIniObject.INI_JOB_PATH, destination + "\\" + userIniObject.INI_JOB_FOLDER);
            }
            DirectoryCopy(userIniObject.INI_BLOCK_PATH, destination + "\\" + userIniObject.INI_BLOCK_FOLDER, true);
            DirectoryCopy(userIniObject.INI_BLOCK_PATH, destination + "\\" + userIniObject.INI_JOB_FOLDER + "\\" + userIniObject.INI_BLOCK_FOLDER, true);
            MessageBox.Show("Essential Backup complete", "Essential Backup Complete", MessageBoxButtons.OK);


@@ -608,8 +609,15 @@ private static void DirectoryCopy(string sourceDirName, string destDirName, bool
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
                try
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, true);
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e);
                }
            }

            // If copying subdirectories, copy them and their contents to new location. 
@@ -872,24 +880,101 @@ private void button4_Click_1(object sender, EventArgs e)
            }
            else
            {
                string findString = currentUsersDropdown.Text.ToString();
                bool done = false;
                
                foreach (EclipseObject obj in INI_LIST)
                if (backgroundWorker1.IsBusy != true)
                {
                    if (obj.FILE_NAME.Equals(findString) && done == false)
                    // Start the asynchronous operation.
                    backgroundWorker1.RunWorkerAsync();
                    transferProgressLabel.Visible = true;
                    cancelButton.Visible = true;
                }
            }
        }
        // This event handler is where the time-consuming work is done. 
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string findString = currentUsersDropdown.Text.ToString();
            bool done = false;
            int count = 0;
            int reportPercentage = 0;


            foreach (EclipseObject obj in INI_LIST)
            {
                if (obj.FILE_NAME.Equals(findString) && done == false)
                {
                    // Get the subdirectories for the specified directory.
                    DirectoryInfo dir = new DirectoryInfo(obj.INI_JOB_PATH);
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    count = Convert.ToInt16(Directory.EnumerateFiles(obj.INI_JOB_PATH));
                    reportPercentage = 100/count;
                    

                    if (!dir.Exists)
                    {
                        backupAllUserFiles(obj, destinationText.Text);
                        done = true;
                        throw new DirectoryNotFoundException(
                            "Source directory does not exist or could not be found: "
                            + obj.INI_JOB_PATH);
                    }
                    else

                    // If the destination directory doesn't exist, create it. 
                    if (!Directory.Exists(destinationText.Text))
                    {
                        //MessageBox.Show("Backup did not succeed", "Backup did not succeed", MessageBoxButtons.OK);
                        Directory.CreateDirectory(destinationText.Text);
                    }

                    // Get the files in the directory and copy them to the new location.
                    FileInfo[] files = dir.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        worker.ReportProgress(reportPercentage);
                        string temppath = Path.Combine(destinationText.Text, file.Name);
                        file.CopyTo(temppath, true);
                    }

                    
                        foreach (DirectoryInfo subdir in dirs)
                        {
                            string temppath = Path.Combine(destinationText.Text, subdir.Name);
                            DirectoryCopy(subdir.FullName, temppath, true);
                        }
                    
                    done = true;
                }
                else
                {
                    //MessageBox.Show("Backup did not succeed", "Backup did not succeed", MessageBoxButtons.OK);
                }
            }
            
        }

        // This event handler updates the progress. 
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            transferProgressLabel.Text = (e.ProgressPercentage.ToString() + "%");
            transferProgressBar.Value = (e.ProgressPercentage);
        }

        // This event handler deals with the results of the background operation. 
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                transferProgressLabel.Text = "Canceled!";
                transferProgressBar.Value = 0;
            }
            else if (e.Error != null)
            {
                transferProgressLabel.Text = "Error: " + e.Error.Message;
                transferProgressBar.Value = 0;
            }
            else
            {
                transferProgressLabel.Text = "Done!";
                transferProgressBar.Value = 0;
            }
        }
    }
}
