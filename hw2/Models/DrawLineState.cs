using DrawingModel;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Models
{
    internal class DrawLineState : IState
    {
        Point ul_point, lr_point;

        List<Shape> selectedShapes = new List<Shape>();
        bool ul_pressed;            // 記錄左上角按了沒
        Shape shape = new Shape();        // 記錄正在畫的圖
        Shape firstshape = new Shape();

        void IState.Initialize(Model m)
        {
            ul_pressed = false;
        }

        public void MouseDown(Model m, Point point)
        {

            double temp = 9999;
            if (selectedShapes.Count() != 0)
            {

                for (int i = 0; i <= selectedShapes[0].LinePoint.Count - 1; i++)
                {
                    double len = Math.Sqrt(Math.Pow(point.X - selectedShapes[0].LinePoint[i].X, 2) + Math.Pow((point.Y) - selectedShapes[0].LinePoint[i].Y, 2));
                    if (len <= 8 && len < temp)
                    {
                        firstshape = selectedShapes[0];
                        temp = len;
                        shape.FirstLineIndex = i;
                        ul_point = lr_point = selectedShapes[0].LinePoint[i];
                        shape.X = selectedShapes[0].LinePoint[i].X;
                        shape.Y = selectedShapes[0].LinePoint[i].Y;
                    }
                }
            }
            if (temp != 9999)
            {
                ul_pressed = true;
                m.Add_shape("Line", "", (int)shape.X, (int)shape.Y, 0, 0);
                m.shapes[m.shapes.Count - 1].FirstLineIndex = shape.FirstLineIndex;
                m.shapes[m.shapes.Count - 1].fathershape.Add(selectedShapes[0]);
            }
        }

        public void MouseMove(Model m, Point point)
        {
            selectedShapes.Clear();
            foreach (Shape shape in Enumerable.Reverse(m.shapes))
            {
                if (shape.IsPointInEllipse(point) && shape.ShapeName != "Line")
                {
                    //  m.commandManager.Execute(new MoveCommand(m, shape));
                    selectedShapes.Add(shape);
                    if (!ul_pressed)
                    {
                        return;
                    }

                }
            }
            if (ul_pressed)
            {
                m.shapes[m.shapes.Count - 1].Shape_Width = (int)(point.X - ul_point.X);
                m.shapes[m.shapes.Count - 1].Shape_Height = (int)(point.Y - ul_point.Y);
                shape.Shape_Width = point.X - ul_point.X;
                shape.Shape_Height = point.Y - ul_point.Y;
            }

        }

        public void MouseUp(Model m, Point point)
        {
            if (ul_pressed)
            {

                int secondlineindex = 0;
                double temp = 9999;
                Point secondpoint = new Point();
                if (selectedShapes.Count >= 1)
                {
                    for (int i = 0; i <= selectedShapes[0].LinePoint.Count - 1; i++)
                    {
                        double len = Math.Sqrt(Math.Pow(point.X - selectedShapes[0].LinePoint[i].X, 2) + Math.Pow((point.Y) - selectedShapes[0].LinePoint[i].Y, 2));
                        if (len <= 8 && len < temp)
                        {
                            secondlineindex = i;
                            temp = len;
                            secondpoint.X = selectedShapes[0].LinePoint[i].X;
                            secondpoint.Y = selectedShapes[0].LinePoint[i].Y;
                        }
                    }
                }
                try
                {
                    if (firstshape == selectedShapes[0])
                    {
                        ul_pressed = false;
                        m.EnterPointerState();
                        m.DeleteShape();
                        return;
                    }
                }
                catch
                {
                    ul_pressed = false;
                    m.EnterPointerState();
                    m.DeleteShape();
                    return; 
                }

                if (temp != 9999)
                {
                    m.shapes[m.shapes.Count - 1].Shape_Width = (int)(secondpoint.X - ul_point.X);
                    m.shapes[m.shapes.Count - 1].Shape_Height = (int)(secondpoint.Y - ul_point.Y);
                    m.shapes[m.shapes.Count - 1].fathershape.Add(selectedShapes[0]);
                    m.shapes[m.shapes.Count - 1].SecondLineIndex = secondlineindex;
                    m.commandManager.Execute(new DrawCommand(m, m.shapes[m.shapes.Count - 1]));

                }
                else
                {
                    m.DeleteShape();
                }
                ul_pressed = false;
                m.EnterPointerState();
            }

            //pointerState.AddSelectedShape(m.shapes[m.shapes.Count - 1]);
        }

        public void OnPaint(Model m, IGraphics g)
        {
            g.Draw(m.shapes);
            if (selectedShapes.Count >= 1)
            {
                g.DrawLinePoint(selectedShapes[0]);
            }

            // 畫出虛線的提示
        }

        public void KeyDown(Model m, int keyValue)
        {
            // do nothing
        }

        public void KeyUp(Model m, int keyValue)
        {
            // do nothing
        }
    }
}
