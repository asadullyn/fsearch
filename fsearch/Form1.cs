using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace fsearch
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private const string FormSaveFile = "fsf.bin";

        [Serializable()]    
        private class FormFiels
        {
            private string dname;
            private string fnamepattern = "";
            private string hastext = "";

            public string DirName
            {
                get 
                { 
                    return dname; 
                }

                set
                {
                    dname = value;
                }
            }

            public string NameTemplate
            {
                get
                {
                    return fnamepattern;
                }

                set
                {
                    fnamepattern = value;
                }
            }

            public string HasText
            {
                get
                {
                    return hastext;
                }

                set
                {
                    hastext = value;
                }
            }
        }

        private void saveForm(){

            FormFiels ff = new FormFiels();
            ff.DirName = this.startDir.Text;
            ff.NameTemplate = this.fnamePattern.Text;
            ff.HasText = this.hasText.Text;

            Stream fsfs = File.Create(FormSaveFile);
            BinaryFormatter serializer = new BinaryFormatter();
            try
            {
                serializer.Serialize(fsfs, ff);
            }
            catch (SerializationException se)
            {

            }
            fsfs.Close();
        }

        private void readForm()
        {
            FormFiels ff = new FormFiels();
            if (File.Exists(FormSaveFile))
            {
                Stream fsfs = File.OpenRead(FormSaveFile);
                BinaryFormatter deserializer = new BinaryFormatter();
                try
                {
                    ff = (FormFiels)deserializer.Deserialize(fsfs);
                }
                catch (SerializationException se)
                {

                }
                fsfs.Close();
                this.startDir.Text = ff.DirName;
                this.fnamePattern.Text = ff.NameTemplate;
                this.hasText.Text = ff.HasText;
            }
        }

        private void startDirOpen_Click(object sender, EventArgs e)
        {
            string dirpath;
            FolderBrowserDialog dirFBD = new FolderBrowserDialog();
            dirFBD.ShowNewFolderButton = false;
            dirFBD.ShowDialog();
            dirpath = dirFBD.SelectedPath;
            startDir.Text = dirpath;

            fileTree.Nodes.Clear();
            DirectoryInfo dir = new DirectoryInfo(dirpath);
            ScanDir(dir);
        }


        private void ScanDir(DirectoryInfo dir, TreeNode tn = null)
        {
            TreeNode dn, fn;
            try
            {
                if (tn != null)
                {
                    tn.Nodes.RemoveAt(0);
                }

                foreach (DirectoryInfo dirs in dir.GetDirectories())
                {
                    if (tn == null)
                    {
                        dn = fileTree.Nodes.Add(dirs.Name);
                    }
                    else
                    {
                        dn = tn.Nodes.Add(dirs.Name);
                    }

                    dn.Nodes.Add("");
                    dn.Tag = dirs;
                }

                foreach (FileInfo files in dir.GetFiles())
                {
                    if (tn == null)
                    {
                        fn = fileTree.Nodes.Add(files.Name);
                    }
                    else
                    {
                        fn = tn.Nodes.Add(files.Name);
                    }
                    
                    fn.Tag = files;
                }
            }
            catch (UnauthorizedAccessException uex)
            {
                MessageBox.Show("Отказано в доступе!");
            }
        }

        private void fileTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            ScanDir((DirectoryInfo)e.Node.Tag, e.Node);
        }


        private int fcount;
        private int sec;
        

        private void SearchFiles(BackgroundWorker w, DoWorkEventArgs e, string basedir, string patt, string text)
        {
            if (text != "")
            {
                try
                {
                    foreach (string files in Directory.GetFiles(basedir, (patt != "") ? patt : "*"))
                    {
                        if (w.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }

                        StreamReader str = new StreamReader(files, Encoding.Default);
                        while (!str.EndOfStream)
                        {
                            if (w.CancellationPending)
                            {
                                e.Cancel = true;
                                break;
                            }

                            string line = str.ReadLine();

                            if (line.Contains(text))
                            {
                                fcount++;
                                w.ReportProgress(0, files);
                                break;
                            }

                        }

                    }
                }
                catch (IOException ex)
                {

                }
                catch (UnauthorizedAccessException uex)
                {

                }
            }
            else
            {
                foreach (string files in Directory.GetFileSystemEntries(basedir, (patt!="")?patt:"*" ))
                {
                    if (w.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    fcount++;
                    w.ReportProgress(0, files);
                }
            }

            
            foreach (string dirs in Directory.GetDirectories(basedir))
            {
                if (w.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                try
                {
                   SearchFiles(w, e, dirs, patt, text);
                }
                catch (IOException ex)
                {
                
                }
                catch (UnauthorizedAccessException uex)
                {

                }
            }
        }



        private void searchButton_Click(object sender, EventArgs e)
        {
            string sdir = startDir.Text.Trim();
            string patt = fnamePattern.Text.Trim();
            string text = hasText.Text.Trim();
            string[] args = new string[3] { sdir, patt, text };
            fcount = 0;
            sec = 0;
            timer.Enabled = true;
            timer.Start();

            if (!Directory.Exists(sdir))
            {
                MessageBox.Show("Такой папки не существует!");
            }
            else
            {
                saveForm();
                searchResultBox.Items.Clear();
                this.searchButton.Enabled = false;
                this.cancelButton.Enabled = true;

                if (!BWSearch.IsBusy)
                {
                    BWSearch.RunWorkerAsync(args);
                }
            }
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            BWSearch.CancelAsync();
            timer.Stop();
            spenttime.Text = sec.ToString() + " сек.";
            timer.Enabled = false;
            this.cancelButton.Enabled = false;
            currentFile.Text = "";
        }

        private void BWSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string[] args = (string[])e.Argument;
            SearchFiles(worker, e, args[0], args[1], args[2]);
        }

        private void BWSearch_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string file = (string)e.UserState;
            this.searchResultBox.Items.Add(file);
            this.currentFile.Text = file;
            this.filecount.Text = fcount.ToString();
            //this.Refresh();
        }

        private void BWSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (timer.Enabled) 
            {
                spenttime.Text = sec.ToString() + " сек.";
                timer.Enabled = false;
            }

            this.currentFile.Text = "";
            searchButton.Enabled = true;
            cancelButton.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            sec++;
            spenttime.Text = sec.ToString() + " сек.";
        }

        private string getDirName(string file)
        {
            int slen = file.Length;

            while(file[slen - 1]!='\\')
            {
                slen--;
            }

            string dirname = file.Substring(0, slen);
            return dirname;
        }

        private void showFileLocation(string file)
        {
            fileTree.Nodes.Clear();
            DirectoryInfo dir = new DirectoryInfo(getDirName(file));
            ScanDir(dir);
        }

        private void searchResultBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string file = searchResultBox.SelectedItem.ToString();
                showFileLocation(file);
                this.dirName.Text = getDirName(file);
            }
            catch (NullReferenceException nre)
            {

            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            readForm();
        }
        

    }
}
