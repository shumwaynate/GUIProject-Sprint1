using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace GUIProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public static int shape = 1;
        public static int action = 1;
        public static double length = 1;
        public static double width = 1;
        public static double radius = 1;
        private void radioButton1_CheckedChanged(object sender, EventArgs e) //square
        {
            if (radioButton1.Enabled ==true || radioButton2.Enabled == true) { 
                textBox1.Enabled = true;
                textBox2.Enabled = false;
                textBox2.Text = string.Empty;
                textBox3.Enabled = false;
                textBox3.Text = string.Empty;
            }
            if (radioButton1.Enabled == true)
            {
                pictureBox1.Image = Image.FromFile("../../Pictures/Square.png");
            }
            shape = 1;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) //Rectangle
        {
            if (radioButton2.Enabled == true) { 
                textBox1.Enabled = true;
                textBox2.Enabled = false;
                textBox2.Text = string.Empty;
                textBox3.Enabled = true;
                pictureBox1.Image = Image.FromFile("../../Pictures/Rectangle.png");
            }
            shape = 2;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e) //Circle
        {
            if (radioButton3.Enabled == true) { 
                textBox1.Enabled = false;
                textBox1.Text = string.Empty;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox3.Text = string.Empty;
                pictureBox1.Image = Image.FromFile("../../Pictures/Circle.png");
            }
            shape = 3;
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e) //Perimeter
        {
            action = 1;
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e) //Area
        {
            action = 2;
        }
        private void textBox1_TextChanged(object sender, EventArgs e) //side length
        {
            if (textBox1.Text != string.Empty)
            {
                length = Convert.ToDouble(textBox1.Text);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e) //side width
        {
            if (textBox3.Text != string.Empty)
            {
                width = Convert.ToDouble(textBox3.Text);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) //Circle radius
        {
            if (textBox2.Text != string.Empty)
            {
                radius = Convert.ToDouble(textBox2.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e) //Calculate
        {
            string answer = Calculate(length, width, radius, shape, action);
            DialogResult dr = MessageBox.Show(answer, "Calculation Complete");
        }
        
        public static string Calculate(double length, double width, double radius, int shape, int action)
        { 
            if(shape == 1){
               if(action== 1){
                   return String.Format("The Perimeter is {0,0:0.00}",getSquarePer(length));
               }
               else{
                   return String.Format("The Area is {0,0:0.00}",getSquareArea(length));
               }
            }
            else if (shape == 2){
                if (action == 1){
                    return String.Format("The Perimeter is {0,0:0.00}", getRectanglePer(width, length));
                }
                else{
                    return String.Format("The Area is {0,0:0.00}", getRectangleArea(width, length));
                }
             }
            else if (shape == 3){
                if (action == 1){
                    return "The Perimeter is "+ getCirclePer(radius);
                }
                else{
                    return "The Area is " +getCircleArea(radius);
                }
            }
            else { return "Something went terribly wrong!!!"; }
          
        }


       public static double getSquarePer(double length){
            return length * 4;
        }
        public static double getSquareArea(double length){
            return length * length;
        }
        public static double getRectanglePer(double width, double height){
            return (2 * width) + (2 * height);
        }
        public static double getRectangleArea(double width, double height){
        return width * height;
        }
        public static String getCirclePer(double radius){
            double dubRadius = radius * 2;


            String perimeter = String.Format("{0, 0:0.00 }π", dubRadius);
            return perimeter;
        }
        public static String getCircleArea(double radius){
            double squRadius = radius * radius;
            return String.Format("{0,0:0.00}π", squRadius);
        }

        private void pictureBox1_Click(object sender, EventArgs e) //shape picture box
        {
            
        }
    }
}
