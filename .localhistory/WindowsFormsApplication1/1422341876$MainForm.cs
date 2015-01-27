using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form

        ////TODO : Make a sort of INI maintenance, try to figure out bad values, or recreate
    ///from say a scratch ini, replace just the key values... could potentially be a way
    ///to help and avoid having to manually do UserFIle5= blank and redo wizard, instead
    ///we could have preloaded default set w/ your values plugged in and there we go back up
    ///
    {
        //The variables here are used for referencing the system, the various ini parsings that take
        //place and corresponding paths
        public string CURRENT_SYSTEM_MAIN_DRIVE = Path.GetPathRoot(Environment.SystemDirectory);
        public string CURRENT_USERFILE5;
        public string CURRENT_MAINDIRECTORY5;
        public static string USER_ECLIPSE_FOLDER;
        public string SELECTED_USER_INI;
        public string SELECTED_USER_JOB_FOLDER;
        public string SELECTED_USER_MAIN_DICTIONARY;
        public string USERFILE5_LINE;
        public string USER_DOCUMENTS_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        //These lists and dictionaries are for referencing the objects that are browsed to
        //or scanned for, and ultimately in each scenario the user is requesting to look
        //at a directory for either backing up or restoring the eclipse related files
        //in that directory.
        public List<EclipseObject> FILE_MAP = new List<EclipseObject>();
        public List<EclipseObject> INI_LIST = new List<EclipseObject>();
        public List<EclipseObject> ECL_LIST = new List<EclipseObject>();
        public List<EclipseObject> NOT_LIST = new List<EclipseObject>();
        public List<EclipseObject> DIX_LIST = new List<EclipseObject>();

        //Need to straighten out whether or not these collections FILE_LOCATION_MAP and 
        //ECL_OBJ_MAP are actually needed right now.
        //Was possibly having issues with referencing from the list, but can probably do away
        //with these at some point.
        public Dictionary<EclipseObject, string> FILE_LOCATION_MAP = new Dictionary<EclipseObject, string>();
        public Dictionary<string, EclipseObject> ECL_OBJ_MAP = new Dictionary<string, EclipseObject>();
        public Dictionary<string, string> ECLIPSE_MAIN_INI_ARRAY = new Dictionary<string, string>();

        //These counters and node array are for the diagnostic node treeView1 that is not seen
        //in the release
        public TreeNode[] fileNodeArray;
        public int FILE_COUNTER = 0;
        public Dictionary<String, TreeNode> fileNodeList = new Dictionary<String, TreeNode>();



        public Form1()
        {
            InitializeComponent();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

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
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ECLIPSE_MAIN_INI_ARRAY = parseMainEclipseIniToDictionary();
            //CURRENT_MAINDIRECTORY5 = ECLIPSE_MAIN_INI_ARRAY;
            string mainDir5 = ECLIPSE_MAIN_INI_ARRAY["MainDirectory5"];
            string userFile5 = ECLIPSE_MAIN_INI_ARRAY["UserFile5"];
            USERFILE5_LINE = userFile5;
            eclipseiniInfoListBox.Items.Add(USERFILE5_LINE);
            string USER_ECLIPSE_FOLDER_COMPARE = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Eclipse";
            USER_ECLIPSE_FOLDER = mainDir5.Replace("{DOC}", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\"));
            CURRENT_MAINDIRECTORY5 = USER_ECLIPSE_FOLDER;

            DriveInfo[] files = DriveInfo.GetDrives();
            foreach (DriveInfo d in files)
            {
                transferToQuickPickComboBox.Items.Add(String.Format(d.Name));
                // can convert to GB free: (decided to take this out)
                //freeSpaceLabel.Text = (d.AvailableFreeSpace / 1000000000 + "gb free");
            }

        }

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
            public string INI_JOB_PATH;
            public string INI_JOB_FOLDER;
            public string INI_MAIN_DICTIONARY;
            public string INI_BLOCK_PATH;
            public string INI_BLOCK_FOLDER;
            public string[] INI_BLOCK_ARRAY;
            public string INI_SPELL_DIX;
            public string[] INI_INFO_ARRAY;
            public Dictionary<string, string> INI_INFO = new Dictionary<string, string>();
            public char[] splitArray = new char[] { '\\' };

            public EclipseObject(string name, string type, string path)
            {
                this.FILE_NAME = name; //this is going to be a string ref. to the file, may be the same as path ultimately since that would force it to be unique
                this.FILE_TYPE = type; //is going to be ".INI", ".ECL", ".NOT", ".DIX", ".ESP", ".ESD" this is passed in as a literal string
                this.FILE_PATH = path; //should be the objects path i.e.: C:\Users\Docs\Eclipse\Tyler\job1.ecl
                this.FILE_USER_FOLDER = Path.GetDirectoryName(FILE_PATH);//trims off the actual file name to reveal the folder
                if (type == ".INI")//if the file is an INI when we create we give it all these characteristics:
                {
                    this.INI_INFO_ARRAY = File.ReadAllLines(this.FILE_PATH);
                    this.INI_INFO = ParseUserIni(this.INI_INFO_ARRAY);

                    if (INI_INFO.ContainsKey("JobPath"))
                    {
                        this.INI_JOB_PATH = INI_INFO["JobPath"];
                    }
                    else
                    {
                        this.INI_JOB_PATH = "No job path found";
                    }

                    string[] JOB_PATH_ARRAY = INI_JOB_PATH.Split('\\');
                    this.INI_JOB_FOLDER = JOB_PATH_ARRAY.Last();
                    this.INI_MAIN_DICTIONARY = INI_INFO["MainDictionary"];

                    if (INI_INFO.ContainsKey("BlockPath"))
                    {
                        this.INI_BLOCK_PATH = INI_INFO["BlockPath"];
                        this.INI_BLOCK_ARRAY = this.INI_BLOCK_PATH.Split(splitArray);
                        this.INI_BLOCK_FOLDER = INI_BLOCK_ARRAY.Last();
                    }
                    else
                    {
                        this.INI_BLOCK_PATH = this.INI_JOB_PATH;
                    }

                    this.INI_SPELL_DIX = INI_INFO["SpellDictionary"];
                    //this.INI_JOB_PATH = parseJobFolderFromIni(path) ;
                }
            }
        }

        //The ReWriteMainEclipseINI method was intended to change the
        //"UserFile5=" line automatically in the Eclipse.ini.
        //This was pretty much abandoned, as I realized that it makes more sense
        //to have Eclipse load once, setup ini, possibly make changes to job 
        //paths, etc., then we can use utility to restore, and theoretically
        //we are in good shape at that point... but this was cool and possibly
        // useful method to parse and rewrite the Eclipse.ini
        public void ReWriteMainEclipseINI(string newUserFile5Value, Dictionary<string, string> ini_parsed_dictionary)
        {   //This method takes a new string to use as a new UserFile5 Value, and a dictionary object that
            //is presumably the eclipse.ini.ReadAllLines and then using a delimiting filter with the delimiter
            //an '=', you can split the resulting string array from the ReadAllLines and get Key/Value pairs
            //for a dictionary. This method ReWriteMainEclipseINI is meant to parse that info back into the 
            //ini file and actually wind up writing the Eclipse.ini
            //WARNING: Backup your Eclipse.ini.... :)

            ECLIPSE_MAIN_INI_ARRAY["UserFile5"] = newUserFile5Value;
            List<string> newEclipseINI = new List<string>();

            //at this point we assume the eclipse_main_ini or w/e ini file has been parsed to a 
            //dictionary that we can recombine back into a List, and then write
            //that list out line by line back into eclipse.ini, theoretically
            foreach (KeyValuePair<string, string> val1 in ini_parsed_dictionary)
            {
                string rewrittenLine = val1.Key + "=" + val1.Value;
                newEclipseINI.Add(rewrittenLine);

            }
            try
            {
                System.IO.File.WriteAllLines(Path.GetPathRoot(Environment.SystemDirectory) + "\\Windows\\eclipse.ini", newEclipseINI);
            }
            catch (System.IO.IOException)
            {
                Console.Write("Issue with write ECLIPSE.INI");
            }
        }

        //Here's the method that parses out the eclipse.ini to a dictionary
        //for reference. 
        //to take the C:\Windows\Eclipse.ini and parse it out for basic info
        //about the system. We are assuming the user has Total Eclipse installed and has
        //actually ran it on this system.
        public Dictionary<string, string> parseMainEclipseIniToDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string currentWindowsFolderEclipseIniLocation = Path.GetPathRoot(Environment.SystemDirectory) + "\\Windows\\eclipse.ini";
            string[] result = File.ReadAllLines(currentWindowsFolderEclipseIniLocation);
            string oneLineIniLines = "";

            foreach (String iniLine in result)
            {
                try
                {

                    if (iniLine.Contains('='))
                    {
                        var parts = iniLine.Split('=');
                        dictionary.Add(parts[0], parts[1]);
                    }
                    else
                    {
                        oneLineIniLines += "\\\\" + iniLine;
                    }
                }
                catch (IndexOutOfRangeException)
                {

                }
                catch (System.ArgumentException)
                {

                }
            }
            dictionary.Add("OneLineINILines", oneLineIniLines);
            return dictionary;
        }

        //Here's method to restore files back to local pc, which is based on the
        //info we get from eclipse.ini, MainDirectory5= line
        public bool RestoreEclipseFilesToLocalPC(EclipseObject iniObject)
        {
            transferProgressBar.Value = Directory.GetFiles(Path.GetDirectoryName(iniObject.FILE_PATH), "*", SearchOption.AllDirectories).Length;
            //First use our writeINIBackup to get an ini and a set file created right on the main dir 5 from the eclipse.ini
            writeINIbackup(Path.Combine(CURRENT_MAINDIRECTORY5, iniObject.FILE_NAME), iniObject.INI_INFO_ARRAY);
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
                    copyFile(Path.GetFileName(i), Path.GetDirectoryName(i), destination);
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
                    copyFile(Path.GetFileName(file), Path.GetDirectoryName(file), Path.Combine(destination, iniObject.INI_JOB_FOLDER));
                    transferProgressBar.PerformStep();
                }
            }
            //Now lets do the top level of the backup folder
            foreach (string subdirPath in Directory.GetDirectories(Path.Combine(copyFolder, iniObject.INI_JOB_FOLDER)))
            {
                Console.WriteLine("sub dir in job folder detected: " + subdirPath);
                DirectoryInfo dinfo = new DirectoryInfo(subdirPath);
                string SubfolderName = dinfo.Parent.Name;
                Directory.CreateDirectory(Path.Combine(destination, iniObject.INI_JOB_FOLDER, SubfolderName));
                foreach (string file in Directory.GetFiles(subdirPath))
                {
                    Console.WriteLine("3rd wave - Attempting to copy: " + Path.GetFileName(file) + " / " + Path.GetDirectoryName(file) + " / " + subdirPath);
                    copyFile(Path.GetFileName(file), Path.GetDirectoryName(file), Path.Combine(subdirPath, new FileInfo(file).Directory.Name));
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


        //Here's method to restore JUST ESSENTIAL files back to local pc, which is based on the
        //info we get from eclipse.ini, MainDirectory5= line
        public bool RestoreSelectiveEclipseFilesToLocalPC(EclipseObject iniObject)
        {
            transferProgressBar.Value = 0;
            transferProgressBar.Maximum = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(iniObject.FILE_PATH), iniObject.INI_JOB_FOLDER), "*.*", SearchOption.AllDirectories).Length + 1;
            //First use our writeINIBackup to get an ini and a set file created right on the main dir 5 from the eclipse.ini
            writeINIbackup(CURRENT_MAINDIRECTORY5 + "\\" + iniObject.INI_JOB_FOLDER + ".ini", iniObject.INI_INFO_ARRAY);
            transferProgressBar.PerformStep();
            ///Next we perform a quick assessment of the folder we want to actually copy, so this will be looking at the files
            ///current path for reference, then taking the ini part off the path, and replacing with referencing the job folder name. 
            ///Could maybe be done a better way
            string copyFolder = iniObject.FILE_PATH.TrimEnd(iniObject.FILE_NAME.ToCharArray()) + "\\" + iniObject.INI_JOB_FOLDER;
            //Destination uses the current mainDir5, parsed previously from Eclipse.ini, and of course user folder name
            string destination = CURRENT_MAINDIRECTORY5 + "\\" + iniObject.INI_JOB_FOLDER;
            //Now, we launch the copy procedure.
            
            string[] allTopLevelFiles = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(iniObject.FILE_PATH),iniObject.INI_JOB_FOLDER), "*.*", SearchOption.TopDirectoryOnly);
            string[] eclFiles = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(iniObject.FILE_PATH), iniObject.INI_JOB_FOLDER), "*.ecl", SearchOption.TopDirectoryOnly);
            string[] dixFiles = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(iniObject.FILE_PATH), iniObject.INI_JOB_FOLDER), "*.dix", SearchOption.TopDirectoryOnly);
            string[] spellFiles = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(iniObject.FILE_PATH), iniObject.INI_JOB_FOLDER), "*.es*", SearchOption.TopDirectoryOnly);
            string[] wavFiles = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(iniObject.FILE_PATH), iniObject.INI_JOB_FOLDER), "*.wav", SearchOption.TopDirectoryOnly);
            string[] allBlockFiles = Directory.GetFiles(Path.Combine(iniObject.INI_JOB_FOLDER, Path.GetDirectoryName(iniObject.INI_BLOCK_PATH)), "*.*", SearchOption.TopDirectoryOnly);
            int blockCount = Directory.GetFiles(iniObject.INI_BLOCK_PATH).Length;
            transferProgressBar.Maximum = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(iniObject.FILE_PATH), iniObject.INI_JOB_FOLDER), "*.*", SearchOption.AllDirectories).Length;
            foreach (string i in allTopLevelFiles)
            {
                transferProgressBar.PerformStep();
                copyFile(Path.GetFileName(i), Path.GetDirectoryName(i), destination);
            }
            //DirectoryCopy(copyFolder, destination, true);
            //DirectoryCopy(CurrentINILocation+iniObject.INI_BLOCK_FOLDER, destination + "\\" + iniObject.INI_BLOCK_FOLDER + "\\", true);
            //EclipseObject newIniObject = new EclipseObject("recreated" + iniObject.FILE_NAME, ".INI", iniObject.INI_JOB_PATH);
            //iniObject.INI_JOB_FOLDER = CURRENT_MAINDIRECTORY5 + 

            return true;
        }

        //This method will take w/e path we give it and scan for files, creating
        //the objects in the INI_LIST, ECL_LIST, DIX_LIST, NOT_LIST for later
        //reference.
        public bool loadEclipseFilesFromPath(string path)
        {

            ECL_OBJ_MAP.Clear();
            INI_LIST.Clear();
            DIX_LIST.Clear();
            ECL_LIST.Clear();
            NOT_LIST.Clear();
            string[] parts = path.Split('\\');
            //First this will get the root level of drive n grab any files available
            try
            {
                foreach (string f in Directory.GetFiles(path))
                {
                    parts = f.Split('\\');
                    if (f.Contains(".esp"))
                    {
                        EclipseObject obj = new EclipseObject(Path.GetFileName(f), ".ESP", f);
                        FILE_MAP.Add(obj);
                    }
                    if (f.Contains(".esd"))
                    {
                        EclipseObject obj = new EclipseObject(Path.GetFileName(f), ".ESD", f);
                        FILE_MAP.Add(obj);
                    }
                    else if (f.Contains(".ini"))
                    {
                        EclipseObject obj = new EclipseObject(Path.GetFileName(f), ".INI", f);
                        //ECL_OBJ_MAP.Add(f.Substring(path.Length + 1), obj);
                        
                        INI_LIST.Add(obj);
                    }
                    else if (f.Contains(".dix"))
                    {
                        EclipseObject obj = new EclipseObject(parts.Last(), ".DIX", f);
                        FILE_MAP.Add(obj);
                    }
                    else if (f.Contains(".ecl"))
                    {
                        EclipseObject obj = new EclipseObject(parts.Last(), ".ECL", f);
                        FILE_MAP.Add(obj);
                    }
                }
            }
            catch (System.Exception excpt)
            {
                Console.Write(excpt);
            }
            //Next it's supposed to enumerate the directory and get w/e is in there
            try
            {
                foreach (string d in Directory.GetDirectories(path))
                {
                    foreach (string f in Directory.EnumerateFiles(d))
                    {
                        if (f.Contains(".esp") || f.Contains(".esd"))
                        {
                            EclipseObject obj = new EclipseObject(f.Substring(d.Length + 1), ".ESP", f);
                            FILE_MAP.Add(obj);
                            Console.WriteLine("File added: " + f.Substring(d.Length + 1));
                        }

                        else if (f.Contains(".ini"))
                        {
                            EclipseObject obj = new EclipseObject(f.Substring(d.Length + 1), ".INI", f);
                            //FILE_COUNTER += 1;
                            INI_LIST.Add(obj);
                            Console.WriteLine("File added: " + f.Substring(d.Length + 1));
                        }

                        else if (f.Contains(".dix"))
                        {
                            EclipseObject obj = new EclipseObject(f.Substring(d.Length + 1), ".DIX", f);
                            FILE_MAP.Add(obj);
                            Console.WriteLine("File added: " + f.Substring(d.Length + 1));
                        }
                        else if (f.Contains(".ecl"))
                        {
                            EclipseObject obj = new EclipseObject(f.Substring(d.Length + 1), ".ECL", f);
                            FILE_MAP.Add(obj);
                            Console.WriteLine("File added: " + f.Substring(d.Length + 1));
                        }
                    }
                }
            }
            catch (System.Exception excpt)
            {
                Console.Write(excpt);
                return false;
            }


            foreach (EclipseObject obj in FILE_MAP)
            {
                if (obj.FILE_TYPE == ".INI")
                {
                    INI_LIST.Add(obj);
                    ECL_OBJ_MAP.Add(obj.FILE_NAME, obj);

                }
                if (obj.FILE_TYPE == ".ECL")
                {
                    ECL_LIST.Add(obj);
                }
                if (obj.FILE_TYPE == ".DIX")
                {
                    DIX_LIST.Add(obj);
                }
                if (obj.FILE_TYPE == ".NOT")
                {
                    NOT_LIST.Add(obj);
                }
            }
            return true;
        }
        //This method will use Eclipse.ini info for eclipse folder and scan for files, creating
        //the objects in the INI_LIST, ECL_LIST, DIX_LIST, NOT_LIST for later
        //reference.
        public bool loadEclipseFilesFromLocalDisk()
        {
            ECL_OBJ_MAP.Clear();
            INI_LIST.Clear();
            DIX_LIST.Clear();
            ECL_LIST.Clear();
            NOT_LIST.Clear();

            try
            {
                foreach (string d in Directory.GetDirectories(USER_ECLIPSE_FOLDER))
                {
                    foreach (string f in Directory.EnumerateFiles(d))
                    {
                        if (f.Contains(".esp"))
                        {
                            EclipseObject obj = new EclipseObject(f.Substring(d.Length + 1), ".ESP", f);
                            FILE_MAP.Add(obj);
                        }
                        if (f.Contains(".esd"))
                        {
                            EclipseObject obj = new EclipseObject(f.Substring(d.Length + 1), ".ESD", f);
                            FILE_MAP.Add(obj);
                        }
                        else if (f.Contains(".ini"))
                        {
                            EclipseObject obj = new EclipseObject(f.Substring(d.Length + 1), ".INI", f);
                            FILE_MAP.Add(obj);

                        }
                        else if (f.Contains(".dix"))
                        {
                            EclipseObject obj = new EclipseObject(f.Substring(d.Length + 1), ".DIX", f);
                            FILE_MAP.Add(obj);
                        }
                        else if (f.Contains(".ecl"))
                        {
                            EclipseObject obj = new EclipseObject(f.Substring(d.Length + 1), ".ECL", f);
                            FILE_MAP.Add(obj);
                        }
                    }
                }
            }
            catch (System.Exception excpt)
            {
                Console.Write(excpt);
            }

            try
            {
                foreach (string f in Directory.EnumerateFiles(USER_ECLIPSE_FOLDER))
                {
                    if (f.Contains(".esp"))
                    {
                        EclipseObject obj = new EclipseObject(f.Substring(USER_ECLIPSE_FOLDER.Length), ".ESP", f);
                        FILE_MAP.Add(obj);
                    }
                    if (f.Contains(".esd"))
                    {
                        EclipseObject obj = new EclipseObject(f.Substring(USER_ECLIPSE_FOLDER.Length), ".ESD", f);
                        FILE_MAP.Add(obj);
                    }
                    else if (f.Contains(".ini"))
                    {
                        EclipseObject obj = new EclipseObject(f.Substring(USER_ECLIPSE_FOLDER.Length + 1), ".INI", f);
                        FILE_MAP.Add(obj);

                    }
                    else if (f.Contains(".dix"))
                    {
                        EclipseObject obj = new EclipseObject(f.Substring(USER_ECLIPSE_FOLDER.Length), ".DIX", f);
                        FILE_MAP.Add(obj);
                    }
                    else if (f.Contains(".ecl"))
                    {
                        EclipseObject obj = new EclipseObject(f.Substring(USER_ECLIPSE_FOLDER.Length), ".ECL", f);
                        FILE_MAP.Add(obj);
                    }
                }
            }
            catch (System.Exception excpt)
            {
                Console.Write(excpt);
            }

            foreach (EclipseObject obj in FILE_MAP)
            {
                if (obj.FILE_TYPE == ".INI")
                {
                    INI_LIST.Add(obj);
                    //ECL_OBJ_MAP.Add(obj.FILE_NAME, obj);
                }
                if (obj.FILE_TYPE == ".ECL")
                {
                    ECL_LIST.Add(obj);
                }
                if (obj.FILE_TYPE == ".DIX")
                {
                    DIX_LIST.Add(obj);
                }
                if (obj.FILE_TYPE == ".NOT")
                {
                    NOT_LIST.Add(obj);
                }
            }
            return true;
        }

        //Calls loadEclipseFilesFromLocalDisk, shows us options for backup
        private void loadButton_Click(object sender, EventArgs e)
        {


            ECL_OBJ_MAP.Clear();
            INI_LIST.Clear();
            DIX_LIST.Clear();
            ECL_LIST.Clear();
            NOT_LIST.Clear();
            fileInfoView.Nodes.Clear();
            if (loadEclipseFilesFromLocalDisk())
            {
                unpack();
                LoadDataSource(INI_LIST);
                setupJobCheckListBox();
                backupPanel.Visible = true;
                restorePanel.Visible = false;
                chooseUserPanel.Visible = true;
            }

        }

        public void setupJobCheckListBox()
        {
            foreach (EclipseObject obj in ECL_LIST)
            {
                availableJobsCheckedListBox1.Items.Add(obj.FILE_NAME);

            }
        }


        //This unpack was used to populate the nodeListView, which I was primarily
        //using for diagnostic info. Not really using this in the release version,
        //but didn't want to dump the cool node stuff I had worked on
        public void unpack()
        {
            int count = 0;
            //Goes through and builds top level of node list, using the INI_LIST w/ the EclipseObjects, referencing the Ini_JOB path,
            //and the file name with a - in between. Later on we'll use the INI path to determine the file placement inside the node
            //foreach (KeyValuePair<string, EclipseObject> pair in ECL_OBJ_MAP)
            foreach (EclipseObject obj in INI_LIST)
            {
                //MessageBox.Show(obj.FILE_NAME);
                fileInfoView.Nodes.Add(obj.FILE_NAME + " - " + obj.INI_JOB_PATH);

                fileInfoView.Nodes[count].Nodes.Add("File Name: " + obj.FILE_NAME);

                fileInfoView.Nodes[count].Nodes.Add("Job Path: " + obj.INI_JOB_PATH);
                fileInfoView.Nodes[count].Nodes.Add("Main Dictionary: " + obj.INI_MAIN_DICTIONARY);
                fileInfoView.Nodes[count].Nodes.Add("Blocks Path: " + obj.INI_BLOCK_PATH);
                fileInfoView.Nodes[count].Nodes.Add("Blocks Folder: " + obj.INI_BLOCK_FOLDER);
                fileInfoView.Nodes[count].Nodes.Add("Spell Dictionary: " + obj.INI_SPELL_DIX);
                fileInfoView.Nodes[count].Nodes.Add("INI File Location: " + obj.FILE_PATH);
                //currentUsersDropdown.Items.Add(obj.FILE_NAME);
                count += 1;
            }
        }

        public void clearUserDropdown()
        {
            foreach (EclipseObject obj in INI_LIST)
            {
                currentUsersDropdown.Items.Remove(obj.FILE_NAME);
            }
        }


        //Here's the method that will take w/e user we give it, in the form of an EclipseObject,
        //and will then proceed to rewrite the ini data to new ini, create a set file from same data,
        //then use the reference for the main dictionary and copy that file over, and then it will
        //get the esp, esd, then it will take whatever blocks folder is available and copy that as
        //well.
        public void backupEssentialUserFiles(EclipseObject userIniObject, string destination)
        {
            writeINIbackup(destination + "\\" + userIniObject.FILE_NAME, userIniObject.INI_INFO_ARRAY);
            string[] filePathArray = new string[] { userIniObject.INI_MAIN_DICTIONARY, userIniObject.INI_SPELL_DIX };
            foreach (string i in filePathArray)
                try
                {
                    copyFile(i, userIniObject.INI_JOB_PATH, destination + "\\" + userIniObject.INI_JOB_FOLDER);
                }
                catch (IOException)
                {
                    MessageBox.Show("File not found: " + i, "File Not Found Error", MessageBoxButtons.OK);
                }

            if (userIniObject.INI_BLOCK_PATH != userIniObject.INI_JOB_PATH)
            {
                DirectoryCopy(userIniObject.INI_BLOCK_PATH, destination + "\\" + userIniObject.INI_JOB_FOLDER + "\\" + userIniObject.INI_BLOCK_FOLDER, true);
            }
            else
            {
                MessageBox.Show("Note: Blocks folder was not detected", "Note", MessageBoxButtons.OK);
            }

            MessageBox.Show("Essential Backup complete", "Essential Backup Complete", MessageBoxButtons.OK);


        }
        //This method takes ALL user files and dumps to destination. Looking to add progress bar
        //to this in NumeratedDirectoryCopy method to replace this.
        public void backupAllUserFiles(EclipseObject userIniObject, string destination)
        {
            transferProgressBar.Value = 
                Directory.GetFiles(userIniObject.INI_JOB_PATH, "*", SearchOption.AllDirectories).Length;
            writeINIbackup(destination + "\\" + userIniObject.FILE_NAME, userIniObject.INI_INFO_ARRAY);
            writeINIbackup(Path.Combine(destination, userIniObject.FILE_NAME), userIniObject.INI_INFO_ARRAY);
            transferProgressBar.PerformStep();
            /*string[] filePathArray = new string[] { userIniObject.INI_MAIN_DICTIONARY, userIniObject.INI_JOB_PATH, userIniObject.INI_SPELL_DIX, userIniObject.INI_BLOCK_PATH };
            foreach (string i in filePathArray)
            {
                copyFile(i, userIniObject.INI_JOB_PATH, destination);
            }*/
            foreach (string dirPath in Directory.GetDirectories(userIniObject.INI_JOB_PATH))
            {
                Directory.CreateDirectory(Path.Combine(destination, dirPath));
                foreach (string file in Directory.GetFiles(dirPath))
                {
                    copyFile(Path.GetFileName(file), Path.GetDirectoryName(file), Path.Combine(destination, userIniObject.INI_JOB_FOLDER, userIniObject.INI_BLOCK_FOLDER));
                    transferProgressBar.PerformStep();
                }
            }

            foreach (string i in Directory.GetFiles(userIniObject.INI_JOB_PATH, "*", SearchOption.TopDirectoryOnly))
                try
                {
                    copyFile(Path.GetFileName(i), Path.GetDirectoryName(i) ,destination + "\\" + userIniObject.INI_JOB_FOLDER);
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

        //Here's a method we give a source directory, a destination directory, and true/false to also
        //copy the sub directories
        private static bool NumeratedDirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
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

                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
            return true;

        }


        //Here's a method we give a source directory, a destination directory, and true/false to also
        //copy the sub directories
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
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
                        DirectoryCopy(subdir.FullName, temppath, copySubDirs);
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
        public void writeINIbackup(string destination, string[] iniLinesArray)
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


        //Here's the method we give a source file, the location, and the destination.
        //Yes it's an ugly method, and could definitely be more efficient, but this
        //is getting the job done in one area of the project for now.
        public void copyFile(string sFile, string sLocation, string sDestLocation)
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
                Console.WriteLine("Looks like " + sFile + "at: " + sLocation +" " + " is in use by another program.");
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
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

        //Here's a dictionary method that returns a dictionary from a string[], so we
        //are assuming you have an ini or text file that we do for example a ReadAllLines
        //and we have a string[], so now from that string[] we delimit using '=' to generate
        //key + value for easier reference. Probably a way to improve on this.
        public static Dictionary<string, string> ParseUserIni(string[] iniInfo)
        {
            string[] data = iniInfo;
            //StreamReader reader = ReadAllLines(data);
            //StreamReader reader = File.OpenText(path);
            //string line;
            string result = "";
            string jobPathInterpret = "";
            Dictionary<string, string> results = new Dictionary<string, string>();
            foreach (string line in data)
            {
                string[] items = line.Split('\t');
                string[] removedChars = new string[] { "Path", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "=", "MAIN" };
                char[] delimiter = new char[] { '=' };
                //char[] MainDictionarydelimiter = "=".ToCharArray();
                //int myInteger = int.Parse(items[1]); // here's integer
                //Now here's path:
                foreach (string item in items)
                {
                    if (item.StartsWith("Path") && item.Contains("JOB="))
                    {
                        if (item.Contains("{MAIN}"))
                        {
                            result = line.Replace("{MAIN}", USER_ECLIPSE_FOLDER + "\\");
                            string[] resultArray = result.Split(delimiter);
                            result = resultArray.Last();
                            results.Add("JobPath", result);
                        }
                        else if (item.Contains("DOC"))
                        {
                            result = line.Replace("{DOC}", (Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\"));
                            string[] resultArray = result.Split(delimiter);
                            result = resultArray[2];
                            jobPathInterpret = result;
                            results.Add("JobPath", result);
                        }

                    }
                    if (item.StartsWith("MainDictionary="))
                    {
                        result = line.Replace("{DOC}", (Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\"));
                        string[] resultArray = result.Split(delimiter);
                        result = resultArray[1];

                        results.Add("MainDictionary", result);
                    }
                    if (item.StartsWith("SpellUser="))
                    {
                        result = line.Replace("{DOC}", (Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\"));
                        string[] resultArray = result.Split(delimiter);
                        result = resultArray[1];
                        results.Add("SpellDictionary", result);
                    }
                    if (item.StartsWith("Path") && item.Contains("BLOCK="))
                    {
                        if (item.Contains("{JOB}"))
                        {
                            result = line.Replace("{JOB}", jobPathInterpret + "\\");
                            string[] resultArray = result.Split(delimiter);
                            result = resultArray.Last();
                            results.Add("BlockPath", result);
                        }
                        else if (item.Contains("{MAIN}"))
                        {
                            result = line.Replace("{MAIN}", USER_ECLIPSE_FOLDER + "\\");
                            string[] resultArray = result.Split(delimiter);
                            result = resultArray.Last();
                            results.Add("BlockPath", result);
                        }

                    }

                }

            }
            return results;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            transferToQuickPickComboBox.Items.Clear();
            DriveInfo[] files = DriveInfo.GetDrives();
            foreach (DriveInfo d in files)
            {
                transferToQuickPickComboBox.Items.Add(String.Format(d.Name));
                //freeSpaceLabel.Text = (d.AvailableFreeSpace / 1000000000 + "gb free");
            }
        }


        private void button5_Click(object sender, EventArgs e)
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
                        backupEssentialUserFiles(obj, destinationText.Text);
                        done = true;

                    }
                    else
                    {
                        //MessageBox.Show("Backup did not succeed", "Backup did not succeed", MessageBoxButtons.OK);
                    }
                }
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            transferProgressBar.Visible = true;
            fileInfoView.Nodes.Clear();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                //treeView1.Nodes.Add(folderBrowserDialog1.SelectedPath);
                if (loadEclipseFilesFromPath(folderBrowserDialog1.SelectedPath)) unpack();
                LoadDataSource(INI_LIST);
                restorePanel.Visible = true;
                backupPanel.Visible = false;
                chooseUserPanel.Visible = true;
            }
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            //ReWriteMainEclipseINI(currentUsersDropdown.Text);
            string findString = currentUsersDropdown.Text.ToString();
            foreach (EclipseObject obj in INI_LIST)
            {
                if (obj.FILE_NAME.Equals(findString))
                {
                    RestoreEclipseFilesToLocalPC(obj);
                    MessageBox.Show("Files Restored");
                }

                else
                {
                    MessageBox.Show("User not found. Restoration not successful", "User Not Found", MessageBoxButtons.OK);

                }
            }



        }

        private void button1_Click(object sender, EventArgs e)
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
                    backupAllUserFiles(transferObject, destinationText.Text);

                }
                else
                {
                    MessageBox.Show("Full backup failed, user object was invalid", "Fail", MessageBoxButtons.OK);
                }
            }
        }
        // This event handler is where the time-consuming work is done. 
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string findString = currentUsersDropdown.Text.ToString();
            int count = 0;
            int reportPercentage = 0;
            EclipseObject obj = ECL_OBJ_MAP[findString];
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(obj.INI_JOB_PATH);
            DirectoryInfo[] dirs = dir.GetDirectories();
            count = Convert.ToInt16(Directory.EnumerateFiles(obj.INI_JOB_PATH));
            reportPercentage = 100 / count;

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                        + obj.INI_JOB_PATH);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destinationText.Text))
            {
                Directory.CreateDirectory(destinationText.Text);
            }
            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {

                    string temppath = Path.Combine(destinationText.Text, file.Name);
                    file.CopyTo(temppath, true);
                }
                foreach (DirectoryInfo subdir in dirs)
                {
                    worker.ReportProgress(reportPercentage * 10);
                    string temppath = Path.Combine(destinationText.Text, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, true);
                }
                worker.ReportProgress(reportPercentage * 10);
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            /*if (RestoreAllEclipseFilesToLocalPC(INI_LIST.Find(s(currentUsersDropdown.Text])){
                MessageBox.Show("Backup Complete", "Backup Complete", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Backup Fail", "Backup Fail", MessageBoxButtons.OK);
            
            }*/
        }
    }
}

