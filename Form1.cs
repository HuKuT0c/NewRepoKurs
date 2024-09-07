using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Repeat
{
    public partial class Form1 : Form
    {

        List<Particle> particles = new List<Particle>();
        //Emitter emitter = new Emitter();
        Emitter emitter;
        private int MousePositionX = 0;
        private int MousePositionY = 0;
        private int tbdValue1 = 100;
        double angle;
        double pos = 1, speed = 0.1, m, n;
        int Xvector1, Xvector2, Yvector1, Yvector2;
        int Xcirlce = 100;
        int Ycirlce = 100;

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // тут теперь обновляем эмиттер
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black); //черный фон
                task1(g);
                emitter.Render(g); // а тут теперь рендерим через эмиттер
            }
            // обновить picDisplay
            picDisplay.Invalidate();
        }

    
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {

           

        }
      
        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            
           
        }

       
        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            Xcirlce = radiusDirection.Value;
            Ycirlce = Xcirlce;
        }


        private void speedBar_Scroll(object sender, EventArgs e)
        {
            m = speedBar.Value;
            n = 100;
            speed = m / n;
        }

      
        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
       
        

       
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

       
       

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
           
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
           
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
        }

        private void task1(Graphics g)
        {
            tbdValue1 = radiusDirection.Value;
            g.DrawEllipse(new Pen(Color.White, 4), picDisplay.Width / 2 - Xcirlce / 2,
           picDisplay.Height / 2 - Ycirlce / 2 + 1, Xcirlce, Ycirlce);
            pos = pos + speed;
            emitter.X = (int)(picDisplay.Width / 2 + Xcirlce / 2 * Math.Cos(pos));
            emitter.Y = (int)(picDisplay.Height / 2 + Ycirlce / 2 * Math.Sin(pos));
            //координаты вектора радиуса
            Xvector1 = picDisplay.Width / 2 - emitter.X;
            Yvector1 = picDisplay.Height / 2 - emitter.Y;

            Yvector2 = -5;
            Xvector2 = 5 - emitter.Y;

            angle = (290 / Math.PI) * Math.Acos(Math.Cos((Yvector1 * Yvector2 + Xvector2
           * Xvector1) / (Math.Sqrt(Math.Pow(Yvector2, 2) + Math.Pow(Xvector2, 2)) *
           Math.Sqrt(Math.Pow(Xvector1, 2) + Math.Pow(Yvector1, 2)))));
            //в зависимости от четверти оркужности задаём определённый угл поворота
            if (emitter.X < picDisplay.Width / 2 & emitter.Y > picDisplay.Height / 2)
            {
                emitter.Direction = -(int)(angle);
            }
            if (emitter.X < picDisplay.Width / 2 & emitter.Y < picDisplay.Height / 2)
            {

                emitter.Direction = 180 + (int)(angle);
            }
            if (emitter.X > picDisplay.Width / 2 & emitter.Y < picDisplay.Height / 2)
            {
                emitter.Direction = 180 - (int)(angle);
            }
            if (emitter.X > picDisplay.Width / 2 & emitter.Y > picDisplay.Height / 2)
            {
                emitter.Direction = (int)(angle);
            }
            emitter.Spreading = 100;
        }

    }
}
