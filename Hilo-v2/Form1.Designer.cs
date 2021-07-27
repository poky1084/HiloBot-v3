
namespace Hilo_v2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ManualPage = new System.Windows.Forms.TabPage();
            this.ResettoBaseWin = new System.Windows.Forms.CheckBox();
            this.ResetBaseStop = new System.Windows.Forms.CheckBox();
            this.StopAutocheckBox2 = new System.Windows.Forms.CheckBox();
            this.StopAutoValue = new System.Windows.Forms.NumericUpDown();
            this.StopWincheckBox2 = new System.Windows.Forms.CheckBox();
            this.CashoutcheckBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CurrencyList = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BaseBetAmount = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.DelayBet = new System.Windows.Forms.NumericUpDown();
            this.DelayGuess = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.StopLimit = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.IncrementLoss = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.AutoCashout = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.ManualEqual_btn = new System.Windows.Forms.Button();
            this.ManualStart = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.suitBox = new System.Windows.Forms.TextBox();
            this.rankBox = new System.Windows.Forms.TextBox();
            this.patternBox = new System.Windows.Forms.TextBox();
            this.ManualCashout_btn = new System.Windows.Forms.Button();
            this.ManualLow = new System.Windows.Forms.Button();
            this.ManualSkip = new System.Windows.Forms.Button();
            this.ManualHigh = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.BetsPage = new System.Windows.Forms.TabPage();
            this.listView4 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LogPage = new System.Windows.Forms.TabPage();
            this.LogView2 = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.ManualPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StopAutoValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseBetAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayBet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayGuess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StopLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncrementLoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoCashout)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.BetsPage.SuspendLayout();
            this.LogPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(367, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 368);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(351, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.UseSystemPasswordChar = true;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(5, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(442, 90);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ManualPage);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.BetsPage);
            this.tabControl1.Controls.Add(this.LogPage);
            this.tabControl1.Location = new System.Drawing.Point(2, 115);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(447, 253);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // ManualPage
            // 
            this.ManualPage.Controls.Add(this.ResettoBaseWin);
            this.ManualPage.Controls.Add(this.ResetBaseStop);
            this.ManualPage.Controls.Add(this.StopAutocheckBox2);
            this.ManualPage.Controls.Add(this.StopAutoValue);
            this.ManualPage.Controls.Add(this.StopWincheckBox2);
            this.ManualPage.Controls.Add(this.CashoutcheckBox2);
            this.ManualPage.Controls.Add(this.checkBox1);
            this.ManualPage.Controls.Add(this.label7);
            this.ManualPage.Controls.Add(this.CurrencyList);
            this.ManualPage.Controls.Add(this.label6);
            this.ManualPage.Controls.Add(this.BaseBetAmount);
            this.ManualPage.Controls.Add(this.label5);
            this.ManualPage.Controls.Add(this.DelayBet);
            this.ManualPage.Controls.Add(this.DelayGuess);
            this.ManualPage.Controls.Add(this.label4);
            this.ManualPage.Controls.Add(this.button3);
            this.ManualPage.Controls.Add(this.linkLabel3);
            this.ManualPage.Controls.Add(this.StopLimit);
            this.ManualPage.Controls.Add(this.label11);
            this.ManualPage.Controls.Add(this.IncrementLoss);
            this.ManualPage.Controls.Add(this.label10);
            this.ManualPage.Controls.Add(this.AutoCashout);
            this.ManualPage.Controls.Add(this.button2);
            this.ManualPage.Controls.Add(this.ManualEqual_btn);
            this.ManualPage.Controls.Add(this.ManualStart);
            this.ManualPage.Controls.Add(this.linkLabel2);
            this.ManualPage.Controls.Add(this.suitBox);
            this.ManualPage.Controls.Add(this.rankBox);
            this.ManualPage.Controls.Add(this.patternBox);
            this.ManualPage.Controls.Add(this.ManualCashout_btn);
            this.ManualPage.Controls.Add(this.ManualLow);
            this.ManualPage.Controls.Add(this.ManualSkip);
            this.ManualPage.Controls.Add(this.ManualHigh);
            this.ManualPage.Location = new System.Drawing.Point(4, 22);
            this.ManualPage.Name = "ManualPage";
            this.ManualPage.Size = new System.Drawing.Size(439, 227);
            this.ManualPage.TabIndex = 2;
            this.ManualPage.Text = "Manual";
            this.ManualPage.UseVisualStyleBackColor = true;
            // 
            // ResettoBaseWin
            // 
            this.ResettoBaseWin.AutoSize = true;
            this.ResettoBaseWin.Checked = true;
            this.ResettoBaseWin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ResettoBaseWin.Location = new System.Drawing.Point(12, 183);
            this.ResettoBaseWin.Name = "ResettoBaseWin";
            this.ResettoBaseWin.Size = new System.Drawing.Size(102, 17);
            this.ResettoBaseWin.TabIndex = 35;
            this.ResettoBaseWin.Text = "Base bet on win";
            this.ResettoBaseWin.UseVisualStyleBackColor = true;
            // 
            // ResetBaseStop
            // 
            this.ResetBaseStop.AutoSize = true;
            this.ResetBaseStop.Checked = true;
            this.ResetBaseStop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ResetBaseStop.Location = new System.Drawing.Point(115, 183);
            this.ResetBaseStop.Name = "ResetBaseStop";
            this.ResetBaseStop.Size = new System.Drawing.Size(130, 17);
            this.ResetBaseStop.TabIndex = 34;
            this.ResetBaseStop.Text = "Reset to base on stop";
            this.ResetBaseStop.UseVisualStyleBackColor = true;
            // 
            // StopAutocheckBox2
            // 
            this.StopAutocheckBox2.AutoSize = true;
            this.StopAutocheckBox2.Location = new System.Drawing.Point(217, 118);
            this.StopAutocheckBox2.Name = "StopAutocheckBox2";
            this.StopAutocheckBox2.Size = new System.Drawing.Size(132, 17);
            this.StopAutocheckBox2.TabIndex = 33;
            this.StopAutocheckBox2.Text = "Stop Auto on Multiplier";
            this.StopAutocheckBox2.UseVisualStyleBackColor = true;
            this.StopAutocheckBox2.CheckedChanged += new System.EventHandler(this.StopAutocheckBox2_CheckedChanged);
            // 
            // StopAutoValue
            // 
            this.StopAutoValue.DecimalPlaces = 2;
            this.StopAutoValue.Enabled = false;
            this.StopAutoValue.Location = new System.Drawing.Point(351, 115);
            this.StopAutoValue.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.StopAutoValue.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.StopAutoValue.Name = "StopAutoValue";
            this.StopAutoValue.Size = new System.Drawing.Size(83, 20);
            this.StopAutoValue.TabIndex = 32;
            this.StopAutoValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.StopAutoValue.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // StopWincheckBox2
            // 
            this.StopWincheckBox2.AutoSize = true;
            this.StopWincheckBox2.Location = new System.Drawing.Point(241, 72);
            this.StopWincheckBox2.Name = "StopWincheckBox2";
            this.StopWincheckBox2.Size = new System.Drawing.Size(82, 17);
            this.StopWincheckBox2.TabIndex = 31;
            this.StopWincheckBox2.Text = "Stop on win";
            this.StopWincheckBox2.UseVisualStyleBackColor = true;
            this.StopWincheckBox2.CheckedChanged += new System.EventHandler(this.StopWincheckBox2_CheckedChanged);
            // 
            // CashoutcheckBox2
            // 
            this.CashoutcheckBox2.AutoSize = true;
            this.CashoutcheckBox2.Location = new System.Drawing.Point(217, 140);
            this.CashoutcheckBox2.Name = "CashoutcheckBox2";
            this.CashoutcheckBox2.Size = new System.Drawing.Size(124, 17);
            this.CashoutcheckBox2.TabIndex = 30;
            this.CashoutcheckBox2.Text = "Cashout on Multiplier";
            this.CashoutcheckBox2.UseVisualStyleBackColor = true;
            this.CashoutcheckBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(241, 52);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 17);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "Pause on Pattern";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(214, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Currency";
            // 
            // CurrencyList
            // 
            this.CurrencyList.FormattingEnabled = true;
            this.CurrencyList.Items.AddRange(new object[] {
            "btc",
            "eth",
            "ltc",
            "doge",
            "bch",
            "xrp",
            "trx",
            "eos"});
            this.CurrencyList.Location = new System.Drawing.Point(265, 94);
            this.CurrencyList.Name = "CurrencyList";
            this.CurrencyList.Size = new System.Drawing.Size(41, 21);
            this.CurrencyList.TabIndex = 27;
            this.CurrencyList.Text = "btc";
            this.CurrencyList.SelectedIndexChanged += new System.EventHandler(this.CurrencyList_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(305, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Basebet";
            // 
            // BaseBetAmount
            // 
            this.BaseBetAmount.DecimalPlaces = 8;
            this.BaseBetAmount.Increment = new decimal(new int[] {
            1,
            0,
            0,
            458752});
            this.BaseBetAmount.Location = new System.Drawing.Point(351, 94);
            this.BaseBetAmount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.BaseBetAmount.Name = "BaseBetAmount";
            this.BaseBetAmount.Size = new System.Drawing.Size(83, 20);
            this.BaseBetAmount.TabIndex = 25;
            this.BaseBetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BaseBetAmount.ValueChanged += new System.EventHandler(this.BaseBetAmount_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Bet delay (ms)";
            // 
            // DelayBet
            // 
            this.DelayBet.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.DelayBet.Location = new System.Drawing.Point(266, 205);
            this.DelayBet.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.DelayBet.Name = "DelayBet";
            this.DelayBet.Size = new System.Drawing.Size(46, 20);
            this.DelayBet.TabIndex = 23;
            this.DelayBet.ValueChanged += new System.EventHandler(this.DelayBet_ValueChanged);
            // 
            // DelayGuess
            // 
            this.DelayGuess.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.DelayGuess.Location = new System.Drawing.Point(392, 205);
            this.DelayGuess.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.DelayGuess.Name = "DelayGuess";
            this.DelayGuess.Size = new System.Drawing.Size(45, 20);
            this.DelayGuess.TabIndex = 22;
            this.DelayGuess.ValueChanged += new System.EventHandler(this.DelayGuess_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Guess delay (ms)";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(351, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 20);
            this.button3.TabIndex = 20;
            this.button3.Text = "Start Auto";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.LinkColor = System.Drawing.Color.Black;
            this.linkLabel3.Location = new System.Drawing.Point(318, 10);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(46, 13);
            this.linkLabel3.TabIndex = 19;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Patterns";
            // 
            // StopLimit
            // 
            this.StopLimit.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.StopLimit.Location = new System.Drawing.Point(115, 205);
            this.StopLimit.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.StopLimit.Name = "StopLimit";
            this.StopLimit.Size = new System.Drawing.Size(73, 20);
            this.StopLimit.TabIndex = 18;
            this.StopLimit.ValueChanged += new System.EventHandler(this.StopLimit_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 206);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Stop bet after games";
            // 
            // IncrementLoss
            // 
            this.IncrementLoss.DecimalPlaces = 3;
            this.IncrementLoss.Location = new System.Drawing.Point(97, 160);
            this.IncrementLoss.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IncrementLoss.Name = "IncrementLoss";
            this.IncrementLoss.Size = new System.Drawing.Size(83, 20);
            this.IncrementLoss.TabIndex = 16;
            this.IncrementLoss.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IncrementLoss.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Increment on loss";
            // 
            // AutoCashout
            // 
            this.AutoCashout.DecimalPlaces = 2;
            this.AutoCashout.Enabled = false;
            this.AutoCashout.Location = new System.Drawing.Point(351, 136);
            this.AutoCashout.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.AutoCashout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AutoCashout.Name = "AutoCashout";
            this.AutoCashout.Size = new System.Drawing.Size(83, 20);
            this.AutoCashout.TabIndex = 14;
            this.AutoCashout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.AutoCashout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(351, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 20);
            this.button2.TabIndex = 12;
            this.button2.Text = "Stop Auto";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ManualEqual_btn
            // 
            this.ManualEqual_btn.Location = new System.Drawing.Point(88, 49);
            this.ManualEqual_btn.Name = "ManualEqual_btn";
            this.ManualEqual_btn.Size = new System.Drawing.Size(64, 32);
            this.ManualEqual_btn.TabIndex = 11;
            this.ManualEqual_btn.Text = "Equal";
            this.ManualEqual_btn.UseVisualStyleBackColor = true;
            this.ManualEqual_btn.Click += new System.EventHandler(this.ManualEqual_btn_Click);
            // 
            // ManualStart
            // 
            this.ManualStart.Location = new System.Drawing.Point(19, 127);
            this.ManualStart.Name = "ManualStart";
            this.ManualStart.Size = new System.Drawing.Size(134, 20);
            this.ManualStart.TabIndex = 10;
            this.ManualStart.Text = "Start Manual";
            this.ManualStart.UseVisualStyleBackColor = true;
            this.ManualStart.Click += new System.EventHandler(this.ManualStart_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(180, 10);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(51, 13);
            this.linkLabel2.TabIndex = 7;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "StartCard";
            // 
            // suitBox
            // 
            this.suitBox.Location = new System.Drawing.Point(219, 26);
            this.suitBox.Name = "suitBox";
            this.suitBox.Size = new System.Drawing.Size(26, 20);
            this.suitBox.TabIndex = 6;
            this.suitBox.Text = "H";
            this.suitBox.TextChanged += new System.EventHandler(this.suitBox_TextChanged);
            // 
            // rankBox
            // 
            this.rankBox.Location = new System.Drawing.Point(180, 26);
            this.rankBox.Name = "rankBox";
            this.rankBox.Size = new System.Drawing.Size(35, 20);
            this.rankBox.TabIndex = 5;
            this.rankBox.Text = "A";
            this.rankBox.TextChanged += new System.EventHandler(this.rankBox_TextChanged);
            // 
            // patternBox
            // 
            this.patternBox.Location = new System.Drawing.Point(249, 26);
            this.patternBox.Name = "patternBox";
            this.patternBox.Size = new System.Drawing.Size(186, 20);
            this.patternBox.TabIndex = 4;
            this.patternBox.Text = "5,5,5,5";
            this.patternBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.patternBox.TextChanged += new System.EventHandler(this.patternBox_TextChanged);
            // 
            // ManualCashout_btn
            // 
            this.ManualCashout_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.ManualCashout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManualCashout_btn.Location = new System.Drawing.Point(19, 86);
            this.ManualCashout_btn.Name = "ManualCashout_btn";
            this.ManualCashout_btn.Size = new System.Drawing.Size(134, 36);
            this.ManualCashout_btn.TabIndex = 3;
            this.ManualCashout_btn.Text = "Cashout";
            this.ManualCashout_btn.UseVisualStyleBackColor = false;
            this.ManualCashout_btn.Click += new System.EventHandler(this.ManualCashout_btn_Click);
            // 
            // ManualLow
            // 
            this.ManualLow.Location = new System.Drawing.Point(19, 49);
            this.ManualLow.Name = "ManualLow";
            this.ManualLow.Size = new System.Drawing.Size(64, 32);
            this.ManualLow.TabIndex = 2;
            this.ManualLow.Text = "Low";
            this.ManualLow.UseVisualStyleBackColor = true;
            this.ManualLow.Click += new System.EventHandler(this.ManualLow_Click);
            // 
            // ManualSkip
            // 
            this.ManualSkip.Location = new System.Drawing.Point(88, 10);
            this.ManualSkip.Name = "ManualSkip";
            this.ManualSkip.Size = new System.Drawing.Size(64, 33);
            this.ManualSkip.TabIndex = 1;
            this.ManualSkip.Text = "Skip";
            this.ManualSkip.UseVisualStyleBackColor = true;
            this.ManualSkip.Click += new System.EventHandler(this.ManualSkip_Click);
            // 
            // ManualHigh
            // 
            this.ManualHigh.Location = new System.Drawing.Point(19, 10);
            this.ManualHigh.Name = "ManualHigh";
            this.ManualHigh.Size = new System.Drawing.Size(64, 33);
            this.ManualHigh.TabIndex = 0;
            this.ManualHigh.Text = "High";
            this.ManualHigh.UseVisualStyleBackColor = true;
            this.ManualHigh.Click += new System.EventHandler(this.ManualHigh_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.textBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(439, 227);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "FAQ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(6, 14);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(430, 201);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // BetsPage
            // 
            this.BetsPage.Controls.Add(this.listView4);
            this.BetsPage.Location = new System.Drawing.Point(4, 22);
            this.BetsPage.Name = "BetsPage";
            this.BetsPage.Padding = new System.Windows.Forms.Padding(3);
            this.BetsPage.Size = new System.Drawing.Size(439, 227);
            this.BetsPage.TabIndex = 0;
            this.BetsPage.Text = "Bets";
            this.BetsPage.UseVisualStyleBackColor = true;
            // 
            // listView4
            // 
            this.listView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView4.HideSelection = false;
            this.listView4.Location = new System.Drawing.Point(3, 3);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(438, 224);
            this.listView4.TabIndex = 0;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Profit";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Bet";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Multiplier";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Cards";
            this.columnHeader5.Width = 150;
            // 
            // LogPage
            // 
            this.LogPage.Controls.Add(this.LogView2);
            this.LogPage.Location = new System.Drawing.Point(4, 22);
            this.LogPage.Name = "LogPage";
            this.LogPage.Size = new System.Drawing.Size(439, 227);
            this.LogPage.TabIndex = 4;
            this.LogPage.Text = "Log";
            this.LogPage.UseVisualStyleBackColor = true;
            // 
            // LogView2
            // 
            this.LogView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.LogView2.HideSelection = false;
            this.LogView2.Location = new System.Drawing.Point(0, 3);
            this.LogView2.Name = "LogView2";
            this.LogView2.Size = new System.Drawing.Size(440, 224);
            this.LogView2.TabIndex = 0;
            this.LogView2.UseCompatibleStateImageBehavior = false;
            this.LogView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Time";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Message";
            this.columnHeader7.Width = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Multiplier:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(107, 93);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(47, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "0.00x";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(-3, 393);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 22);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Status:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(349, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Profit: 0.00000000";
            this.label8.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 412);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "HiLo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.ManualPage.ResumeLayout(false);
            this.ManualPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StopAutoValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseBetAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayBet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayGuess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StopLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncrementLoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoCashout)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.BetsPage.ResumeLayout(false);
            this.LogPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage BetsPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage ManualPage;
        private System.Windows.Forms.Button ManualCashout_btn;
        private System.Windows.Forms.Button ManualLow;
        private System.Windows.Forms.Button ManualSkip;
        private System.Windows.Forms.Button ManualHigh;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TextBox suitBox;
        private System.Windows.Forms.TextBox rankBox;
        private System.Windows.Forms.TextBox patternBox;
        private System.Windows.Forms.Button ManualStart;
        private System.Windows.Forms.Button ManualEqual_btn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.NumericUpDown StopLimit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown IncrementLoss;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown AutoCashout;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown DelayGuess;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown DelayBet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown BaseBetAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CurrencyList;
        private System.Windows.Forms.TabPage LogPage;
        private System.Windows.Forms.ListView LogView2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox CashoutcheckBox2;
        private System.Windows.Forms.CheckBox StopWincheckBox2;
        private System.Windows.Forms.CheckBox StopAutocheckBox2;
        private System.Windows.Forms.NumericUpDown StopAutoValue;
        private System.Windows.Forms.CheckBox ResetBaseStop;
        private System.Windows.Forms.CheckBox ResettoBaseWin;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
    }



}

