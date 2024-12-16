using DrawingModel;
using hw2.Models;
using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace hw2.PresentationMode
{
     public class PresentationModel
    {
        Model _model;
        public PresentationModel(ref Model model)
        {
            this._model = model;
        }


        public void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e,ref string now_checked_shap_iteam,ref Model model)
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
                if(now_checked_shap_iteam == "PointState")
                {
                    model.EnterPointerState();
                }
                else
                {
                    model.EnterDrawingState();
                }
            }
        }
        public void ToolStripButtonDisable(object sender, ref Model model)
        {
            //if (model.IsLineButtonChecked)
            //{
            //    foreach (ToolStripButton item in ((ToolStrip)sender).Items)
            //    {
            //            if(item.Text != "LineState")
            //            {
            //                item.Enabled = false;
            //            }
            //    }
            //}
        }
        public void RefreshToolStrip(object sender,ref Model model,Panel panel)
        {
            foreach (ToolStripButton item in ((ToolStrip)sender).Items)
            {
                if(item.Text == "undo")
                {
                    item.Enabled = model.IsUndoEnabled; 
                }
                if(item.Text == "redo")
                {
                    item.Enabled = model.IsRedoEnabled;
                }
                if (model.IsPointerButtonChecked)
                {
                    if(item.Text == "PointState")
                    {
                        panel.Cursor = Cursors.Default;
                        item.Checked = true;
                    }
                    else
                    {
                        item.Checked = false; 
                    }
                }
                else
                {
                    panel.Cursor = Cursors.Cross;
                }
            }
        }
        public void CheckDate(ref Button Adddate, ref TextBox literbox ,  ref TextBox x_box, ref TextBox y_box , ref TextBox heigh_box , ref TextBox width_box,ref Label x,ref Label y,ref Label heigh, ref Label width ,ref Label literal)
        {
            Adddate.Enabled = true; 
            if (literbox.Text == "")
            {
                literal.ForeColor = Color.Red;
            }
            else
            {
                literal.ForeColor = Color.Black;
            }
            ValidateTextBoxIntegerOnly(ref Adddate,x_box, x);
            ValidateTextBoxIntegerOnly(ref Adddate, y_box, y);
            ValidateTextBoxIntegerOnly(ref Adddate, width_box, width);
            ValidateTextBoxIntegerOnly(ref Adddate, heigh_box, heigh);
        }
        void ValidateTextBoxIntegerOnly(ref Button Adddate, TextBox textBox,Label label)
        {
            // 檢查是否是整數
            if (!int.TryParse(textBox.Text, out _))
            {
                Adddate.Enabled = false; 
                label.ForeColor = Color.Red;
            }
            else
            {
                label.ForeColor= Color.Black;
            }
        }
    }
}

