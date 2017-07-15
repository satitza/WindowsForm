namespace ExtremeInternetShop
{
    partial class AllAppointments
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllAppointments));
            this.monthCalendarAll = new System.Windows.Forms.MonthCalendar();
            this.dataGridViewAll = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShopStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.วันที่นัด = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShopID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ชื่อร้าน = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ผู้ติดต่อ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.เบอร์โทรศัพท์ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.เลขที่ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ย่าน = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ถนน = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.แขวง = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.เขต = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.จังหวัด = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.หมายเหตุ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtShopComment = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCounty = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtZone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumHome = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtShopPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtShopMaster = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShopName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtShopID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteDate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEditDate = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dateTimePickerAll = new System.Windows.Forms.DateTimePicker();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtDateComment = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAll)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendarAll
            // 
            this.monthCalendarAll.CalendarDimensions = new System.Drawing.Size(3, 3);
            this.monthCalendarAll.Location = new System.Drawing.Point(5, 2);
            this.monthCalendarAll.Name = "monthCalendarAll";
            this.monthCalendarAll.TabIndex = 0;
            this.toolTip1.SetToolTip(this.monthCalendarAll, "คลิกที่วันเพื่อดูนัดหมาย");
            this.monthCalendarAll.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarAll_DateChanged);
            // 
            // dataGridViewAll
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridViewAll.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ShopStatus,
            this.วันที่นัด,
            this.ShopID,
            this.ชื่อร้าน,
            this.ผู้ติดต่อ,
            this.เบอร์โทรศัพท์,
            this.เลขที่,
            this.ย่าน,
            this.ถนน,
            this.แขวง,
            this.เขต,
            this.จังหวัด,
            this.หมายเหตุ});
            this.dataGridViewAll.Location = new System.Drawing.Point(5, 463);
            this.dataGridViewAll.Name = "dataGridViewAll";
            this.dataGridViewAll.Size = new System.Drawing.Size(1293, 224);
            this.dataGridViewAll.TabIndex = 1;
            this.dataGridViewAll.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAll_CellClick);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 43;
            // 
            // ShopStatus
            // 
            this.ShopStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ShopStatus.HeaderText = "ShopStatus";
            this.ShopStatus.Name = "ShopStatus";
            this.ShopStatus.Width = 87;
            // 
            // วันที่นัด
            // 
            this.วันที่นัด.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.วันที่นัด.HeaderText = "วันที่นัด";
            this.วันที่นัด.Name = "วันที่นัด";
            this.วันที่นัด.Width = 68;
            // 
            // ShopID
            // 
            this.ShopID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ShopID.HeaderText = "ShopID";
            this.ShopID.Name = "ShopID";
            this.ShopID.Width = 68;
            // 
            // ชื่อร้าน
            // 
            this.ชื่อร้าน.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ชื่อร้าน.HeaderText = "ชื่อร้าน";
            this.ชื่อร้าน.Name = "ชื่อร้าน";
            this.ชื่อร้าน.Width = 64;
            // 
            // ผู้ติดต่อ
            // 
            this.ผู้ติดต่อ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ผู้ติดต่อ.HeaderText = "ผู้ติดต่อ";
            this.ผู้ติดต่อ.Name = "ผู้ติดต่อ";
            this.ผู้ติดต่อ.Width = 66;
            // 
            // เบอร์โทรศัพท์
            // 
            this.เบอร์โทรศัพท์.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.เบอร์โทรศัพท์.HeaderText = "เบอร์โทรสัพท์";
            this.เบอร์โทรศัพท์.Name = "เบอร์โทรศัพท์";
            this.เบอร์โทรศัพท์.Width = 95;
            // 
            // เลขที่
            // 
            this.เลขที่.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.เลขที่.HeaderText = "เลขที่";
            this.เลขที่.Name = "เลขที่";
            this.เลขที่.Width = 56;
            // 
            // ย่าน
            // 
            this.ย่าน.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ย่าน.HeaderText = "ย่าน";
            this.ย่าน.Name = "ย่าน";
            this.ย่าน.Width = 52;
            // 
            // ถนน
            // 
            this.ถนน.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ถนน.HeaderText = "ถนน";
            this.ถนน.Name = "ถนน";
            this.ถนน.Width = 55;
            // 
            // แขวง
            // 
            this.แขวง.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.แขวง.HeaderText = "แขวง";
            this.แขวง.Name = "แขวง";
            this.แขวง.Width = 57;
            // 
            // เขต
            // 
            this.เขต.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.เขต.HeaderText = "เขต";
            this.เขต.Name = "เขต";
            this.เขต.Width = 50;
            // 
            // จังหวัด
            // 
            this.จังหวัด.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.จังหวัด.HeaderText = "จังหวัด";
            this.จังหวัด.Name = "จังหวัด";
            this.จังหวัด.Width = 63;
            // 
            // หมายเหตุ
            // 
            this.หมายเหตุ.HeaderText = "หมายเหตุ";
            this.หมายเหตุ.Name = "หมายเหตุ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtShopComment);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtCounty);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtArea);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtDistrict);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtStreet);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtZone);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtNumHome);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtShopPhone);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtShopMaster);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtShopName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtShopID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(559, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 226);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ที่อยู่ร้านเกมส์";
            // 
            // txtShopComment
            // 
            this.txtShopComment.Location = new System.Drawing.Point(70, 98);
            this.txtShopComment.Multiline = true;
            this.txtShopComment.Name = "txtShopComment";
            this.txtShopComment.ReadOnly = true;
            this.txtShopComment.Size = new System.Drawing.Size(661, 122);
            this.txtShopComment.TabIndex = 23;
            this.toolTip1.SetToolTip(this.txtShopComment, "หมายเหตุ");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "หมายเหตุ";
            // 
            // txtCounty
            // 
            this.txtCounty.Location = new System.Drawing.Point(262, 71);
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.ReadOnly = true;
            this.txtCounty.Size = new System.Drawing.Size(171, 20);
            this.txtCounty.TabIndex = 21;
            this.toolTip1.SetToolTip(this.txtCounty, "จังหวัด");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(218, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "จังหวัด";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(99, 71);
            this.txtArea.Name = "txtArea";
            this.txtArea.ReadOnly = true;
            this.txtArea.Size = new System.Drawing.Size(113, 20);
            this.txtArea.TabIndex = 19;
            this.toolTip1.SetToolTip(this.txtArea, "เขต");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(68, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "เขต";
            // 
            // txtDistrict
            // 
            this.txtDistrict.Location = new System.Drawing.Point(546, 45);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.ReadOnly = true;
            this.txtDistrict.Size = new System.Drawing.Size(113, 20);
            this.txtDistrict.TabIndex = 17;
            this.toolTip1.SetToolTip(this.txtDistrict, "แขวง");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(510, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "แขวง";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(389, 45);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.ReadOnly = true;
            this.txtStreet.Size = new System.Drawing.Size(113, 20);
            this.txtStreet.TabIndex = 15;
            this.toolTip1.SetToolTip(this.txtStreet, "ถนน");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(353, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "ถนน";
            // 
            // txtZone
            // 
            this.txtZone.Location = new System.Drawing.Point(234, 45);
            this.txtZone.Name = "txtZone";
            this.txtZone.ReadOnly = true;
            this.txtZone.Size = new System.Drawing.Size(113, 20);
            this.txtZone.TabIndex = 13;
            this.toolTip1.SetToolTip(this.txtZone, "ย่าน");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "ย่าน";
            // 
            // txtNumHome
            // 
            this.txtNumHome.Location = new System.Drawing.Point(105, 45);
            this.txtNumHome.Name = "txtNumHome";
            this.txtNumHome.ReadOnly = true;
            this.txtNumHome.Size = new System.Drawing.Size(90, 20);
            this.txtNumHome.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtNumHome, "เลขที่");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "เลขที่";
            // 
            // txtShopPhone
            // 
            this.txtShopPhone.Location = new System.Drawing.Point(625, 19);
            this.txtShopPhone.Name = "txtShopPhone";
            this.txtShopPhone.ReadOnly = true;
            this.txtShopPhone.Size = new System.Drawing.Size(108, 20);
            this.txtShopPhone.TabIndex = 9;
            this.toolTip1.SetToolTip(this.txtShopPhone, "เบอร์โทรศัพท์");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(549, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "เบอร์โทรสัพท์";
            // 
            // txtShopMaster
            // 
            this.txtShopMaster.Location = new System.Drawing.Point(454, 19);
            this.txtShopMaster.Name = "txtShopMaster";
            this.txtShopMaster.ReadOnly = true;
            this.txtShopMaster.Size = new System.Drawing.Size(89, 20);
            this.txtShopMaster.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtShopMaster, "ชื่อผู้ติดต่อ");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(407, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "ผู้ติดต่อ";
            // 
            // txtShopName
            // 
            this.txtShopName.Location = new System.Drawing.Point(294, 19);
            this.txtShopName.Name = "txtShopName";
            this.txtShopName.ReadOnly = true;
            this.txtShopName.Size = new System.Drawing.Size(106, 20);
            this.txtShopName.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtShopName, "ชื่อร้านเกมส์");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "ชื่อร้าน";
            // 
            // txtShopID
            // 
            this.txtShopID.Location = new System.Drawing.Point(162, 19);
            this.txtShopID.Name = "txtShopID";
            this.txtShopID.ReadOnly = true;
            this.txtShopID.Size = new System.Drawing.Size(79, 20);
            this.txtShopID.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtShopID, "Shop ID");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ShopID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(36, 19);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(71, 20);
            this.txtID.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtID, "ID");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteDate);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnEditDate);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.dateTimePickerAll);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.txtDateComment);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(559, 244);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(739, 186);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ข้อมูลนัดหมาย";
            // 
            // btnDeleteDate
            // 
            this.btnDeleteDate.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteDate.Image")));
            this.btnDeleteDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteDate.Location = new System.Drawing.Point(439, 26);
            this.btnDeleteDate.Name = "btnDeleteDate";
            this.btnDeleteDate.Size = new System.Drawing.Size(125, 23);
            this.btnDeleteDate.TabIndex = 11;
            this.btnDeleteDate.Text = "ลบวันนัดหมาย";
            this.toolTip1.SetToolTip(this.btnDeleteDate, "ลบวันนัดหมาย");
            this.btnDeleteDate.UseVisualStyleBackColor = true;
            this.btnDeleteDate.Click += new System.EventHandler(this.btnDeleteDate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(413, 157);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "บันทึก";
            this.toolTip1.SetToolTip(this.btnSave, "บันทึกหมายเหตุ");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEditDate
            // 
            this.btnEditDate.Image = ((System.Drawing.Image)(resources.GetObject("btnEditDate.Image")));
            this.btnEditDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditDate.Location = new System.Drawing.Point(308, 26);
            this.btnEditDate.Name = "btnEditDate";
            this.btnEditDate.Size = new System.Drawing.Size(125, 23);
            this.btnEditDate.TabIndex = 6;
            this.btnEditDate.Text = "แก้ใขวันนัดหมาย";
            this.toolTip1.SetToolTip(this.btnEditDate, "แก้ใขวันนัดหมาย");
            this.btnEditDate.UseVisualStyleBackColor = true;
            this.btnEditDate.Click += new System.EventHandler(this.btnEditDate_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(494, 157);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "แก้ใข";
            this.toolTip1.SetToolTip(this.btnEdit, "แก้ใขหมายเหตุ");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dateTimePickerAll
            // 
            this.dateTimePickerAll.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerAll.Location = new System.Drawing.Point(105, 28);
            this.dateTimePickerAll.Name = "dateTimePickerAll";
            this.dateTimePickerAll.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerAll.TabIndex = 5;
            this.toolTip1.SetToolTip(this.dateTimePickerAll, "วันที่นัดหมาย");
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(575, 157);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "ลบ";
            this.toolTip1.SetToolTip(this.btnDelete, "ลบหมายเหคุ");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "แก้ใขวันนัด";
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(656, 157);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "เครียร์";
            this.toolTip1.SetToolTip(this.btnClear, "เครียร์ Textbox และโหลดข้อมูลใหม่");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtDateComment
            // 
            this.txtDateComment.Location = new System.Drawing.Point(105, 55);
            this.txtDateComment.Multiline = true;
            this.txtDateComment.Name = "txtDateComment";
            this.txtDateComment.Size = new System.Drawing.Size(626, 96);
            this.txtDateComment.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtDateComment, "หมายเหตุของแต่ละวัน");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(43, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "หมายเหตุ";
            // 
            // AllAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 689);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewAll);
            this.Controls.Add(this.monthCalendarAll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AllAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รายการนัดหมายทั้งหมด";
            this.Load += new System.EventHandler(this.AllAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAll)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendarAll;
        private System.Windows.Forms.DataGridView dataGridViewAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtShopComment;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCounty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtZone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumHome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtShopPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtShopMaster;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtShopName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtShopID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtDateComment;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShopStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn วันที่นัด;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShopID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ชื่อร้าน;
        private System.Windows.Forms.DataGridViewTextBoxColumn ผู้ติดต่อ;
        private System.Windows.Forms.DataGridViewTextBoxColumn เบอร์โทรศัพท์;
        private System.Windows.Forms.DataGridViewTextBoxColumn เลขที่;
        private System.Windows.Forms.DataGridViewTextBoxColumn ย่าน;
        private System.Windows.Forms.DataGridViewTextBoxColumn ถนน;
        private System.Windows.Forms.DataGridViewTextBoxColumn แขวง;
        private System.Windows.Forms.DataGridViewTextBoxColumn เขต;
        private System.Windows.Forms.DataGridViewTextBoxColumn จังหวัด;
        private System.Windows.Forms.DataGridViewTextBoxColumn หมายเหตุ;
        private System.Windows.Forms.Button btnEditDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteDate;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}