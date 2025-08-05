using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StudyLinq5 : MonoBehaviour
{
    #region Data Class
    [System.Serializable]
    public class Student
    {
        public int studentID;
        public string studentName;

        public Student(int studentID, string studentName)
        {
            this.studentID = studentID;
            this.studentName = studentName;
        }
    }

    [System.Serializable]
    public class Grade
    {
        public int studentID;
        public int score;
        public string subject;

        public Grade(int studentID, int score, string subject)
        {
            this.studentID = studentID;
            this.score = score;
            this.subject = subject;
        }
    }

    #endregion

    public List<Student> students = new List<Student>();
    public List<Grade> grades = new List<Grade>();

    void Start()
    {
        #region Add Data
        students.Add(new Student(1, "Alice"));
        students.Add(new Student(2, "Bob"));
        students.Add(new Student(3, "Charlie"));
        students.Add(new Student(4, "Eve"));
        students.Add(new Student(5, "Frank"));

        grades.Add(new Grade(1, 90, "Math"));
        grades.Add(new Grade(2, 85, "Science"));
        grades.Add(new Grade(3, 92, "English"));
        grades.Add(new Grade(4, 76, "Math"));
        grades.Add(new Grade(6, 90, "History"));
        #endregion

        OuterJoin();
    }

    private void OuterJoin()
    {
        var leftOuterJoin = from student in students
                            join grade in grades on student.studentID equals grade.studentID into studentGrades
                            from grade in studentGrades.DefaultIfEmpty()
                            select new
                            {
                                StudentID = student.studentID,
                                StudentName = student.studentName,
                                Subject = grade?.subject ?? "N/A",
                                Score = grade?.score ?? 0
                            };

        var rightOuterJoin = from grade in grades
                             join student in students on grade.studentID equals student.studentID into gradeStudents
                             from student in gradeStudents.DefaultIfEmpty()
                             where student == null
                             select new
                             {
                                 StudentID = grade.studentID,
                                 StudentName = "N/A",
                                 Subject = grade?.subject ?? "N/A",
                                 Score = grade?.score ?? 0
                             };

        var outerJoin = leftOuterJoin.Union(rightOuterJoin);

        foreach (var person in outerJoin)
        {
            Debug.Log($"ID : {person.StudentID} / Name : {person.StudentName} / Subject : {person.Subject} / Score : {person.Score}");
        }
    }
}