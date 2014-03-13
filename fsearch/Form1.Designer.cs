namespace fsearch
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxSP = new System.Windows.Forms.GroupBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.hasText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fnamePattern = new System.Windows.Forms.TextBox();
            this.startDirOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.startDir = new System.Windows.Forms.TextBox();
            this.searchResultBox = new System.Windows.Forms.ListBox();
            this.fileTree = new System.Windows.Forms.TreeView();
            this.currentFile = new System.Windows.Forms.Label();
            this.BWSearch = new System.ComponentModel.BackgroundWorker();
            this.label4 = new System.Windows.Forms.Label();
            this.filecount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.spenttime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBoxSP.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSP
            // 
            this.groupBoxSP.Controls.Add(this.cancelButton);
            this.groupBoxSP.Controls.Add(this.searchButton);
            this.groupBoxSP.Controls.Add(this.label3);
            this.groupBoxSP.Controls.Add(this.hasText);
            this.groupBoxSP.Controls.Add(this.label2);
            this.groupBoxSP.Controls.Add(this.fnamePattern);
            this.groupBoxSP.Controls.Add(this.startDirOpen);
            this.groupBoxSP.Controls.Add(this.label1);
            this.groupBoxSP.Controls.Add(this.startDir);
            this.groupBoxSP.Location = new System.Drawing.Point(240, 43);
            this.groupBoxSP.Name = "groupBoxSP";
            this.groupBoxSP.Size = new System.Drawing.Size(485, 175);
            this.groupBoxSP.TabIndex = 0;
            this.groupBoxSP.TabStop = false;
            this.groupBoxSP.Text = "Параметры поиска";
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(249, 128);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(114, 24);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Остановить поиск";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(112, 128);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(114, 24);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Начать поиск";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Содержит текст:";
            // 
            // hasText
            // 
            this.hasText.Location = new System.Drawing.Point(112, 91);
            this.hasText.Name = "hasText";
            this.hasText.Size = new System.Drawing.Size(279, 20);
            this.hasText.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Шаблон имени:";
            // 
            // fnamePattern
            // 
            this.fnamePattern.Location = new System.Drawing.Point(112, 61);
            this.fnamePattern.Name = "fnamePattern";
            this.fnamePattern.Size = new System.Drawing.Size(279, 20);
            this.fnamePattern.TabIndex = 3;
            // 
            // startDirOpen
            // 
            this.startDirOpen.Location = new System.Drawing.Point(397, 30);
            this.startDirOpen.Name = "startDirOpen";
            this.startDirOpen.Size = new System.Drawing.Size(75, 22);
            this.startDirOpen.TabIndex = 2;
            this.startDirOpen.Text = "Открыть";
            this.startDirOpen.UseVisualStyleBackColor = true;
            this.startDirOpen.Click += new System.EventHandler(this.startDirOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Папка поиска:";
            // 
            // startDir
            // 
            this.startDir.Location = new System.Drawing.Point(112, 31);
            this.startDir.Name = "startDir";
            this.startDir.Size = new System.Drawing.Size(279, 20);
            this.startDir.TabIndex = 0;
            // 
            // searchResultBox
            // 
            this.searchResultBox.FormattingEnabled = true;
            this.searchResultBox.Location = new System.Drawing.Point(240, 247);
            this.searchResultBox.Name = "searchResultBox";
            this.searchResultBox.ScrollAlwaysVisible = true;
            this.searchResultBox.Size = new System.Drawing.Size(485, 238);
            this.searchResultBox.TabIndex = 1;
            this.searchResultBox.DoubleClick += new System.EventHandler(this.searchResultBox_DoubleClick);
            // 
            // fileTree
            // 
            this.fileTree.Location = new System.Drawing.Point(13, 43);
            this.fileTree.Name = "fileTree";
            this.fileTree.Size = new System.Drawing.Size(207, 442);
            this.fileTree.TabIndex = 2;
            this.fileTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.fileTree_BeforeExpand);
            // 
            // currentFile
            // 
            this.currentFile.AutoSize = true;
            this.currentFile.Location = new System.Drawing.Point(237, 498);
            this.currentFile.MaximumSize = new System.Drawing.Size(500, 13);
            this.currentFile.Name = "currentFile";
            this.currentFile.Size = new System.Drawing.Size(0, 13);
            this.currentFile.TabIndex = 3;
            // 
            // BWSearch
            // 
            this.BWSearch.WorkerReportsProgress = true;
            this.BWSearch.WorkerSupportsCancellation = true;
            this.BWSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BWSearch_DoWork);
            this.BWSearch.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BWSearch_ProgressChanged);
            this.BWSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BWSearch_RunWorkerCompleted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 498);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Всего файлов:";
            // 
            // filecount
            // 
            this.filecount.AutoSize = true;
            this.filecount.Location = new System.Drawing.Point(101, 498);
            this.filecount.Name = "filecount";
            this.filecount.Size = new System.Drawing.Size(0, 13);
            this.filecount.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 520);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Потрачено времени:";
            // 
            // spenttime
            // 
            this.spenttime.AutoSize = true;
            this.spenttime.Location = new System.Drawing.Point(131, 520);
            this.spenttime.Name = "spenttime";
            this.spenttime.Size = new System.Drawing.Size(0, 13);
            this.spenttime.TabIndex = 7;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.spenttime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.filecount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.currentFile);
            this.Controls.Add(this.fileTree);
            this.Controls.Add(this.searchResultBox);
            this.Controls.Add(this.groupBoxSP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Поиск файлов";
            this.groupBoxSP.ResumeLayout(false);
            this.groupBoxSP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox startDir;
        private System.Windows.Forms.Button startDirOpen;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hasText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fnamePattern;
        private System.Windows.Forms.ListBox searchResultBox;
        private System.Windows.Forms.TreeView fileTree;
        private System.Windows.Forms.Label currentFile;
        private System.ComponentModel.BackgroundWorker BWSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label filecount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label spenttime;
        private System.Windows.Forms.Timer timer;
    }
}

