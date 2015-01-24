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
    {

        public string CURRENT_SYSTEM_MAIN_DRIVE = Path.GetPathRoot(Environment.SystemDirectory);
        public string CURRENT_USERFILE5;
        public string CURRENT_MAINDIRECTORY5;
        public static string USER_ECLIPSE_FOLDER;
        public string SELECTED_USER_INI;
        public string SELECTED_USER_JOB_FOLDER;
        public string SELECTED_USER_MAIN_DICTIONARY;
        public string USERFILE5_LINE;
        public string USER_DOCUMENTS_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public List<EclipseObject> FILE_MAP = new List<EclipseObject>();
        public List<EclipseObject> INI_LIST = new List<EclipseObject>();
        public List<EclipseObject> ECL_LIST = new List<EclipseObject>();
        public List<EclipseObject> NOT_LIST = new List<EclipseObject>();
        public List<EclipseObject> DIX_LIST = new List<EclipseObject>();
        //public List<string> results = new List<string>();

        public Dictionary<String, TreeNode> fileNodeList = new Dictionary<String, TreeNode>();
        public Dictionary<string, string> ECLIPSE_MAIN_INI_ARRAY = new Dictionary<string, string>();
        public Dictionary<EclipseObject, string> FILE_LOCATION_MAP = new Dictionary<EclipseObject, string>();
        public Dictionary<string, EclipseObject> ECL_OBJ_MAP = new Dictionary<string, EclipseObject>();

        public TreeNode[] fileNodeArray;
        public int FILE_COUNTER = 0;

        public Form1()
        {
            InitializeComponent();            
        }

        public void ReWriteMainEclipseINI(string newUserFile5Value)
        {
            ECLIPSE_MAIN_INI_ARRAY["UserFile5"] = newUserFile5Value;
            List<string> newEclipseINI = new List<string>();
            
            foreach (KeyValuePair<string, string> val1 in ECLIPSE_MAIN_INI_ARRAY){
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

        private void Form1_Load(object sender, EventArgs e)
        {
            ECLIPSE_MAIN_INI_ARRAY = parseMainEclipseIniToDictionary();
            //CURRENT_MAINDIRECTORY5 = ECLIPSE_MAIN_INI_ARRAY;
            string mainDir5 = ECLIPSE_MAIN_INI_ARRAY["MainDirectory5"];
            string userFile5 = ECLIPSE_MAIN_INI_ARRAY["UserFile5"];
            USERFILE5_LINE = userFile5;
            eclipseiniListBox.Items.Add(USERFILE5_LINE);
            string USER_ECLIPSE_FOLDER_COMPARE = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Eclipse";
            USER_ECLIPSE_FOLDER = mainDir5.Replace("{DOC}", Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\"));
            
            CURRENT_MAINDIRECTORY5 = USER_ECLIPSE_FOLDER;
            transferToComboBox.Items.Add(USER_ECLIPSE_FOLDER);
            transferToComboBox.Items.Add(USER_ECLIPSE_FOLDER_COMPARE);

            /*if (loadEclipseFilesFromPath(USER_ECLIPSE_FOLDER)) {
                unpack();            
            }*/

            DriveInfo[] files = DriveInfo.GetDrives();
            foreach (DriveInfo d in files)
            {
                transferToComboBox.Items.Add(String.Format(d.Name));
                // can convert to GB free: (decided to take this out)
                //freeSpaceLabel.Text = (d.AvailableFreeSpace / 1000000000 + "gb free");
            }
        }

        public bool RestoreEclipseFilesToLocalPC(EclipseObject iniObject)
        {
            writeINIbackup(CURRENT_MAINDIRECTORY5 + "\\" + iniObject.INI_JOB_FOLDER+".ini", iniObject.INI_INFO_ARRAY);
            string[] filePathArray = new string[] {  };
            string destination = CURRENT_MAINDIRECTORY5 + "\\" + iniObject.INI_JOB_FOLDER;
            foreach (EclipseObject i in FILE_MAP)
            {
                copyFile(i.FILE_PATH, iniObject.FILE_PATH, destination);
            }
            DirectoryCopy(iniObject.INI_BLOCK_PATH, destination + "\\" + iniObject.INI_BLOCK_FOLDER + "\\", true);

            //EclipseObject newIniObject = new EclipseObject("recreated" + iniObject.FILE_NAME, ".INI", iniObject.INI_JOB_PATH);
            //iniObject.INI_JOB_FOLDER = CURRENT_MAINDIRECTORY5 + 

            return true;
        }

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
                        EclipseObject obj = new EclipseObject(parts.Last(), ".ESP", f);
                        FILE_MAP.Add(obj);
                    }
                    if (f.Contains(".esd"))
                    {
                        EclipseObject obj = new EclipseObject(parts.Last(), ".ESD", f);
                        FILE_MAP.Add(obj);
                    }
                    else if (f.Contains(".ini"))
                    {
                        EclipseObject obj = new EclipseObject(parts.Last(), ".INI", f);
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
                    try
                    {
                        ECL_OBJ_MAP.Add(obj.FILE_NAME, obj);
                    }
                    //catch {
                    catch
                    {

                    }
                    

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
                            EclipseObject obj = new EclipseObject(f.Substring(USER_ECLIPSE_FOLDER.Length+1), ".INI", f);
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

            
            /*try
            {
                foreach (string d in Directory.GetDirectories(USER_DOCUMENTS_PATH))
                {
                    foreach (string f in Directory.EnumerateFiles(d))
                    {
                        if (f.Contains(".esp") || f.Contains(".esd"))
                        {
                            EclipseObject obj = new EclipseObject(f.Substring(d.Length + 1), ".ESP", f);
                            FILE_MAP.Add(obj);
                        }

                        else if (f.Contains(".ini"))
                        {
                            EclipseObject obj = new EclipseObject(f.Substring(d.Length + 1), ".INI", f);
                            FILE_COUNTER += 1;
                            INI_LIST.Add(obj);
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
            }*/

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

        private void loadButton_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            if (loadEclipseFilesFromLocalDisk())
            {
                unpack();
            }

        }

        public void unpack()
        {
            int count = 0;
            //Goes through and builds top level of node list, using the INI_LIST w/ the EclipseObjects, referencing the Ini_JOB path,
            //and the file name with a - in between. Later on we'll use the INI path to determine the file placement inside the node
            //foreach (KeyValuePair<string, EclipseObject> pair in ECL_OBJ_MAP)
            foreach (EclipseObject obj in INI_LIST)
            {
                //MessageBox.Show(obj.FILE_NAME);
                treeView1.Nodes.Add(obj.FILE_NAME + " - " + obj.INI_JOB_PATH);

                treeView1.Nodes[count].Nodes.Add("File Name: " + obj.FILE_NAME);
           
                treeView1.Nodes[count].Nodes.Add("Job Path: " + obj.INI_JOB_PATH);
                treeView1.Nodes[count].Nodes.Add("Main Dictionary: " + obj.INI_MAIN_DICTIONARY);
                treeView1.Nodes[count].Nodes.Add("Blocks Path: " + obj.INI_BLOCK_PATH);
                treeView1.Nodes[count].Nodes.Add("Blocks Folder: " + obj.INI_BLOCK_FOLDER);
                treeView1.Nodes[count].Nodes.Add("Spell Dictionary: " + obj.INI_SPELL_DIX);
                treeView1.Nodes[count].Nodes.Add("INI File Location: " + obj.FILE_PATH);
                currentUsersDropdown.Items.Add(obj.FILE_NAME);
                count += 1;
            }
        }


        public class EclipseObject
        {
            public string FILE_NAME;
            public string FILE_TYPE;
            public string FILE_PATH;
            public string FILE_USER_FOLDER;
            public string FILE_SIZE;
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
                this.FILE_NAME = name;
                this.FILE_TYPE = type;
                this.FILE_PATH = path;
                this.FILE_USER_FOLDER = FILE_PATH.TrimEnd(FILE_NAME.ToCharArray());
                if (type == ".INI")
                {
                    this.INI_INFO_ARRAY = File.ReadAllLines(this.FILE_PATH);
                    this.INI_INFO = ParseUserIni(this.INI_INFO_ARRAY);
                    
                    this.INI_JOB_PATH = INI_INFO["JobPath"];
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

        

        public void backupEssentialUserFiles(EclipseObject userIniObject, string destination)
        {
            writeINIbackup(destination + "\\" + userIniObject.FILE_NAME, userIniObject.INI_INFO_ARRAY);
            string[] filePathArray = new string[] { userIniObject.INI_MAIN_DICTIONARY, userIniObject.INI_SPELL_DIX };
            foreach (string i in filePathArray)
            {
                copyFile(i, userIniObject.INI_JOB_PATH, destination);
            }
            DirectoryCopy(userIniObject.INI_BLOCK_PATH, destination + "\\" + userIniObject.INI_BLOCK_FOLDER + "\\", true);
            MessageBox.Show("Essential Backup complete", "Essential Backup Complete", MessageBoxButtons.OK);


        }


        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
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

        }

        public void writeINIbackup(string destination, string[] iniLinesArray)
        {
            try
            {
                System.IO.File.WriteAllLines(destination, iniLinesArray);
                System.IO.File.WriteAllLines(destination + ".set", iniLinesArray);
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
                Console.WriteLine("Looks like " + sFile + " is in use by another program.");
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
            destinationText.Text = (transferToComboBox.Text);

        }

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
                        result = line.Replace("{DOC}", (Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\"));
                        string[] resultArray = result.Split(delimiter);
                        result = resultArray[2];
                        jobPathInterpret = result;
                        results.Add("JobPath", result);
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
                            result = line.Replace("{MAIN}", USER_ECLIPSE_FOLDER  + "\\");
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
            transferToComboBox.Items.Clear();
            DriveInfo[] files = DriveInfo.GetDrives();
            foreach (DriveInfo d in files)
            {
                transferToComboBox.Items.Add(String.Format(d.Name));
                //freeSpaceLabel.Text = (d.AvailableFreeSpace / 1000000000 + "gb free");
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            string findString = currentUsersDropdown.Text.ToString();
            foreach (EclipseObject obj in INI_LIST)
            {
                if (obj.FILE_NAME.Equals(findString))
                {
                    backupEssentialUserFiles(obj, destinationText.Text);
                }
            }


        }


        private void button7_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                //treeView1.Nodes.Add(folderBrowserDialog1.SelectedPath);
                if (loadEclipseFilesFromPath(folderBrowserDialog1.SelectedPath)) unpack();

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

            }
        }

    }
}

