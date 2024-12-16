using DrawingModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace hw2.Models
{
    internal class PointerState : IState
    {
        List<Shape> selectedShapes = new List<Shape>();
        // Ctrl鍵的KeyValue
        const int CTRL_KEY = 17;
        // 紀錄是否按下Ctrl鍵
        bool isCtrlKeyDown;
        bool ispress = false;
        bool isshapemove = false;
        bool isStringmove = false;
        bool isExecute = true; 
        public void Initialize(Model m)
        {
            // 當進入PointerState時，應該尚未選取任何形狀，因此清空selectedShapes
            selectedShapes.Clear();
            isCtrlKeyDown = false;
        }

        public void MouseDown(Model m, Point point)
        {

            foreach (Shape shape in Enumerable.Reverse(m.shapes))
            {
                if (shape.IsPointInEllipse(point))
                {
                    isExecute = false; 
                    ispress = true;
                    //  m.commandManager.Execute(new MoveCommand(m, shape));
                    selectedShapes.Clear();
                    selectedShapes.Add(shape);
                    return;
                }
            }
            if (!isCtrlKeyDown)
                selectedShapes.Clear();
        }

        public void AddSelectedShape(Shape ellipse)
        {
            // Bug: 應該寫判斷式，不重複加入相同的Shape比較好
            selectedShapes.Add(ellipse);
        }

        public void MouseMove(Model m, Point point)
        {
            try
            {
                if (!isExecute)
                {
                    m.commandManager.Execute(new MoveCommand(m, selectedShapes[0]));
                    isExecute = true; 
                }
                if (ispress)
                {
                    if (Math.Abs(point.X - (selectedShapes[0].str_x +( selectedShapes[0].Literal.Length * 7 / 2))) <= 10 && Math.Abs(point.Y - selectedShapes[0].str_y) <= 20 && isshapemove == false)
                    {
                        isStringmove = true;
                        if (selectedShapes[0].BoundingBoxContainStringBox())
                        {
                            selectedShapes[0].str_x = point.X - selectedShapes[0].Literal.Length * 7 / 2;
                            selectedShapes[0].str_y = point.Y;
                        }
                        else
                        {
                            selectedShapes[0].str_x = selectedShapes[0].X + selectedShapes[0].Shape_Width / 2;
                            selectedShapes[0].str_y = selectedShapes[0].Y + selectedShapes[0].Shape_Height / 2;

                        }
                    }
                    else if(isStringmove == false )
                    {

                        isshapemove = true;
                        int dx, dy;
                        dx = selectedShapes[0].str_x - selectedShapes[0].X;
                        dy = selectedShapes[0].Y - selectedShapes[0].str_y;
                        selectedShapes[0].X = point.X - selectedShapes[0].Shape_Width / 2;
                        selectedShapes[0].Y = point.Y - selectedShapes[0].Shape_Height / 2;
                        selectedShapes[0].str_x = selectedShapes[0].X + dx;
                        selectedShapes[0].str_y = selectedShapes[0].Y - dy;
                        selectedShapes[0].renewLinePoint();
                    }
                }
            }
            catch
            {

            }
        }

        public void MouseUp(Model m, Point point)
        {

            isExecute = true; 
            isStringmove = false; 
            isshapemove = false; 
            ispress = false; 
        }

        public void OnPaint(Model m, IGraphics g)
        {
            //畫出所有的Ellipse
            g.Draw(m.shapes);
            // 畫出被選中圖形的外框
           
            foreach (Shape shape in selectedShapes)
                g.DrawBoundBox(shape);
        }

        public void KeyDown(Model m, int keyValue)
        {

        }

        public void KeyUp(Model m, int keyValue)
        {

        }
    }
}
