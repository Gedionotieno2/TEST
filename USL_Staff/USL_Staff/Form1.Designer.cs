namespace USL_Staff
{
    partial class frmDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetails));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpEmp = new System.Windows.Forms.DateTimePicker();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.cbBase = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtIDNo = new System.Windows.Forms.TextBox();
            this.txtStaffNo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.btnSavePic = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pic = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRes = new System.Windows.Forms.TextBox();
            this.txtSubLoc = new System.Windows.Forms.TextBox();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.txtDiv = new System.Windows.Forms.TextBox();
            this.txtDist = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lvNames = new System.Windows.Forms.ListView();
            this.txtSrch = new System.Windows.Forms.TextBox();
            this.Warnings = new System.Windows.Forms.GroupBox();
            this.lvWarn = new System.Windows.Forms.ListView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSecRefRel = new System.Windows.Forms.TextBox();
            this.txtSecRef = new System.Windows.Forms.TextBox();
            this.txtFirstRefRel = new System.Windows.Forms.TextBox();
            this.txtFirstRef = new System.Windows.Forms.TextBox();
            this.btnWarn = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.Warnings.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpEmp);
            this.groupBox1.Controls.Add(this.dtpDob);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cbBase);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAge);
            this.groupBox1.Controls.Add(this.txtSName);
            this.groupBox1.Controls.Add(this.txtMName);
            this.groupBox1.Controls.Add(this.txtFName);
            this.groupBox1.Controls.Add(this.txtIDNo);
            this.groupBox1.Controls.Add(this.txtStaffNo);
            this.groupBox1.Location = new System.Drawing.Point(13, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 242);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtpEmp
            // 
            this.dtpEmp.Location = new System.Drawing.Point(114, 183);
            this.dtpEmp.Name = "dtpEmp";
            this.dtpEmp.Size = new System.Drawing.Size(211, 20);
            this.dtpEmp.TabIndex = 19;
            // 
            // dtpDob
            // 
            this.dtpDob.Location = new System.Drawing.Point(114, 157);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(211, 20);
            this.dtpDob.TabIndex = 18;
            this.dtpDob.ValueChanged += new System.EventHandler(this.dtpDob_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(181, 212);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Base:";
            // 
            // cbBase
            // 
            this.cbBase.FormattingEnabled = true;
            this.cbBase.Location = new System.Drawing.Point(216, 209);
            this.cbBase.Name = "cbBase";
            this.cbBase.Size = new System.Drawing.Size(109, 21);
            this.cbBase.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Age:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Employment date\':";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Date of Birth:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Surname:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Middle Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "ID No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Staff Number:";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(114, 209);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(62, 20);
            this.txtAge.TabIndex = 7;
            // 
            // txtSName
            // 
            this.txtSName.Location = new System.Drawing.Point(114, 131);
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(211, 20);
            this.txtSName.TabIndex = 4;
            // 
            // txtMName
            // 
            this.txtMName.Location = new System.Drawing.Point(114, 105);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(211, 20);
            this.txtMName.TabIndex = 3;
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(114, 79);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(211, 20);
            this.txtFName.TabIndex = 2;
            // 
            // txtIDNo
            // 
            this.txtIDNo.Location = new System.Drawing.Point(114, 53);
            this.txtIDNo.Name = "txtIDNo";
            this.txtIDNo.Size = new System.Drawing.Size(211, 20);
            this.txtIDNo.TabIndex = 1;
            // 
            // txtStaffNo
            // 
            this.txtStaffNo.Location = new System.Drawing.Point(114, 22);
            this.txtStaffNo.Name = "txtStaffNo";
            this.txtStaffNo.Size = new System.Drawing.Size(211, 20);
            this.txtStaffNo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDetails);
            this.groupBox2.Controls.Add(this.btnSavePic);
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.pic);
            this.groupBox2.Location = new System.Drawing.Point(361, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 469);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Photo";
            // 
            // lblDetails
            // 
            this.lblDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDetails.Location = new System.Drawing.Point(7, 351);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(278, 108);
            this.lblDetails.TabIndex = 3;
            // 
            // btnSavePic
            // 
            this.btnSavePic.Location = new System.Drawing.Point(146, 304);
            this.btnSavePic.Name = "btnSavePic";
            this.btnSavePic.Size = new System.Drawing.Size(140, 29);
            this.btnSavePic.TabIndex = 2;
            this.btnSavePic.Text = "Save";
            this.btnSavePic.UseVisualStyleBackColor = true;
            this.btnSavePic.Click += new System.EventHandler(this.btnSavePic_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(7, 306);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(132, 28);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.Black;
            this.pic.Location = new System.Drawing.Point(6, 20);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(280, 280);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtRes);
            this.groupBox3.Controls.Add(this.txtSubLoc);
            this.groupBox3.Controls.Add(this.txtLoc);
            this.groupBox3.Controls.Add(this.txtDiv);
            this.groupBox3.Controls.Add(this.txtDist);
            this.groupBox3.Location = new System.Drawing.Point(13, 327);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(342, 173);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Background Details";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Current Residence:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Sublocation:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Location:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Division:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "District of Birth:";
            // 
            // txtRes
            // 
            this.txtRes.Location = new System.Drawing.Point(114, 148);
            this.txtRes.Name = "txtRes";
            this.txtRes.Size = new System.Drawing.Size(211, 20);
            this.txtRes.TabIndex = 4;
            // 
            // txtSubLoc
            // 
            this.txtSubLoc.Location = new System.Drawing.Point(114, 114);
            this.txtSubLoc.Name = "txtSubLoc";
            this.txtSubLoc.Size = new System.Drawing.Size(211, 20);
            this.txtSubLoc.TabIndex = 3;
            // 
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(114, 79);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(211, 20);
            this.txtLoc.TabIndex = 2;
            // 
            // txtDiv
            // 
            this.txtDiv.Location = new System.Drawing.Point(114, 49);
            this.txtDiv.Name = "txtDiv";
            this.txtDiv.Size = new System.Drawing.Size(211, 20);
            this.txtDiv.TabIndex = 1;
            // 
            // txtDist
            // 
            this.txtDist.Location = new System.Drawing.Point(114, 19);
            this.txtDist.Name = "txtDist";
            this.txtDist.Size = new System.Drawing.Size(211, 20);
            this.txtDist.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lvNames);
            this.groupBox4.Controls.Add(this.txtSrch);
            this.groupBox4.Location = new System.Drawing.Point(663, 70);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(266, 469);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search";
            // 
            // lvNames
            // 
            this.lvNames.FullRowSelect = true;
            this.lvNames.Location = new System.Drawing.Point(7, 53);
            this.lvNames.Name = "lvNames";
            this.lvNames.Size = new System.Drawing.Size(253, 406);
            this.lvNames.TabIndex = 1;
            this.lvNames.UseCompatibleStateImageBehavior = false;
            this.lvNames.SelectedIndexChanged += new System.EventHandler(this.lvNames_SelectedIndexChanged);
            // 
            // txtSrch
            // 
            this.txtSrch.Location = new System.Drawing.Point(7, 20);
            this.txtSrch.Name = "txtSrch";
            this.txtSrch.Size = new System.Drawing.Size(253, 20);
            this.txtSrch.TabIndex = 0;
            this.txtSrch.TextChanged += new System.EventHandler(this.txtSrch_TextChanged);
            // 
            // Warnings
            // 
            this.Warnings.Controls.Add(this.lvWarn);
            this.Warnings.Location = new System.Drawing.Point(361, 546);
            this.Warnings.Name = "Warnings";
            this.Warnings.Size = new System.Drawing.Size(568, 181);
            this.Warnings.TabIndex = 4;
            this.Warnings.TabStop = false;
            this.Warnings.Text = "Warnings";
            // 
            // lvWarn
            // 
            this.lvWarn.Location = new System.Drawing.Point(7, 20);
            this.lvWarn.Name = "lvWarn";
            this.lvWarn.Size = new System.Drawing.Size(555, 155);
            this.lvWarn.TabIndex = 0;
            this.lvWarn.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.txtSecRefRel);
            this.groupBox5.Controls.Add(this.txtSecRef);
            this.groupBox5.Controls.Add(this.txtFirstRefRel);
            this.groupBox5.Controls.Add(this.txtFirstRef);
            this.groupBox5.Location = new System.Drawing.Point(13, 587);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(342, 140);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Referees";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 111);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 13);
            this.label18.TabIndex = 7;
            this.label18.Text = "Relationship:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 81);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "Second Referee:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = "Relationship:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "First Referee:";
            // 
            // txtSecRefRel
            // 
            this.txtSecRefRel.Location = new System.Drawing.Point(114, 111);
            this.txtSecRefRel.Name = "txtSecRefRel";
            this.txtSecRefRel.Size = new System.Drawing.Size(211, 20);
            this.txtSecRefRel.TabIndex = 3;
            // 
            // txtSecRef
            // 
            this.txtSecRef.Location = new System.Drawing.Point(114, 81);
            this.txtSecRef.Name = "txtSecRef";
            this.txtSecRef.Size = new System.Drawing.Size(211, 20);
            this.txtSecRef.TabIndex = 2;
            // 
            // txtFirstRefRel
            // 
            this.txtFirstRefRel.Location = new System.Drawing.Point(114, 50);
            this.txtFirstRefRel.Name = "txtFirstRefRel";
            this.txtFirstRefRel.Size = new System.Drawing.Size(211, 20);
            this.txtFirstRefRel.TabIndex = 1;
            // 
            // txtFirstRef
            // 
            this.txtFirstRef.Location = new System.Drawing.Point(114, 20);
            this.txtFirstRef.Name = "txtFirstRef";
            this.txtFirstRef.Size = new System.Drawing.Size(211, 20);
            this.txtFirstRef.TabIndex = 0;
            // 
            // btnWarn
            // 
            this.btnWarn.Image = global::USL_Staff.Properties.Resources.warning_icon;
            this.btnWarn.Location = new System.Drawing.Point(756, 3);
            this.btnWarn.Name = "btnWarn";
            this.btnWarn.Size = new System.Drawing.Size(173, 64);
            this.btnWarn.TabIndex = 9;
            this.btnWarn.Text = "Warning";
            this.btnWarn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWarn.UseVisualStyleBackColor = true;
            this.btnWarn.Click += new System.EventHandler(this.btnWarn_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::USL_Staff.Properties.Resources.Actions_document_save_icon;
            this.btnSave.Location = new System.Drawing.Point(568, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(189, 64);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::USL_Staff.Properties.Resources.delete_icon;
            this.btnDelete.Location = new System.Drawing.Point(390, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(178, 64);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::USL_Staff.Properties.Resources.edit_file_icon;
            this.btnEdit.Location = new System.Drawing.Point(205, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(186, 64);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = global::USL_Staff.Properties.Resources.users_add_icon;
            this.btnNew.Location = new System.Drawing.Point(13, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(193, 64);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "New ";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.txtEmail);
            this.groupBox6.Controls.Add(this.txtMobile);
            this.groupBox6.Location = new System.Drawing.Point(13, 507);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(342, 74);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Contact Details";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(114, 15);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(211, 20);
            this.txtMobile.TabIndex = 0;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(114, 46);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(211, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 18);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "Mobile:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(18, 49);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 13);
            this.label20.TabIndex = 3;
            this.label20.Text = "Email Address:";
            // 
            // frmDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 733);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnWarn);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.Warnings);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ultimate Security: Staff Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDetails_FormClosing);
            this.Load += new System.EventHandler(this.frmDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.Warnings.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtSName;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtIDNo;
        private System.Windows.Forms.TextBox txtStaffNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Button btnSavePic;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtRes;
        private System.Windows.Forms.TextBox txtSubLoc;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.TextBox txtDiv;
        private System.Windows.Forms.TextBox txtDist;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox Warnings;
        private System.Windows.Forms.ListView lvWarn;
        private System.Windows.Forms.ListView lvNames;
        private System.Windows.Forms.TextBox txtSrch;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnWarn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbBase;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSecRefRel;
        private System.Windows.Forms.TextBox txtSecRef;
        private System.Windows.Forms.TextBox txtFirstRefRel;
        private System.Windows.Forms.TextBox txtFirstRef;
        private System.Windows.Forms.DateTimePicker dtpEmp;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMobile;
    }
}

