using StudentsApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentsApi
{
    public class CSV
    {

        public Boolean IsFull(List<string> list)
        {
            foreach (string s in list)
            {
                if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                {
                    return false;
                }
            }
            return true;
        }
        public Boolean IsFull(string[] list)
        {
            foreach (string s in list)
            {
                if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                {
                    return false;
                }
            }
            return true;
        }

        public Boolean isIndexWellFormatted(string index)
        {
            Regex regex = new Regex(@"^[S]\d{4}$", RegexOptions.IgnoreCase);
            
            return regex.IsMatch(index);
        }

        public Student createStudent(string[] student)
        {
            var st = new Student
            {
                FirstName = student[0],
                LastName = student[1],
                IndexNumber = student[2],
                BirthDate = student[3],
                Studies = new Studies
                {
                    Study = student[4],
                    Mode = student[5],
                    Email = student[6],
                },
                FathersName = student[7],
                MothersName = student[8]
            };
            return st;
        }
        public Student createStudent(string[] student, string index)
        {
            var st = new Student
            {
                FirstName = student[0],
                LastName = student[1],
                IndexNumber = index,
                BirthDate = student[3],
                Studies = new Studies
                {
                    Study = student[4],
                    Mode = student[5],
                    Email = student[6],
                },
                FathersName = student[7],
                MothersName = student[8]
            };
            return st;
        }

        public List<Student> ReadFile(string path)
        {
            using var stream = new StreamReader(File.OpenRead(path));
            
                string line = null;
                List<Student> studentList = new List<Student>();
                while ((line = stream.ReadLine()) != null)
                {
                    string[] student = line.Split(',');
                    Student st = createStudent(student);
                    studentList.Add(st);
                }
            return studentList;
        }
        public void WriteFile(Student student, string path)
        {
            List<string> list = new List<string>
            {
                student.FirstName,
                student.LastName,
                student.IndexNumber,
                student.BirthDate,
                student.Studies.Study,
                student.Studies.Mode,
                student.Studies.Email,
                student.FathersName,
                student.MothersName
            };

            if (!IsFull(list))
            {
                throw new StringIsEmptyException("String is null or empty");
            }
            else if (!isIndexWellFormatted(list[2]))
            {
                throw new IndexIsNotCorrectFormattedException("the index value is not correct formatted");
            }
            else
            {
                File.AppendAllText(path, $"{list[0]}," +
                                         $"{list[1]}," +
                                         $"{list[2]}," +
                                         $"{list[3]}," +
                                         $"{list[4]}," +
                                         $"{list[5]}," +
                                         $"{list[6]}," +
                                         $"{list[7]}," +
                                         $"{list[8]}\n");
            }  
        }        
        public string Update(string[] student, Student newStudent, string index)
        {   
            string updatedString;
            if (IsFull(student))
            {
                student[0] = newStudent.FirstName;
                student[1] = newStudent.LastName;
                student[3] = newStudent.BirthDate;
                student[4] = newStudent.Studies.Study;
                student[5] = newStudent.Studies.Mode;
                student[6] = newStudent.Studies.Email;
                student[7] = newStudent.FathersName;
                student[8] = newStudent.MothersName;
            }
            else 
            {
                throw new StringIsEmptyException("String is null or empty");
            }                
            updatedString = "" + student[0] +
                                "," + student[1] +
                                "," + index +
                                "," + student[3] +
                                "," + student[4] +
                                "," + student[5] +
                                "," + student[6] +
                                "," + student[7] +
                                "," + student[8];
            return updatedString;
        }

        public Student UpdateFile(Student student, string path, string index)
        {
            var lines = new List<string>();
            var file = new System.IO.StreamReader(@".\Data\data.csv");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }
            file.Close();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains(index))
                {
                    string[] postStudent = lines[i].Split(',');
                    lines[i] = Update(postStudent, student, index);
                    Student st = createStudent(postStudent, index);
                    return st;
                }
            }
            File.WriteAllLines(@".\Data\data.csv", lines);
            return new Student();
        }
        public void DeleteFromFile(string index)
        {
            var lines = new List<string>();
            var file = new System.IO.StreamReader(@".\Data\data.csv");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }
            file.Close();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains(index))
                {
                    lines.RemoveAt(i);
                    break;
                }
            }
            File.WriteAllLines(@".\Data\data.csv", lines);
        }
    }
}
