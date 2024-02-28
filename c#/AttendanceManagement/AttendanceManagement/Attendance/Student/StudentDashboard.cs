﻿using AttendanceManagement.AllClasses;
using AttendanceManagement.Attendance.Forms.AdminDashborad;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static AttendanceManagement.AllClasses.StudentsListGenerators;

namespace AttendanceManagement.Attendance.Student
{
    public partial class StudentDashboard : Form
    {
        public string Username, Role, ClassName, JoinDate;
        public static AttendanceManagement.AllClasses.Student Student = StudentsListGenerators.students.FirstOrDefault((x) => x.Email == "ali@gmail.com" && x.Password == "AliEmad123#");

        public StudentDashboard()
        {
            InitializeComponent();
            timerDateAndTime.Start();



            var Student = StudentsListGenerators.students.FirstOrDefault((x) => x.Email == "ali@gmail.com" && x.Password == "AliEmad123#");
            Username = Student.Name;
            Role = "Student";
            ClassName = StudentsListGenerators.AllClasses.FirstOrDefault(x => x.ID == Student.ClassID).Name;
            JoinDate = Student.DateOfJoining;
            List<Courses> comboBoxValues = new List<Courses>();
            comboBoxValues.Add(new Courses { ID = 0, Name = "All Courses", });
            foreach (var item in LoadClassCourses(Student.ClassID, StudentsListGenerators.Courses))
            {
                comboBoxValues.Add(item);

            }
            comboBox2.DataSource = comboBoxValues;






            #region Student Attendance Data

            //var StudentClassAttendancesRawData=StudentsListGenerators.Attandances.Where(attend=> attend.CoursesAttendance.Any(y=>y.Class_id==Student.ClassID)).ToList();
            //List<StudentCourseAttandance> studentAttendances= new List<StudentCourseAttandance>();
            // foreach (var DayAttendace in StudentClassAttendancesRawData)
            // {
            //     bool findFlag = false;

            //     foreach (var courseAttendance in DayAttendace.CoursesAttendance)
            //     {

            //         if(courseAttendance.Class_id==Student.ClassID)
            //         {
            //             var courseName= StudentsListGenerators.Courses.FirstOrDefault(x => x.ID == courseAttendance.Course_id).Name;
            //             if (studentAttendances.Count > 0)
            //             {
            //                 foreach (var studentAttend in studentAttendances)
            //                 {
            //                     if (studentAttend.CourseName == courseName)
            //                     {
            //                         if (courseAttendance.Students.Any(studentID => studentID == Student.Id)) studentAttend.NumberOfAttendendLec++;
            //                         else studentAttend.NumberOfAbsentedLec++;
            //                         findFlag = true;
            //                         break;
            //                     }


            //                 }
            //                 if (findFlag) { continue; }
            //             }




            //             StudentCourseAttandance studentCourseAtt=new StudentCourseAttandance();
            //             studentCourseAtt.CourseName = courseName;
            //             studentCourseAtt.NumberOfLecture = Classes_Courses.FirstOrDefault(x => x.ClassId == Student.ClassID).Courses.FirstOrDefault(course => course.CourseId == courseAttendance.Course_id).LectureNumber;
            //             if (courseAttendance.Students.Any(studentID => studentID == Student.Id)) studentCourseAtt.NumberOfAttendendLec++; 
            //             else studentCourseAtt.NumberOfAbsentedLec++;

            //             studentAttendances.Add(studentCourseAtt);
            //             break;

            //         }

            //     }


            // }
            #endregion


            dataGridView1.DataSource = LoadAllStudentCoursesAttendance(Student);



        }
        private void MoveSidePanel(Control button)
        {
            panelSide.Location = new Point(button.Location.X - button.Location.X, button.Location.Y - 211);
            panelSide1.Location = new Point(button.Location.X, button.Location.Y);
            panelSide2.Location = new Point(button.Location.X, button.Location.Y + 45);
        }



        private void buttonAttendance_Click(object sender, EventArgs e)
        {
            MoveSidePanel(buttonAttendance);

        }




        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            //Close();
            DialogResult dialogResult = MessageBox.Show("Are you want to log out", "log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                timerDateAndTime.Stop();
                Close();
            }
            else
            {
                panelExpand.Hide();
            }
        }


        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            panelExpand.Hide();
            WindowState = FormWindowState.Minimized;
        }


        private void pictureBoxExpand_Click(object sender, EventArgs e)
        {
            if (panelExpand.Visible)
            {
                panelExpand.Visible = false;
            }
            else
                panelExpand.Visible = true;
        }


        private void timerDateAndTime_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            labelTime.Text = now.ToString();
        }


        private void FormDashborad_Load(object sender, EventArgs e)
        {
            panelExpand.Hide();
            labelUsername.Text = Username;
            labelRole.Text = Role;
            ClassValue.Text = ClassName;
            JoiningDateValue.Text = JoinDate;


        }
        private void buttonReport_Click(object sender, EventArgs e)
        {
            MoveSidePanel(buttonReport);
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF (*.pdf)|*.pdf";
                saveFileDialog.FileName = "Result.pdf";
                bool ErrorMassage = false;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        try
                        {
                            File.Delete(saveFileDialog.FileName);

                        }
                        catch (Exception ex)
                        {
                            ErrorMassage = true;
                            MessageBox.Show("Unable to write data in the disk" + ex.Message);

                        }
                    }
                    if (!ErrorMassage)
                    {

                        try
                        {
                            PdfPTable PTable = new PdfPTable(dataGridView1.Columns.Count);
                            PTable.DefaultCell.Padding = 2;
                            PTable.WidthPercentage = 100;
                            PTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(column.HeaderText));
                                PTable.AddCell(pCell);

                            }
                            foreach (DataGridViewRow viewRow in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell dCell in viewRow.Cells)
                                {
                                    PTable.AddCell(dCell.Value.ToString());
                                }
                            }


                            using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);

                                document.Open();
                                document.Add(PTable);
                                document.Close();
                                fileStream.Close();

                            }
                            MessageBox.Show("Data saved successfully", "info");
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("An error happend while saving the data" + ex.Message);
                        }
                    }
                }



            }
            else
            {
                MessageBox.Show("No data is here to save ", "Info");
            }


        }



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ParentOfClassesAndCourses p = comboBox1.SelectedItem as ParentOfClassesAndCourses;
            ////textBox1.Text = p.ID.ToString();
            //var classCourse = Classes_Courses.FirstOrDefault(x => x.ClassId == p.ID);


            //#region generate the dropdownList valuse for each different Class

            //var ComboBox2Values = new List<Courses>();
            //if (classCourse != null)
            //{
            //    foreach (var coursID in classCourse.Courses)
            //    {
            //        foreach (var Course in StudentsListGenerators.Courses)
            //        {
            //            if (coursID.CourseId == Course.ID)
            //            {
            //                ComboBox2Values.Add(Course);
            //                break;

            //            }
            //        }



            //    }
            //    textBox1.Text = Classes_Courses.FirstOrDefault(x => x.ClassId == p.ID).ToString();

            //}
            //else
            //{
            //    ComboBox2Values = [];
            //    comboBox2.Text = "";

            //}

            //comboBox2.DataSource = ComboBox2Values;
            //#endregion


        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            ParentOfClassesAndCourses selectedValue = comboBox2.SelectedItem as ParentOfClassesAndCourses;


            if (selectedValue.ID > 0)
            {
                dataGridView1.DataSource = LoadAllStudentCoursesAttendance(Student).Where(attend => attend.CourseName == selectedValue.Name).ToList();
            }
            else
            {
                dataGridView1.DataSource = LoadAllStudentCoursesAttendance(Student);
            }

        }
    }



}
