using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace EclipseFileManagerPlus
{
    /// <summary>
    /// 1) Figure out info from Eclipse.ini
    /// 2) Build lists of EclipseObjects that contain all pertinent file path info
    /// 3) User is given lists of valid user ini's in their MainDirectory5 parsed from the
    /// Eclipse.ini. Give user choice if they want to backup "essential", they will get JUST the
    /// blocks, main dictionary, spell dictionary, and optionally they can check box jobs
    /// from the list of recent files
    /// 4) User could and/or do a "full" backup, which will essentially give them EVERY
    /// file in their selected users job folder.
    /// 5) The same idea of "essential" and "full" is used for restoration function, so that
    /// the user can restore an ini to the system, or restore all files to the system, so the
    /// idea is the user can use the utility on both sides during a migration scenario.
    /// 6) We are assuming the user has run Eclipse install, v5+ and the eclipse.ini will be in
    /// their main windows drive under Windows folder as eclipse.ini, i.e. C:\Windows\eclipse.ini
    /// </summary>
    /// <returns></returns>
    public partial class MainForm : Form{
    //Here's the allmighty EclipseObject, which we are using to organize all objects
    //found when scanning folders for objects. As we find objects we are creating simple
    //string based entities, which if they are INI file type will get a few extra
    //characteristics for use later on, otherwise we pretty much just have the file path and 
    //the name is parsed out based on splitting the path to a string array, delimited by
    // '\\ and then grabbing the last chunk of that array for the actual file name reference
    public class EclipseObject
    {
        public string FILE_NAME;
        public string FILE_TYPE;
        public string FILE_PATH;
        public string FILE_USER_FOLDER;
        public string FILE_SIZE;
        //If the object is an INI it will have these characteristics
        //These are full path references for the object
        public string INI_MAIN_PATH;
        public string INI_JOB_PATH;
        public string INI_BLOCK_PATH;
        public string INI_MAIN_DICTIONARY_PATH;

        /// These are the folder names, just "Blocks" or "TylerJobs"
        public string INI_JOB_FOLDER;
        public string INI_BLOCK_FOLDER;
        public string INI_MAIN_DICTIONARY_NAME;

        public string INI_SPELL_DIX;
        public string[] INI_INFO_ARRAY;

        public EclipseObject(string name, string type, string path)
        {
            this.FILE_NAME = name; //this is going to be a string ref. to the file, may be the same as path ultimately since that would force it to be unique
            this.FILE_TYPE = type; //is going to be ".INI", ".ECL", ".NOT", ".DIX", ".ESP", ".ESD" this is passed in as a literal string
            this.FILE_PATH = path; //should be the objects path i.e.: C:\Users\Docs\Eclipse\Tyler\job1.ecl
            this.FILE_USER_FOLDER = Path.GetDirectoryName(FILE_PATH);//trims off the actual file name to reveal the folder
            if (type == ".INI")//if the file is an INI when we create we give it all these characteristics:
            {
                this.INI_INFO_ARRAY = File.ReadAllLines(this.FILE_PATH);

                foreach (String iniLine in INI_INFO_ARRAY)
                {
                    if (iniLine.StartsWith("Path") && iniLine.Contains("=MAIN="))
                    {
                        var parts = iniLine.Split('=');
                        this.INI_MAIN_PATH = parts[1].Replace("{DOC}", Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\");
                    }
                    if (iniLine.StartsWith("Path") && iniLine.Contains("=JOB="))
                    {
                        string[] JOB_PATH_ARRAY = iniLine.Split('=');
                        this.INI_JOB_PATH = JOB_PATH_ARRAY.Last().Replace("{DOC}", Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\");
                        JOB_PATH_ARRAY = this.INI_JOB_PATH.Split('\\');
                        this.INI_JOB_FOLDER = JOB_PATH_ARRAY.Last();

                        MessageBox.Show(INI_JOB_FOLDER);
                        if (this.INI_MAIN_DICTIONARY_NAME != null)
                        {
                            this.INI_MAIN_DICTIONARY_PATH = Path.Combine(this.INI_JOB_PATH + "\\" + this.INI_MAIN_DICTIONARY_NAME);
                        }
                    }
                    if (iniLine.StartsWith("MainDictionary="))
                    {
                        var parts = iniLine.Split('=');
                        this.INI_MAIN_DICTIONARY_NAME = parts[1];
                    }
                    if (iniLine.StartsWith("SpellUser="))
                    {
                        var parts = iniLine.Split('=');
                        this.INI_SPELL_DIX = parts[1];
                    }

                    if (iniLine.StartsWith("Path") && iniLine.Contains("=BLOCK="))
                    {
                        var parts = iniLine.Split('=');
                        this.INI_BLOCK_PATH = parts.Last().Replace("{JOB}", this.INI_JOB_PATH + "\\");
                        string[] INI_BLOCK_ARRAY = this.INI_BLOCK_PATH.Split('\\');
                        this.INI_BLOCK_FOLDER = INI_BLOCK_ARRAY.Last();
                    }
                }
            }
        }
    }
 
        //The variables here are used for referencing the system, the various ini parsings that take
        //place and corresponding paths
        public string CURRENT_SYSTEM_MAIN_DRIVE = Path.GetPathRoot(Environment.SystemDirectory);
        public string USER_DOCUMENTS_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        
        public string CURRENT_USERFILE5;
        public string CURRENT_MAINDIRECTORY5;
        public string USER_ECLIPSE_FOLDER;
        public string SELECTED_USER_INI;
        public string SELECTED_USER_JOB_FOLDER;
        public string SELECTED_USER_MAIN_DICTIONARY;
        public string USERFILE5_LINE;

        public List<EclipseObject> INI_LIST = new List<EclipseObject>();
        public List<EclipseObject> ECL_LIST = new List<EclipseObject>();
        public List<EclipseObject> NOT_LIST = new List<EclipseObject>();
        public List<EclipseObject> DIX_LIST = new List<EclipseObject>();
        public List<EclipseObject> WAV_LIST = new List<EclipseObject>();
        public List<EclipseObject> ESP_LIST = new List<EclipseObject>();
        public List<EclipseObject> ESD_LIST = new List<EclipseObject>();

        public List<string> RECENT_FILE_PATH_LIST = new List<string>();       
        
        public bool ReadMainEclipseINI()
        {
            string currentWindowsFolderEclipseIniLocation = CURRENT_SYSTEM_MAIN_DRIVE + "\\Windows\\eclipse.ini";
            string[] result = File.ReadAllLines(currentWindowsFolderEclipseIniLocation);
            foreach (String iniLine in result)
            {
                ///This grabs the MainDir5 line, then splits to array delimited
                ///by =, then we get the second chunk of resulting array which is path,
                ///we replace {DOC} with current users personal folder
                if (iniLine.Contains("MainDirectory5"))
                {
                    var parts = iniLine.Split('=');
                    CURRENT_MAINDIRECTORY5 = parts[1].Replace("{DOC}", Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\");
                }
                ///This should populate recent files list, each line starts
                ///with "File3=C:\Whatever"
                if (iniLine.StartsWith("File"))
                {
                    var parts = iniLine.Split('=');
                    RECENT_FILE_PATH_LIST.Add(parts[1]);
                }

            }
            if (CURRENT_MAINDIRECTORY5 != null)
            {
                return true;
            }
            return false;
        }

        public MainForm()
        {
            InitializeComponent();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }       

        private void MainForm_Load(object sender, EventArgs e)
        {
            currentUsersDropdown.MaxDropDownItems = 100;
            if (ReadMainEclipseINI())
            {                
                MessageBox.Show("Eclipse MainDir5 has been found as: "+CURRENT_MAINDIRECTORY5);
            } else {
                MessageBox.Show("Warning: Eclipse.ini looking under: "+ CURRENT_SYSTEM_MAIN_DRIVE + "\\Windows\\eclipse.ini, not successfully read. May need to reinstall");
            }
            /// to-do: use the recent file list to populate the recent jobs
            /// list, the keys should contain paths
            DriveInfo[] files = DriveInfo.GetDrives();
            foreach (DriveInfo d in files)
            {
                transferToQuickPickComboBox.Items.Add(String.Format(d.Name));
                // can convert to GB free: (decided to take this out)
                //freeSpaceLabel.Text = (d.AvailableFreeSpace / 1000000000 + "gb free");
            }

        }

        public bool LoadEclipseFilesFromPath(string path)
        {
            ClearAllCollections();
            try
            {
                foreach (string d in Directory.GetDirectories(path))
                {
                    foreach (string f in Directory.EnumerateFiles(d))
                    {
                        WritePathDataToEclipseCollections(f);
                    }
                }
            }
            catch (System.Exception excpt)
            {
                Console.Write(excpt);
            }

            try
            {
                foreach (string f in Directory.EnumerateFiles(path))
                {
                    WritePathDataToEclipseCollections(f);
                }
            }
            catch (System.Exception excpt)
            {
                Console.Write(excpt);
            }
            return true;
        }

        /*public void LoadLocalDataSource(List<EclipseObject> list)
        {
            List<string> stringList = new List<string>();
            foreach (EclipseObject obj in list)
            {
                if (obj.FILE_TYPE == ".INI")
                {
                    if (Path.GetDirectoryName(obj.FILE_PATH) == CURRENT_MAINDIRECTORY5)
                    {
                        stringList.Add(obj.FILE_NAME);
                    }
                }
            }
            currentUsersDropdown.DataSource = stringList;
        }*/
        public void LoadDataSource(List<EclipseObject> list)
        {
            List<string> stringList = new List<string>();
            foreach (EclipseObject obj in list)
            {
                if (obj.FILE_TYPE == ".INI")
                {

                    stringList.Add(obj.FILE_NAME);

                }
            }
            currentUsersDropdown.DataSource = stringList;
            setupJobCheckListBox();
        }

        //Here's method to restore files back to local pc, which is based on the
        //info we get from eclipse.ini, MainDirectory5= line
        public bool RestoreAllEclipseFiles(EclipseObject iniObject)
        {
            transferProgressBar.Value = 0;
            transferProgressBar.Maximum = Directory.GetFiles(Path.GetDirectoryName(iniObject.FILE_PATH), "*", SearchOption.AllDirectories).Length;
            //First use our writeINIBackup to get an ini and a set file created right on the main dir 5 from the eclipse.ini
            WriteINIBackup(Path.Combine(CURRENT_MAINDIRECTORY5, iniObject.FILE_NAME), iniObject.INI_INFO_ARRAY);
            transferProgressBar.PerformStep();
            Console.WriteLine("Ini written to: "+Path.Combine(CURRENT_MAINDIRECTORY5, iniObject.FILE_NAME));
            ///Next we perform a quick assessment of the folder we want to actually copy, so this will be looking at the files
            ///current path for reference, then taking the ini part off the path, and replacing with referencing the job folder name. 
            ///Could maybe be done a better way
            string copyFolder = Path.GetDirectoryName(iniObject.FILE_PATH);
            Console.WriteLine("copyFolder set as " +  Path.GetDirectoryName(iniObject.FILE_PATH));
            //Destination uses the current mainDir5, parsed previously from Eclipse.ini, and of course user folder name
            string destination = CURRENT_MAINDIRECTORY5;
            Console.WriteLine("Destinaton set as " +  destination);
            //Now, we launch the copy procedure.
            foreach (string i in Directory.GetFiles(copyFolder, "*", SearchOption.TopDirectoryOnly))
                try
                {
                    CopyFile(Path.GetFileName(i), Path.GetDirectoryName(i), destination);
                    Console.WriteLine("1st Wave - TRY COPY: "+Path.GetFileName(i)+" \\ "+Path.GetDirectoryName(i)+" \\ "+destination);
                    //copyFile(i, userIniObject.INI_JOB_PATH, destination + "\\" + userIniObject.INI_JOB_FOLDER);
                    transferProgressBar.PerformStep();
                }
                catch (IOException)
                {
                    Console.WriteLine("File not found: " + i);
                    return false;
                }
            //This will get all sub folders of main dir, blocks and anything else user has
            foreach (string dirPath in Directory.GetDirectories(copyFolder))
            {
                //creates all directories
                
                foreach (string file in Directory.GetFiles(Path.Combine(destination, dirPath), "*", SearchOption.TopDirectoryOnly))
                {
                    
                    Console.WriteLine("2nd wave - Attempting to copy: "+Path.GetFileName(file)+" / "+ Path.GetDirectoryName(file)+" / "+Path.Combine(destination, iniObject.INI_JOB_FOLDER));
                    CopyFile(Path.GetFileName(file), Path.GetDirectoryName(file), Path.Combine(destination, iniObject.INI_JOB_FOLDER));
                    transferProgressBar.PerformStep();
                }
            }
            //Now lets do the top level of the backup folder
            foreach (string subdirPath in Directory.GetDirectories(Path.Combine(copyFolder, iniObject.INI_JOB_FOLDER)))
            {
                Console.WriteLine("sub dir in job folder detected: " + subdirPath);
                DirectoryInfo dinfo = new DirectoryInfo(subdirPath);
                string SubfolderName = dinfo.Name;
                string destinationSubFolderPath = Path.Combine(destination, iniObject.INI_JOB_FOLDER, SubfolderName);
                Directory.CreateDirectory(destinationSubFolderPath);
                foreach (string file in Directory.GetFiles(subdirPath))
                {
                    Console.WriteLine("3rd wave - Attempting to copy: " + Path.GetFileName(file) + " / " + Path.GetDirectoryName(file) + " / " + destinationSubFolderPath);
                    CopyFile(Path.GetFileName(file), Path.GetDirectoryName(file), destinationSubFolderPath);
                    transferProgressBar.PerformStep();
                }

            }
            //DirectoryCopy(userIniObject.INI_JOB_PATH, destination, true);
            //MessageBox.Show("Full Backup complete", "Full Backup Complete", MessageBoxButtons.OK);
            Console.WriteLine("Restoration Completed Succesfully");
            //DirectoryCopy(copyFolder, destination, true);
            //DirectoryCopy(CurrentINILocation+iniObject.INI_BLOCK_FOLDER, destination + "\\" + iniObject.INI_BLOCK_FOLDER + "\\", true);
            //EclipseObject newIniObject = new EclipseObject("recreated" + iniObject.FILE_NAME, ".INI", iniObject.INI_JOB_PATH);
            //iniObject.INI_JOB_FOLDER = CURRENT_MAINDIRECTORY5 + 

            return true;
        }

        public bool RestoreEssentialEclipseFiles(EclipseObject iniObject)
        {
            List<string> checkedFilesToCopy = checkmarkedJobsToCopy();
            transferProgressBar.Value = 0;
            string copyFolder = Path.GetDirectoryName(iniObject.FILE_PATH);
            Console.WriteLine("copyFolder set as " + Path.GetDirectoryName(iniObject.FILE_PATH));
            //Destination uses the current mainDir5, parsed previously from Eclipse.ini, and of course user folder name
            string destination = CURRENT_MAINDIRECTORY5;
            Console.WriteLine("Destinaton set as " + destination);
            string[] essentialFilePaths = new string[] { Path.Combine(copyFolder, iniObject.INI_JOB_FOLDER, iniObject.INI_MAIN_DICTIONARY_NAME), Path.Combine(copyFolder, iniObject.INI_JOB_FOLDER, iniObject.INI_SPELL_DIX) };
            foreach (string i in essentialFilePaths)
            {
                Console.WriteLine(i + " added as essential file");
            }

            //transferProgressBar.Maximum = Directory.GetFiles(Path.GetDirectoryName(iniObject.FILE_PATH), , SearchOption.AllDirectories).Length;
            //First use our writeINIBackup to get an ini and a set file created right on the main dir 5 from the eclipse.ini
            WriteINIBackup(Path.Combine(CURRENT_MAINDIRECTORY5, iniObject.FILE_NAME), iniObject.INI_INFO_ARRAY);
            transferProgressBar.PerformStep();
            Console.WriteLine("Ini written to: " + Path.Combine(CURRENT_MAINDIRECTORY5, iniObject.FILE_NAME));
            ///Next we perform a quick assessment of the folder we want to actually copy, so this will be looking at the files
            ///current path for reference, then taking the ini part off the path, and replacing with referencing the job folder name. 
            ///Could maybe be done a better way

            //Now, we launch the copy procedure.
            //Get the blocks folder
            foreach (string subdirPath in Directory.GetDirectories(Path.Combine(copyFolder, iniObject.INI_JOB_FOLDER)))
            {
                try
                {
                    if (subdirPath == Path.Combine(copyFolder, iniObject.INI_JOB_FOLDER, iniObject.INI_BLOCK_FOLDER))
                    {
                        string blockDest = Path.Combine(destination, iniObject.INI_JOB_FOLDER, iniObject.INI_BLOCK_FOLDER);
                        Directory.CreateDirectory(blockDest);
                        foreach (string file in Directory.GetFiles(subdirPath))
                        {
                            CopyFile(Path.GetFileName(file), Path.GetDirectoryName(file), blockDest);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception was caught during copy subDirPath: " + e);
                }
            }
            foreach (string i in essentialFilePaths)
            {
                CopyFile(Path.GetFileName(i), Path.GetDirectoryName(i), Path.Combine(destination, iniObject.INI_JOB_FOLDER));
                Console.WriteLine(i + " written to " + Path.Combine(destination, iniObject.INI_JOB_FOLDER));
            }
            foreach (string i in checkedFilesToCopy)
            {
                try
                {
                    foreach (EclipseObject obj in WAV_LIST)
                    {
                        if (obj.FILE_NAME.Contains(i))
                        {
                            Console.WriteLine("jobFile in Copystring: " + obj.FILE_NAME + " \\ + checked file=" + i);
                            CopyFile(Path.GetFileName(obj.FILE_PATH), Path.GetDirectoryName(obj.FILE_PATH), destination + "\\" + iniObject.INI_JOB_FOLDER);
                            transferProgressBar.PerformStep();
                        }
                    }
                    foreach (EclipseObject obj in ECL_LIST)
                    {
                        if (obj.FILE_NAME.Contains(i))
                        {
                            Console.WriteLine("jobFile in Copystring: " + obj.FILE_NAME + " \\ + checked file=" + i);
                            CopyFile(Path.GetFileName(obj.FILE_PATH), Path.GetDirectoryName(obj.FILE_PATH), destination + "\\" + iniObject.INI_JOB_FOLDER);
                            transferProgressBar.PerformStep();
                        }
                    }
                    foreach (EclipseObject obj in NOT_LIST)
                    {
                        if (obj.FILE_NAME.Contains(i))
                        {
                            Console.WriteLine("jobFile in Copystring: " + obj.FILE_NAME + " \\ + checked file=" + i);
                            CopyFile(Path.GetFileName(obj.FILE_PATH), Path.GetDirectoryName(obj.FILE_PATH), destination + "\\" + iniObject.INI_JOB_FOLDER);
                            transferProgressBar.PerformStep();
                        }
                    }
                    foreach (EclipseObject obj in DIX_LIST)
                    {
                        if (obj.FILE_NAME.Contains(i))
                        {
                            Console.WriteLine("jobFile in Copystring: " + obj.FILE_NAME + " \\ + checked file=" + i);
                            CopyFile(Path.GetFileName(obj.FILE_PATH), Path.GetDirectoryName(obj.FILE_PATH), destination + "\\" + iniObject.INI_JOB_FOLDER);
                            transferProgressBar.PerformStep();
                        }
                    }
                    Console.WriteLine("Trying to copy checked files..");
                }
                catch (IOException)
                {
                    MessageBox.Show("File not found: " + i, "File Not Found Error", MessageBoxButtons.OK);
                }
            }
            transferProgressBar.Value = transferProgressBar.Maximum;
            return true;
        }
        
        //Here's the method that will take w/e user we give it, in the form of an EclipseObject,
        //and will then proceed to rewrite the ini data to new ini, create a set file from same data,
        //then use the reference for the main dictionary and copy that file over, and then it will
        //get the esp, esd, then it will take whatever blocks folder is available and copy that as
        //well.
        //This method takes ALL user files and dumps to destination. Looking to add progress bar
        //to this in NumeratedDirectoryCopy method to replace this.
        public void BackupAllEclipseFiles(EclipseObject userIniObject, string destination)
        {
            try
            {
                transferProgressBar.Value = 0;
                var JobPathFileDirectory = Directory.GetFiles(userIniObject.INI_JOB_PATH, "*", SearchOption.AllDirectories);
                var JobPathFileDirectoryTopLevel = Directory.GetFiles(userIniObject.INI_JOB_PATH, "*", SearchOption.TopDirectoryOnly);
                var JobPathFolders = Directory.GetDirectories(userIniObject.INI_JOB_PATH);
                WriteINIBackup(destination + "\\" + userIniObject.FILE_NAME, userIniObject.INI_INFO_ARRAY);
                //writeINIbackup(Path.Combine(destination, userIniObject.INI_JOB_FOLDER), userIniObject.INI_INFO_ARRAY);
                transferProgressBar.PerformStep();
                /*string[] filePathArray = new string[] { userIniObject.INI_MAIN_DICTIONARY, userIniObject.INI_JOB_PATH, userIniObject.INI_SPELL_DIX, userIniObject.INI_BLOCK_PATH };
                foreach (string i in filePathArray)
                {
                    copyFile(i, userIniObject.INI_JOB_PATH, destination);
                }*/
                foreach (string dirPath in JobPathFolders)
                {
                    Directory.CreateDirectory(Path.Combine(destination, dirPath));
                    foreach (string file in Directory.GetFiles(dirPath))
                    {
                        //this copies the file as the file name, the path, and then uses a snippet to get just the folder name of the original file and use tha as the destination folder..
                        CopyFile(Path.GetFileName(file), Path.GetDirectoryName(file), Path.Combine(destination, userIniObject.INI_JOB_FOLDER, (dirPath.Replace(Path.GetDirectoryName(dirPath) + Path.DirectorySeparatorChar, ""))));
                        transferProgressBar.PerformStep();
                    }
                }

                foreach (string i in JobPathFileDirectoryTopLevel)
                    try
                    {
                        CopyFile(Path.GetFileName(i), Path.GetDirectoryName(i), destination + "\\" + userIniObject.INI_JOB_FOLDER);
                        //copyFile(i, userIniObject.INI_JOB_PATH, destination + "\\" + userIniObject.INI_JOB_FOLDER);
                        transferProgressBar.PerformStep();
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("File not found: " + i, "File Not Found Error", MessageBoxButtons.OK);
                    }
                //DirectoryCopy(userIniObject.INI_JOB_PATH, destination, true);
                MessageBox.Show("Full Backup complete", "Full Backup Complete", MessageBoxButtons.OK);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e);
                MessageBox.Show("Error: Files were not found / IO Error - Files may have been removed", "File Not Found Error", MessageBoxButtons.OK);
            }
        }

        public void BackupEssentialEclipseFiles(EclipseObject userIniObject, string destination)
        {
            transferProgressBar.Value = 0;
            transferProgressBar.Maximum = 0;
            ///Here we use the checkmarkedJobsToCopy method to produce a list of whatever
            ///is currently checked in the file list
            List<string> checkedFilesToCopy = checkmarkedJobsToCopy();
            foreach (string i in checkedFilesToCopy)
            {
                Console.WriteLine("checkedFilesToCopy: " + i);
            }
            ///We add size to progress bar so later on as we copy these files we will increment
            ///the progressbar
            transferProgressBar.Maximum += checkedFilesToCopy.Count;
            ///Here we give the idea of the essential files main dix and spell dix paths to copy and add to progress bar
            string[] filePathArray = new string[] { userIniObject.INI_MAIN_DICTIONARY_PATH};
            WriteINIBackup(destination + "\\" + userIniObject.FILE_NAME, userIniObject.INI_INFO_ARRAY);
            transferProgressBar.PerformStep();
            Directory.CreateDirectory(Path.Combine(destination, userIniObject.INI_JOB_FOLDER)); 
            foreach (string i in filePathArray)
            {
                try
                {
                    CopyFile(Path.GetFileName(i), Path.GetDirectoryName(i), Path.Combine(destination, userIniObject.INI_JOB_FOLDER));
                    transferProgressBar.PerformStep();
                }
                catch (IOException)
                {
                    MessageBox.Show("File not found: " + i, "File Not Found Error", MessageBoxButtons.OK);
                }
            }

            if (userIniObject.INI_BLOCK_PATH != null)
            { 
                try
                {
                    foreach (string dirPath in Directory.GetDirectories(userIniObject.INI_JOB_PATH))
                    {
                        if (dirPath == userIniObject.INI_BLOCK_PATH)
                        {
                            string dirPathFolderName = dirPath.Replace(Path.GetDirectoryName(dirPath) + Path.DirectorySeparatorChar, "");
                            //Directory.CreateDirectory(Path.Combine(destination, dirPathFolderName));
                            foreach (string file in Directory.GetFiles(dirPath))
                            {
                                CopyFile(Path.GetFileName(file), Path.GetDirectoryName(file), Path.Combine(destination, userIniObject.INI_JOB_FOLDER, dirPathFolderName));
                                transferProgressBar.PerformStep();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Note: Blocks folder was not detected", "Note", MessageBoxButtons.OK);
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error writing block - " + e);
                }
            }

            foreach (string i in checkedFilesToCopy)
            {
                try
                {
                    foreach (EclipseObject obj in WAV_LIST)
                    {
                        if (obj.FILE_NAME.Contains(i))
                        {
                            Console.WriteLine("jobFile in Copystring: " + obj.FILE_NAME + " \\ + checked file=" + i);
                            CopyFile(Path.GetFileName(obj.FILE_PATH), Path.GetDirectoryName(obj.FILE_PATH), destination + "\\" + userIniObject.INI_JOB_FOLDER);
                            transferProgressBar.PerformStep();
                        }
                    }
                    foreach (EclipseObject obj in ECL_LIST)
                    {
                        if (obj.FILE_NAME.Contains(i))
                        {
                            Console.WriteLine("jobFile in Copystring: " + obj.FILE_NAME + " \\ + checked file=" + i);
                            CopyFile(Path.GetFileName(obj.FILE_PATH), Path.GetDirectoryName(obj.FILE_PATH), destination + "\\" + userIniObject.INI_JOB_FOLDER);
                            transferProgressBar.PerformStep();
                        }
                    }
                    foreach (EclipseObject obj in NOT_LIST)
                    {
                        if (obj.FILE_NAME.Contains(i))
                        {
                            Console.WriteLine("jobFile in Copystring: " + obj.FILE_NAME + " \\ + checked file=" + i);
                            CopyFile(Path.GetFileName(obj.FILE_PATH), Path.GetDirectoryName(obj.FILE_PATH), destination + "\\" + userIniObject.INI_JOB_FOLDER);
                            transferProgressBar.PerformStep();
                        }
                    }
                    foreach (EclipseObject obj in DIX_LIST)
                    {
                        if (obj.FILE_NAME.Contains(i))
                        {
                            Console.WriteLine("jobFile in Copystring: " + obj.FILE_NAME + " \\ + checked file=" + i);
                            CopyFile(Path.GetFileName(obj.FILE_PATH), Path.GetDirectoryName(obj.FILE_PATH), destination + "\\" + userIniObject.INI_JOB_FOLDER);
                            transferProgressBar.PerformStep();
                        }
                    }
                    Console.WriteLine("Trying to copy checked files..");
                }
                catch (IOException)
                {
                    MessageBox.Show("File not found: " + i, "File Not Found Error", MessageBoxButtons.OK);
                }
            }
                transferProgressBar.Value = transferProgressBar.Maximum;
                MessageBox.Show("Essential Backup complete", "Essential Backup Complete", MessageBoxButtons.OK);
        }

        public void CopyFile(string sFile, string sLocation, string sDestLocation)
        {
            string fileName = sFile;
            string sourcePath = sLocation;
            string targetPath = sDestLocation;

            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            try
            {
                System.IO.File.Copy(sourceFile, destFile, true);
            }
            catch (System.UnauthorizedAccessException)
            {
                Console.WriteLine("Problem copying: Access Denied when copying:  " + sFile + " to: " + targetPath,
                                "Problem Copying",
                                MessageBoxButtons.OK);
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("Looks like " + sFile + "at: " + sLocation + " " + " is in use by another program.");
            }
        }

        //Here's a method we give a source directory, a destination directory, and true/false to also
        //copy the sub directories
        private static void CopyDirectory(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            try
            {
                DirectoryInfo[] dirs = dir.GetDirectories();


                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Source directory does not exist or could not be found: "
                        + sourceDirName);
                }

                // If the destination directory doesn't exist, create it. 
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
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
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        CopyDirectory(subdir.FullName, temppath, copySubDirs);
                    }
                }
            }

            catch (IOException e)
            {
                Console.WriteLine(e);
            }

        }

        //Here's the method that takes a destination, and a string[] that is assuming it is a
        //text file that we did a ReadAllLines or something like that on so that we have a 
        //string[]. Then it will create the .ini and the .set on the destination
        public void WriteINIBackup(string destination, string[] iniLinesArray)
        {
            try
            {
                System.IO.File.WriteAllLines(destination, iniLinesArray);
                System.IO.File.WriteAllLines(destination.TrimEnd(".ini".ToCharArray()) + ".set", iniLinesArray);
            }
            catch (System.IO.IOException)
            {
                Console.Write("Error");
            }
            catch (System.UnauthorizedAccessException)
            {
                MessageBox.Show("Unauthorized Access Exception - Access Denied");
            }
        }
        
        public List<String> checkmarkedJobsToCopy()
        {
            List<string> fileList = new List<string>();
            foreach (string i in availableJobsCheckedListBox1.CheckedItems)
            {
                fileList.Add(i);
            }
            return fileList;
        }

        public void setupJobCheckListBox()
        {
            foreach (EclipseObject obj in ECL_LIST)
            {
                //if (Path.GetDirectoryName(obj.FILE_PATH) == )
                availableJobsCheckedListBox1.Items.Add(obj.FILE_NAME.TrimEnd(".ecl".ToCharArray()));

            }
        }

        public void WritePathDataToEclipseCollections(string f)
        {
            if (f.Contains(".esp"))
            {
                EclipseObject obj = new EclipseObject(Path.GetFileName(f), ".ESP", f);
                ESP_LIST.Add(obj);
                Console.WriteLine("File added: " + Path.GetFileName(f));
            }
            else if (f.Contains(".esd"))
            {
                EclipseObject obj = new EclipseObject(Path.GetFileName(f), ".ESD", f);
                ESD_LIST.Add(obj);
                Console.WriteLine("File added: " + Path.GetFileName(f));
            }
            else if (f.Contains(".not"))
            {
                EclipseObject obj = new EclipseObject(Path.GetFileName(f), ".NOT", f);
                NOT_LIST.Add(obj);
                Console.WriteLine("File added: " + Path.GetFileName(f));
            }
            else if (f.Contains(".ini"))
            {
                EclipseObject obj = new EclipseObject(Path.GetFileName(f), ".INI", f);
                INI_LIST.Add(obj);
                Console.WriteLine("File added: " + Path.GetFileName(f));

            }
            else if (f.Contains(".dix"))
            {
                EclipseObject obj = new EclipseObject(Path.GetFileName(f), ".DIX", f);
                DIX_LIST.Add(obj);
                Console.WriteLine("File added: " + Path.GetFileName(f));
            }
            else if (f.Contains(".ecl"))
            {
                EclipseObject obj = new EclipseObject(Path.GetFileName(f), ".ECL", f);
                ECL_LIST.Add(obj);
                Console.WriteLine("File added: " + Path.GetFileName(f));
            }
            else if (f.EndsWith(".wav"))
            {
                EclipseObject obj = new EclipseObject(Path.GetFileName(f), ".WAV", f);
                WAV_LIST.Add(obj);
                Console.WriteLine("File added: " + Path.GetFileName(f));
            }
        }

        public void ClearAllCollections()
        {
            currentUsersDropdown.Text = "";
            currentUsersDropdown.DataSource = null;
            availableJobsCheckedListBox1.Items.Clear();
            //ECL_OBJ_MAP.Clear();
            INI_LIST.Clear();
            DIX_LIST.Clear();
            ECL_LIST.Clear();
            NOT_LIST.Clear();
            WAV_LIST.Clear();
        }

        private void BackupEclipseUserButton_Click(object sender, EventArgs e)
        {
            loadingText.Visible = true;

            if (LoadEclipseFilesFromPath(CURRENT_MAINDIRECTORY5))
            {
                LoadDataSource(INI_LIST);
                setupJobCheckListBox();
                backupPanel.Visible = true;
                restorePanel.Visible = false;
                chooseUserPanel.Visible = true;
                loadingText.Visible = false;
            }

        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.destinationText.Text = "";
                this.destinationText.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void transferToComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            destinationText.Text = "";
            destinationText.Text = (transferToQuickPickComboBox.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            transferToQuickPickComboBox.Items.Clear();
            DriveInfo[] files = DriveInfo.GetDrives();
            foreach (DriveInfo d in files)
            {
                transferToQuickPickComboBox.Items.Add(String.Format(d.Name));
                //freeSpaceLabel.Text = (d.AvailableFreeSpace / 1000000000 + "gb free");
            }
        }

        private void BackupEssentialFilesOnlyButton_Click(object sender, EventArgs e)
        {
            if (currentUsersDropdown.Text == "")
            {
                MessageBox.Show("Choose User to Backup from Drop Down Menu", "Choose User to Backup", MessageBoxButtons.OK);

            }
            else if (destinationText.Text == "")
            {
                MessageBox.Show("Set Destination either by browse or quick pick from the dropdown for drive select", "Set Destination", MessageBoxButtons.OK);

            }
            else
            {
                string findString = currentUsersDropdown.Text.ToString();
                bool done = false;
                foreach (EclipseObject obj in INI_LIST)
                {
                    if (obj.FILE_NAME.Equals(findString) && done == false)
                    {
                        BackupEssentialEclipseFiles(obj, destinationText.Text);
                        done = true;
                    }
                    else
                    {
                        //MessageBox.Show("Backup did not succeed", "Backup did not succeed", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void RestoreEclipseUserButton_Click(object sender, EventArgs e)
        {
            transferProgressBar.Visible = true;           
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                loadingText.Visible = true;

                //treeView1.Nodes.Add(folderBrowserDialog1.SelectedPath);
                if (LoadEclipseFilesFromPath(folderBrowserDialog1.SelectedPath))
                {
                    LoadDataSource(INI_LIST);
                    restorePanel.Visible = true;
                    backupPanel.Visible = false;
                    chooseUserPanel.Visible = true;
                    loadingText.Visible = false;
                }
                else
                {
                    loadingText.Text = "Load failed";
                }
            }
        }

        private void RestoreAllFilesButton_Click(object sender, EventArgs e)
        {
            //ReWriteMainEclipseINI(currentUsersDropdown.Text);
            string findString = currentUsersDropdown.Text.ToString();
            foreach (EclipseObject obj in INI_LIST)
            {
                if (obj.FILE_NAME.Equals(findString))
                {
                    RestoreAllEclipseFiles(obj);
                    MessageBox.Show("Files Restored");
                }

                else
                {
                    MessageBox.Show("User not found. Restoration not successful", "User Not Found", MessageBoxButtons.OK);

                }
            }



        }

        private void BackupAllFilesButton_Click(object sender, EventArgs e)
        {
            if (currentUsersDropdown.Text == "")
            {
                MessageBox.Show("Choose User to Backup from Drop Down Menu", "Choose User to Backup", MessageBoxButtons.OK);

            }
            else if (destinationText.Text == "")
            {
                MessageBox.Show("Set Destination either by browse or quick pick from the dropdown for drive select", "Set Destination", MessageBoxButtons.OK);

            }
            else
            {
                string findString = currentUsersDropdown.Text.ToString();
                bool done = false;
                EclipseObject transferObject = new EclipseObject("null","null","null");
                foreach (EclipseObject obj in INI_LIST)
                {
                    if (obj.FILE_NAME.Equals(findString) && done == false)
                    {
                        transferObject = obj;
                        done = true;

                    }
                    else
                    {
                        //MessageBox.Show("Backup did not succeed", "Backup did not succeed", MessageBoxButtons.OK);
                    }

                    /*if (backgroundWorker1.IsBusy != true)
                    {
                        // Start the asynchronous operation.
                        backgroundWorker1.RunWorkerAsync();
                        transferProgressLabel.Visible = true;
                        cancelButton.Visible = true;    
                    }*/
                }
                if (transferObject.FILE_NAME != "null")
                {
                    BackupAllEclipseFiles(transferObject, destinationText.Text);

                }
                else
                {
                    MessageBox.Show("Full backup failed, user object was invalid", "Fail", MessageBoxButtons.OK);
                }
            }
        }       

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }

        private void RestoreEssentialFilesOnlyButton_Click(object sender, EventArgs e)
        {
            foreach (EclipseObject obj in INI_LIST)
            {
                if (Path.GetFileName(obj.FILE_PATH) == currentUsersDropdown.Text)
                {
                    if (RestoreEssentialEclipseFiles(obj))
                    {
                        MessageBox.Show("Essential Files Restored", "Essential Files Restored", MessageBoxButtons.OK);
                    }
                }
            }
            
            /*if (RestoreAllEclipseFilesToLocalPC(INI_LIST.Find(s(currentUsersDropdown.Text])){
                MessageBox.Show("Backup Complete", "Backup Complete", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Backup Fail", "Backup Fail", MessageBoxButtons.OK);
            
            }*/
        }

        private void transferProgressBar_Click(object sender, EventArgs e)
        {

        }

        private void currentUsersDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SELECTED_USER_INI = currentUsersDropdown.Text;
        }

        private void BrowseForEclipseUserFolderButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                loadingText.Visible = true;

                if (LoadEclipseFilesFromPath(folderBrowserDialog1.SelectedPath))
                {
                    LoadDataSource(INI_LIST);
                    backupPanel.Visible = true;
                    restorePanel.Visible = false;
                    chooseUserPanel.Visible = true;
                    loadingText.Visible = false;
                }
                else
                {
                    loadingText.Text = "Load failed";
                }
            }
        }
    }
}

