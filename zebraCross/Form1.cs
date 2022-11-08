using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zebraCross
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Mini Project: Zebra Cross Simulation";

            //auto maximized window ke screen desktop
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            button1.BackColor = Color.Red;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button2.BackColor = Color.Yellow;

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            button3.BackColor = Color.Green;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen p = new Pen(Color.White);

            

            //latar jalan
            g.FillRectangle(Brushes.Gray, new Rectangle(0, 0, 2000, 800));

            //
            g.FillRectangle(Brushes.AliceBlue, new Rectangle(0, 0, 2000, 150));

            //bikin pembatas jalan kiri 
            PointF j1 = new PointF(0, 150); //titik jalan kiri atas
            PointF j2 = new PointF(170, 150); //titik jalan kanan atas
            PointF j3 = new PointF(170, 800); //titik jalan kanan bawah
            PointF j4 = new PointF(0, 800); //titik jalan kiri bawah

            //diubah menjadi array
            PointF[] jalan1 ={
                j1, j2, j3, j4
            };
            g.FillPolygon(Brushes.LightGray, jalan1);

            //bikin pembatas jalan kanan 
            PointF j5 = new PointF(1365, 150); //titik jalan kiri atas
            PointF j6 = new PointF(1535, 150); //titik jalan kanan atas
            PointF j7 = new PointF(1535, 800); //titik jalan kanan bawah
            PointF j8 = new PointF(1365, 800); //titik jalan kiri bawah

            //diubah menjadi array
            PointF[] jalan2 ={
                j5, j6, j7, j8
            };
            g.FillPolygon(Brushes.LightGray, jalan2);

            //bikin traffic light for vehicles
            PointF t1 = new PointF(100, 400); //titik jalan kiri atas
            PointF t2 = new PointF(130, 400); //titik jalan kanan atas
            PointF t3 = new PointF(130, 650); //titik jalan kanan bawah
            PointF t4 = new PointF(100, 650); //titik jalan kiri bawah

            //diubah menjadi array
            PointF[] forVehicles1 ={
                t1 , t2, t3, t4
            };
            g.FillPolygon(Brushes.Black, forVehicles1);

            PointF t5 = new PointF(80, 300); //titik jalan kiri atas
            PointF t6 = new PointF(150, 300); //titik jalan kanan atas
            PointF t7 = new PointF(150, 450); //titik jalan kanan bawah
            PointF t8 = new PointF(80, 450); //titik jalan kiri bawah

            //diubah menjadi array
            PointF[] forVehicles2 ={
                t5, t6, t7, t8 
            };
            g.FillPolygon(Brushes.Black, forVehicles2);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}
