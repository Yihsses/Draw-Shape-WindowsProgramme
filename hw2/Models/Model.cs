using DrawingModel;
using hw2.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace hw2.Models
{
    public class Model
    {
        public CommandManager commandManager = new CommandManager();
        public List<Shape> shapes = new List<Shape>();
        public List<Point> literal_xy = new List<Point>();
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        public double _firstPointX;
        public double _firstPointY;
        bool _isPressed = false;
        public string nowpointstate = "";
        public IState pointerState;
        public IState drawingState;
        public IState currentState;
        public IState lineState;
        public Model() 
        {
            // 建立pointerState物件，也可以改用Factory替代new
            lineState = new DrawLineState();
            pointerState = new PointerState();
            // 建立drawingState物件，令DrawingState知道PointerState
            drawingState = new DrawingState((PointerState)pointerState);

            // 預設為PointerState
            EnterDrawingState();
        }
        public void EnterPointerState()
        {
            pointerState.Initialize(this);
            currentState = pointerState;
        }

        public void EnterDrawingState()
        {
            drawingState.Initialize(this);
            currentState = drawingState;
        }
        public void EnterLineState()
        {
            lineState.Initialize(this);
            currentState = lineState;
        }
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
        public void Add_shpae(Shape shape)
        {
            shapes.Add(shape);
            NotifyModelChanged();
        }
        public void DeleteShape()
        {
            shapes.RemoveAt(shapes.Count - 1);
            NotifyModelChanged();

        }
        public void Delete_shape(int index)
        {
            shapes.RemoveAt(index);
            currentState.Initialize(this);
            Rnew_index();
            NotifyModelChanged();
        }
        public void PointerPressed(double x, double y, string shape_name)
        {
            nowpointstate = shape_name;
            currentState.MouseDown(this, new Point((int)x, (int)y));

        }
        public void PointerMoved(double x, double y)
        {
            currentState.MouseMove(this, new Point((int)x, (int)y));
            NotifyModelChanged();
        }
        public void PointerReleased(double x, double y)
        {
            currentState.MouseUp(this, new Point((int)x, (int)y));
            NotifyModelChanged();

        }
        public void OnPaint(IGraphics g)
        {
            currentState.OnPaint(this, g);
        }
        public void Draw(IGraphics graphics)
        {
            graphics.Draw(shapes);
        
        }
        public void Undo()
        {
            commandManager.Undo();
            NotifyModelChanged();
        }

        public void Redo()
        {
            commandManager.Redo();
            NotifyModelChanged();
        }
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
        public string GenerateRandomString()
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int length = random.Next(3, 11); // 上限為11才能產生10
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
        }
        public bool IsPointerButtonChecked
        {
            get { return currentState == pointerState; }
        }

        public bool IsDrawingButtonChecked
        {
            get { return currentState == drawingState; }
        }
        public bool IsLineButtonChecked
        {
            get { return currentState == lineState; }
        }
        public bool IsRedoEnabled
        {
            get
            {
                return commandManager.IsRedoEnabled;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return commandManager.IsUndoEnabled;
            }
        }
    }
}
