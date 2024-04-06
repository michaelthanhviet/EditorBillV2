namespace EditorBill
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.FilterDescriptor filterDescriptor1 = new Telerik.WinControls.Data.FilterDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnChooseFile = new Telerik.WinControls.UI.RadButton();
            this.lblFileName = new Telerik.WinControls.UI.RadLabel();
            this.btnClear = new Telerik.WinControls.UI.RadButton();
            this.btnUpdateAll = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.rgvSoPhieu = new Telerik.WinControls.UI.RadGridView();
            this.rgvProduct = new Telerik.WinControls.UI.RadGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnChooseFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSoPhieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSoPhieu.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvProduct.MasterTemplate)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.LightCyan;
            this.radPanel1.Controls.Add(this.btnChooseFile);
            this.radPanel1.Controls.Add(this.lblFileName);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1157, 71);
            this.radPanel1.TabIndex = 19;
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btnChooseFile.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnChooseFile.Image = global::EditorBill.Properties.Resources.upload1;
            this.btnChooseFile.Location = new System.Drawing.Point(3, 21);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(130, 32);
            this.btnChooseFile.TabIndex = 0;
            this.btnChooseFile.Text = "Chọn file";
            this.btnChooseFile.ThemeName = "Office2010Blue";
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileName.AutoSize = false;
            this.lblFileName.BackColor = System.Drawing.Color.LightCyan;
            this.lblFileName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblFileName.Location = new System.Drawing.Point(139, 21);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(740, 31);
            this.lblFileName.TabIndex = 18;
            this.lblFileName.Text = "Chưa có file nào được chọn.";
            this.lblFileName.ThemeName = "office2010BlueTheme1";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Enabled = false;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btnClear.ForeColor = System.Drawing.Color.Red;
            this.btnClear.Image = global::EditorBill.Properties.Resources.delete;
            this.btnClear.Location = new System.Drawing.Point(23, 54);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(117, 32);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "Xóa file";
            this.btnClear.ThemeName = "Office2010Blue";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdateAll
            // 
            this.btnUpdateAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdateAll.Enabled = false;
            this.btnUpdateAll.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btnUpdateAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdateAll.Location = new System.Drawing.Point(153, 54);
            this.btnUpdateAll.Name = "btnUpdateAll";
            this.btnUpdateAll.Size = new System.Drawing.Size(210, 32);
            this.btnUpdateAll.TabIndex = 0;
            this.btnUpdateAll.Text = "Cập nhật toàn bộ";
            this.btnUpdateAll.ThemeName = "Office2010Blue";
            this.btnUpdateAll.Click += new System.EventHandler(this.btnUpdateAll_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.radGroupBox1.Controls.Add(this.rgvSoPhieu);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.radGroupBox1.ForeColor = System.Drawing.Color.Black;
            this.radGroupBox1.HeaderText = "Số  Phiếu";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 71);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(2, 25, 2, 2);
            this.radGroupBox1.Size = new System.Drawing.Size(247, 512);
            this.radGroupBox1.TabIndex = 20;
            this.radGroupBox1.Text = "Số  Phiếu";
            this.radGroupBox1.ThemeName = "Office2010Blue";
            // 
            // rgvSoPhieu
            // 
            this.rgvSoPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgvSoPhieu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.rgvSoPhieu.Location = new System.Drawing.Point(0, 25);
            // 
            // 
            // 
            this.rgvSoPhieu.MasterTemplate.AllowAddNewRow = false;
            this.rgvSoPhieu.MasterTemplate.AllowCellContextMenu = false;
            this.rgvSoPhieu.MasterTemplate.AllowColumnChooser = false;
            this.rgvSoPhieu.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.rgvSoPhieu.MasterTemplate.AllowColumnReorder = false;
            this.rgvSoPhieu.MasterTemplate.AllowColumnResize = false;
            this.rgvSoPhieu.MasterTemplate.AllowDeleteRow = false;
            this.rgvSoPhieu.MasterTemplate.AllowDragToGroup = false;
            this.rgvSoPhieu.MasterTemplate.AllowEditRow = false;
            this.rgvSoPhieu.MasterTemplate.AllowRowResize = false;
            gridViewTextBoxColumn1.HeaderText = "Số Phiếu";
            gridViewTextBoxColumn1.Name = "SoPhieu";
            gridViewTextBoxColumn1.Width = 200;
            this.rgvSoPhieu.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.rgvSoPhieu.MasterTemplate.MultiSelect = true;
            this.rgvSoPhieu.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgvSoPhieu.Name = "rgvSoPhieu";
            this.rgvSoPhieu.Size = new System.Drawing.Size(247, 487);
            this.rgvSoPhieu.TabIndex = 0;
            this.rgvSoPhieu.ThemeName = "Office2010Blue";
            // 
            // rgvProduct
            // 
            this.rgvProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgvProduct.EnableCustomFiltering = true;
            this.rgvProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.rgvProduct.Location = new System.Drawing.Point(3, 25);
            // 
            // 
            // 
            this.rgvProduct.MasterTemplate.AllowAddNewRow = false;
            this.rgvProduct.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.rgvProduct.MasterTemplate.AllowColumnReorder = false;
            this.rgvProduct.MasterTemplate.AllowColumnResize = false;
            this.rgvProduct.MasterTemplate.AllowDeleteRow = false;
            this.rgvProduct.MasterTemplate.AllowDragToGroup = false;
            this.rgvProduct.MasterTemplate.AllowRowResize = false;
            this.rgvProduct.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn2.HeaderText = "Mã hàng";
            gridViewTextBoxColumn2.Name = "ID";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 200;
            gridViewTextBoxColumn3.AllowSearching = false;
            gridViewTextBoxColumn3.HeaderText = "Miêu tả";
            gridViewTextBoxColumn3.Name = "Description";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 400;
            gridViewTextBoxColumn4.AllowSearching = false;
            gridViewTextBoxColumn4.HeaderText = "Giá Thùng";
            gridViewTextBoxColumn4.Name = "Price1";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn4.Width = 130;
            gridViewTextBoxColumn5.AllowSearching = false;
            gridViewTextBoxColumn5.HeaderText = "Giá lẻ";
            gridViewTextBoxColumn5.Name = "Price2";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn5.Width = 130;
            this.rgvProduct.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.rgvProduct.MasterTemplate.EnableCustomFiltering = true;
            this.rgvProduct.MasterTemplate.FilterDescriptors.AddRange(new Telerik.WinControls.Data.FilterDescriptor[] {
            filterDescriptor1});
            this.rgvProduct.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.rgvProduct.Name = "rgvProduct";
            this.rgvProduct.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.None;
            this.rgvProduct.Size = new System.Drawing.Size(904, 364);
            this.rgvProduct.TabIndex = 21;
            this.rgvProduct.ThemeName = "Office2010Blue";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Azure;
            this.groupBox1.Controls.Add(this.rgvProduct);
            this.groupBox1.Location = new System.Drawing.Point(247, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(910, 392);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hàng bán";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.BackColor = System.Drawing.Color.PowderBlue;
            this.radGroupBox2.Controls.Add(this.btnClear);
            this.radGroupBox2.Controls.Add(this.btnUpdateAll);
            this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radGroupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.radGroupBox2.HeaderText = "Chức năng";
            this.radGroupBox2.Location = new System.Drawing.Point(247, 460);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(910, 123);
            this.radGroupBox2.TabIndex = 23;
            this.radGroupBox2.Text = "Chức năng";
            this.radGroupBox2.ThemeName = "Office2010Blue";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1157, 583);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radPanel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor Bill";
            this.ThemeName = "Office2010Blue";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnChooseFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFileName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgvSoPhieu.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvSoPhieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvProduct.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvProduct)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnChooseFile;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel lblFileName;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadButton btnUpdateAll;
        private Telerik.WinControls.UI.RadButton btnClear;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        public Telerik.WinControls.UI.RadGridView rgvProduct;
        private Telerik.WinControls.UI.RadGridView rgvSoPhieu;
    }
}