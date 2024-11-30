using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Models
{

    public class Shape
    {

        public int ID { get; set; }
        public string Literal { get; set; }
        public string ShapeName { get; set; }
        public int X
        {
            get { return boundingBox.X; }
            set { boundingBox.X = value; }
        }
        public int Y
        {
            get { return boundingBox.Y; }
            set { boundingBox.Y = value; }
        }

        public virtual void Draw(Graphics _graphics) { }

        public virtual void DrawBoundingBox(Graphics g) {
            g.DrawRectangle(Pens.Red, boundingBox);
        }
        public int Shape_Width
        {
            get { return boundingBox.Width; }
            set { boundingBox.Width = value; }
        }
        public int Shape_Height
        {
            get { return boundingBox.Height; }
            set { boundingBox.Height = value; }
        }
        protected Rectangle boundingBox;


        public object[] Getobject()
        {
             return new object[] { "刪除",ID, ShapeName, Literal, X,Y,Math.Abs(Shape_Height), Math.Abs(Shape_Width) };
        }


        public bool IsPointInEllipse(Point point)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(boundingBox);
            return path.IsVisible(point);
        }


    }

}
