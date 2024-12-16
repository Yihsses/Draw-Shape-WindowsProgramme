using hw2.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    internal class Line : Shape
    {
        public Line(int ID, string ShapeName, string Literal, ref int  X,ref int Y, int Shape_Height, int Shape_Width)
        {
            this.ID = ID;
            this.ShapeName = ShapeName;
            this.Literal = Literal;
            this.X = X;
            this.Y = Y;
            this.Shape_Height = Shape_Height;
            this.Shape_Width = Shape_Width;
        }
        public override void Draw(Graphics graphics)
        {
            using (Pen pen = new Pen(Color.Black,5)) // 3 是筆寬
            {
                this.X = this.fathershape[0].LinePoint[FirstLineIndex].X;
                this.Y = this.fathershape[0].LinePoint[FirstLineIndex].Y;
                if(fathershape.Count > 1)
                {
                    this.Shape_Width = this.fathershape[1].LinePoint[SecondLineIndex].X - this.X;
                    this.Shape_Height = this.fathershape[1].LinePoint[SecondLineIndex].Y - this.Y;
                }
                graphics.DrawLine(pen, this.X, this.Y, this.X + this.Shape_Width, this.Y + this.Shape_Height);
            }
        }
    }
}