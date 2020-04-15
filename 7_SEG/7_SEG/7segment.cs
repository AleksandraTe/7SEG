using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7_SEG
{
    public partial class _7segment : UserControl
    {
        private Color ColA { get; set; }
        private Color ColB { get; set; }
        private Color ColC { get; set; }
        private Color ColD { get; set; }
        private Color ColE { get; set; }
        private Color ColF { get; set; }
        private Color ColG { get; set; }
        private Color ColH { get; set; }
        public Color ColOff { get; set; }
        public Color ColOn { get; set; }
        public string Nr  { get; set; }
        public int NumberOfDisplays { get; set; }
        private char Number { get; set; }
        private bool isPoint { get; set; }



        public _7segment()
        {

             ColOff = Color.DarkGray;
             ColOn = Color.Navy;
             Nr = "0";
             NumberOfDisplays = 1;
             InitializeComponent();
            
        }
 
        private void _7segment_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            isPoint = false;

            for (int i = 0; i < NumberOfDisplays; i++)
            {
                int x = NumberOfDisplays - Nr.Length;
                if (i >= x)
                {

                    Number = Nr[i-x];
                    CheckNumber(Number);
                    if (!isPoint)
                    {

                        SegmentHor(ColA, g, 17 + i * 80, 15);
                        SegmentVer(ColB, g, 79 + i * 80, 15);
                        SegmentVer(ColC, g, 79 + i * 80, 75);
                        SegmentHor(ColD, g, 17 + i * 80, 135);
                        SegmentVer(ColE, g, 15 + i * 80, 75);
                        SegmentVer(ColF, g, 15 + i * 80, 15);
                        SegmentHor(ColG, g, 17 + i * 80, 75);
                    }

                    else
                    {
                        SegmentHor(ColA, g, 17 + (i - 1) * 80, 15);
                        SegmentVer(ColB, g, 79 + (i - 1) * 80, 15);
                        SegmentVer(ColC, g, 79 + (i - 1) * 80, 75);
                        SegmentHor(ColD, g, 17 + (i - 1) * 80, 135);
                        SegmentVer(ColE, g, 15 + (i - 1) * 80, 75);
                        SegmentVer(ColF, g, 15 + (i - 1) * 80, 15);
                        SegmentHor(ColG, g, 17 + (i - 1) * 80, 75);
                    }
                    if ((i - x + 1) < Nr.Length)
                    {

                        if (!isPoint)
                        {


                            if (Nr[i - x + 1].Equals('.'))
                            {
                                ColH = ColOn;
                                SegmentPoint(ColH, g, 83 + i * 80, 132);
                                i++;
                                isPoint = true;
                            }
                            else
                            {
                                ColH = ColOff;
                                SegmentPoint(ColH, g, 83 + i * 80, 132);
                            }
                        }
                        else
                        {
                            if (Nr[i - x + 1].Equals('.'))
                            {
                                ColH = ColOn;
                                SegmentPoint(ColH, g, 83 + (i-1) * 80, 132);
                                i++;
                                isPoint = true;
                            }
                            else
                            {
                                ColH = ColOff;
                                SegmentPoint(ColH, g, 83 + (i-1) * 80, 132);
                            }
                        }
                    }

                }
                else
                {

                    SegmentHor(ColOff, g, 17 + i * 80, 15);
                    SegmentVer(ColOff, g, 79 + i * 80, 15);
                    SegmentVer(ColOff, g, 79 + i * 80, 75);
                    SegmentHor(ColOff, g, 17 + i * 80, 135);
                    SegmentVer(ColOff, g, 15 + i * 80, 75);
                    SegmentVer(ColOff, g, 15 + i * 80, 15);
                    SegmentHor(ColOff, g, 17 + i * 80, 75);
                    SegmentPoint(ColOff, g, 83 + i * 80, 132);
                }
            }
        }

            void SegmentVer(Color Col, Graphics g, int x, int y)
            {

                SolidBrush brush = new SolidBrush(Col);

                Point point1 = new Point(x - 5, y + 5);
                Point point2 = new Point(x, y);
                Point point3 = new Point(x + 5, y + 5);
                Point point4 = new Point(x + 5, y + 55);
                Point point5 = new Point(x, y + 60);
                Point point6 = new Point(x - 5, y + 55);

            Point[] points = { point1, point2, point3, point4, point5, point6 };
                g.FillPolygon(brush, points);
            }
            void SegmentHor(Color Col, Graphics g, int x, int y)
            {
                SolidBrush brush = new SolidBrush(Col);

                Point point1 = new Point(x + 5, y - 5);
                Point point2 = new Point(x, y);
                Point point3 = new Point(x + 5, y + 5);
                Point point4 = new Point(x + 55, y + 5);
                Point point5 = new Point(x + 60, y);
                Point point6 = new Point(x + 55, y - 5);
            Point[] points = { point1, point2, point3, point4, point5, point6 };
                g.FillPolygon(brush, points);

            }
            void SegmentPoint(Color Col, Graphics g, int x, int y)
            {

                SolidBrush brush = new SolidBrush(Col);
                g.FillRectangle(brush, x, y, 8, 8);
            
            }
        

        private void CheckNumber(char nr)
            {
                if (nr.Equals('0'))
                {
                    ColA = ColOn;
                    ColB = ColOn;
                    ColC = ColOn;
                    ColD = ColOn;
                    ColE = ColOn;
                    ColF = ColOn;
                    ColG = ColOff;
                }

                else if (nr.Equals('1'))
                {
                    ColA = ColOff;
                    ColB = ColOn;
                    ColC = ColOn;
                    ColD = ColOff;
                    ColE = ColOff;
                    ColF = ColOff;
                    ColG = ColOff;
                }

                else if (nr.Equals('2'))
                {
                    ColA = ColOn;
                    ColB = ColOn;
                    ColC = ColOff;
                    ColD = ColOn;
                    ColE = ColOn;
                    ColF = ColOff;
                    ColG = ColOn;
                }

                else if (nr.Equals('3'))
                {
                    ColA = ColOn;
                    ColB = ColOn;
                    ColC = ColOn;
                    ColD = ColOn;
                    ColE = ColOff;
                    ColF = ColOff;
                    ColG = ColOn;
                }

                else if (nr.Equals('4'))
                {
                    ColA = ColOff;
                    ColB = ColOn;
                    ColC = ColOn;
                    ColD = ColOff;
                    ColE = ColOff;
                    ColF = ColOn;
                    ColG = ColOn;
                }

                else if (nr.Equals('5'))
                {
                    ColA = ColOn;
                    ColB = ColOff;
                    ColC = ColOn;
                    ColD = ColOn;
                    ColE = ColOff;
                    ColF = ColOn;
                    ColG = ColOn;
                }

                else if (nr.Equals('6'))
                {
                    ColA = ColOn;
                    ColB = ColOff;
                    ColC = ColOn;
                    ColD = ColOn;
                    ColE = ColOn;
                    ColF = ColOn;
                    ColG = ColOn;
                }

                else if (nr.Equals('7'))
                 {
                    ColA = ColOn;
                    ColB = ColOn;
                    ColC = ColOn;
                    ColD = ColOff;
                    ColE = ColOff;
                    ColF = ColOff;
                    ColG = ColOff;
                }

                else if (nr.Equals('8'))
                {
                    ColA = ColOn;
                    ColB = ColOn;
                    ColC = ColOn;
                    ColD = ColOn;
                    ColE = ColOn;
                    ColF = ColOn;
                    ColG = ColOn;
                }

                else if (nr.Equals('9'))
                 {
                    ColA = ColOn;
                    ColB = ColOn;
                    ColC = ColOn;
                    ColD = ColOn;
                    ColE = ColOff;
                    ColF = ColOn;
                    ColG = ColOn;
                }
                else if (nr.Equals('-'))
                 {
                    ColA = ColOff;
                    ColB = ColOff;
                    ColC = ColOff;
                    ColD = ColOff;
                    ColE = ColOff;
                    ColF = ColOff;
                    ColG = ColOn;
                 }
              
                else
                {
                    ColA = ColOff;
                    ColB = ColOff;
                    ColC = ColOff;
                    ColD = ColOff;
                    ColE = ColOff;
                    ColF = ColOff;
                    ColG = ColOff;
                }
            }
        

        
    }
}
