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

        public void Initialize(Model m)
        {
            // 當進入PointerState時，應該尚未選取任何形狀，因此清空selectedShapes
            selectedShapes.Clear();
            isCtrlKeyDown = false;
        }

        public void MouseDown(Model m, Point point)
        {
            ispress = true;
            // 檢查是否有選到圖形，使用相反順序檢查，以便選到最上層的圖形
            foreach (Shape shape in Enumerable.Reverse(m.shapes))
            {
                if (shape.IsPointInEllipse(point))
                {
                    
                        // 若沒按下Ctrl鍵，則清空selectedShapes，再新增選取的圖形
                        selectedShapes.Clear();
                        selectedShapes.Add(shape);
                    
                    return;
                }
            }
            // 若沒有選到任何圖形，則清空selectedShapes，但是如果按下Ctrl鍵，則selectedShapes不變
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
                if (ispress)
                {
                    selectedShapes[0].X = point.X - selectedShapes[0].Shape_Width/2;
                    selectedShapes[0].Y = point.Y - selectedShapes[0].Shape_Height / 2;
                }
            }
            catch
            {

            }

            // 可以考慮改為繼承，省掉空的實作
            // do nothing
        }

        public void MouseUp(Model m, Point point)
        {
            ispress = false; 
            // do nothing
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
