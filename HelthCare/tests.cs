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
    public partial class tests : Form
    {
        Functions Con;
        public tests()
        {
            InitializeComponent();
            Con = new Functions();
            ShowTest();
        }
        private void ShowTest()
        {
            string Query = "Select * from TestTbl";
            TestList.DataSource = Con.GetData(Query);
        }
        private void Clear()
        {
            TNameTb.Text = "";
            TCostTb.Text = "";
        }
        private void save_Click(object sender, EventArgs e)
        {
            if (TNameTb.Text == " " || TCostTb.Text == " " )
            {
                MessageBox.Show("Missing Data!!!!");
            }
            else
            {
            
                string TName = TNameTb.Text;
                int Cost = Convert.ToInt32(TCostTb.Text);
                string Query = "insert into TestTbl values('{0}',{1})";
                Query = string.Format(Query,TName,Cost);
                Con.SetData(Query);
                ShowTest();
                Clear();
                MessageBox.Show("Test Added!!!");
            }
        }
        int Key = 0;
        private void TestList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TNameTb.Text = TestList.SelectedRows[0].Cells[1].Value.ToString();
            TCostTb.Text = TestList.SelectedRows[0].Cells[2].Value.ToString();
            
            if (TNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(TestList.SelectedRows[0].Cells[0].Value.ToString());
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

                string Query = "Delete from TestTbl  where TestCode={0} ";
                Query = string.Format(Query, Key);
                Con.SetData(Query);
                ShowTest();
                Clear();
                MessageBox.Show("Test Deleted!!!");
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (TNameTb.Text == " " || TCostTb.Text == " ")
            {
                MessageBox.Show("Missing Data!!!!");
            }
            else
            {

                string TName = TNameTb.Text;
                int Cost = Convert.ToInt32(TCostTb.Text);
                string Query = "update TestTbl set TestName='{0}',TestCost={1} where TestCode={2} ";
                Query = string.Format(Query, TName, Cost,Key);
                Con.SetData(Query);
                ShowTest();
                Clear();
                MessageBox.Show("Test Updated!!!");
            }
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

        private void label14_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
