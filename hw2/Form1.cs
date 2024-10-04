using hw2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw2
{
    public partial class MyDrawingForm : Form
    {
        public MyDrawingForm()
        {
            InitializeComponent();
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
                Shape shape = Shapefactory.GetShape(shap_data_GridView.RowCount + 1,
                    shape_comboBox.Text,
                     literalbox.Text,
                     Int32.Parse(xbox.Text),
                     Int32.Parse(ybox.Text),
                     Int32.Parse(hbox.Text),
                     Int32.Parse(wbox.Text
                    ));
                shap_data_GridView.Rows.Add(shape.Getobject());
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
                for (int i = 0; i < shap_data_GridView.RowCount; i++)
                {
                    shap_data_GridView.Rows[i].Cells[1].Value = i + 1;
                }
            }
        }
    }
}
