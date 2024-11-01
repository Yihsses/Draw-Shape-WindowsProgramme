using DrawingModel;
using hw2.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Models
{
    internal class Model
    {

        public List<Shape> shapes = new List<Shape>();
        public Model() { }
        string answer;
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        double _firstPointX;
        double _firstPointY;
        bool _isPressed = false;
        List<Line> _lines = new List<Line>();
        Line _hint = new Line();
        void Rnew_index()
        {
            for (int i = 0; i < shapes.Count(); i++)
            {
                shapes[i].ID = i + 1;
            }
        }
        public void Add_shape(string shape_name, string literal, int x, int y, int h, int w)
        {
            shapes.Add(Shapefactory.GetShape(
                    shapes.Count + 1,
                     shape_name,
                    literal,
                    x,
                    y,
                   h,
                   w
            ));
        }
        public void Delete_shape(int index)
        {
            shapes.RemoveAt(index);
            Rnew_index();
        }
        public void PointerPressed(double x, double y, string shape_name)
        {
            if (x > 0 && y > 0)
            {
                _firstPointX = x;
                _firstPointY = y;
                Add_shape(shape_name, GenerateRandomString(), (int)_firstPointX, (int)_firstPointY, 0, 0);
                _hint.x1 = _firstPointX;
                _hint.y1 = _firstPointY;
                _isPressed = true;
            }
        }
        public void PointerMoved(double x, double y)
        {
            if (_isPressed)
            {
                shapes[shapes.Count - 1].Shape_Width = (int)(x - _firstPointX);
                shapes[shapes.Count - 1].Shape_Height = (int)(y - _firstPointY);
                _hint.x2 = x;
                _hint.y2 = y;
                NotifyModelChanged();
            }
        }
        public void PointerReleased(double x, double y)
        {
            if (_isPressed)
            {
                _isPressed = false;
                NotifyModelChanged();
            }
        }
        public void Clear()
        {
            _isPressed = false;
            _lines.Clear();
            NotifyModelChanged();
        }
        public void Draw(IGraphics graphics)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i].ShapeName == "Start")
                {
                    graphics.DrawStart(shapes[i].X, shapes[i].Y, shapes[i].Shape_Width, shapes[i].Shape_Height);
                }
                else if (shapes[i].ShapeName == "Terminator")
                {
                    graphics.DrawTerminator(shapes[i].X, shapes[i].Y, shapes[i].Shape_Width, shapes[i].Shape_Height);
                }
                else if (shapes[i].ShapeName == "Decision")
                {
                    graphics.DrawDecision(shapes[i].X, shapes[i].Y, shapes[i].Shape_Width, shapes[i].Shape_Height);
                }
                else if (shapes[i].ShapeName == "Process")
                {
                    graphics.DrawProcess(shapes[i].X, shapes[i].Y, shapes[i].Shape_Width, shapes[i].Shape_Height);
                }
                if (_isPressed == false)
                {
                    graphics.DrawString(shapes[i].X + shapes[i].Shape_Width / 2.5, shapes[i].Y + shapes[i].Shape_Height / 2, shapes[i].Literal);
                }
                else if (i != shapes.Count - 1)
                {
                    graphics.DrawString(shapes[i].X + shapes[i].Shape_Width / 2.5, shapes[i].Y + shapes[i].Shape_Height / 2, shapes[i].Literal);

                }
            }

            //foreach (Line aLine in _lines)
            //    aLine.Draw(graphics);
            //if (_isPressed)
            //    _hint.Draw(graphics);
        }
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
        private string GenerateRandomString()
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int length = random.Next(3, 11); // 上限為11才能產生10
            StringBuilder result = new StringBuilder(length);

            // 隨機選擇字符
            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
        }
    }
}
