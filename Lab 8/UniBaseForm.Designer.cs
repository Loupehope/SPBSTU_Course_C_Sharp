namespace Lab_8
{
    partial class UniBaseForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UniBaseForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.loadXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRow = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.findTool = new System.Windows.Forms.ToolStripMenuItem();
            this.teacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.universityDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.universityDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadXMLToolStripMenuItem,
            this.addRow,
            this.deleteRow,
            this.findTool,
            this.dropSearch});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1794, 40);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // loadXMLToolStripMenuItem
            // 
            this.loadXMLToolStripMenuItem.Name = "loadXMLToolStripMenuItem";
            this.loadXMLToolStripMenuItem.Size = new System.Drawing.Size(196, 36);
            this.loadXMLToolStripMenuItem.Text = "Загрузить XML";
            this.loadXMLToolStripMenuItem.Click += new System.EventHandler(this.loadXMLToolStripMenuItem_Click);
            // 
            // addRow
            // 
            this.addRow.Name = "addRow";
            this.addRow.Size = new System.Drawing.Size(141, 36);
            this.addRow.Text = "Добавить";
            this.addRow.Click += new System.EventHandler(this.addRowToolStripMenuItem_Click);
            // 
            // deleteRow
            // 
            this.deleteRow.Name = "deleteRow";
            this.deleteRow.Size = new System.Drawing.Size(123, 36);
            this.deleteRow.Text = "Удалить";
            this.deleteRow.Click += new System.EventHandler(this.deleteRowToolStripMenuItem_Click);
            // 
            // findTool
            // 
            this.findTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teacherToolStripMenuItem,
            this.groupToolStripMenuItem,
            this.finalWorkToolStripMenuItem,
            this.finalCheckToolStripMenuItem});
            this.findTool.Name = "findTool";
            this.findTool.Size = new System.Drawing.Size(103, 36);
            this.findTool.Text = "Поиск";
            // 
            // teacherToolStripMenuItem
            // 
            this.teacherToolStripMenuItem.Name = "teacherToolStripMenuItem";
            this.teacherToolStripMenuItem.Size = new System.Drawing.Size(422, 44);
            this.teacherToolStripMenuItem.Text = "По преподавателю";
            this.teacherToolStripMenuItem.Click += new System.EventHandler(this.teacherToolStripMenuItem_Click);
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(422, 44);
            this.groupToolStripMenuItem.Text = "По номеру группы";
            this.groupToolStripMenuItem.Click += new System.EventHandler(this.groupToolStripMenuItem_Click);
            // 
            // finalWorkToolStripMenuItem
            // 
            this.finalWorkToolStripMenuItem.Name = "finalWorkToolStripMenuItem";
            this.finalWorkToolStripMenuItem.Size = new System.Drawing.Size(422, 44);
            this.finalWorkToolStripMenuItem.Text = "По наличию курсовой";
            this.finalWorkToolStripMenuItem.Click += new System.EventHandler(this.finalWorkToolStripMenuItem_Click);
            // 
            // finalCheckToolStripMenuItem
            // 
            this.finalCheckToolStripMenuItem.Name = "finalCheckToolStripMenuItem";
            this.finalCheckToolStripMenuItem.Size = new System.Drawing.Size(422, 44);
            this.finalCheckToolStripMenuItem.Text = "По итоговому контролю";
            this.finalCheckToolStripMenuItem.Click += new System.EventHandler(this.finalCheckToolStripMenuItem_Click);
            // 
            // dropSearch
            // 
            this.dropSearch.Name = "dropSearch";
            this.dropSearch.Size = new System.Drawing.Size(211, 36);
            this.dropSearch.Text = "Сбросить поиск";
            this.dropSearch.Click += new System.EventHandler(this.dropSearch_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 40);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1794, 890);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Код дисциплины";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Дисциплина";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Преподаватель";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Код группы";
            this.columnHeader4.Width = 178;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Количество студентов";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 320;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Часы лекций";
            this.columnHeader6.Width = 234;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Часы практик";
            this.columnHeader7.Width = 216;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Наличие курсовой";
            this.columnHeader8.Width = 342;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Вид итогового контроля";
            this.columnHeader9.Width = 314;
            // 
            // universityDataBindingSource
            // 
            this.universityDataBindingSource.DataSource = typeof(Lab_8.UniversityData);
            // 
            // UniBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1794, 930);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(1820, 1001);
            this.Name = "UniBaseForm";
            this.Text = "UniBase";
            this.Load += new System.EventHandler(this.UniBaseForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.universityDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem loadXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRow;
        private System.Windows.Forms.ToolStripMenuItem deleteRow;
        private System.Windows.Forms.ToolStripMenuItem findTool;
        private System.Windows.Forms.ToolStripMenuItem teacherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finalWorkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finalCheckToolStripMenuItem;
        private System.Windows.Forms.BindingSource universityDataBindingSource;
        private System.Windows.Forms.ToolStripMenuItem dropSearch;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}

