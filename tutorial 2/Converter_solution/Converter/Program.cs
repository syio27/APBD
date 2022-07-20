using Converter.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            //3 parameters
            var path = @".\Data\data.csv";
            var destinationPath = "result.json" //@"C:\Users\77076\Desktop\APBD\tutorial 2\result.json";
            var dataFormat = "json";

            var log = @"C:\Users\77076\Desktop\APBD\tutorial 2\log.txt";

            if (args.Length >= 3) 
            {
                path = args[0];
                destinationPath = args[1];
                dataFormat = args[2];
            }
                      
            if (File.Exists(destinationPath))
            {
                    File.WriteAllText(destinationPath, String.Empty);
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(log))
                {
                    writer.WriteLine("File does not exist");
                }
                throw new FileNotFoundException("File does not exist");
            }
               
            

            //read from file
            var list = new List<Student>();
            var set = new HashSet<Student>();
            var logList = new List<Student>();
            using (var stream = new StreamReader(new FileInfo(path).OpenRead()))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] student = line.Split(',');
                    var st = new Student
                    {
                        FirstName = student[0],
                        LastName = student[1],
                        Studies = new Studies
                        {
                            StudiesName = student[2],
                            Mode = student[3]
                        },
                        StudentNum = student[4],
                        BirthDate = DateTime.Parse(student[5]),
                        Email = student[6],
                        MotherName = student[7],
                        FatherName = student[8]
                    };
                    }
                }
            }
        }
    }
