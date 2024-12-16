using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters;

namespace hw2.Models
{

    public class Shape
    {

        public int ID { get; set; }
        public string Literal;
        public string ShapeName { get; set; }
        public List<Point> LinePoint = new List<Point>();
        public List<Shape> fathershape = new List<Shape>();
        public int FirstLineIndex, SecondLineIndex; 
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
        public int str_x
        {
            get { return str_boundingBox.X; }
            set { str_boundingBox.X = value; }
        }
        public int str_y
        {
            get { return str_boundingBox.Y; }
            set { str_boundingBox.Y = value; }
        }
        public virtual void Draw(Graphics _graphics) { }

        public virtual void DrawBoundingBox(Graphics g) {
            g.DrawRectangle(Pens.Red, boundingBox);
            str_boundingBox.Width = Literal.Length*7;
            str_boundingBox.Height = 15;
            g.DrawRectangle(Pens.Red, str_boundingBox);
            g.FillEllipse(Brushes.Orange, str_boundingBox.X + str_boundingBox.Width / 2-4, str_boundingBox.Y-4, 8, 8);
        }
        public void renewLinePoint()
        {
            LinePoint.Clear();
            LinePoint.Add(new Point(X + Shape_Width, Y + Shape_Height / 2));
            LinePoint.Add(new Point(X, Y + Shape_Height / 2));
            LinePoint.Add(new Point(X + Shape_Width / 2, Y));
            LinePoint.Add(new Point(X + Shape_Width / 2, Y + Shape_Height));
        }

        public void DrawLineingPoint(Graphics g)
        {
            LinePoint.Clear();
            LinePoint.Add(new Point(X + Shape_Width, Y + Shape_Height / 2));
            LinePoint.Add(new Point(X , Y + Shape_Height / 2));
            LinePoint.Add(new Point(X + Shape_Width / 2, Y));
            LinePoint.Add(new Point(X + Shape_Width / 2, Y + Shape_Height));
           for(int i = 0; i < LinePoint.Count(); i++)
            {
                g.FillEllipse(Brushes.Gray, LinePoint[i].X-4, LinePoint[i].Y-4, 8, 8);
            }
        }
        public virtual bool BoundingBoxContainStringBox()
        {
            return boundingBox.Contains(str_boundingBox);
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

        protected Rectangle str_boundingBox;

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

        public bool IsPointInString(Point point)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(str_boundingBox);
            return path.IsVisible(point);
        }

    }

}
