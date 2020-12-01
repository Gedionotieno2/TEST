using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading;	
using System.Configuration;

namespace RAS_CORE
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
    /// 
    struct Alarm
    {
        public string qSignal;
    }

    //update receiver listview delegate: thread safety
    public delegate void SetTextCallback(string s);
    public delegate void setTcpTextCallBack(string str);
    public delegate void SetListBoxItem(String str, String type); 

	public class frmMain : System.Windows.Forms.Form
    {
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListBox lstConn;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.StatusBar sb;
		private System.Windows.Forms.TextBox txtRcv;
		private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvRcv;
		private RData mData;
		private System.Windows.Forms.Timer tmrRCI;
		private System.Windows.Forms.Timer tmrCIU;
		private System.Windows.Forms.ListBox lstEv;
		private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Timer tmRM;
        private System.Windows.Forms.ListBox lstEvtLog;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.DateTimePicker dtpLog;
		private System.Windows.Forms.Label label1;

		//my vars
		private string logMsg;
		private string logRCI;
        private System.Windows.Forms.TextBox txtRcvRCI;
        private TreeView tvComp;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private GroupBox groupBox8;
        private TextBox tHtFX;
        private TextBox tHbFX;
        private Label label3;
        private Label label2;
        private TextBox tLsFX;
        private Label label4;
        private TextBox tHbRCI;
        private TextBox tCkCIU;
        private TextBox tHbCIU;
        private TextBox txtFX;
        private TextBox tLsRCI;
        private Label label5;
        private Label label7;
        private Label label6;
        private TextBox tLsCIU;
        private Label label9;
        private Label label8;

        Queue alQueue = new Queue(); //hold alarms which have not been sent to client
        private ArrayList m_aryClients = new ArrayList();
        private ImageList imgLst;
        private SocketChatClient client;

        private string sBuff;
        private TextBox textBox1;
        private Label label10;
        private CommStudio.Connections.SerialConnection sConn;
        private ListBox lbCIU;
        private CommStudio.Connections.SerialConnection scRCI;
        private CommStudio.Connections.SerialConnection scFox; //to hold temporary CIU data
        private Hashtable hT;

		public frmMain()
		{
			// Required for Windows Form Designer support

			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tvComp = new System.Windows.Forms.TreeView();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstEvtLog = new System.Windows.Forms.ListBox();
            this.dtpLog = new System.Windows.Forms.DateTimePicker();
            this.lstConn = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbCIU = new System.Windows.Forms.ListBox();
            this.txtFX = new System.Windows.Forms.TextBox();
            this.txtRcvRCI = new System.Windows.Forms.TextBox();
            this.txtRcv = new System.Windows.Forms.TextBox();
            this.lstEv = new System.Windows.Forms.ListBox();
            this.sb = new System.Windows.Forms.StatusBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvRcv = new System.Windows.Forms.ListView();
            this.tmrRCI = new System.Windows.Forms.Timer(this.components);
            this.tmrCIU = new System.Windows.Forms.Timer(this.components);
            this.tmRM = new System.Windows.Forms.Timer(this.components);
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tLsRCI = new System.Windows.Forms.TextBox();
            this.tHbRCI = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tLsCIU = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tCkCIU = new System.Windows.Forms.TextBox();
            this.tHbCIU = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tLsFX = new System.Windows.Forms.TextBox();
            this.tHtFX = new System.Windows.Forms.TextBox();
            this.tHbFX = new System.Windows.Forms.TextBox();
            this.sConn = new CommStudio.Connections.SerialConnection(this.components);
            this.scRCI = new CommStudio.Connections.SerialConnection(this.components);
            this.scFox = new CommStudio.Connections.SerialConnection(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(621, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 438);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tvComp);
            this.groupBox5.Location = new System.Drawing.Point(6, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(293, 225);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // tvComp
            // 
            this.tvComp.ImageIndex = 0;
            this.tvComp.ImageList = this.imgLst;
            this.tvComp.Location = new System.Drawing.Point(6, 13);
            this.tvComp.Name = "tvComp";
            this.tvComp.SelectedImageIndex = 0;
            this.tvComp.Size = new System.Drawing.Size(279, 206);
            this.tvComp.TabIndex = 0;
            // 
            // imgLst
            // 
            this.imgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst.ImageStream")));
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst.Images.SetKeyName(0, "Computer-icon.png");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.lstEvtLog);
            this.groupBox4.Controls.Add(this.dtpLog);
            this.groupBox4.Location = new System.Drawing.Point(6, 239);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(293, 185);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(198, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Call Events for this Date";
            // 
            // lstEvtLog
            // 
            this.lstEvtLog.Location = new System.Drawing.Point(8, 16);
            this.lstEvtLog.Name = "lstEvtLog";
            this.lstEvtLog.Size = new System.Drawing.Size(277, 134);
            this.lstEvtLog.TabIndex = 2;
            // 
            // dtpLog
            // 
            this.dtpLog.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLog.Location = new System.Drawing.Point(8, 154);
            this.dtpLog.Name = "dtpLog";
            this.dtpLog.Size = new System.Drawing.Size(184, 20);
            this.dtpLog.TabIndex = 1;
            this.dtpLog.ValueChanged += new System.EventHandler(this.dtpLog_ValueChanged);
            // 
            // lstConn
            // 
            this.lstConn.BackColor = System.Drawing.Color.Black;
            this.lstConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstConn.ForeColor = System.Drawing.Color.Lime;
            this.lstConn.ItemHeight = 16;
            this.lstConn.Location = new System.Drawing.Point(8, 248);
            this.lstConn.Name = "lstConn";
            this.lstConn.Size = new System.Drawing.Size(296, 180);
            this.lstConn.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbCIU);
            this.groupBox2.Controls.Add(this.txtFX);
            this.groupBox2.Controls.Add(this.lstConn);
            this.groupBox2.Controls.Add(this.txtRcvRCI);
            this.groupBox2.Controls.Add(this.txtRcv);
            this.groupBox2.Controls.Add(this.lstEv);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(8, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(607, 438);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Incoming Data";
            // 
            // lbCIU
            // 
            this.lbCIU.BackColor = System.Drawing.Color.Black;
            this.lbCIU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbCIU.FormattingEnabled = true;
            this.lbCIU.Location = new System.Drawing.Point(310, 17);
            this.lbCIU.Name = "lbCIU";
            this.lbCIU.Size = new System.Drawing.Size(291, 407);
            this.lbCIU.TabIndex = 7;
            // 
            // txtFX
            // 
            this.txtFX.Location = new System.Drawing.Point(99, 118);
            this.txtFX.Name = "txtFX";
            this.txtFX.Size = new System.Drawing.Size(100, 20);
            this.txtFX.TabIndex = 6;
            this.txtFX.Visible = false;
            this.txtFX.TextChanged += new System.EventHandler(this.txtFX_TextChanged);
            // 
            // txtRcvRCI
            // 
            this.txtRcvRCI.Location = new System.Drawing.Point(160, 64);
            this.txtRcvRCI.Name = "txtRcvRCI";
            this.txtRcvRCI.Size = new System.Drawing.Size(88, 20);
            this.txtRcvRCI.TabIndex = 4;
            this.txtRcvRCI.Visible = false;
            this.txtRcvRCI.TextChanged += new System.EventHandler(this.txtRcvRCI_TextChanged);
            // 
            // txtRcv
            // 
            this.txtRcv.Location = new System.Drawing.Point(136, 32);
            this.txtRcv.Name = "txtRcv";
            this.txtRcv.Size = new System.Drawing.Size(152, 20);
            this.txtRcv.TabIndex = 1;
            this.txtRcv.Visible = false;
            this.txtRcv.TextChanged += new System.EventHandler(this.txtRcv_TextChanged);
            // 
            // lstEv
            // 
            this.lstEv.BackColor = System.Drawing.Color.Black;
            this.lstEv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lstEv.Location = new System.Drawing.Point(8, 17);
            this.lstEv.Name = "lstEv";
            this.lstEv.Size = new System.Drawing.Size(296, 225);
            this.lstEv.TabIndex = 2;
            // 
            // sb
            // 
            this.sb.Location = new System.Drawing.Point(0, 682);
            this.sb.Name = "sb";
            this.sb.Size = new System.Drawing.Size(933, 22);
            this.sb.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvRcv);
            this.groupBox3.Location = new System.Drawing.Point(8, 532);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(919, 144);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Receivers";
            // 
            // lvRcv
            // 
            this.lvRcv.BackColor = System.Drawing.Color.DimGray;
            this.lvRcv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvRcv.Location = new System.Drawing.Point(8, 16);
            this.lvRcv.Name = "lvRcv";
            this.lvRcv.Size = new System.Drawing.Size(903, 122);
            this.lvRcv.TabIndex = 0;
            this.lvRcv.UseCompatibleStateImageBehavior = false;
            // 
            // tmrRCI
            // 
            this.tmrRCI.Enabled = true;
            this.tmrRCI.Interval = 10000;
            this.tmrRCI.Tick += new System.EventHandler(this.tmrRCI_Tick);
            // 
            // tmrCIU
            // 
            this.tmrCIU.Enabled = true;
            this.tmrCIU.Interval = 15000;
            this.tmrCIU.Tick += new System.EventHandler(this.tmrCIU_Tick);
            // 
            // tmRM
            // 
            this.tmRM.Enabled = true;
            this.tmRM.Tick += new System.EventHandler(this.tmRM_Tick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.tLsRCI);
            this.groupBox6.Controls.Add(this.tHbRCI);
            this.groupBox6.Location = new System.Drawing.Point(8, 443);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(304, 88);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "RCI 3300";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Comms Check";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.ForeColor = System.Drawing.Color.Yellow;
            this.textBox1.Location = new System.Drawing.Point(102, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Last Signal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "HeartBeat";
            // 
            // tLsRCI
            // 
            this.tLsRCI.BackColor = System.Drawing.Color.Black;
            this.tLsRCI.ForeColor = System.Drawing.Color.Yellow;
            this.tLsRCI.Location = new System.Drawing.Point(102, 36);
            this.tLsRCI.Name = "tLsRCI";
            this.tLsRCI.Size = new System.Drawing.Size(196, 20);
            this.tLsRCI.TabIndex = 1;
            // 
            // tHbRCI
            // 
            this.tHbRCI.BackColor = System.Drawing.Color.Black;
            this.tHbRCI.ForeColor = System.Drawing.Color.Yellow;
            this.tHbRCI.Location = new System.Drawing.Point(102, 12);
            this.tHbRCI.Name = "tHbRCI";
            this.tHbRCI.Size = new System.Drawing.Size(196, 20);
            this.tHbRCI.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.tLsCIU);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.tCkCIU);
            this.groupBox7.Controls.Add(this.tHbCIU);
            this.groupBox7.Location = new System.Drawing.Point(318, 443);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(308, 88);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "CIU";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Last Signal";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Comms Check (CK)";
            // 
            // tLsCIU
            // 
            this.tLsCIU.BackColor = System.Drawing.Color.Black;
            this.tLsCIU.ForeColor = System.Drawing.Color.Yellow;
            this.tLsCIU.Location = new System.Drawing.Point(112, 60);
            this.tLsCIU.Name = "tLsCIU";
            this.tLsCIU.Size = new System.Drawing.Size(190, 20);
            this.tLsCIU.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Heart Beat";
            // 
            // tCkCIU
            // 
            this.tCkCIU.BackColor = System.Drawing.Color.Black;
            this.tCkCIU.ForeColor = System.Drawing.Color.Yellow;
            this.tCkCIU.Location = new System.Drawing.Point(112, 36);
            this.tCkCIU.Name = "tCkCIU";
            this.tCkCIU.Size = new System.Drawing.Size(190, 20);
            this.tCkCIU.TabIndex = 1;
            // 
            // tHbCIU
            // 
            this.tHbCIU.BackColor = System.Drawing.Color.Black;
            this.tHbCIU.ForeColor = System.Drawing.Color.Yellow;
            this.tHbCIU.Location = new System.Drawing.Point(112, 13);
            this.tHbCIU.Name = "tHbCIU";
            this.tHbCIU.Size = new System.Drawing.Size(190, 20);
            this.tHbCIU.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Controls.Add(this.tLsFX);
            this.groupBox8.Controls.Add(this.tHtFX);
            this.groupBox8.Controls.Add(this.tHbFX);
            this.groupBox8.Location = new System.Drawing.Point(632, 444);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(295, 87);
            this.groupBox8.TabIndex = 12;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "FX 255";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Last Signal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hour Test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "HeartBeat";
            // 
            // tLsFX
            // 
            this.tLsFX.BackColor = System.Drawing.Color.Black;
            this.tLsFX.ForeColor = System.Drawing.Color.Yellow;
            this.tLsFX.Location = new System.Drawing.Point(97, 60);
            this.tLsFX.Name = "tLsFX";
            this.tLsFX.Size = new System.Drawing.Size(191, 20);
            this.tLsFX.TabIndex = 2;
            // 
            // tHtFX
            // 
            this.tHtFX.BackColor = System.Drawing.Color.Black;
            this.tHtFX.ForeColor = System.Drawing.Color.Yellow;
            this.tHtFX.Location = new System.Drawing.Point(96, 35);
            this.tHtFX.Name = "tHtFX";
            this.tHtFX.Size = new System.Drawing.Size(191, 20);
            this.tHtFX.TabIndex = 1;
            // 
            // tHbFX
            // 
            this.tHbFX.BackColor = System.Drawing.Color.Black;
            this.tHbFX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tHbFX.ForeColor = System.Drawing.Color.Yellow;
            this.tHbFX.Location = new System.Drawing.Point(96, 12);
            this.tHbFX.Name = "tHbFX";
            this.tHbFX.Size = new System.Drawing.Size(192, 20);
            this.tHbFX.TabIndex = 0;
            // 
            // sConn
            // 
            this.sConn.Break = false;
            this.sConn.DataAvailableThreshold = 1;
            this.sConn.Encoding = ((System.Text.Encoding)(resources.GetObject("sConn.Encoding")));
            this.sConn.Options = new CommStudio.Connections.SerialOptions("COM1", 115200, CommStudio.Connections.Parity.None, 8, CommStudio.Connections.CommStopBits.One, false, false, true, false, true, true);
            this.sConn.SynchronizingObject = this;
            this.sConn.DataAvailable += new CommStudio.Connections.Connection.DataAvailableEventHandler(this.sConn_DataAvailable);
            // 
            // scRCI
            // 
            this.scRCI.Break = false;
            this.scRCI.DataAvailableThreshold = 1;
            this.scRCI.Encoding = ((System.Text.Encoding)(resources.GetObject("scRCI.Encoding")));
            this.scRCI.Options = new CommStudio.Connections.SerialOptions("COM1", 115200, CommStudio.Connections.Parity.None, 8, CommStudio.Connections.CommStopBits.One, false, false, true, false, true, true);
            this.scRCI.SynchronizingObject = this;
            this.scRCI.DataAvailable += new CommStudio.Connections.Connection.DataAvailableEventHandler(this.scRCI_DataAvailable);
            // 
            // scFox
            // 
            this.scFox.Break = false;
            this.scFox.DataAvailableThreshold = 1;
            this.scFox.Encoding = ((System.Text.Encoding)(resources.GetObject("scFox.Encoding")));
            this.scFox.Options = new CommStudio.Connections.SerialOptions("COM1", 115200, CommStudio.Connections.Parity.None, 8, CommStudio.Connections.CommStopBits.One, false, false, true, false, true, true);
            this.scFox.SynchronizingObject = this;
            this.scFox.DataAvailable += new CommStudio.Connections.Connection.DataAvailableEventHandler(this.scFox_DataAvailable);
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(933, 704);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.sb);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RAS CORE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 

		[STAThread]
		static void Main() 
		{

			Application.Run(new frmMain());
		
		}

		private void frmMain_Load(object sender, System.EventArgs e)
		{
			int i;

            LoadHT(); // fox zone translation
			lvRcv.View=View.Details;
			lvRcv.GridLines=true;
			//start listening for connections...asychronous, we can proceed
			Thread lThread=new Thread(new ThreadStart(this._StartListen));
    		lThread.Start();
			//retrieve the existing receivers
			for (i=0; i<6; i++)
			{
				lvRcv.Columns.Add(new ColumnHeader());
			}
			lvRcv.Columns[0].Text="ID";
			lvRcv.Columns[0].Width=lvRcv.Width * 1/10;
			lvRcv.Columns[1].Text="Receiver Name";
			lvRcv.Columns[1].Width=lvRcv.Width * 3/10;
			lvRcv.Columns[2].Text="Receiver Full Name";
			lvRcv.Columns[2].Width=lvRcv.Width * 2/10;
			lvRcv.Columns[3].Text="COM Port";
			lvRcv.Columns[3].Width=lvRcv.Width * 1/10;
			lvRcv.Columns[4].Text="Settings";
			lvRcv.Columns[4].Width=lvRcv.Width * 2/10;
			lvRcv.Columns[5].Text="HeartBeat Delay";
			lvRcv.Columns[5].Width=lvRcv.Width * 1/10 -2;

            //treeview
            TreeNode node;
            node = tvComp.Nodes.Add("Connected Clients");
            tvComp.ImageList = imgLst;
            node.ImageIndex = 1;


				
			//GetReceivers();
			mData =new RData();
            mData.GetRcv(lvRcv);

			//open ports etc
			this.OpenRCI();

			this.OpenCIU();

            OpenFX();
		}

        private void LoadHT()
        {
            hT = new Hashtable();
            hT.Add("003", "1");
            hT.Add("000", "2");
            hT.Add("001", "17");
            hT.Add("002", "3");
            hT.Add("004", "4");
            hT.Add("005", "5");
            hT.Add("006", "6");
            hT.Add("007", "7");
            hT.Add("008", "8");
            hT.Add("009", "9");
            hT.Add("010", "10"); //AC Fail
            hT.Add("011", "11"); //AC Restore
            hT.Add("017", "12"); //Power up
            hT.Add("020", "13"); //Armed3de 3cde 
            hT.Add("040", "14"); //Disarmed
            hT.Add("013", "15");
            hT.Add("015", "16");
            hT.Add("012", "17");

        }

		//open receivers
		private void OpenRCI()
		{
			Receiver rcv=mData.getReceiver(3);

            try
            {
                this.scRCI.Options = new CommStudio.Connections.SerialOptions("COM" +rcv.rcvCOMPort, 600,
                    CommStudio.Connections.Parity.None, 8, CommStudio.Connections.CommStopBits.One,
                    false, false, false, false, true, true);
                this.scRCI.Open();

                tmrRCI.Interval = rcv.iHeartBeat * 500;
                tmrRCI.Enabled = true;
            }
            catch (System.IO.IOException exception)
            {
                string error = exception.Message;
                MessageBox.Show(error);
            }

		}

		private void OpenCIU()
		{
			Receiver rcv=mData.getReceiver(2);
			try
			{
                this.sConn.Options = new CommStudio.Connections.SerialOptions("COM" + rcv.rcvCOMPort.ToString(), 4800,
                    CommStudio.Connections.Parity.Odd, 7, CommStudio.Connections.CommStopBits.One, false, false, true, false, true, true);
                sConn.Open();

                tmrCIU.Interval = rcv.iHeartBeat * 500;
                tmrCIU.Enabled = true;
			} 
			catch (Exception Ex)
			{
				MessageBox.Show("Error: " + Ex.Message,"RAS CORE",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}

		}

        private void OpenFX()
        {
            Receiver rcv = mData.getReceiver(4);

            try
            {
                this.scFox.Options = new CommStudio.Connections.SerialOptions("COM" + rcv.rcvCOMPort, 19200,
                    CommStudio.Connections.Parity.None, 8, CommStudio.Connections.CommStopBits.One,
                    false, false, false, false, true, true);
                scFox.Open();
            }
            catch (System.IO.IOException exception)
            {
                string error = exception.Message;
                MessageBox.Show(error);
            }
        }

        private void writeTCPevt(string _tcpMsg)
        {
            if (this.lstConn.InvokeRequired)
            {
                setTcpTextCallBack s = new setTcpTextCallBack(writeTCPevt);
                this.BeginInvoke(s, new object[] { _tcpMsg });
                return;
            }
            else
                this.lstConn.Items.Add(_tcpMsg);
        }

        private void WriteComEvt(string _errMsg)
        {
            //called on delegate thread
            if (this.lstEv.InvokeRequired)
            {
                SetTextCallback s = new SetTextCallback(WriteComEvt);
                this.BeginInvoke(s, new object[] { _errMsg });
                return;
            }
            else
            {
                this.lstEv.Items.Add(_errMsg);
            }

        }
        
		private void _StartListen()
		{
			writeTCPevt("RAS CORE started: " + DateTime.Now.ToString( "G" ));
			const int nPortListen = 399;
			// Determine the IPAddress of this machine
			IPAddress ipLocalAddr = null;
			try
			{
				// NOTE: DNS lookups are nice and all but quite time consuming.
				ipLocalAddr = IPAddress.Parse(ConfigurationManager.AppSettings["ip_address"]);
			}
			catch( Exception ex )
			{
                writeTCPevt("Error trying to get local IP address " + ex.Message);
				
			}
		
            writeTCPevt("Listening on : " + ipLocalAddr.ToString() + ":" + nPortListen);
			// Create the listener socket in this machines IP address
			Socket listener = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
			listener.Bind( new IPEndPoint( ipLocalAddr, 399 ) );
			//listener.Bind( new IPEndPoint( IPAddress.Loopback, 399 ) );	// For use with localhost 127.0.0.1
			listener.Listen( 10 );

			// Setup a callback to be notified of connection requests
			listener.BeginAccept( new AsyncCallback( OnConnectRequest ), listener );
		}

		/// <summary>
		/// Callback used when a client requests a connection. 
		/// Accept the connection, adding it to our list and setup to 
		/// accept more connections.
		/// </summary>
		/// <param name="ar"></param>
		public void OnConnectRequest( IAsyncResult ar )
		{
			Socket listener = (Socket)ar.AsyncState;
			NewConnection( listener.EndAccept( ar ) );
			listener.BeginAccept( new AsyncCallback( OnConnectRequest ), listener );
		}

		/// <summary>
		/// Add the given connection to our list of clients
		/// Note we have a new friend
		/// Send a welcome to the new client
		/// Setup a callback to recieve data
		/// </summary>
		/// <param name="sockClient">Connection to keep</param>
		//public void NewConnection( TcpListener listener )
		public void NewConnection( Socket sockClient )
		{
			// Program blocks on Accept() until a client connects.
			//SocketChatClient client = new SocketChatClient( listener.AcceptSocket() );
			SocketChatClient client = new SocketChatClient( sockClient );
			m_aryClients.Add( client );
            writeTCPevt("Client " + client.Sock.RemoteEndPoint + " Connected > " + DateTime.Now.ToString());
            UpdateClientList(client.Sock.RemoteEndPoint.ToString(), "Add");
 
			// Get current date and time.
			DateTime now = DateTime.Now;
			String strDateLine = "You are Connected to RAS CORE > " + now.ToString("G") + "";
             
			// Convert to byte array and send.
			Byte[] byteDateLine = System.Text.Encoding.ASCII.GetBytes( strDateLine.ToCharArray() );
			client.Sock.Send( byteDateLine, byteDateLine.Length, 0 );

            //send enqueued data
            if (alQueue.Count > 0)
            {
                do
                {
                    Thread.Sleep(1000);
                    Alarm localAlarm = (Alarm)alQueue.Dequeue();
                    _SendData(localAlarm.qSignal);
                } while (alQueue.Count != 0);
            }

			client.SetupRecieveCallback( this );
		}

        private void UpdateClientList(string str, string type)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.tvComp.InvokeRequired)
            {
                SetListBoxItem d = new SetListBoxItem(UpdateClientList);
                this.Invoke(d, new object[] { str, type });
            }
            else
            {
                // If type is Add, the add Client info in Tree View
                if (type.Equals("Add"))
                {
                    this.tvComp.Nodes[0].Nodes.Add(str);
                    this.tvComp.ExpandAll();
                }
                // Else delete Client information from Tree View
                else
                {
                    foreach (TreeNode n in this.tvComp.Nodes[0].Nodes)
                    {
                        if (n.Text.Equals(str))
                            this.tvComp.Nodes.Remove(n);
                    }
                }

            }
        }

		/// <summary>
		/// Get the new data and send it out to all other connections. 
		/// Note: If not data was recieved the connection has probably 
		/// died.
		/// </summary>
		/// <param name="ar"></param>
		public void OnRecievedData( IAsyncResult ar )
		{
			client = (SocketChatClient)ar.AsyncState;
			byte [] aryRet = client.GetRecievedData( ar );

			// If no data was recieved then the connection is probably dead
			if( aryRet.Length < 1 )
			{
                writeTCPevt("Client " + client.Sock.RemoteEndPoint + ", disconnected");
                UpdateClientList(client.Sock.RemoteEndPoint.ToString(), "Delete");
				client.Sock.Close();
				m_aryClients.Remove( client );      				
				return;
			}

			// Send the recieved data to all clients (including sender for echo)
			foreach( SocketChatClient clientSend in m_aryClients )
			{
				try
				{
					clientSend.Sock.Send( aryRet );
				}
				catch
				{
					// If the send fails the close the connection
					lstConn.Items.Add( "Send to client "+client.Sock.RemoteEndPoint+ "failed" );
					clientSend.Sock.Close();
					m_aryClients.Remove( client );
					return;
				}
				//check if clocking sig...
				string clk = Encoding.ASCII.GetString(aryRet,0,aryRet.Length);
			}
			client.SetupRecieveCallback( this );
		}

		private void mnuCloseConn_Click(object sender, System.EventArgs e)
		{
		
		}

		//try send some data from the server
		private void _SendData(string Data)
		{
		foreach( SocketChatClient clientSend in m_aryClients )
			try
			{
				byte [] arySend=Encoding.ASCII.GetBytes(Data);
				clientSend.Sock.Send(arySend);
			}
			catch
			{
				// If the send fails the close the connection
				lstConn.Items.Add( "Send to client "+ client.Sock.RemoteEndPoint+ "failed" );
				clientSend.Sock.Close();
				m_aryClients.Remove( client );
				return;

			}
		}

	
		private void txtRcv_TextChanged(object sender, System.EventArgs e)
		{
			string currDate, currTime, strCode;
            char[] ZnArr = new char[8];
			currDate = DateTime.Today.ToShortDateString();
			currTime = DateTime.Now.ToLongTimeString();

            if (txtRcv.Text.Length == 7)
            {
                sBuff = txtRcv.Text.Trim();
                txtRcv.Text = "";
                return;
            }
            if (txtRcv.Text.Length == 4 && txtRcv.Text == "CK08")
            {
                tCkCIU.Text = currDate + " " + currTime;
                txtRcv.Text = "";
                return; //comms check
            }


            if (txtRcv.Text.Length == 11 && txtRcv.Text != "CK08")
			{
				Unit unit = new Unit();
				strCode=sBuff + txtRcv.Text;
				string code = strCode.Substring(2,4);
				string zone = strCode.Substring(7,2);
                ZnArr = MakeBin(zone).ToCharArray();

                for (int i = 0; i < 8; i++)
                {
                    if (ZnArr[i].ToString() == "1")
                    {
                        //check event code for zone...
                        if (unit.getEvtCode(code, Convert.ToString(i+1)) == 1)
                        {
                            //queue if no clients are connected
                            if (m_aryClients.Count == 0)
                            {
                                Enque_alarm(strCode.Substring(2, 4) + " " + Convert.ToString(i + 1) + " " +
                                   DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                            }
                            else
                            {
                                _SendData(strCode.Substring(2, 4) + " " + Convert.ToString(i + 1) + " " +
                                    DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                            }
                        }
                        else
                        {
                            //non-priority event
                            unit.Add_lp_Event(code, i, unit.getEvtCode(code, Convert.ToString(i + 1)), "");
                        }
                    }
                }
                lbCIU.Items.Insert(0, currDate + ' ' + currTime + "> Received on CIU: Code=" +code + " " + zone);
                logMsg = currDate + ' ' + currTime + "> Received on CIU: Code = " + strCode.Substring(2, 4) + " " + strCode.Substring(7, 2);
                Thread logThrd = new Thread(new ThreadStart(this.WriteDataLog));
                logThrd.Start();

			}
            txtRcv.Text = "";
		}

		private void tmrRCI_Tick(object sender, System.EventArgs e)
		{
            if (this.scRCI.IsOpen)
            {
                scRCI.Write("" + (char)6 + "" + (char)6);
                tHbRCI.Text = DateTime.Today.ToShortDateString() + " " + DateTime.Today.ToLongTimeString();
            }

		}

		private void tmrCIU_Tick(object sender, System.EventArgs e)
		{
            if (this.sConn.IsOpen)
            {
                this.sConn.Write("" + (char)6 + "" + (char)6);
                tHbCIU.Text = DateTime.Today.ToShortDateString() + " " + DateTime.Today.ToLongTimeString();
            }
		}


		private void tmRM_Tick(object sender, System.EventArgs e)
		{
			if (lstEv.Items.Count > 16)
			{
				lstEv.Items.RemoveAt(16);
			}
            if (lbCIU.Items.Count > 32)
                lbCIU.Items.RemoveAt(32);
		}

		private void WriteDataLog()
		{
			FileIO f=new FileIO();
			f.WriteDayLog(logMsg);
		}
		private void WriteRCILog()
		{
			FileIO ft = new FileIO();
			ft.WriteDayLog(logRCI);
		}

		private void dtpLog_ValueChanged(object sender, System.EventArgs e)
		{
			//get the logs for that day
			if (dtpLog.Value > DateTime.Now)
			{
				MessageBox.Show(this,"Please select a Date <=Today!!","RAS Core",
					MessageBoxButtons.OK,MessageBoxIcon.Hand);
				lstEvtLog.Items.Clear();
				return;
			} 
			else
			{
				lstEvtLog.Items.Clear();
				FileIO f=new FileIO();
				f.ReadDayFile(dtpLog.Value, lstEvtLog);
			}
		}

		private void txtRcvRCI_TextChanged(object sender, System.EventArgs e)
		{
			string currDate, currTime, str;
			currDate = DateTime.Today.ToShortDateString();
			currTime = DateTime.Now.ToLongTimeString();

			str=txtRcvRCI.Text;
			str=str.Remove(0,3);
			if (str.Length > 3 )
			{
				if (str.Substring(0,4)=="OKAY")
				{
                    tLsRCI.Text = currDate + " " + currTime;
					return;
				}

                //queue the data if there are no connected clients
                if (m_aryClients.Count == 0)
                {
                    Enque_alarm("R" + str + " 0" + " " +
                    DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                }
                else
                {
                    _SendData("R" + str + " 0" + " " +
                        DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                }
				lstEv.Items.Insert(0, currDate + ' ' + currTime +"> Received on RCI: Code=" +
					str + " 0");
				logRCI =currDate + ' ' + currTime +"> Received on RCI: Code = " + str + " 0";

				Thread logThrd = new Thread(new ThreadStart(this.WriteRCILog));
				logThrd.IsBackground = true;
				logThrd.Start();

			}

		}

        private void Enque_alarm(string sSignal)
        {
            Alarm qAlarm = new Alarm();
            qAlarm.qSignal = sSignal;
            alQueue.Enqueue(qAlarm);
        }

        private string MakeBin(string sHex)
        {
            //convert Hex string to char array of bin
            string ret = Convert.ToString(Convert.ToInt32(sHex, 16), 2);
            return ret.PadLeft(8,'0');
        }

        private void txtFX_TextChanged(object sender, EventArgs e)
        {
            RData pData = new RData();
            Unit unit = new Unit();
            
            if (txtFX.Text != "")
            {
                string Msg = txtFX.Text;
                if (Msg.Length < 7) return;
                if (Msg.Substring(7, 1) == "@") // heartbeat
                {
                    tHbFX.Text = DateTime.Today.ToShortDateString() + " " +
                        DateTime.Now.ToLongTimeString();
                    txtFX.Text = "";
                    return;
                }

                if (Msg.Length == 18)
                {
                    string currDate = DateTime.Today.ToShortDateString();
                    string currTime = DateTime.Now.ToLongTimeString();

                    string code = Msg.Substring(0, 4);
                    string user_code = Msg.Substring(11, 3);
                    string rpt_num = Msg.Substring(4, 2);
                    string evt_type = Msg.Substring(8, 3); 
                    string evt_q = Msg.Substring(7, 1); //event qualifier
                    int i_stren = int.Parse(Msg.Substring(6, 1)); //signal strenth

                    if (code != "9900")

                    {
                        //check event types
                        if (int.Parse(hT[evt_type].ToString()) < 9)
                        {
                            if (unit.getEvtCode("F" + code, hT[evt_type].ToString()) == 1)
                            {
                                if (m_aryClients.Count == 0)
                                {
                                    Enque_alarm("F" + code + " " + evt_type + " " + user_code + " " + currDate + " " + currTime +
                                         " " + rpt_num + " " + i_stren.ToString());
                                }
                                else
                                {
                                    _SendData("F" + code + " " + evt_type + " " + user_code + " " + currDate + " " + currTime +
                                         " " + rpt_num + " " + i_stren.ToString());
                                }
                            }
                        }
                    }
                    
                        pData.saveFX_Evt(code, user_code, evt_type, evt_q, i_stren);
                        lstEv.Items.Insert(0, currDate + " " + currTime + "> Received on FX255: Code=" +
                        code + " " + evt_type);
                }
                txtFX.Text = "";
            }
        }

        private void sConn_DataAvailable(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(50);
            txtRcv.Text = System.Text.RegularExpressions.Regex.Replace(this.sConn.Read(this.sConn.Available), "[\x01-\x1F]", "");
            sConn.Write("" + (char)6 + "" + (char)6);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void scRCI_DataAvailable(object sender, EventArgs e)
        {
            Thread.Sleep(25);
            string DSTR = this.scRCI.Read(sConn.Available);
            txtRcvRCI.Text = DSTR;
        }

        private void scFox_DataAvailable(object sender, EventArgs e)
        {
            Thread.Sleep(25);
            string DSTR = this.scFox.Read(scFox.Available);
            txtFX.Text = DSTR;
        }	
	}

	/// <summary>
	/// Class holding information and buffers for the Client socket connection
	/// </summary>
	internal class SocketChatClient
	{
		private Socket m_sock;						// Connection to the client
		private byte[] m_byBuff = new byte[50];		// Receive data buffer
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="sock">client socket conneciton this object represents</param>
		public SocketChatClient( Socket sock )
		{
			m_sock = sock;
		}

		// Readonly access
		public Socket Sock
		{
			get{ return m_sock; }
		}

		/// <summary>
		/// Setup the callback for recieved data and loss of conneciton
		/// </summary>
		/// <param name="app"></param>
		public void SetupRecieveCallback( frmMain app )
		{
			try
			{
				AsyncCallback recieveData = new AsyncCallback(app.OnRecievedData);
				m_sock.BeginReceive( m_byBuff, 0, m_byBuff.Length, SocketFlags.None, recieveData, this );
			}
			catch( Exception ex )
			{
				MessageBox.Show( "Receive callback setup failed! "+ ex.Message );
			}
		}

		/// <summary>
		/// Data has been recieved so we shall put it in an array and
		/// return it.
		/// </summary>
		/// <param name="ar"></param>
		/// <returns>Array of bytes containing the received data</returns>
		public byte [] GetRecievedData( IAsyncResult ar )
		{
			int nBytesRec = 0;
			try
			{
				nBytesRec = m_sock.EndReceive( ar );
			}
			catch{}
			byte [] byReturn = new byte[nBytesRec];
			Array.Copy( m_byBuff, byReturn, nBytesRec );	
			return byReturn;
		}
	
	}
}
