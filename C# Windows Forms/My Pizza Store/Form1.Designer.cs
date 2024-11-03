namespace My_Pizza_Store
{
    partial class PizzaStoreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PizzaStoreForm));
            this.lbPizzaStore = new System.Windows.Forms.Label();
            this.cbTomato = new System.Windows.Forms.CheckBox();
            this.btOrder = new System.Windows.Forms.Button();
            this.gbOrderSummary = new System.Windows.Forms.GroupBox();
            this.lbCoupon = new System.Windows.Forms.Label();
            this.lbPayMethod = new System.Windows.Forms.Label();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.lbToppings = new System.Windows.Forms.Label();
            this.lbCrust = new System.Windows.Forms.Label();
            this.lbPizzaSize = new System.Windows.Forms.Label();
            this.lbWhereToEat = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gpToppings = new System.Windows.Forms.GroupBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.cbChees = new System.Windows.Forms.CheckBox();
            this.cbOlives = new System.Windows.Forms.CheckBox();
            this.cbOnuin = new System.Windows.Forms.CheckBox();
            this.cbMashroom = new System.Windows.Forms.CheckBox();
            this.cbGreenPapper = new System.Windows.Forms.CheckBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.gbPay = new System.Windows.Forms.GroupBox();
            this.rdVisa = new System.Windows.Forms.RadioButton();
            this.rdCash = new System.Windows.Forms.RadioButton();
            this.gbCrust = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rdThinkCrust = new System.Windows.Forms.RadioButton();
            this.rdThinCrust = new System.Windows.Forms.RadioButton();
            this.gbPizzaSize = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rdLarge = new System.Windows.Forms.RadioButton();
            this.rdSmall = new System.Windows.Forms.RadioButton();
            this.rdMeduim = new System.Windows.Forms.RadioButton();
            this.gbWhereToEat = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.rdEatIn = new System.Windows.Forms.RadioButton();
            this.rdTakeAway = new System.Windows.Forms.RadioButton();
            this.btNewOrder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mtbCoupon = new System.Windows.Forms.MaskedTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbTime = new System.Windows.Forms.Label();
            this.CouponError = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbOrderSummary.SuspendLayout();
            this.gpToppings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.gbPay.SuspendLayout();
            this.gbCrust.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbPizzaSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbWhereToEat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CouponError)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPizzaStore
            // 
            this.lbPizzaStore.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbPizzaStore.AutoSize = true;
            this.lbPizzaStore.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPizzaStore.ForeColor = System.Drawing.Color.Red;
            this.lbPizzaStore.Location = new System.Drawing.Point(426, 22);
            this.lbPizzaStore.Name = "lbPizzaStore";
            this.lbPizzaStore.Size = new System.Drawing.Size(382, 68);
            this.lbPizzaStore.TabIndex = 22;
            this.lbPizzaStore.Text = "Make your Pizza";
            this.lbPizzaStore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbTomato
            // 
            this.cbTomato.AutoSize = true;
            this.cbTomato.Location = new System.Drawing.Point(28, 47);
            this.cbTomato.Name = "cbTomato";
            this.cbTomato.Size = new System.Drawing.Size(107, 29);
            this.cbTomato.TabIndex = 7;
            this.cbTomato.Text = "Tomato";
            this.cbTomato.UseVisualStyleBackColor = true;
            this.cbTomato.CheckedChanged += new System.EventHandler(this.cbTomato_CheckedChanged);
            // 
            // btOrder
            // 
            this.btOrder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOrder.Location = new System.Drawing.Point(673, 500);
            this.btOrder.Name = "btOrder";
            this.btOrder.Size = new System.Drawing.Size(135, 85);
            this.btOrder.TabIndex = 17;
            this.btOrder.Text = "Order";
            this.btOrder.UseVisualStyleBackColor = true;
            this.btOrder.Click += new System.EventHandler(this.btOrder_Click);
            // 
            // gbOrderSummary
            // 
            this.gbOrderSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOrderSummary.Controls.Add(this.lbCoupon);
            this.gbOrderSummary.Controls.Add(this.lbPayMethod);
            this.gbOrderSummary.Controls.Add(this.lbQuantity);
            this.gbOrderSummary.Controls.Add(this.lbToppings);
            this.gbOrderSummary.Controls.Add(this.lbCrust);
            this.gbOrderSummary.Controls.Add(this.lbPizzaSize);
            this.gbOrderSummary.Controls.Add(this.lbWhereToEat);
            this.gbOrderSummary.Controls.Add(this.label10);
            this.gbOrderSummary.Controls.Add(this.lbPrice);
            this.gbOrderSummary.Controls.Add(this.label9);
            this.gbOrderSummary.Controls.Add(this.label8);
            this.gbOrderSummary.Controls.Add(this.label7);
            this.gbOrderSummary.Controls.Add(this.label6);
            this.gbOrderSummary.Controls.Add(this.label5);
            this.gbOrderSummary.Controls.Add(this.label4);
            this.gbOrderSummary.Controls.Add(this.label3);
            this.gbOrderSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOrderSummary.Location = new System.Drawing.Point(879, 93);
            this.gbOrderSummary.Name = "gbOrderSummary";
            this.gbOrderSummary.Size = new System.Drawing.Size(424, 612);
            this.gbOrderSummary.TabIndex = 27;
            this.gbOrderSummary.TabStop = false;
            this.gbOrderSummary.Text = "OrderSymmary";
            // 
            // lbCoupon
            // 
            this.lbCoupon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbCoupon.AutoSize = true;
            this.lbCoupon.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCoupon.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbCoupon.Location = new System.Drawing.Point(339, 366);
            this.lbCoupon.Name = "lbCoupon";
            this.lbCoupon.Size = new System.Drawing.Size(31, 36);
            this.lbCoupon.TabIndex = 24;
            this.lbCoupon.Text = "0";
            this.lbCoupon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbPayMethod
            // 
            this.lbPayMethod.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbPayMethod.AutoSize = true;
            this.lbPayMethod.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPayMethod.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbPayMethod.Location = new System.Drawing.Point(243, 420);
            this.lbPayMethod.Name = "lbPayMethod";
            this.lbPayMethod.Size = new System.Drawing.Size(0, 36);
            this.lbPayMethod.TabIndex = 23;
            this.lbPayMethod.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbQuantity
            // 
            this.lbQuantity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantity.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbQuantity.Location = new System.Drawing.Point(144, 366);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(31, 36);
            this.lbQuantity.TabIndex = 22;
            this.lbQuantity.Text = "1";
            this.lbQuantity.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbToppings
            // 
            this.lbToppings.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbToppings.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbToppings.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbToppings.Location = new System.Drawing.Point(15, 170);
            this.lbToppings.Name = "lbToppings";
            this.lbToppings.Size = new System.Drawing.Size(382, 124);
            this.lbToppings.TabIndex = 21;
            // 
            // lbCrust
            // 
            this.lbCrust.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbCrust.AutoSize = true;
            this.lbCrust.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCrust.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbCrust.Location = new System.Drawing.Point(114, 87);
            this.lbCrust.Name = "lbCrust";
            this.lbCrust.Size = new System.Drawing.Size(0, 36);
            this.lbCrust.TabIndex = 20;
            this.lbCrust.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbPizzaSize
            // 
            this.lbPizzaSize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbPizzaSize.AutoSize = true;
            this.lbPizzaSize.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPizzaSize.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbPizzaSize.Location = new System.Drawing.Point(99, 32);
            this.lbPizzaSize.Name = "lbPizzaSize";
            this.lbPizzaSize.Size = new System.Drawing.Size(0, 36);
            this.lbPizzaSize.TabIndex = 19;
            this.lbPizzaSize.Tag = "";
            this.lbPizzaSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbWhereToEat
            // 
            this.lbWhereToEat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbWhereToEat.AutoSize = true;
            this.lbWhereToEat.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWhereToEat.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbWhereToEat.Location = new System.Drawing.Point(215, 310);
            this.lbWhereToEat.Name = "lbWhereToEat";
            this.lbWhereToEat.Size = new System.Drawing.Size(0, 36);
            this.lbWhereToEat.TabIndex = 18;
            this.lbWhereToEat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label10.Location = new System.Drawing.Point(15, 507);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 36);
            this.label10.TabIndex = 35;
            this.label10.Text = "Total Price:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbPrice
            // 
            this.lbPrice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.ForeColor = System.Drawing.Color.Lime;
            this.lbPrice.Location = new System.Drawing.Point(269, 497);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(0, 68);
            this.lbPrice.TabIndex = 11;
            this.lbPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Location = new System.Drawing.Point(15, 420);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(221, 36);
            this.label9.TabIndex = 34;
            this.label9.Text = "Payment method:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(215, 366);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 36);
            this.label8.TabIndex = 33;
            this.label8.Text = "Coupon:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(15, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 36);
            this.label7.TabIndex = 32;
            this.label7.Text = "Quantity:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(15, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 36);
            this.label6.TabIndex = 31;
            this.label6.Text = "Where To Eat:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(15, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 36);
            this.label5.TabIndex = 30;
            this.label5.Text = "Toppings:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(15, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 36);
            this.label4.TabIndex = 29;
            this.label4.Text = "Crust:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(15, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 36);
            this.label3.TabIndex = 28;
            this.label3.Text = "Size:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gpToppings
            // 
            this.gpToppings.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpToppings.Controls.Add(this.pictureBox7);
            this.gpToppings.Controls.Add(this.pictureBox6);
            this.gpToppings.Controls.Add(this.pictureBox5);
            this.gpToppings.Controls.Add(this.cbChees);
            this.gpToppings.Controls.Add(this.cbOlives);
            this.gpToppings.Controls.Add(this.cbOnuin);
            this.gpToppings.Controls.Add(this.cbMashroom);
            this.gpToppings.Controls.Add(this.cbGreenPapper);
            this.gpToppings.Controls.Add(this.cbTomato);
            this.gpToppings.Controls.Add(this.pictureBox4);
            this.gpToppings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpToppings.Location = new System.Drawing.Point(410, 93);
            this.gpToppings.Name = "gpToppings";
            this.gpToppings.Size = new System.Drawing.Size(398, 256);
            this.gpToppings.TabIndex = 23;
            this.gpToppings.TabStop = false;
            this.gpToppings.Text = "Toppings";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(308, 188);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(68, 62);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 16;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(162, 26);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(55, 50);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 15;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(332, 18);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(60, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 14;
            this.pictureBox5.TabStop = false;
            // 
            // cbChees
            // 
            this.cbChees.AutoSize = true;
            this.cbChees.Location = new System.Drawing.Point(241, 47);
            this.cbChees.Name = "cbChees";
            this.cbChees.Size = new System.Drawing.Size(97, 29);
            this.cbChees.TabIndex = 8;
            this.cbChees.Tag = "";
            this.cbChees.Text = "Chees";
            this.cbChees.UseVisualStyleBackColor = true;
            this.cbChees.CheckedChanged += new System.EventHandler(this.cbChees_CheckedChanged);
            // 
            // cbOlives
            // 
            this.cbOlives.AutoSize = true;
            this.cbOlives.Location = new System.Drawing.Point(241, 100);
            this.cbOlives.Name = "cbOlives";
            this.cbOlives.Size = new System.Drawing.Size(95, 29);
            this.cbOlives.TabIndex = 10;
            this.cbOlives.Text = "Olives";
            this.cbOlives.UseVisualStyleBackColor = true;
            this.cbOlives.CheckedChanged += new System.EventHandler(this.cbOlives_CheckedChanged);
            // 
            // cbOnuin
            // 
            this.cbOnuin.AutoSize = true;
            this.cbOnuin.Location = new System.Drawing.Point(28, 100);
            this.cbOnuin.Name = "cbOnuin";
            this.cbOnuin.Size = new System.Drawing.Size(92, 29);
            this.cbOnuin.TabIndex = 9;
            this.cbOnuin.Text = "Onuin";
            this.cbOnuin.UseVisualStyleBackColor = true;
            this.cbOnuin.CheckedChanged += new System.EventHandler(this.cbOnuin_CheckedChanged);
            // 
            // cbMashroom
            // 
            this.cbMashroom.AutoSize = true;
            this.cbMashroom.Location = new System.Drawing.Point(241, 153);
            this.cbMashroom.Name = "cbMashroom";
            this.cbMashroom.Size = new System.Drawing.Size(135, 29);
            this.cbMashroom.TabIndex = 12;
            this.cbMashroom.Text = "Mashroom";
            this.cbMashroom.UseVisualStyleBackColor = true;
            this.cbMashroom.CheckedChanged += new System.EventHandler(this.cbMashroom_CheckedChanged);
            // 
            // cbGreenPapper
            // 
            this.cbGreenPapper.AutoSize = true;
            this.cbGreenPapper.Location = new System.Drawing.Point(28, 153);
            this.cbGreenPapper.Name = "cbGreenPapper";
            this.cbGreenPapper.Size = new System.Drawing.Size(168, 29);
            this.cbGreenPapper.TabIndex = 11;
            this.cbGreenPapper.Text = "Green Papper";
            this.cbGreenPapper.UseVisualStyleBackColor = true;
            this.cbGreenPapper.CheckedChanged += new System.EventHandler(this.cbGreenPapper_CheckedChanged);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(6, 188);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(68, 62);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQuantity.Location = new System.Drawing.Point(410, 539);
            this.nudQuantity.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 30);
            this.nudQuantity.TabIndex = 15;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // gbPay
            // 
            this.gbPay.BackColor = System.Drawing.Color.Gray;
            this.gbPay.Controls.Add(this.rdVisa);
            this.gbPay.Controls.Add(this.rdCash);
            this.gbPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPay.Location = new System.Drawing.Point(42, 526);
            this.gbPay.Name = "gbPay";
            this.gbPay.Size = new System.Drawing.Size(288, 144);
            this.gbPay.TabIndex = 21;
            this.gbPay.TabStop = false;
            this.gbPay.Text = "Payment methods";
            // 
            // rdVisa
            // 
            this.rdVisa.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdVisa.Location = new System.Drawing.Point(160, 29);
            this.rdVisa.Name = "rdVisa";
            this.rdVisa.Size = new System.Drawing.Size(111, 95);
            this.rdVisa.TabIndex = 6;
            this.rdVisa.TabStop = true;
            this.rdVisa.Text = "Visa";
            this.rdVisa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdVisa.UseVisualStyleBackColor = true;
            this.rdVisa.CheckedChanged += new System.EventHandler(this.rdVisa_CheckedChanged);
            // 
            // rdCash
            // 
            this.rdCash.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdCash.Location = new System.Drawing.Point(6, 29);
            this.rdCash.Name = "rdCash";
            this.rdCash.Size = new System.Drawing.Size(111, 95);
            this.rdCash.TabIndex = 5;
            this.rdCash.Text = "Cash";
            this.rdCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdCash.UseVisualStyleBackColor = true;
            this.rdCash.CheckedChanged += new System.EventHandler(this.rdCash_CheckedChanged);
            // 
            // gbCrust
            // 
            this.gbCrust.Controls.Add(this.pictureBox2);
            this.gbCrust.Controls.Add(this.rdThinkCrust);
            this.gbCrust.Controls.Add(this.rdThinCrust);
            this.gbCrust.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCrust.Location = new System.Drawing.Point(42, 365);
            this.gbCrust.Name = "gbCrust";
            this.gbCrust.Size = new System.Drawing.Size(288, 155);
            this.gbCrust.TabIndex = 20;
            this.gbCrust.TabStop = false;
            this.gbCrust.Text = "Crust";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(10, 54);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(111, 95);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // rdThinkCrust
            // 
            this.rdThinkCrust.AutoSize = true;
            this.rdThinkCrust.BackColor = System.Drawing.Color.Transparent;
            this.rdThinkCrust.Location = new System.Drawing.Point(127, 74);
            this.rdThinkCrust.Name = "rdThinkCrust";
            this.rdThinkCrust.Size = new System.Drawing.Size(145, 29);
            this.rdThinkCrust.TabIndex = 4;
            this.rdThinkCrust.TabStop = true;
            this.rdThinkCrust.Text = "Think Crust";
            this.rdThinkCrust.UseVisualStyleBackColor = false;
            this.rdThinkCrust.CheckedChanged += new System.EventHandler(this.rdThinkCrust_CheckedChanged);
            // 
            // rdThinCrust
            // 
            this.rdThinCrust.AutoSize = true;
            this.rdThinCrust.BackColor = System.Drawing.Color.Transparent;
            this.rdThinCrust.Location = new System.Drawing.Point(28, 29);
            this.rdThinCrust.Name = "rdThinCrust";
            this.rdThinCrust.Size = new System.Drawing.Size(134, 29);
            this.rdThinCrust.TabIndex = 3;
            this.rdThinCrust.TabStop = true;
            this.rdThinCrust.Text = "Thin Crust";
            this.rdThinCrust.UseVisualStyleBackColor = false;
            this.rdThinCrust.CheckedChanged += new System.EventHandler(this.rdThinCrust_CheckedChanged);
            // 
            // gbPizzaSize
            // 
            this.gbPizzaSize.AutoSize = true;
            this.gbPizzaSize.BackColor = System.Drawing.Color.Transparent;
            this.gbPizzaSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gbPizzaSize.Controls.Add(this.pictureBox1);
            this.gbPizzaSize.Controls.Add(this.rdLarge);
            this.gbPizzaSize.Controls.Add(this.rdSmall);
            this.gbPizzaSize.Controls.Add(this.rdMeduim);
            this.gbPizzaSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbPizzaSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPizzaSize.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gbPizzaSize.Location = new System.Drawing.Point(42, 93);
            this.gbPizzaSize.Name = "gbPizzaSize";
            this.gbPizzaSize.Size = new System.Drawing.Size(288, 266);
            this.gbPizzaSize.TabIndex = 19;
            this.gbPizzaSize.TabStop = false;
            this.gbPizzaSize.Text = "Pizza Size";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(156, 142);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(111, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // rdLarge
            // 
            this.rdLarge.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdLarge.Location = new System.Drawing.Point(20, 142);
            this.rdLarge.Name = "rdLarge";
            this.rdLarge.Size = new System.Drawing.Size(111, 95);
            this.rdLarge.TabIndex = 2;
            this.rdLarge.TabStop = true;
            this.rdLarge.Text = "Large";
            this.rdLarge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdLarge.UseVisualStyleBackColor = true;
            this.rdLarge.CheckedChanged += new System.EventHandler(this.rdLarge_CheckedChanged);
            // 
            // rdSmall
            // 
            this.rdSmall.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdSmall.Location = new System.Drawing.Point(20, 32);
            this.rdSmall.Name = "rdSmall";
            this.rdSmall.Size = new System.Drawing.Size(111, 95);
            this.rdSmall.TabIndex = 0;
            this.rdSmall.TabStop = true;
            this.rdSmall.Text = "Small";
            this.rdSmall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdSmall.UseVisualStyleBackColor = true;
            this.rdSmall.CheckedChanged += new System.EventHandler(this.rdSmall_CheckedChanged);
            // 
            // rdMeduim
            // 
            this.rdMeduim.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdMeduim.Location = new System.Drawing.Point(156, 32);
            this.rdMeduim.Name = "rdMeduim";
            this.rdMeduim.Size = new System.Drawing.Size(111, 95);
            this.rdMeduim.TabIndex = 1;
            this.rdMeduim.TabStop = true;
            this.rdMeduim.Text = "Meduim";
            this.rdMeduim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdMeduim.UseVisualStyleBackColor = true;
            this.rdMeduim.CheckedChanged += new System.EventHandler(this.rdMeduim_CheckedChanged);
            // 
            // gbWhereToEat
            // 
            this.gbWhereToEat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbWhereToEat.Controls.Add(this.pictureBox3);
            this.gbWhereToEat.Controls.Add(this.rdEatIn);
            this.gbWhereToEat.Controls.Add(this.rdTakeAway);
            this.gbWhereToEat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbWhereToEat.Location = new System.Drawing.Point(410, 365);
            this.gbWhereToEat.Name = "gbWhereToEat";
            this.gbWhereToEat.Size = new System.Drawing.Size(398, 115);
            this.gbWhereToEat.TabIndex = 24;
            this.gbWhereToEat.TabStop = false;
            this.gbWhereToEat.Text = "Where To Eat";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(209, 25);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(183, 79);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // rdEatIn
            // 
            this.rdEatIn.AutoSize = true;
            this.rdEatIn.BackColor = System.Drawing.Color.Transparent;
            this.rdEatIn.Location = new System.Drawing.Point(24, 29);
            this.rdEatIn.Name = "rdEatIn";
            this.rdEatIn.Size = new System.Drawing.Size(89, 29);
            this.rdEatIn.TabIndex = 13;
            this.rdEatIn.TabStop = true;
            this.rdEatIn.Text = "Eat In";
            this.rdEatIn.UseVisualStyleBackColor = false;
            this.rdEatIn.CheckedChanged += new System.EventHandler(this.rdEatIn_CheckedChanged);
            // 
            // rdTakeAway
            // 
            this.rdTakeAway.AutoSize = true;
            this.rdTakeAway.BackColor = System.Drawing.Color.Transparent;
            this.rdTakeAway.Location = new System.Drawing.Point(24, 64);
            this.rdTakeAway.Name = "rdTakeAway";
            this.rdTakeAway.Size = new System.Drawing.Size(141, 29);
            this.rdTakeAway.TabIndex = 14;
            this.rdTakeAway.TabStop = true;
            this.rdTakeAway.Text = "Take Away";
            this.rdTakeAway.UseVisualStyleBackColor = false;
            this.rdTakeAway.CheckedChanged += new System.EventHandler(this.rdTakeAway_CheckedChanged);
            // 
            // btNewOrder
            // 
            this.btNewOrder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btNewOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNewOrder.Location = new System.Drawing.Point(673, 620);
            this.btNewOrder.Name = "btNewOrder";
            this.btNewOrder.Size = new System.Drawing.Size(135, 85);
            this.btNewOrder.TabIndex = 18;
            this.btNewOrder.Text = "New Order";
            this.btNewOrder.UseVisualStyleBackColor = true;
            this.btNewOrder.Click += new System.EventHandler(this.btNewOrder_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(404, 500);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 36);
            this.label1.TabIndex = 25;
            this.label1.Text = "Quantity";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(404, 581);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 36);
            this.label2.TabIndex = 26;
            this.label2.Text = "coupon";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mtbCoupon
            // 
            this.mtbCoupon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mtbCoupon.Location = new System.Drawing.Point(410, 620);
            this.mtbCoupon.Mask = "LLLLLL00";
            this.mtbCoupon.Name = "mtbCoupon";
            this.mtbCoupon.Size = new System.Drawing.Size(104, 22);
            this.mtbCoupon.TabIndex = 16;
            this.mtbCoupon.ValidatingType = typeof(System.DateTime);
            this.mtbCoupon.Validating += new System.ComponentModel.CancelEventHandler(this.mtbCoupon_Validating);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.White;
            this.lbTime.Location = new System.Drawing.Point(12, 9);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(0, 68);
            this.lbTime.TabIndex = 10;
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CouponError
            // 
            this.CouponError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.CouponError.ContainerControl = this;
            // 
            // PizzaStoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1331, 726);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.mtbCoupon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btNewOrder);
            this.Controls.Add(this.gbWhereToEat);
            this.Controls.Add(this.gpToppings);
            this.Controls.Add(this.gbPay);
            this.Controls.Add(this.gbCrust);
            this.Controls.Add(this.gbPizzaSize);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.gbOrderSummary);
            this.Controls.Add(this.btOrder);
            this.Controls.Add(this.lbPizzaStore);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PizzaStoreForm";
            this.Text = "My Pizza Store";
            this.gbOrderSummary.ResumeLayout(false);
            this.gbOrderSummary.PerformLayout();
            this.gpToppings.ResumeLayout(false);
            this.gpToppings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.gbPay.ResumeLayout(false);
            this.gbCrust.ResumeLayout(false);
            this.gbCrust.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbPizzaSize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbWhereToEat.ResumeLayout(false);
            this.gbWhereToEat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CouponError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbPizzaStore;
        private System.Windows.Forms.CheckBox cbTomato;
        private System.Windows.Forms.Button btOrder;
        private System.Windows.Forms.GroupBox gbOrderSummary;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.GroupBox gpToppings;
        private System.Windows.Forms.GroupBox gbPay;
        private System.Windows.Forms.GroupBox gbCrust;
        private System.Windows.Forms.GroupBox gbPizzaSize;
        private System.Windows.Forms.RadioButton rdLarge;
        private System.Windows.Forms.RadioButton rdMeduim;
        private System.Windows.Forms.RadioButton rdSmall;
        private System.Windows.Forms.RadioButton rdThinkCrust;
        private System.Windows.Forms.RadioButton rdThinCrust;
        private System.Windows.Forms.RadioButton rdVisa;
        private System.Windows.Forms.RadioButton rdCash;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox cbChees;
        private System.Windows.Forms.CheckBox cbOlives;
        private System.Windows.Forms.CheckBox cbOnuin;
        private System.Windows.Forms.CheckBox cbMashroom;
        private System.Windows.Forms.CheckBox cbGreenPapper;
        private System.Windows.Forms.GroupBox gbWhereToEat;
        private System.Windows.Forms.Button btNewOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RadioButton rdEatIn;
        private System.Windows.Forms.RadioButton rdTakeAway;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtbCoupon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbWhereToEat;
        private System.Windows.Forms.Label lbPizzaSize;
        private System.Windows.Forms.Label lbCrust;
        private System.Windows.Forms.Label lbToppings;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.Label lbPayMethod;
        private System.Windows.Forms.ErrorProvider CouponError;
        private System.Windows.Forms.Label lbCoupon;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}

