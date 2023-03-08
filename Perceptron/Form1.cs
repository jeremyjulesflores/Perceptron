using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Perceptron
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button7.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
        }

        Perceptron perceptron;
        public int input1;
        public int input2;
        public void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.BackColor != Color.Black)
            {
                button.BackColor = Color.Black;
            }
            else
            {
                button.BackColor = Color.White;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button7.Enabled = true;
            button5.BackColor = Color.Green;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            perceptron = new Perceptron();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {                             
        }

        private void button7_Click(object sender, EventArgs e) // Train button
        {
            if(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;

                if (radioButton1.Checked)//OR
                {
                    perceptron.Train(1, 0, 1, Convert.ToInt32(textBox1.Text));
                    perceptron.Train(0, 1, 1, Convert.ToInt32(textBox1.Text));
                    perceptron.Train(1, 1, 1, Convert.ToInt32(textBox1.Text));
                    perceptron.Train(0, 0, 0, Convert.ToInt32(textBox1.Text));

                }
                else if (radioButton2.Checked)//AND
                {
                    perceptron.Train(1, 0, 0, Convert.ToInt32(textBox1.Text));
                    perceptron.Train(0, 1, 0, Convert.ToInt32(textBox1.Text));
                    perceptron.Train(1, 1, 1, Convert.ToInt32(textBox1.Text));
                    perceptron.Train(0, 0, 0, Convert.ToInt32(textBox1.Text));
                }
                else//NOR
                {
                    perceptron.Train(1, 1, 0, Convert.ToInt32(textBox1.Text));
                    perceptron.Train(0, 0, 1, Convert.ToInt32(textBox1.Text));
                    perceptron.Train(1, 0, 0, Convert.ToInt32(textBox1.Text));
                    perceptron.Train(0, 1, 0, Convert.ToInt32(textBox1.Text));
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;

            if(button1.BackColor != Color.Black)
            {
                input1 = 0;
            }
            else
            {
                input1 = 1;
            }

            if(button2.BackColor != Color.Black)
            {
                input2 = 0;

            }
            else
            {
                input2 = 1;
            }

            int output = perceptron.Activate(input1, input2);

            if(output == 0)
            {
                label4.Text = "Value : 0";

            }
            else
            {
                label4.Text = "Value : 1";
                button3.BackColor = Color.Black;
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            button5.BackColor = Color.Red;
            button7.Enabled = false;

            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
        }
    }
}
                          