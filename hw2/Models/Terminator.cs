using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Models
{
    public class Terminator : Shape
    {
        public Terminator(int ID, string ShapeName, string Literal, int X, int Y, int Shape_Height, int Shape_Width)
        {
            this.ID = ID;
            this.ShapeName = ShapeName;
            this.Literal = Literal;
            this.X = X;
            this.Y = Y;
            this.Shape_Height = Shape_Height;
            this.Shape_Width = Shape_Width;
        }
        public override void Draw(Graphics _graphics)
        {
            try
            {
                _graphics.DrawArc(Pens.Black, this.X, (float)this.Y, (float)this.Shape_Height, (float)this.Shape_Height, 90, 180);
                _graphics.DrawArc(Pens.Black, (float)(this.X + this.Shape_Width), (float)this.Y, (float)this.Shape_Height, (float)this.Shape_Height, 270, 180);
                _graphics.DrawLine(Pens.Black, (float)(this.X + this.Shape_Height / 2), (float)this.Y, (float)(this.X + this.Shape_Width + this.Shape_Height / 2), (float)(this.Y));
                _graphics.DrawLine(Pens.Black, (float)(this.X + this.Shape_Height / 2), (float)(this.Y + this.Shape_Height), (float)(this.X + this.Shape_Width + this.Shape_Height / 2), (float)(this.Y + this.Shape_Height));
            }
            catch
            {

            }
        }
        public override void DrawBoundingBox(Graphics g)
        {
            boundingBox.Width = boundingBox.Width * 2;
            g.DrawRectangle(Pens.Red, boundingBox);
            boundingBox.Width = boundingBox.Width / 2;

            str_boundingBox.Width = Literal.Length * 7;
            str_boundingBox.Height = 15;
            g.DrawRectangle(Pens.Red, str_boundingBox);
            g.FillEllipse(Brushes.Orange, str_boundingBox.X + str_boundingBox.Width / 2 - 4, str_boundingBox.Y - 4, 8, 8);
        }
        public override bool BoundingBoxContainStringBox()
        {
            boundingBox.Width = boundingBox.Width * 2;
            bool temp = boundingBox.Contains(str_boundingBox);
            boundingBox.Width = boundingBox.Width / 2;

            return (temp);
        }
    }
}
