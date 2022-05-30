using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WINFORM2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "ANKET";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            bool res = false;
            if (CtextBox2 && CtextBox3 && CtextBox4 && CtextBox5 && CtextBox7 && CMasket && (radioButton1.Checked || radioButton2.Checked))
                res = true;
            if (res)
            {
                User user = new User(textBox3.Text, textBox2.Text, textBox4.Text, maskedTextBox1.Text, textBox7.Text, textBox5.Text, radioButton1.Checked ? "Male" : "Female", dateTimePicker1.Value);
                if (!File.Exists(textBox2.Text.ToUpper()) && CtextBox2)
                {
                    File.WriteAllText(textBox2.Text.ToUpper(), JsonConvert.SerializeObject(user));
                    MessageBox.Show("Success");
                    Reset();
                }
                else
                    MessageBox.Show("This user already existis");
            }
            else
            {
                MessageBox.Show("NULL");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CheckTexBox(ref textBox1, ref CtextBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CtextBox1)
            {
                User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(textBox1.Text.ToUpper()));
                textBox2.Text = user.Surname;
                textBox3.Text = user.Name;
                textBox4.Text = user.ParentName;
                textBox7.Text = user.Country;
                textBox5.Text = user.City;
                maskedTextBox1.Text = user.phone;
                dateTimePicker1.Value = user.BirthDate;
                if (user.Gender == "Male")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;

                textBox1.ResetText();
                textBox1.BackColor = Color.White;
            }
            else
                MessageBox.Show("Error");
        }

        bool Reseting = false;
        void Reset()
        {
            Reseting = true;
            textBox2.ResetText();
            textBox1.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
            textBox5.ResetText();
            textBox7.ResetText();
            maskedTextBox1.ResetText();
            dateTimePicker1.Value = DateTime.Now;
            radioButton1.Checked = true;
            Reseting = false;
        }
        void CheckTexBox(ref TextBox textBox, ref bool control, string regex = "^ ([A - Za - z] + ([ ]?[a - z]?['-]?[A-Za-z]+)*)$")
        {
            if (Reseting)
                return;
            if (textBox.Text.Length >= 3)

                if (new Regex("^([A-Za-z]+([ ]?[a-z]?['-]?[A-Za-z]+)*)$").IsMatch(textBox.Text))
                {
                    textBox.BackColor = Color.White;
                    control = true;
                }
                else
                {
                    textBox.BackColor = Color.Red;
                    control = false;
                }
            else
            {
                control = false;
                textBox.BackColor = Color.Red;
            }
        }
        void CheckTexBox(ref MaskedTextBox textBox, ref bool control, string regex = "^ ([A - Za - z] + ([ ]?[a - z]?['-]?[A-Za-z]+)*)$")
        {
            if (Reseting)
                return;

            if (textBox.Text.Length >= 3)
            {
                textBox.BackColor = Color.White;
                control = true;
            }
            else
            {
                control = false;
                textBox.BackColor = Color.Red;
            }
        }

        bool CtextBox1 = false;
        bool CtextBox2 = false;
        bool CtextBox3 = false;
        bool CtextBox4 = false;
        bool CtextBox7 = false;
        bool CtextBox5 = false;
        bool CMasket = false;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CheckTexBox(ref textBox2, ref CtextBox2);

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            CheckTexBox(ref textBox3, ref CtextBox3);

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            CheckTexBox(ref textBox4, ref CtextBox4);

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            CheckTexBox(ref textBox7, ref CtextBox7);

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            CheckTexBox(ref textBox5, ref CtextBox5);

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            CheckTexBox(ref maskedTextBox1, ref CMasket);
        }
    }
}
