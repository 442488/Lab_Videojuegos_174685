using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collision
{
    public partial class CANVAS : Form
    {

        Ball ball;
        Bitmap bmp;
        Graphics g;
         


        public CANVAS()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {

            ball = new Ball(new Random(), PB1.Size);
            bmp = new Bitmap(PB1.Width, PB1.Height);
            g = Graphics.FromImage(bmp);
            PB1.Image = bmp;
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.Transparent);
            ball.Update();
            ball.Render(g);

            label1.Text = "DIR: " + ball.dir.ToString();
            label2.Text = "SPEED: " + ball.speedX + "  ,  " + ball.speedY;
            label3.Text = "SIZE: " + ball.diameter;


            PB1.Invalidate();
        }

        private void BTN_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}
