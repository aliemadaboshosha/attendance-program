﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AttendanceManagement.AllClasses
{

    public class LoadUserFromXML
    {

        public static List<User> LoadUsersFromXml(string filePath)
        {
            List<User> users = new List<User>();

            try
            {
                XDocument doc = XDocument.Load(filePath);

                // Load students
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                var students = (
                    from usersElement in doc.Root.Elements("users")
                    from student in usersElement.Elements("students").Elements("student")
                    select new Students
                    {
                        Id = (int)student.Element("id"),
                        Name = (string)student.Element("name"),
                        Age = (int)student.Element("age"),
                        DateOfJoining = (string)student.Element("date_of_joining"),
                        Email = (string)student.Element("email"),
                        Password = (string)student.Element("password"),
                        ClassID = (string)student.Element("class_id"),
                        UserType="student"
                    }
                ).ToList();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8601 // Possible null reference assignment.

                // Load teachers
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                var teachers = (
                    from usersElement in doc.Root.Elements("users")
                    from teacher in usersElement.Elements("teachers").Elements("teacher")
                    select new Teachers
                    {
                        Id = (int)teacher.Element("id"),
                        Name = (string)teacher.Element("name"),
                        Age = (int)teacher.Element("age"),
                        DateOfJoining = (string)teacher.Element("date_of_joining"),
                        Email = (string)teacher.Element("email"),
                        Password = (string)teacher.Element("password"),
                        CoursesTaught = teacher.Elements("courses").Elements("course_id").Select(course => (int)course).ToList(),
                        UserType = "teacher"
                    }
                ).ToList();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8601 // Possible null reference assignment.

                // Load admins
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                var admins = (
                    from usersElement in doc.Root.Elements("users")
                    from admin in usersElement.Elements("admin")
                    select new Admins
                    {
                        Id = (int)admin.Element("id"),
                        Name = (string)admin.Element("name"),
                        Age = (int)admin.Element("age"),
                        DateOfJoining = (string)admin.Element("date_of_joining"),
                        Email = (string)admin.Element("email"),
                        Password = (string)admin.Element("password"),
                        UserType = "admin"
                    }
                ).ToList();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8601 // Possible null reference assignment.

                // Combine all users
                users.AddRange(students);
                users.AddRange(teachers);
                users.AddRange(admins);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading users from XML: " + ex.Message);
            }

            return users;
        }
    }
    }
