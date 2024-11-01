namespace hw2
{
    partial class MyDrawingForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyDrawingForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shap_data_GridView = new System.Windows.Forms.DataGridView();
            this.delete_column = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shape_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.literal_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x__column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.h__column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.w__column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.databox = new System.Windows.Forms.GroupBox();
            this.W = new System.Windows.Forms.Label();
            this.H = new System.Windows.Forms.Label();
            this.Y = new System.Windows.Forms.Label();
            this.X = new System.Windows.Forms.Label();
            this.literal = new System.Windows.Forms.Label();
            this.wbox = new System.Windows.Forms.TextBox();
            this.hbox = new System.Windows.Forms.TextBox();
            this.ybox = new System.Windows.Forms.TextBox();
            this.xbox = new System.Windows.Forms.TextBox();
            this.literalbox = new System.Windows.Forms.TextBox();
            this.shape_comboBox = new System.Windows.Forms.ComboBox();
            this.add_data_button = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.ToolStripButton();
            this.terminator = new System.Windows.Forms.ToolStripButton();
            this.Decision = new System.Windows.Forms.ToolStripButton();
            this.Process = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shap_data_GridView)).BeginInit();
            this.databox.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1096, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.關於ToolStripMenuItem});
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.關於ToolStripMenuItem.Text = "關於";
            // 
            // shap_data_GridView
            // 
            this.shap_data_GridView.AllowUserToAddRows = false;
            this.shap_data_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shap_data_GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.delete_column,
            this.ID_column,
            this.shape_column,
            this.literal_column,
            this.x__column,
            this.y_column,
            this.h__column,
            this.w__column});
            this.shap_data_GridView.Location = new System.Drawing.Point(8, 87);
            this.shap_data_GridView.Name = "shap_data_GridView";
            this.shap_data_GridView.ReadOnly = true;
            this.shap_data_GridView.RowHeadersVisible = false;
            this.shap_data_GridView.RowTemplate.Height = 24;
            this.shap_data_GridView.Size = new System.Drawing.Size(371, 376);
            this.shap_data_GridView.TabIndex = 1;
            this.shap_data_GridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.shap_data_GridView_CellClick);
            // 
            // delete_column
            // 
            this.delete_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.delete_column.FillWeight = 120F;
            this.delete_column.HeaderText = "刪除";
            this.delete_column.Name = "delete_column";
            this.delete_column.ReadOnly = true;
            this.delete_column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete_column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ID_column
            // 
            this.ID_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID_column.FillWeight = 60F;
            this.ID_column.HeaderText = "ID";
            this.ID_column.Name = "ID_column";
            this.ID_column.ReadOnly = true;
            // 
            // shape_column
            // 
            this.shape_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.shape_column.FillWeight = 120F;
            this.shape_column.HeaderText = "形狀";
            this.shape_column.Name = "shape_column";
            this.shape_column.ReadOnly = true;
            // 
            // literal_column
            // 
            this.literal_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.literal_column.FillWeight = 130F;
            this.literal_column.HeaderText = "文字";
            this.literal_column.Name = "literal_column";
            this.literal_column.ReadOnly = true;
            // 
            // x__column
            // 
            this.x__column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.x__column.FillWeight = 60F;
            this.x__column.HeaderText = "X";
            this.x__column.Name = "x__column";
            this.x__column.ReadOnly = true;
            // 
            // y_column
            // 
            this.y_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.y_column.FillWeight = 60F;
            this.y_column.HeaderText = "Y";
            this.y_column.Name = "y_column";
            this.y_column.ReadOnly = true;
            // 
            // h__column
            // 
            this.h__column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.h__column.FillWeight = 60F;
            this.h__column.HeaderText = "H";
            this.h__column.Name = "h__column";
            this.h__column.ReadOnly = true;
            // 
            // w__column
            // 
            this.w__column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.w__column.FillWeight = 60F;
            this.w__column.HeaderText = "W";
            this.w__column.Name = "w__column";
            this.w__column.ReadOnly = true;
            // 
            // databox
            // 
            this.databox.Controls.Add(this.W);
            this.databox.Controls.Add(this.H);
            this.databox.Controls.Add(this.shap_data_GridView);
            this.databox.Controls.Add(this.Y);
            this.databox.Controls.Add(this.X);
            this.databox.Controls.Add(this.literal);
            this.databox.Controls.Add(this.wbox);
            this.databox.Controls.Add(this.hbox);
            this.databox.Controls.Add(this.ybox);
            this.databox.Controls.Add(this.xbox);
            this.databox.Controls.Add(this.literalbox);
            this.databox.Controls.Add(this.shape_comboBox);
            this.databox.Controls.Add(this.add_data_button);
            this.databox.Location = new System.Drawing.Point(699, 70);
            this.databox.Name = "databox";
            this.databox.Size = new System.Drawing.Size(385, 456);
            this.databox.TabIndex = 2;
            this.databox.TabStop = false;
            this.databox.Text = "資料顯示";
            // 
            // W
            // 
            this.W.AutoSize = true;
            this.W.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.W.Location = new System.Drawing.Point(346, 39);
            this.W.Name = "W";
            this.W.Size = new System.Drawing.Size(18, 13);
            this.W.TabIndex = 13;
            this.W.Text = "W";
            // 
            // H
            // 
            this.H.AutoSize = true;
            this.H.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.H.Location = new System.Drawing.Point(305, 39);
            this.H.Name = "H";
            this.H.Size = new System.Drawing.Size(15, 13);
            this.H.TabIndex = 12;
            this.H.Text = "H";
            this.H.Click += new System.EventHandler(this.label4_Click);
            // 
            // Y
            // 
            this.Y.AutoSize = true;
            this.Y.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Y.Location = new System.Drawing.Point(264, 39);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(14, 13);
            this.Y.TabIndex = 11;
            this.Y.Text = "Y";
            // 
            // X
            // 
            this.X.AutoSize = true;
            this.X.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.X.Location = new System.Drawing.Point(222, 39);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(14, 13);
            this.X.TabIndex = 10;
            this.X.Text = "X";
            // 
            // literal
            // 
            this.literal.AutoSize = true;
            this.literal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.literal.Location = new System.Drawing.Point(164, 39);
            this.literal.Name = "literal";
            this.literal.Size = new System.Drawing.Size(31, 13);
            this.literal.TabIndex = 9;
            this.literal.Text = "文字";
            // 
            // wbox
            // 
            this.wbox.Location = new System.Drawing.Point(336, 58);
            this.wbox.Name = "wbox";
            this.wbox.Size = new System.Drawing.Size(35, 22);
            this.wbox.TabIndex = 8;
            // 
            // hbox
            // 
            this.hbox.Location = new System.Drawing.Point(295, 58);
            this.hbox.Name = "hbox";
            this.hbox.Size = new System.Drawing.Size(35, 22);
            this.hbox.TabIndex = 7;
            // 
            // ybox
            // 
            this.ybox.Location = new System.Drawing.Point(254, 58);
            this.ybox.Name = "ybox";
            this.ybox.Size = new System.Drawing.Size(35, 22);
            this.ybox.TabIndex = 6;
            // 
            // xbox
            // 
            this.xbox.Location = new System.Drawing.Point(213, 58);
            this.xbox.Name = "xbox";
            this.xbox.Size = new System.Drawing.Size(35, 22);
            this.xbox.TabIndex = 5;
            // 
            // literalbox
            // 
            this.literalbox.Location = new System.Drawing.Point(154, 58);
            this.literalbox.Name = "literalbox";
            this.literalbox.Size = new System.Drawing.Size(53, 22);
            this.literalbox.TabIndex = 4;
            // 
            // shape_comboBox
            // 
            this.shape_comboBox.FormattingEnabled = true;
            this.shape_comboBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.shape_comboBox.Items.AddRange(new object[] {
            "Start",
            "Terminator",
            "Process",
            "Decision"});
            this.shape_comboBox.Location = new System.Drawing.Point(87, 58);
            this.shape_comboBox.Name = "shape_comboBox";
            this.shape_comboBox.Size = new System.Drawing.Size(61, 20);
            this.shape_comboBox.TabIndex = 3;
            // 
            // add_data_button
            // 
            this.add_data_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.add_data_button.Location = new System.Drawing.Point(7, 39);
            this.add_data_button.Name = "add_data_button";
            this.add_data_button.Size = new System.Drawing.Size(74, 39);
            this.add_data_button.TabIndex = 2;
            this.add_data_button.Text = "新增";
            this.add_data_button.UseVisualStyleBackColor = false;
            this.add_data_button.Click += new System.EventHandler(this.add_data_button_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.start,
            this.terminator,
            this.Decision,
            this.Process});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1096, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "第一頁";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "第二頁";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // start
            // 
            this.start.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.start.Image = ((System.Drawing.Image)(resources.GetObject("start.Image")));
            this.start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(23, 22);
            this.start.Text = "Start";
            this.start.ToolTipText = "Start";
            // 
            // terminator
            // 
            this.terminator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.terminator.Image = ((System.Drawing.Image)(resources.GetObject("terminator.Image")));
            this.terminator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.terminator.Name = "terminator";
            this.terminator.Size = new System.Drawing.Size(23, 22);
            this.terminator.Text = "Terminator";
            this.terminator.ToolTipText = "Terminator";
            // 
            // Decision
            // 
            this.Decision.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Decision.Image = ((System.Drawing.Image)(resources.GetObject("Decision.Image")));
            this.Decision.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Decision.Name = "Decision";
            this.Decision.Size = new System.Drawing.Size(23, 22);
            this.Decision.Text = "Decision";
            this.Decision.ToolTipText = "Decision";
            // 
            // Process
            // 
            this.Process.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Process.Image = ((System.Drawing.Image)(resources.GetObject("Process.Image")));
            this.Process.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Process.Name = "Process";
            this.Process.Size = new System.Drawing.Size(23, 22);
            this.Process.Text = "Process";
            this.Process.ToolTipText = "Process";
            // 
            // MyDrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 550);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.databox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MyDrawingForm";
            this.Text = "MyDrawing";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shap_data_GridView)).EndInit();
            this.databox.ResumeLayout(false);
            this.databox.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關於ToolStripMenuItem;
        private System.Windows.Forms.DataGridView shap_data_GridView;
        private System.Windows.Forms.GroupBox databox;
        private System.Windows.Forms.ComboBox shape_comboBox;
        private System.Windows.Forms.Button add_data_button;
        private System.Windows.Forms.Label H;
        private System.Windows.Forms.Label Y;
        private System.Windows.Forms.Label X;
        private System.Windows.Forms.Label literal;
        private System.Windows.Forms.TextBox wbox;
        private System.Windows.Forms.TextBox hbox;
        private System.Windows.Forms.TextBox ybox;
        private System.Windows.Forms.TextBox xbox;
        private System.Windows.Forms.TextBox literalbox;
        private System.Windows.Forms.Label W;
        private System.Windows.Forms.DataGridViewButtonColumn delete_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn shape_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn literal_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn x__column;
        private System.Windows.Forms.DataGridViewTextBoxColumn y_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn h__column;
        private System.Windows.Forms.DataGridViewTextBoxColumn w__column;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton start;
        private System.Windows.Forms.ToolStripButton terminator;
        private System.Windows.Forms.ToolStripButton Decision;
        private System.Windows.Forms.ToolStripButton Process;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

