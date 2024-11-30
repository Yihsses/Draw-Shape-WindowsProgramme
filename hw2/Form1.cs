using DrawingForm;
using DrawingModel;
using hw2.Models;
using hw2.PresentationMode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace hw2
{

    public partial class MyDrawingForm : Form
    {
        Model model = new Model();
        PresentationMode.PresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();
        string now_checked_shap_iteam = "";

        public MyDrawingForm()
        {
            InitializeComponent();
            _canvas.Dock = DockStyle.None;
            _canvas.Location = new Point(150, 40);
            _canvas.Cursor = Cursors.Cross;
            _canvas.Size = new Size(500, 500);
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            DoubleBuffered = true;

            Controls.Add(_canvas);
            model = new Model();
            _presentationModel = new PresentationModel(ref model);
            model._modelChanged += HandleModelChanged;
            model.EnterPointerState();
            RefreshUI();
        }

        public void HandleCanvasPressed(object sender,
       System.Windows.Forms.MouseEventArgs e)
        {

            model.PointerPressed(e.X, e.Y, now_checked_shap_iteam);

        }
        public void HandleCanvasReleased(object sender,
       System.Windows.Forms.MouseEventArgs e)
        {
            model.PointerReleased(e.X, e.Y);
            RefreshUI(); 
            renew_data_gridView();
        }
        public void HandleCanvasMoved(object sender,
       System.Windows.Forms.MouseEventArgs e)
        {
            model.PointerMoved(e.X, e.Y);
        }
        public void HandleCanvasPaint(object sender,
       System.Windows.Forms.PaintEventArgs e)
        {

            //_presentationModel.Draw(e.Graphics);
            model.OnPaint(new WindowsFormsGraphicsAdaptor(e.Graphics));
        }
        public void HandleModelChanged()
        {
            Invalidate(true);
        }
        public void renew_data_gridView()
        {
            shap_data_GridView.Rows.Clear();
            for (int i = 0; i < model.shapes.Count; i++)
            {
                shap_data_GridView.Rows.Add(model.shapes[i].Getobject());
            }

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            this.shape_comboBox.SelectedIndex = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void add_data_button_Click(object sender, EventArgs e)
        {

            try
            {
                model.Add_shape(
                    shape_comboBox.Text,
                     literalbox.Text,
                     Int32.Parse(xbox.Text),
                     Int32.Parse(ybox.Text),
                     Int32.Parse(hbox.Text),
                     Int32.Parse(wbox.Text));
                shap_data_GridView.Rows.Clear();
                for (int i = 0; i < model.shapes.Count; i++)
                    shap_data_GridView.Rows.Add(model.shapes[i].Getobject());
                HandleModelChanged();
            }
            catch
            {
                MessageBox.Show("欄位未輸入或有錯誤");
            }

        }

        private void shap_data_GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                shap_data_GridView.Rows.RemoveAt(e.RowIndex);
                model.Delete_shape(e.RowIndex);
                for (int i = 0; i < shap_data_GridView.RowCount; i++)
                {
                    shap_data_GridView.Rows[i].Cells[1].Value = model.shapes[i].ID;
                }
            }
            HandleModelChanged();
        }
        private void RefreshUI()
        {
           _presentationModel.RefreshToolStrip(toolStrip1,ref model, _canvas);
            Invalidate();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e )
        {
            _presentationModel.ToolStrip1_ItemClicked(sender, e,ref now_checked_shap_iteam,ref model);
            RefreshUI(); 
        }

        private void xbox_TextChanged(object sender, EventArgs e)
        {
            _presentationModel.CheckDate(ref add_data_button, ref literalbox, ref xbox, ref ybox, ref hbox, ref wbox, ref X, ref Y, ref H, ref W, ref literal);

        }
    }
}
