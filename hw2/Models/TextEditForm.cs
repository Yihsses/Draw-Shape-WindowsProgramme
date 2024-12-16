using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw2.Models
{
    public partial class TextEditForm : Form
    {
        public string EditedText { get; private set; } // 用戶編輯後的文字
        private string _originalText;                 // 保存初始文字內容

        public TextEditForm(string initialText = "")
        {
            InitializeComponent();
            _originalText = initialText;  // 儲存初始文字
            txtInput.Text = initialText;  // 設定輸入框的初始文字
            btnConfirm.Enabled = false;   // 初始時，禁用「確定」按鍵
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            // 當輸入文字變更時，判斷與初始文字是否不同，來控制「確定」按鍵
            btnConfirm.Enabled = txtInput.Text != _originalText;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 點擊「確定」按鈕時，儲存輸入的文字並關閉視窗
            EditedText = txtInput.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 點擊「取消」按鈕時，直接關閉視窗
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
