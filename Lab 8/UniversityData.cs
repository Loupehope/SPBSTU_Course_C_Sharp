using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class UniversityData
    {
        public string subjectId { get; set; }

        public string subjectName { get; set; }

        public string teacherLastname { get; set; } 

        public string groupId { get; set; }

        public string studentsCount { get; set; }

        public string lectureHours { get; set; }

        public string practicHours { get; set; }

        public string isCoursework { get; set; }

        public string finalCheck { get; set; }

        public UniversityData(string subjectId, 
            string subjectName, 
            string teacherLastname,
            string groupId, 
            string studentsCount,
            string lectureHours,
            string practicHours,
            string isCoursework,
            string finalCheck)
        {
            this.subjectId = subjectId;
            this.subjectName = subjectName;
            this.teacherLastname = teacherLastname;
            this.groupId = groupId;
            this.studentsCount = studentsCount;
            this.lectureHours = lectureHours;
            this.practicHours = practicHours;
            this.isCoursework = isCoursework;
            this.finalCheck = finalCheck;
        }

        public bool isCorrect()
        {
            return !(String.IsNullOrEmpty(subjectId) || String.IsNullOrEmpty(subjectName) ||
                String.IsNullOrEmpty(teacherLastname) || String.IsNullOrEmpty(groupId) ||
                String.IsNullOrEmpty(studentsCount) || String.IsNullOrEmpty(lectureHours) ||
                String.IsNullOrEmpty(practicHours) || String.IsNullOrEmpty(isCoursework) ||
                String.IsNullOrEmpty(finalCheck)) && isValidData();
        }

        private bool isValidData()
        {
            return subjectId.All(Char.IsDigit) && subjectName.All(c => Char.IsLetter(c) 
                    || c == '(' || c == ')' || c == ' ' || c == '-')
                    && teacherLastname.All(Char.IsLetter) && studentsCount.All(Char.IsDigit)
                    && groupId.All(c => Char.IsDigit(c) || c == '/')
                    && lectureHours.All(Char.IsDigit) && practicHours.All(Char.IsDigit)
                    && (isCoursework == "true" || isCoursework == "false")
                    && (finalCheck == "0,5" || finalCheck == "0,35");

        }

        public bool isEqual(UniversityData data)
        {
            return subjectId == data.subjectId &&
             subjectName == data.subjectName &&
             teacherLastname == data.teacherLastname &&
             groupId == data.groupId &&
             studentsCount == data.studentsCount &&
             lectureHours == data.lectureHours &&
             practicHours == data.practicHours &&
             isCoursework == data.isCoursework &&
             finalCheck == data.finalCheck;
        }
    }
}
