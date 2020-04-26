using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_8;
using System.Xml.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UnexistingFile()
        {
            UniBaseForm form = new UniBaseForm();
            XDocument doc = new XDocument(
                new XElement("subjects",
                new XElement("subject",
                new XAttribute("subjectId", 11),
                new XElement("subjectName", "Архитектура вычислительных систем"),
                new XElement("teacherLastname", "Абрамов"),
                new XElement("groupId", "3530202/90001"),
                new XElement("studentsCount", "50"),
                new XElement("lectureHours", "56"),
                new XElement("practicHours", "12"),
                new XElement("isCoursework", "true"),
                new XElement("finalCheck", "0,5"))));

            doc.Save("file.xml");

            Assert.ThrowsException<System.ArgumentException>(() => form.serializeXML("NOTfile.xml"));
        }

        [TestMethod]
        public void UncorrectPath()
        {
            UniBaseForm form = new UniBaseForm();
            XDocument doc = new XDocument(
                new XElement("subjects",
                new XElement("subject",
                new XAttribute("subjectId", 11),
                new XElement("subjectName", "Архитектура вычислительных систем"),
                new XElement("teacherLastname", "Абрамов"),
                new XElement("groupId", "3530202/90001"),
                new XElement("studentsCount", "50"),
                new XElement("lectureHours", "56"),
                new XElement("practicHours", "12"),
                new XElement("isCoursework", "true"),
                new XElement("finalCheck", "0,5"))));

            doc.Save("file.xml");

            Assert.ThrowsException<System.ArgumentException>(() => form.serializeXML("c:\\file.xml"));
        }

        [TestMethod]
        public void CorrectPath()
        {
            UniBaseForm form = new UniBaseForm();
            XDocument doc = new XDocument(
                new XElement("subjects",
                new XElement("subject",
                new XAttribute("subjectId", 11),
                new XElement("subjectName", "Архитектура вычислительных систем"),
                new XElement("teacherLastname", "Абрамов"),
                new XElement("groupId", "3530202/90001"),
                new XElement("studentsCount", "50"),
                new XElement("lectureHours", "56"),
                new XElement("practicHours", "12"),
                new XElement("isCoursework", "true"),
                new XElement("finalCheck", "0,5"))));

            doc.Save("file.xml");
            form.serializeXML("file.xml");
        }

        [TestMethod]
        public void UnknownFormat()
        {
            UniBaseForm form = new UniBaseForm();
            XDocument doc = new XDocument(
                new XElement("subjects",
                new XElement("subject",
                new XAttribute("subjectId", 11),
                new XElement("subjectName", "Архитектура вычислительных систем"),
                new XElement("teacherLastname", "Абрамов"),
                new XElement("groupId", "3530202/90001"),
                new XElement("studentsCount", "50"),
                new XElement("lectureHours", "56"),
                new XElement("practicHours", "12"),
                new XElement("isCoursework", "true"),
                new XElement("finalCheck", "0,5"))));

            doc.Save("file.xml");

            Assert.ThrowsException<System.ArgumentException>(() => form.serializeXML("c:\\data.txt"));
        }

        [TestMethod]
        public void NullValue()
        {
            UniBaseForm form = new UniBaseForm();

            UniversityData odj = new UniversityData("1", null, "Абрамов", "3530202/90001", "50", "56", "12", "true", "0,5");
            XDocument doc = new XDocument(new XElement("subjects"));

            doc.Save("file.xml");

            Assert.ThrowsException<System.ArgumentNullException>(() => form.addNewDataToXml("file.xml", odj));

        }

        [TestMethod]
        public void UncorrectPath_addNewDataToXml()
        {
            UniBaseForm form = new UniBaseForm();

            UniversityData odj = new UniversityData("1", "Физика", "Абрамов", "3530202/90001", "50", "56", "12", "true", "0,5");
            XDocument doc = new XDocument(new XElement("subjects"));

            doc.Save("file.xml");
            Assert.ThrowsException<System.ArgumentNullException>(() => form.addNewDataToXml(null, odj));
        }

        [TestMethod]
        public void UncorrectfinalCheck()
        {
            UniBaseForm form = new UniBaseForm();

            UniversityData odj = new UniversityData("1", "Физика", "Абрамов", "3530202/90001", "50", "56", "12", "true", "4353636");
            XDocument doc = new XDocument(new XElement("subjects"));

            doc.Save("file.xml");
            Assert.ThrowsException<System.ArgumentNullException>(() => form.addNewDataToXml("file.xml", odj));
        }

        [TestMethod]
        public void UncorrectisCoursework()
        {
            UniBaseForm form = new UniBaseForm();

            UniversityData odj = new UniversityData("1", "Физика", "Абрамов", "3530202/90001", "50", "56", "12", "UNCORRECT", "0,5");
            XDocument doc = new XDocument(new XElement("subjects"));

            doc.Save("file.xml");
            Assert.ThrowsException<System.ArgumentNullException>(() => form.addNewDataToXml("file.xml", odj));
        }

        [TestMethod]
        public void UncorrectPath_deleteRowFromXML()
        {
            UniBaseForm form = new UniBaseForm();

            UniversityData odj = new UniversityData("1", "Физика", "Абрамов", "3530202/90001", "50", "56", "12", "true", "0,5");
            XDocument doc = new XDocument(
                new XElement("subjects",
                new XElement("subject",
                new XAttribute("subjectId", 11),
                new XElement("subjectName", "Архитектура вычислительных систем"),
                new XElement("teacherLastname", "Абрамов"),
                new XElement("groupId", "3530202/90001"),
                new XElement("studentsCount", "50"),
                new XElement("lectureHours", "56"),
                new XElement("practicHours", "12"),
                new XElement("isCoursework", "true"),
                new XElement("finalCheck", "0,5"))));

            doc.Save("file.xml");
            Assert.ThrowsException<System.ArgumentException>(() => form.deleteRowFromXML("d:\\fg.xml", odj));
        }

        [TestMethod]
        public void NullElement_deleteRowFromXML()
        {
            UniBaseForm form = new UniBaseForm();
            XDocument doc = new XDocument(
                new XElement("subjects",
                new XElement("subject",
                new XAttribute("subjectId", 11),
                new XElement("subjectName", ""),
                new XElement("teacherLastname", "Абрамов"),
                new XElement("groupId", "3530202/90001"),
                new XElement("studentsCount", "50"),
                new XElement("lectureHours", "56"),
                new XElement("practicHours", "12"),
                new XElement("isCoursework", "true"),
                new XElement("finalCheck", "0,5"))));

            doc.Save("file.xml");
            Assert.ThrowsException<System.ArgumentNullException>(() => form.deleteRowFromXML("file.xml", null));
        }

        [TestMethod]
        public void UncorrectfinalCheck_deleteRowFromXML()
        {
            UniBaseForm form = new UniBaseForm();

            UniversityData odj = new UniversityData("1", "Физика", "Абрамов", "3530202/90001", "50", "56", "12", "UNCORRECT", "0,5");
            XDocument doc = new XDocument(
                new XElement("subjects",
                new XElement("subject",
                new XAttribute("subjectId", 11),
                new XElement("subjectName", ""),
                new XElement("teacherLastname", "Абрамов"),
                new XElement("groupId", "3530202/90001"),
                new XElement("studentsCount", "50"),
                new XElement("lectureHours", "56"),
                new XElement("practicHours", "12"),
                new XElement("isCoursework", "true"),
                new XElement("finalCheck", "0,5"))));

            doc.Save("file.xml");
            Assert.ThrowsException<System.ArgumentNullException>(() => form.deleteRowFromXML("file.xml", odj));
        }
    }
}
