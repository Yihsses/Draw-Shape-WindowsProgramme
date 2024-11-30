using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Models
{
    public class Process : Shape
    {
        public Process(int ID, string ShapeName, string Literal, int X, int Y, int Shape_Height, int Shape_Width)
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
            _graphics.DrawRectangle(Pens.Black, this.X, this.Y, this.Shape_Width, this.Shape_Height);
        }
    }
}
