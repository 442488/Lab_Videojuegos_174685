using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Collision
{

    public class Ball
    {

        public float diameter, radio;
        public Point pos, dir;
        public Size space;
        public int speedX, speedY;



        public Ball(Random rand, Size size)
        {

            do
            {
             pos = new Point(rand.Next(0, size.Width), rand.Next(0, size.Height));
            } while (LimitarAparicion(pos.X, pos.Y, 110, 100, 110, 200) || LimitarAparicion(pos.X, pos.Y, 360, 210, 160, 90));

            dir = new Point(1 + rand.Next(size.Width) / 100, 1 + rand.Next(size.Height) / 100);

            speedX = rand.Next(-10, 10);
            speedY = rand.Next(-10, 10);

            space = size;
            diameter = rand.Next(15, 70);
            radio = diameter / 2;

        }

        private bool LimitarAparicion(int x, int y, int rectX, int rectY, int rectWidth, int rectHeight)
        {
            return x >= rectX && x <= rectX + rectWidth && y >= rectY && y <= rectY + rectHeight;
        }


        public void Render(Graphics g)
        {
            g.FillEllipse(Brushes.Yellow, pos.X - radio, pos.Y - radio, diameter, diameter);
            g.DrawEllipse(Pens.AliceBlue, pos.X - radio, pos.Y - radio, diameter, diameter);
            g.FillEllipse(Brushes.Gray, pos.X - 2, pos.Y, 4, 4);

            g.DrawRectangle(Pens.Pink, 100, 90, 100, 190);
            g.DrawRectangle(Pens.Pink, 350, 200, 150, 80);
        }


        public void Update()
        {
            //medidas del rectangulo1
            int rectangleX1 = 100;
            int rectangleY1 = 90;
            int rectangleW1 = 100;
            int rectangleH1 = 190;

            //medidas del cuadrado
            int squareX2 = 350;
            int squareY2 = 200;
            int squareW2 = 150;
            int squareH2 = 80;


            if ((pos.X - radio) <= 2)
            {
                pos.X = 3 + (int)radio;
                speedX *= -1;
            }

            if ((pos.X + radio) >= space.Width -2)
            {
                pos.X = (int)(space.Width - radio);
                speedX *= -1;
            }

            if ((pos.Y - radio) <= 2)
            {
                pos.Y = 3 + (int)radio;
                speedY *= -1;
            }

            if ((pos.Y + radio) >= space.Height - 2)
            {
                pos.Y = (int)(space.Height - radio);
                speedY *= -1;
            }

            //Colision del rectangulo y cuadrado 

            if (pos.X - radio <= rectangleX1 + rectangleW1 && pos.X + radio >= rectangleX1 && pos.Y - radio <= rectangleY1 + rectangleH1 && pos.Y + radio >= rectangleY1)
            {
                
              if ((pos.X - radio <= rectangleX1 && speedX < 0) || (pos.X + radio >= rectangleX1 + rectangleW1 && speedX > 0))
                {
                    speedX *= -1;
                    pos.X = (speedX > 0) ? rectangleX1 - (int)radio - 1 : rectangleX1 + rectangleW1 + (int)radio + 1;
                }

              
              if ((pos.Y - radio <= rectangleY1 && speedY < 0) || (pos.Y + radio >= rectangleY1 + rectangleH1 && speedY > 0))
                {
                    speedY *= -1;
                    pos.Y = (speedY > 0) ? rectangleY1 - (int)radio - 1 : rectangleY1 + rectangleH1 + (int)radio + 1;
                }
            }

            if (pos.X - radio <= squareX2 + squareW2 && pos.X + radio >= squareX2 && pos.Y - radio <= squareY2 + squareH2 && pos.Y + radio >= squareY2)
            {
               
              if ((pos.X - radio <= squareX2 && speedX <= 0) || (pos.X + radio >= squareX2 + squareW2 && speedX >= 0))
                {
                    speedX *= -1;
                    pos.X = (speedX >= 0) ? squareX2 - (int)radio - 1 : squareX2 + squareW2 + (int)radio + 1;
                }

                
             if ((pos.Y - radio <= squareY2 && speedY < 0) || (pos.Y + radio >= squareY2 + squareH2 && speedY >= 0))
                {
                    speedY *= -1;
                    pos.Y = (speedY >= 0) ? squareY2 - (int)radio - 1 : squareY2 + squareH2 + (int)radio + 1;
                }
            }

            float desplazamientoX = speedX * (float)Math.Cos(dir.X);
            float desplazamientoY = speedY * (float)Math.Sin(dir.Y);

            pos.X = (int)(pos.X + desplazamientoX);
            pos.Y = (int)(pos.Y + desplazamientoY);


        }

    }

}

