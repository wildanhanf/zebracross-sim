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
        Random rng = new Random();
        // variables for walking animation
        Bitmap walkFrame;
        Bitmap[] walkFrames;
        Timer walkTimer = new Timer();
        Timer carTimer = new Timer();
        float positionX = 100;
        float positionY = 350;
        int walkSpriteIndex = 0;


        public Form1()
        {
            InitializeComponent();
            this.Text = "Mini Project: Zebra Cross Simulation";

            //auto maximized window ke screen desktop
            // this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;

            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;

            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;

            // split walking sprite
            walkFrames = new Bitmap[] {
                Properties.Resources.walk_0,Properties.Resources.walk_1,Properties.Resources.walk_2,Properties.Resources.walk_3,
                Properties.Resources.walk_4,Properties.Resources.walk_5,
            };

            panel1.BringToFront();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();

            // walking
            if(walkTimer.Enabled == true)
            {
                positionX += 7;
                pedestrian.Left += 14;
                pedestrian.Image = walk_Frame2Draw();
            }

            if (carTimer.Enabled == true)
            {
                car1.Top -= rng.Next(20,30);
                car2.Top -= rng.Next(20,30);
            }
        }

        private void car_Animator()
        {
            carTimer.Interval = 150;
            carTimer.Tick += timer2_Tick;
            carTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            carTimer.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            car_Animator();
        }

        private void walk_Animator()
        {
            walkTimer.Interval = 105;
            walkTimer.Tick += timer1_Tick;
            walkTimer.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private Bitmap walk_Frame2Draw()
        {
            if(walkSpriteIndex < walkFrames.Length)
            {
                walkFrame = walkFrames[walkSpriteIndex];
                walkSpriteIndex++;
            }
            else
            {
                walkSpriteIndex = 0;
            }
            return walkFrame;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            walkTimer.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            walk_Animator();
        }

        private void car1_LocationChanged(object sender, EventArgs e)
        {
            if (car1.Top < -300)
            {
                car1.Top = rng.Next(600,1400);
            }

            if(car2.Top < -300)
            {
                car2.Top = rng.Next(600, 1400);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //latar jalan
            g.FillRectangle(Brushes.Gray, new Rectangle(0, 0, 1064, 680));

            //bikin pembatas jalan kiri 
            PointF j1 = new PointF(0, 90); //titik jalan kiri atas
            PointF j2 = new PointF(170, 90); //titik jalan kanan atas
            PointF j3 = new PointF(170, 680); //titik jalan kanan bawah
            PointF j4 = new PointF(0, 680); //titik jalan kiri bawah

            //diubah menjadi array
            PointF[] jalan1 ={
                j1, j2, j3, j4
            };
            g.FillPolygon(Brushes.LightGray, jalan1);

            //bikin pembatas jalan kanan 
            PointF j5 = new PointF(944, 90); //titik jalan kiri atas
            PointF j6 = new PointF(1064, 90); //titik jalan kanan atas
            PointF j7 = new PointF(1064, 680); //titik jalan kanan bawah
            PointF j8 = new PointF(944, 680); //titik jalan kiri bawah

            //diubah menjadi array
            PointF[] jalan2 ={
                j5, j6, j7, j8
            };
            g.FillPolygon(Brushes.LightGray, jalan2);

            //bikin traffic light untuk kendaraan (tiang)
            PointF t1 = new PointF(52, 250);
            PointF t2 = new PointF(72, 250);
            PointF t3 = new PointF(72, 400);
            PointF t4 = new PointF(52, 400);

            //diubah menjadi array
            PointF[] forVehicles1 ={
                t1 , t2, t3, t4
            };
            g.FillPolygon(Brushes.Black, forVehicles1);

            // bikin traffic lights untuk kendaraan (box)
            PointF t5 = new PointF(30, 105);
            PointF t6 = new PointF(95, 105);
            PointF t7 = new PointF(95, 250);
            PointF t8 = new PointF(30, 250);

            //diubah menjadi array
            PointF[] forVehicles2 ={
                t5, t6, t7, t8
            };
            g.FillPolygon(Brushes.Black, forVehicles2);

            //bikin traffic light untuk pejalan kaki (tiang)
            PointF p1 = new PointF(962, 270);
            PointF p2 = new PointF(982, 270);
            PointF p3 = new PointF(982, 420);
            PointF p4 = new PointF(962, 420);

            //diubah menjadi array
            PointF[] forPedestrian1 ={
                p1, p2, p3, p4
            };
            g.FillPolygon(Brushes.Black, forPedestrian1);

            // bikin traffic lights untuk pejalan kaki (box)
            PointF p5 = new PointF(950, 175);
            PointF p6 = new PointF(995, 175);
            PointF p7 = new PointF(995, 275);
            PointF p8 = new PointF(950, 275);

            //diubah menjadi array
            PointF[] forPedestrian2 ={
                p5, p6, p7, p8
            };
            g.FillPolygon(Brushes.Black, forPedestrian2);


            // zebracross
            int xZebracross = 140;
            while (true)
            {
                xZebracross += 50;
                if (xZebracross > 900)
                {
                    break;
                }
                else
                {
                    g.FillRectangle(Brushes.White, new Rectangle(xZebracross, 400, 30, 200));
                }
            }
        }

        private void pedestrian_LocationChanged(object sender, EventArgs e)
        {
            if (pedestrian.Left > 1200)
            {
                pedestrian.Left = -10;
            }
        }
    }
}
