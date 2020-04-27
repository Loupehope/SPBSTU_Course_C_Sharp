using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab_8
{
    public partial class UniBaseForm : Form
    {
        /// <summary>
        /// Путь xml файла для чтения и записи
        /// </summary>
        private string filePath;

        /// <summary>
        /// Лист, отображающихся записей 
        /// </summary>
        private List<UniversityData> dataBase = new List<UniversityData>();

        /// <summary>
        /// Конструктор
        /// </summary>
        public UniBaseForm()
        {
            InitializeComponent();
            
            deleteRow.Enabled = false;
            addRow.Enabled = false;
            findTool.Enabled = false;
            dropSearch.Enabled = false;
        }

        /// <summary>
        /// Обработчик нажатий на кнопку загрузки файла
        /// </summary>
        /// <param name="sender">Посылатель событий</param>
        /// <param name="e">Событие</param>
        private void loadXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "XML files (*.xml)|*.xml";

                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                
                try
                {
                    serializeXML(openFileDialog.FileName);
                }
                catch (ArgumentException)
                {
                    dataBase.Clear();
                    MessageBox.Show("Некорректный путь к xml-файлу",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                catch (NullReferenceException)
                {
                    dataBase.Clear();
                    MessageBox.Show("Некорректный данные в xml-файле",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    dataBase.Clear();
                    MessageBox.Show("Что-то пошло не так: " + ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                filePath = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Метод преобразования xml-файла в модели
        /// </summary>
        /// <param name="xmlPath">Путь xml-файла</param>
        public void serializeXML(string xmlPath)
        {
            XDocument doc;

            try
            {
                doc = XDocument.Load(xmlPath);
            }
            catch
            {
                throw new System.ArgumentException();
            }

            dataBase.Clear();

            foreach (XElement uniElement in doc.Element("subjects").Elements("subject"))
            {
                XAttribute nameAttribute = uniElement.Attribute("subjectId");
                XElement subjectNameElement = uniElement.Element("subjectName");
                XElement teacherLastnameElement = uniElement.Element("teacherLastname");
                XElement groupIdElement = uniElement.Element("groupId");
                XElement studentsCountElement = uniElement.Element("studentsCount");
                XElement lectureHoursElement = uniElement.Element("lectureHours");
                XElement practicHoursElement = uniElement.Element("practicHours");
                XElement isCourseworkElement = uniElement.Element("isCoursework");
                XElement finalCheckElement = uniElement.Element("finalCheck");

                if (nameAttribute == null || subjectNameElement == null ||
                    teacherLastnameElement == null || groupIdElement == null ||
                    studentsCountElement == null || lectureHoursElement == null ||
                    practicHoursElement == null || isCourseworkElement == null || finalCheckElement == null)
                {
                    throw new System.NullReferenceException();
                }

                UniversityData data = new UniversityData(nameAttribute.Value,
                        subjectNameElement.Value,
                        teacherLastnameElement.Value,
                        groupIdElement.Value,
                        studentsCountElement.Value,
                        lectureHoursElement.Value,
                        practicHoursElement.Value,
                        isCourseworkElement.Value,
                        finalCheckElement.Value);

                if (!data.isCorrect())
                    throw new System.NullReferenceException();

                dataBase.Add(data);
            }


            if (dataBase.Count() > 0)
            {
                deleteRow.Enabled = true;
                addRow.Enabled = true;
                findTool.Enabled = true;
            }
            else
            {
                deleteRow.Enabled = false;
                addRow.Enabled = true;
                findTool.Enabled = false;
                dropSearch.Enabled = false;
            }

            addItemsToListView(dataBase);
        }

        /// <summary>
        /// Метод обработки нажатия на кнопку добавления новой записи
        /// </summary>
        /// <param name="sender">Посылатель события</param>
        /// <param name="e">Событие</param>
        private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new NewRow())
            {
                form.ShowDialog();
                if (!form.isSave) return;
                
                try
                {
                    addNewDataToXml(filePath, form.data);
                    dataBase.Add(form.data);
                    addItemsToListView(dataBase);
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Некорректный данные для записи в xml-файл",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Некорректный путь к xml-файлу",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Что-то пошло не так: " + ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                form.data = null;
            }
        }

        /// <summary>
        /// Метод добавления данных в xml-файл
        /// </summary>
        /// <param name="xmlPath">Путь xml-файла</param>
        /// <param name="value">Значение</param>
        public void addNewDataToXml(string xmlPath, UniversityData value)
        {
            if (value == null || xmlPath == null)
                throw new System.ArgumentNullException();

            XDocument doc;

            try
            {
                doc = XDocument.Load(xmlPath);
            }
            catch
            {
                throw new System.ArgumentException();
            }

            if (!value.isCorrect())
                throw new System.ArgumentNullException();

            var newElement = new XElement("subject",
                      new XAttribute("subjectId", value.subjectId),
                      new XElement("subjectName", value.subjectName),
                      new XElement("teacherLastname", value.teacherLastname),
                      new XElement("groupId", value.groupId),
                      new XElement("studentsCount", value.studentsCount),
                      new XElement("lectureHours", value.lectureHours),
                      new XElement("practicHours", value.practicHours),
                      new XElement("isCoursework", value.isCoursework),
                      new XElement("finalCheck", value.finalCheck));

            doc.Element("subjects").Add(newElement);
            doc.Save(xmlPath);
        }

        /// <summary>
        /// Обработчик удаления данных из xml-файла
        /// </summary>
        /// <param name="sender">Посылатель событий</param>
        /// <param name="e">Событие</param>
        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<UniversityData> restoreData = new List<UniversityData>();
            
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem row in listView1.SelectedItems)
                {
                    UniversityData data;

                    try
                    {
                        data = new UniversityData(row.SubItems[0].Text,
                                                                row.SubItems[1].Text,
                                                                row.SubItems[2].Text,
                                                                row.SubItems[3].Text,
                                                                row.SubItems[4].Text,
                                                                row.SubItems[5].Text,
                                                                row.SubItems[6].Text,
                                                                row.SubItems[7].Text,
                                                                row.SubItems[8].Text);
                        deleteRowFromXML(filePath, data);
                        restoreData.Add(data);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            foreach (var elem in restoreData)
                                addNewDataToXml(filePath, elem);
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("Что-то пошло не так: " + exc.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                            return;
                        }

                        MessageBox.Show("Что-то пошло не так: " + ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return;
                    }
                }

                foreach (var element in restoreData)
                {
                    dataBase.RemoveAll(elem => elem.isEqual(element));
                }

                if (dataBase.Count() > 0)
                {
                    deleteRow.Enabled = true;
                    addRow.Enabled = true;
                    findTool.Enabled = true;
                }
                else
                {
                    deleteRow.Enabled = false;
                    addRow.Enabled = true;
                    findTool.Enabled = false;
                    dropSearch.Enabled = false;
                }

                addItemsToListView(dataBase);
            }
            else
            {
                MessageBox.Show("Выберите записи для удаления",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод для удаления данных из xml-файла
        /// </summary>
        /// <param name="xmlPath">Путь xml-файла</param>
        /// <param name="value">Значение</param>
        public void deleteRowFromXML(string xmlPath, UniversityData value)
        {
            if (value == null || xmlPath == null)
                throw new System.ArgumentNullException();

            XDocument doc;

            try
            {
                doc = XDocument.Load(xmlPath);
            }
            catch
            {
                throw new System.ArgumentException();
            }

            if (!value.isCorrect())
                throw new System.ArgumentNullException();

            var element = doc.Element("subjects").Elements("subject")
                            .Where(elem => elem.Attribute("subjectId").Value == value.subjectId &&
                            elem.Element("subjectName").Value == value.subjectName &&
                            elem.Element("teacherLastname").Value == value.teacherLastname &&
                            elem.Element("groupId").Value == value.groupId &&
                            elem.Element("studentsCount").Value == value.studentsCount &&
                            elem.Element("lectureHours").Value == value.lectureHours &&
                            elem.Element("practicHours").Value == value.practicHours &&
                            elem.Element("isCoursework").Value == value.isCoursework &&
                            elem.Element("finalCheck").Value == value.finalCheck);

            if (element == null)
                throw new System.NullReferenceException();

            element.Remove();
            doc.Save(xmlPath);
        }

        /// <summary>
        /// Обработчик поиска записей по преподавателю
        /// </summary>
        /// <param name="sender">Посылатель события</param>
        /// <param name="e">Событие</param>
        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FilterForm())
            {
                form.ShowDialog();
                if (form.isSearch)
                {
                    var filteredTeachers = dataBase.Where(elem => elem.teacherLastname.ToLower()
                                                                    .Contains(form.searchString.ToLower()));

                    if (filteredTeachers.Count() > 0)
                    {
                        addItemsToListView(filteredTeachers.ToList());
                        dropSearch.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Ничего не найдено",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Обработчик поиска записей по группе
        /// </summary>
        /// <param name="sender">Посылатель события</param>
        /// <param name="e">Событие</param>
        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FilterForm())
            {
                form.ShowDialog();

                if (form.isSearch)
                {
                    var filteredGroups = dataBase.Where(elem => elem.groupId.ToLower()
                                                                    .Contains(form.searchString.ToLower()));

                    if (filteredGroups.Count() > 0)
                    {
                        addItemsToListView(filteredGroups.ToList());
                        dropSearch.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Ничего не найдено",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Обработчик поиска записей по наличию курсовой работы
        /// </summary>
        /// <param name="sender">Посылатель события</param>
        /// <param name="e">Событие</param>
        private void finalWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new IsCourseWorkForm())
            {
                form.ShowDialog();

                if (form.isSelected)
                {
                    var filteredWorks = dataBase.Where(elem => elem.isCoursework.Contains(form.searchString));
                    
                    if (filteredWorks.Count() > 0)
                    {
                        addItemsToListView(filteredWorks.ToList());
                        dropSearch.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Ничего не найдено",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Обработчик поиска записей по итоговому контролю
        /// </summary>
        /// <param name="sender">Посылатель события</param>
        /// <param name="e">Событие</param>
        private void finalCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FinalWorkForm())
            {
                form.ShowDialog();

                if (form.isSelected)
                {
                    var filteredFinalCheck = dataBase.Where(elem => elem.finalCheck.Contains(form.searchString));

                    if (filteredFinalCheck.Count() > 0)
                    {
                        addItemsToListView(filteredFinalCheck.ToList());
                        dropSearch.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Ничего не найдено",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Обработчик сброса поиска
        /// </summary>
        /// <param name="sender">Посылатель события</param>
        /// <param name="e">Событие</param>
        private void dropSearch_Click(object sender, EventArgs e)
        {
            addItemsToListView(dataBase);
            dropSearch.Enabled = false;
        }

        /// <summary>
        /// Обработчик загрузки формы
        /// </summary>
        /// <param name="sender">Посылатель события</param>
        /// <param name="e">Событие</param>
        private void UniBaseForm_Load(object sender, EventArgs e)
        {
            ResizeListViewColumns();
        }

        /// <summary>
        /// Метод для изменения размера формы под таблицу
        /// </summary>
        private void ResizeListViewColumns()
        {
            int width = 0;

            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -2;
            }

            foreach (ColumnHeader column in listView1.Columns)
            {
                width += column.Width;
            }

            Width = width + 20;
        }

        /// <summary>
        /// Метод для добавления записей в таблицу
        /// </summary>
        /// <param name="data">Лист данных</param>
        private void addItemsToListView(List<UniversityData> data)
        {
            listView1.Items.Clear();

            foreach (var elem in data)
            {
                string[] row = { elem.subjectId, elem.subjectName, elem.teacherLastname, elem.groupId, elem.studentsCount,
                elem.lectureHours, elem.practicHours, elem.isCoursework, elem.finalCheck };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            ResizeListViewColumns();
        }

    }
}
