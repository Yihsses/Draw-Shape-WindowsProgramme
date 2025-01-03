using DrawingModel;
using hw2.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public async Task Load()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Drawing Files (*.mydrawing)|*.mydrawing";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // 讀取檔案並反序列化圖形資料
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        shapes.Clear(); // 清空現有的圖形資料

                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = line.Split(',');
                            if (parts.Length == 8)
                            {
                                // 根據讀取的資料建立圖形並加入列表
                                string name = parts[0];
                                string literal = parts[1];
                                int x = int.Parse(parts[2]);
                                int y = int.Parse(parts[3]);
                                int width = int.Parse(parts[4]);
                                int height = int.Parse(parts[5]);

                                // 在這裡根據需要創建不同的圖形物件
                                Add_shape(name, literal, x, y, width, height);
                                await Task.Delay(100);
                                shapes[shapes.Count -1].str_x = int.Parse(parts[6]);
                                shapes[shapes.Count - 1].str_y = int.Parse(parts[7]);
                                await Task.Delay(100);
                                NotifyModelChanged();

                            }
                        }
                    }

                    // 通知模型已經更新
                    NotifyModelChanged();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取檔案失敗: " + ex.Message);
            }
        }
        public async Task SaveAsync()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Drawing Files (*.mydrawing)|*.mydrawing";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;


                    // 模擬延遲以減慢儲存過程
                    await Task.Delay(3000);

                    // 序列化圖形資料並寫入檔案
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (var shape in shapes)
                        {
                            // 將每個圖形的資料寫入檔案，你可以根據圖形類別進行調整
                            writer.WriteLine($"{shape.ShapeName},{shape.Literal},{shape.X},{shape.Y},{shape.Shape_Width},{shape.Shape_Height},{shape.str_x},{shape.str_y}");
                        }
                    }

                    // 儲存完成後啟用存檔按鈕
 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("儲存檔案失敗: " + ex.Message);
            }
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
