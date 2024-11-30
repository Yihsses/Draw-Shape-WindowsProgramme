using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Models
{
    public class Decision : Shape
    {
        public Decision(int ID, string ShapeName, string Literal, int X, int Y, int Shape_Height, int Shape_Width)
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
                Point[] points = new Point[4];
                points[0] = new Point((int)(this.X + this.Shape_Width / 2), (int)(this.Y));
                points[1] = new Point((int)(this.X + this.Shape_Width), (int)(this.Y + this.Shape_Height / 2));
                points[2] = new Point((int)(this.X + this.Shape_Width / 2), (int)(this.Y + this.Shape_Height));
                points[3] = new Point((int)(this.X), (int)(this.Y + this.Shape_Height / 2));
                _graphics.DrawPolygon(Pens.Black, points);
            }
            catch
            {
            }
        }
    }
}
