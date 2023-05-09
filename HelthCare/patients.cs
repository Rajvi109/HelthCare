using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace HelthCare
{
    public partial class patients : Form
    {
        Functions Con;
        public patients()
        {
            InitializeComponent();
            Con = new Functions();
            ShowPatients();
        }
        private void ShowPatients()
        {
            string Query = "Select * from Patientstbl";
            PatientsList.DataSource = Con.GetData(Query); 
        }

        

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(PatNameTb.Text ==" "||PatPhoneTb.Text==" "||PatAddTb.Text==" "|| GenCb.SelectedIndex== -1 )
            {
                MessageBox.Show("Missing Data!!!!");
            }
            else
            {
                string Patient = PatNameTb.Text;
                string Gender = GenCb.SelectedItem.ToString();
                string BDate = DOBTb.Value.Date.ToString();
                string Phone = PatPhoneTb.Text;
                string Address = PatAddTb.Text;
                string Query = "insert into Patientstbl values('{0}','{1}','{2}','{3}','{4}' )";
                Query = string.Format(Query, Patient, Gender, BDate, Phone, Address);
                Con.SetData(Query);
                ShowPatients();
                Clear();
                MessageBox.Show("Patient Added!!!");
            }
        }
        int Key = 0;
        private void PatientsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatNameTb.Text = PatientsList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.SelectedItem = PatientsList.SelectedRows[0].Cells[2].Value.ToString();
            DOBTb.Text= PatientsList.SelectedRows[0].Cells[3].Value.ToString();
            PatPhoneTb.Text = PatientsList.SelectedRows[0].Cells[4].Value.ToString(); 
            PatAddTb.Text = PatientsList.SelectedRows[0].Cells[5].Value.ToString();
            if(PatNameTb.Text=="")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(PatientsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

            if (PatNameTb.Text == " " || PatPhoneTb.Text == " " || PatAddTb.Text == " " || GenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!!!");
            }
            else
            {
                string Patient = PatNameTb.Text;
                string Gender = GenCb.SelectedItem.ToString();
                string BDate = DOBTb.Value.Date.ToString();
                string Phone = PatPhoneTb.Text;
                string Address = PatAddTb.Text;
                string Query = "update Patientstbl set PatName='{0}',PatGen='{1}',PatDob='{2}',PatPhone='{3}',PatAdd='{4}' where PatCode='{5}' ";
                Query = string.Format(Query, Patient, Gender, BDate, Phone, Address,Key);
                Con.SetData(Query);
                ShowPatients();
                Clear();
                MessageBox.Show("Patient Updated!!!");
            }

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

            if (Key==0)
            {
                MessageBox.Show("Select Data!!!!");
            }
            else
            {
               
                string Query = "Delete from Patientstbl  where PatCode={0} ";
                Query = string.Format(Query, Key);
                Con.SetData(Query);
                ShowPatients();
                Clear();
                MessageBox.Show("Patient Deleted!!!");
            }
        }
        private void Clear()
        {
            PatNameTb.Text = "";
            GenCb.SelectedIndex = -1;
            PatPhoneTb.Text = "";
            PatAddTb.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            patients Obj = new patients();
            Obj.Show();
            this.Hide();
        }
         
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tests Obj = new tests();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            diagnosis Obj = new diagnosis();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
