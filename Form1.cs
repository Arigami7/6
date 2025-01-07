using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PointRhombLibrary;

namespace MikheevProject6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static public bool IsValidRhomb(List<Point> points, out Rhomb outrhomb)
        {
            double highestY = double.MinValue;
            double lowestY = double.MaxValue;
            double rightmostX = double.MinValue;
            double leftmostX = double.MaxValue;
            Point topPoint = points[0];
            Point bottomPoint = points[0];
            Point rightPoint = points[0];
            Point leftPoint = points[0];
            foreach (Point item in points)
            {
                if (item.X > rightmostX)
                {
                    rightmostX = item.X;
                    rightPoint = item;
                }
                if (item.X < leftmostX)
                {
                    leftmostX = item.X;
                    leftPoint = item;
                }
                if (item.Y > highestY)
                {
                    highestY = item.Y;
                    topPoint = item;
                }
                if (item.Y < lowestY)
                {
                    lowestY = item.Y;
                    bottomPoint = item;
                }
            }

            bool lr = leftPoint.IsOnSameY(rightPoint);
            bool tb = topPoint.IsOnSameX(bottomPoint);

            if (lr && tb && rightPoint.GetDistance(topPoint) == topPoint.GetDistance(leftPoint) && 
                topPoint.GetDistance(leftPoint) == leftPoint.GetDistance(bottomPoint) && 
                leftPoint.GetDistance(bottomPoint) == bottomPoint.GetDistance(rightPoint))
            {
                Rhomb rhomb = new Rhomb(topPoint, bottomPoint, leftPoint, rightPoint);
                outrhomb = rhomb;
                return true;
            }
            else
            {
                outrhomb = null;
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (radioButton1.Checked)
                {

                }
                else if (radioButton2.Checked)
                {

                }
                else
                {
                    MessageBox.Show("Выберите параметр!");
                }
            }
            catch
            {
                MessageBox.Show("Введены некорректные значения!");
            }
        }
    }
}


      
