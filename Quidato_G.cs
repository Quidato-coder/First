using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentCRUDApp
{
    public partial class Form1 : Form
    {



        private string connectionString = "SERVER=DESKTOP-6P1LV8Q\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True;";


        public Form1()
        {
            InitializeComponent();
            load_data();

        }
        private void load_data()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String query = "SELECT * FROM Students";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }



        }


        private void button1_Click(object sender, EventArgs e)
        {
            string fname = fname_tb.Text;
            string lname = lname_tb.Text;
            string age = age_tb.Text;
            string course = course_tb.Text;

            if (fname == "" || lname == "" || age == "" || course == "")
            {
                MessageBox.Show("Enter a Value");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String query = "INSERT INTO Students (FirstName, Lastname, Age, Course) VALUES (@FirstName, @LastName, @Age, @Course)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", fname);
                cmd.Parameters.AddWithValue("@LastName", lname);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("Course", course);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student added successfully");
            }
            load_data();

            {

            }

            MessageBox.Show(fname + lname + age + course);
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fname = fname_tb.Text;
            string lname = lname_tb.Text;
            string age = age_tb.Text;
            string course = course_tb.Text;
            string StudentID = studentID_tb.Text;

            if (fname == "" || lname == "" || age == "" || course == "" || StudentID == "")
            {
                MessageBox.Show("Enter a Value");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Students SET Firstname = @FirstName, LastName = @LastName, Age = @Age, Course = @Course WHERE StudentID = @StudentID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", fname);
                cmd.Parameters.AddWithValue("@LastName", lname);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("Course", course);
                cmd.Parameters.AddWithValue("StudentID", StudentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student  updated successfully!");
            }
            load_data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string studentID = studentID = studentID_tb.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Students WHERE StudentID = @StudentID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Deleted Successfully!");

            }

            load_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string studentID = studentID_tb.Text;

            if (studentID == "")
            {
                MessageBox.Show("Enter a Student ID Please!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Students WHERE StudentID = @StudentID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@StudentID", studentID);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;


                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Student Found With This Given ID");
                    return;
                }

                fname_tb.Text = dt.Rows[0]["FirstName"].ToString();
                lname_tb.Text = dt.Rows[0]["LastName"].ToString();
                age_tb.Text = dt.Rows[0]["Age"].ToString();
                course_tb.Text = dt.Rows[0]["Course"].ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            load_data();
            clear_textboxes();
        }

            


        private void clear_textboxes()
        {
            studentID_tb.Text = "";
            fname_tb.Text = "";
            lname_tb.Text = "";
            age_tb.Text = "";
            course_tb.Text = "";

        }



    }
    }


