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
        // variables for walking animation
        Bitmap walkFrame;
        Bitmap[] walkFrames;
        Timer walkTimer = new Timer();
        float positionX = 100;
        float positionY = 350;
        int walkSpriteIndex = 0;


        public Form1()
        {
            InitializeComponent();
            this.Text = "Mini Project: Zebra Cross Simulation";

            //auto maximized window ke screen desktop
            // this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            button1.BackColor = Color.Red;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button2.BackColor = Color.Yellow;

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            button3.BackColor = Color.Green;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;

            // split walking sprite
            walkFrames = new Bitmap[] {
                new Bitmap(Properties.Resources.walk_0),new Bitmap(Properties.Resources.walk_1),
                new Bitmap(Properties.Resources.walk_2),new Bitmap(Properties.Resources.walk_3),
                new Bitmap(Properties.Resources.walk_4),new Bitmap(Properties.Resources.walk_5),
            };
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen p = new Pen(Color.White);

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

            // zebracross
            int xZebracross = 140;
            while(true)
            {
                xZebracross += 50;
                if(xZebracross > 900)
                {
                    break;
                }
                else
                {
                    g.FillRectangle(Brushes.White, new Rectangle(xZebracross, 400, 30, 200));
                }
            }

            // walking
            if(walkTimer.Enabled == true)
            {
                positionX += 7;
                e.Graphics.DrawImage(walk_Frame2Draw(), positionX, positionY);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // lampu hijau
            walkTimer.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // lampu kuning
            positionX = 100;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // lampu merah
            walk_Animator();

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
