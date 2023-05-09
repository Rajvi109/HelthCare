using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelthCare
{
    public partial class diagnosis : Form
    {
        Functions Con;

        public diagnosis()
        {
            InitializeComponent();
            Con = new Functions();
            GetPatients();
            GetTest();
            ShowDiagnosis();
           
        }
        private void ShowDiagnosis()
        {
            string Query = "Select * from DiagnosisTbl ";
            DiagnosisList.DataSource = Con.GetData(Query);
        }
        private void GetPatients()
        {
            string Query = "Select * from Patientstbl";
            PatientCb.DisplayMember = Con.GetData(Query).Columns["PatName"].ToString();
            PatientCb.ValueMember = Con.GetData(Query).Columns["PatCode"].ToString();
            PatientCb.DataSource = Con.GetData(Query);
        }
        private void GetTest()
        {
            string Query = "Select * from TestTbl";
            TestCb.DisplayMember = Con.GetData(Query).Columns["TestName"].ToString();
            TestCb.ValueMember = Con.GetData(Query).Columns["TestCode"].ToString();
            TestCb.DataSource = Con.GetData(Query);
        }
        private void GetCost()
        {
            string Query = "select * from TestTbl where TestCode={0}";
            Query = string.Format(Query, TestCb.SelectedValue.ToString());
            foreach(DataRow dr in Con.GetData(Query).Rows)
            {
                CostTb.Text = dr["TestCost"].ToString();
            }
        }
        private void Clear()
        {
            ResultTb.Text= " ";
            CostTb.Text = " ";
            TestCb.SelectedIndex = -1; 
            PatientCb.SelectedIndex = -1;
        }


        private void save_Click(object sender, EventArgs e)
        {
            if (PatientCb.SelectedIndex == -1 || CostTb.Text == " " || ResultTb.Text == " " )
            {
                MessageBox.Show("Missing Data!!!!");
            }
            else
            {
                string DDate = DiagDateTb.Value.Date.ToString();
                int Patient = Convert.ToInt32(PatientCb.SelectedValue.ToString());
                int Test = Convert.ToInt32(TestCb.SelectedValue.ToString());
                int Cost = Convert.ToInt32(CostTb.Text);
                string Result= ResultTb.Text;

                string Query = "insert into DiagnosisTbl values('{0}',{1},{2},{3},'{4}')";
                Query = string.Format(Query, DDate,Patient,Test, Cost, Result);
                Con.SetData(Query);
                ShowDiagnosis();
                Clear();
                MessageBox.Show("Diagnosis Added!!!");
            }
        }

        
        

        private void TestCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCost();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (PatientCb.SelectedIndex == -1 || CostTb.Text == " " || ResultTb.Text == " ")
            {
                MessageBox.Show("Missing Data!!!!");
            }
            else
            {
                string DDate = DiagDateTb.Value.Date.ToString();
                int Patient = Convert.ToInt32(PatientCb.SelectedValue.ToString());
                int Test = Convert.ToInt32(TestCb.SelectedValue.ToString());
                int Cost = Convert.ToInt32(CostTb.Text);
                string Result = ResultTb.Text;

                string Query = "Update DiagnosisTbl set DiagDate='{0}',Patient={1},Test={2},Cost={3},Result='{4}' where DiagCode={5}";
                Query = string.Format(Query, DDate, Patient, Test, Cost, Result,Key);
                Con.SetData(Query);
                ShowDiagnosis();
                Clear();
                MessageBox.Show("Diagnosis Updated!!!");
            }
        }
        int Key = 0;
        private void DiagnosisList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DiagDateTb.Text = DiagnosisList.SelectedRows[0].Cells[1].Value.ToString();
            PatientCb.SelectedItem = DiagnosisList.SelectedRows[0].Cells[2].Value.ToString();
            TestCb.Text = DiagnosisList.SelectedRows[0].Cells[3].Value.ToString();
            CostTb.Text = DiagnosisList.SelectedRows[0].Cells[4].Value.ToString();
            ResultTb.Text = DiagnosisList.SelectedRows[0].Cells[5].Value.ToString();
            if (CostTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DiagnosisList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select Data!!!!");
                
            }
            else
            {
             

             string Query = "Delete from DiagnosisTbl where DiagCode='{0}' ";
             Query = string.Format(Query, Key);
             Con.SetData(Query);
             ShowDiagnosis();
             Clear();
             MessageBox.Show("Diagnosis Deleted!!!");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            patients Obj = new patients();
            Obj.Show();
            this.Hide();
        }

        

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            diagnosis Obj = new diagnosis();
            Obj.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            tests Obj = new tests();
            Obj.Show();
            this.Hide();
        }
    }
}
