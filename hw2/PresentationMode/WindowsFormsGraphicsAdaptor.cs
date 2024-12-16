using System.Windows.Forms;
using System.Drawing;
using DrawingModel;
using hw2.Models;
using System.Collections.Generic;


namespace hw2.PresentationMode
{
     public class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;

        public WindowsFormsGraphicsAdaptor()
        {
            Bitmap myBitmap = new Bitmap(100,200);
            this._graphics = Graphics.FromImage(myBitmap);
        }

            public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }
        public void ClearAll()
        {

        }
        public void Draw(List<Shape> shapes)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                shapes[i].Draw(this._graphics);
                this.DrawString(shapes[i].str_x, shapes[i].str_y, shapes[i].Literal);

            }
        }
        public void DrawBoundBox(Shape shape)
        {
            shape.DrawBoundingBox(this._graphics);
        }

        public void DrawLinePoint(Shape shape)
        {
            shape.DrawLineingPoint(this._graphics);
        }
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2,
           (float)y2);
        }
        public void DrawStart(double x1, double y1, double x2, double y2)
        {

            _graphics.DrawEllipse(Pens.Black , (float)x1, (float)y1, (float)x2,(float)y2);
        }
        public void DrawTerminator(double x1, double y1, double width, double height)
        {
            try
            {
                _graphics.DrawArc(Pens.Black, (float)x1, (float)y1, (float)height, (float)height, 90, 180);
                _graphics.DrawArc(Pens.Black, (float)(x1 + width), (float)y1, (float)height, (float)height, 270, 180);
                _graphics.DrawLine(Pens.Black, (float)(x1 + height / 2), (float)y1, (float)(x1 + width + height / 2), (float)(y1));
                _graphics.DrawLine(Pens.Black, (float)(x1 + height / 2), (float)(y1 + height), (float)(x1 + width + height / 2), (float)(y1 + height));
            }
            catch
            {

            }
        }
        public void DrawDecision(double x, double y, double width, double height)
        {
            try
            {
                Point[] points = new Point[4];
                points[0] = new Point((int)(x + width / 2), (int)(y));
                points[1] = new Point((int)(x + width ), (int)(y + height / 2));
                points[2] = new Point((int)(x + width / 2), (int)(y + height));
                points[3] = new Point((int)(x), (int)(y + height / 2));
                _graphics.DrawPolygon(Pens.Black, points);
            }
            catch { 
            }
        }
        public void DrawString(double x, double y, string shape_name)
        {
            _graphics.DrawString(shape_name, new Font("Ariral", 7), Brushes.Black, (float)x, (float)y);
        }
        public void DrawProcess(double x, double y, double width, double height)
        {
            _graphics.DrawRectangle(Pens.Black, (float)x, (float)y, (float)width, (float)height); 
        }
    }
}

