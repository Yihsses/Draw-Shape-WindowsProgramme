using DrawingForm;
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
            Controls.Add(_canvas);
            //
            // prepare clear button
            //

            //
            // prepare presentation model and model
            //
            model = new Model();
            _presentationModel = new PresentationModel(ref model,
_canvas);
            model._modelChanged += HandleModelChanged;
        }
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            model.Clear();
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
            _presentationModel.Draw(e.Graphics);
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


        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripButton item in ((ToolStrip)sender).Items)
            {
                if (item != e.ClickedItem)
                    item.Checked = false;
                else
                {
                    now_checked_shap_iteam = item.Text;
                    item.Checked = true;
                }

            }
        }
    }
}
