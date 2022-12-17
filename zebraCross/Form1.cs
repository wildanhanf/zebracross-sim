using System;
using System.Drawing;
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
        Timer carTimer1 = new Timer();
        Timer carTimer2 = new Timer();

        Boolean isCrossing = false;
        Boolean isResetting = false;
        int walkSpriteIndex = 0;


        public Form1()
        {
            InitializeComponent();
            this.Text = "Mini Project: Zebra Cross Simulation";
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            //auto maximized window ke screen desktop
            // this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            carRedLight.FlatStyle = FlatStyle.Flat;
            carRedLight.FlatAppearance.BorderSize = 0;

            carYellowLight.FlatStyle = FlatStyle.Flat;
            carYellowLight.FlatAppearance.BorderSize = 0;

            carGreenLight.FlatStyle = FlatStyle.Flat;
            carGreenLight.FlatAppearance.BorderSize = 0;

            pedestrianRedLight.FlatStyle = FlatStyle.Flat;
            pedestrianRedLight.FlatAppearance.BorderSize = 0;

            pedestrianGreenLight.FlatStyle = FlatStyle.Flat;
            pedestrianGreenLight.FlatAppearance.BorderSize = 0;

            // split walking sprite
            walkFrames = new Bitmap[] {
                Properties.Resources.walk_0,Properties.Resources.walk_1,Properties.Resources.walk_2,Properties.Resources.walk_3,
                Properties.Resources.walk_4,Properties.Resources.walk_5,
            };

            // lower inactive light opacity
            carRedLight.BackColor = ControlPaint.Dark(Color.Red, 50f);
            carYellowLight.BackColor = ControlPaint.Dark(Color.Yellow, 50f);
            pedestrianGreenLight.BackColor = ControlPaint.Dark(Color.Lime, 50f);

            car_StartAnimation();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();

            // walking
            if (walkTimer.Enabled == true)
            {
                pedestrian.Left += 10;
                pedestrian.Image = walk_Frame2Draw();
            }

            if (carTimer1.Enabled == true)
            {
                car1.Top -= rng.Next(20, 30);
                car2.Top -= rng.Next(20, 30);

            }
        }

        private void car_StartAnimation()
        {
            carTimer1.Interval = 105;
            carTimer1.Tick += timerTick;
            carTimer1.Start();

            carTimer2.Interval = 105;
            carTimer2.Tick += timerTick;
            carTimer2.Start();
        }

        private void pedestrian_StartAnimation()
        {
            walkTimer.Interval = 55;
            walkTimer.Tick += timerTick;
            walkTimer.Start();
        }

        private void toggleCarTrafficLight(TrafficLight color)
        {
            switch (color)
            {
                case TrafficLight.Red:
                    carRedLight.BackColor = Color.Red;
                    carYellowLight.BackColor = ControlPaint.Dark(Color.Yellow, 50f);
                    carGreenLight.BackColor = ControlPaint.Dark(Color.Lime, 50f);
                    break;
                case TrafficLight.Yellow:
                    carRedLight.BackColor = ControlPaint.Dark(Color.Red, 50f);
                    carYellowLight.BackColor = Color.Yellow;
                    carGreenLight.BackColor = ControlPaint.Dark(Color.Lime, 50f);
                    break;
                case TrafficLight.Green:
                    carRedLight.BackColor = ControlPaint.Dark(Color.Red, 50f);
                    carYellowLight.BackColor = ControlPaint.Dark(Color.Yellow, 50f);
                    carGreenLight.BackColor = Color.Lime;
                    break;
            }
        }

        private void togglePedestrianTrafficLight(TrafficLight color)
        {
            switch (color)
            {
                case TrafficLight.Red:
                    pedestrianRedLight.BackColor = Color.Red;
                    pedestrianGreenLight.BackColor = ControlPaint.Dark(Color.Lime, 50f);
                    break;
              
                case TrafficLight.Green:
                    pedestrianRedLight.BackColor = ControlPaint.Dark(Color.Red, 50f);
                    pedestrianGreenLight.BackColor = Color.Lime;
                    break;
            }
        }

        private Bitmap walk_Frame2Draw()
        {
            if (walkSpriteIndex < walkFrames.Length)
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

        private void btnGreen_Click(object sender, EventArgs e)
        {
            isCrossing = true;
            toggleCarTrafficLight(TrafficLight.Yellow);
        }

        private void car1_LocationChanged(object sender, EventArgs e)
        {
            if (car1.Top < -300)
            {
                car1.Top = rng.Next(600, 1400);
            }

            if (isCrossing)
            {
                if(car1.Top < 620 || car1.Top > 0)
                {
                    carTimer1.Stop();
                    togglePedestrianTrafficLight(TrafficLight.Green);
                    toggleCarTrafficLight(TrafficLight.Red);
                    pedestrian_StartAnimation();
                }
            }
        }

        private void car2_LocationChanged(object sender, EventArgs e)
        {
            if (car2.Top < -300)
            {
                car2.Top = rng.Next(600, 1400);
            }

            if (isCrossing)
            {
                if(car2.Top < 620 || car2.Top > 0)
                {
                    carTimer2.Stop();
                    togglePedestrianTrafficLight(TrafficLight.Green);
                    toggleCarTrafficLight(TrafficLight.Red);
                    pedestrian_StartAnimation();
                }
            }
        }

        private void pedestrian_LocationChanged(object sender, EventArgs e)
        {
            if (pedestrian.Left > 1200)
            {
                pedestrian.Left = -10;
                isResetting = true;
                isCrossing = false;
                toggleCarTrafficLight(TrafficLight.Yellow);
                togglePedestrianTrafficLight(TrafficLight.Red);
            }

            if(isResetting)
            {
                if(pedestrian.Left >= 20)
                {
                    isResetting = false;
                    walkTimer.Stop();
                    pedestrian.Image = walkFrames[0];
                    Task.Delay(2000).Wait();
                    toggleCarTrafficLight(TrafficLight.Green);
                    car_StartAnimation();
                }
            }
        }

        private void bgPanel_Paint(object sender, PaintEventArgs e)
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

        private void timerTick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
