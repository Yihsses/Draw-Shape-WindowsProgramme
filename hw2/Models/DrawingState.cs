using DrawingModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Models
{
    internal class DrawingState : IState
    {
        Point ul_point, lr_point;   // 記錄圖的左上角、右下角
        bool ul_pressed;            // 記錄左上角按了沒
        Shape shape = new Shape() ;        // 記錄正在畫的圖
        PointerState pointerState;  // 記錄PointerState

        public DrawingState(PointerState pointerState)
        {
            // 建立DrawingState時，傳入PointerState，使得DrawingState可以指定PointerState選取剛剛新增的圖形
            this.pointerState = pointerState;
        }

        void IState.Initialize(Model m)
        {
            ul_pressed = false;
        //    shape = null;
        }

        public void MouseDown(Model m, Point point)
        {
            
            ul_pressed = true;
            ul_point = lr_point = point;
            shape.X = ul_point.X; 
            shape.Y = ul_point.Y;
            shape.Shape_Width = 0; 
            shape.Shape_Height = 0;
            m.Add_shape(m.nowpointstate, "", (int)shape.X, (int)shape.Y, 0, 0);
        }

        public void MouseMove(Model m, Point point)
        {
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
            ul_pressed = false;
            m.shapes[m.shapes.Count - 1].Literal = m.GenerateRandomString();
            m.shapes[m.shapes.Count - 1].str_x = ul_point.X + (int)(shape.Shape_Width / 2.5);
            m.shapes[m.shapes.Count-1].str_y = ul_point.Y + shape.Shape_Height / 2;
            m.commandManager.Execute(new DrawCommand(m, m.shapes[m.shapes.Count - 1]));
            m.EnterPointerState();
            pointerState.AddSelectedShape(m.shapes[m.shapes.Count - 1]);
        }

        public void OnPaint(Model m, IGraphics g)
        {
            // 畫出所有的Ellipse
            g.Draw(m.shapes);  
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
