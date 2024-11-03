using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace My_Pizza_Store
{
  
    public partial class PizzaStoreForm : Form
    {

        public PizzaStoreForm()
        {
            InitializeComponent();


        }

        // Price Functions.
        struct stPriceInfo
        {

             public Byte ToppingsPrice;
             public Byte PizzaPrice;
             public Byte CrustPrice;
             public Byte Coupon;

        }stPriceInfo PriceInfo;
        int GetTotalPrice()
        {

            return PriceInfo.PizzaPrice + PriceInfo.CrustPrice + PriceInfo.ToppingsPrice;

        }
        void UpdateTotalPrice()
        {

            lbPrice.Text = (GetTotalPrice() * nudQuantity.Value - PriceInfo.Coupon).ToString() + "$";

        }

        // Pizza Size Change
        void UpdatePizzaSize()
        {

            if (rdSmall.Checked)
            {

                lbPizzaSize.Text = "Small";
                PriceInfo.PizzaPrice = 10;
                UpdateTotalPrice();
                return;

            }
            else if (rdMeduim.Checked)
            {

                lbPizzaSize.Text = "Meduim";
                PriceInfo.PizzaPrice = 20;
                UpdateTotalPrice();
                return;

            }
            else if (rdLarge.Checked)
            {

                lbPizzaSize.Text = "Large";
                PriceInfo.PizzaPrice = 30;
                UpdateTotalPrice();
                return;

            }

        }
        private void rdSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePizzaSize();
        }
        private void rdMeduim_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePizzaSize();
        }
        private void rdLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePizzaSize();
        }

        // Topping Check
        void UpdateToppings()
        {

            PriceInfo.ToppingsPrice = 0;
            byte ToppingNumbers = 0;
            lbToppings.Text = "";

            if (cbChees.Checked)
            {

                lbToppings.Text += cbChees.Text;
                PriceInfo.ToppingsPrice += 5;
                ToppingNumbers++;

            }
            if (cbGreenPapper.Checked)
            {

                lbToppings.Text += ", " + cbGreenPapper.Text;
                PriceInfo.ToppingsPrice += 5;
                ToppingNumbers++;

            }
            if (cbMashroom.Checked)
            {

                lbToppings.Text += ", " + cbMashroom.Text ;
                PriceInfo.ToppingsPrice += 5;
                ToppingNumbers++;

            }
            if (cbOlives.Checked)
            {

                lbToppings.Text += ", " + cbOlives.Text;
                PriceInfo.ToppingsPrice += 5;
                ToppingNumbers++;

            }
            if (cbOnuin.Checked)
            {

                lbToppings.Text += ", " + cbOnuin.Text;
                PriceInfo.ToppingsPrice += 5;
                ToppingNumbers++;

            }
            if (cbTomato.Checked)
            {

                lbToppings.Text += ", " + cbTomato.Text;
                PriceInfo.ToppingsPrice += 5;
                ToppingNumbers++;

            }

            if (lbToppings.Text.StartsWith(","))
            {

                lbToppings.Text = lbToppings.Text.Substring(1, lbToppings.Text.Length - 1);

            }

            UpdateTotalPrice();

            ToppingsLimit(ToppingNumbers);

        }
        void ToppingsLimit(byte ToppingNumber)
        {
            if (ToppingNumber >= 3) { 

            if (!cbChees.Checked)
            {

                    cbChees.Enabled = false;

            }
            if (!cbGreenPapper.Checked)
            {

                    cbGreenPapper.Enabled = false;

            }
            if (!cbMashroom.Checked)
            {

                    cbMashroom.Enabled = false;

            }
            if (!cbOlives.Checked)
            {

                    cbOlives.Enabled = false;

            }
            if (!cbOnuin.Checked)
            {

                    cbOnuin.Enabled = false;
            }
            if (!cbTomato.Checked)
            {

                cbTomato.Enabled = false;

            }

                return;    

            }

            cbChees.Enabled = true;
            cbGreenPapper.Enabled = true;
            cbMashroom.Enabled = true;
            cbOlives.Enabled = true;
            cbOnuin.Enabled = true;
            cbTomato.Enabled = true;

        }
        private void cbTomato_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void cbChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void cbOnuin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void cbOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void cbGreenPapper_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void cbMashroom_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        // Crust Check.
        void UpdateCrust()
        {

            if (rdThinCrust.Checked)
            {
                lbCrust.Text = "Thin Crust";
                PriceInfo.CrustPrice = 0;
                UpdateTotalPrice();
                return;
            }

            else if (rdThinkCrust.Checked)
            {
                lbCrust.Text = "Think Crust";
                PriceInfo.CrustPrice = 10;
                UpdateTotalPrice();
                return;
            }
        }
        private void rdThinCrust_CheckedChanged(object sender, EventArgs e)
        {
     
            UpdateCrust();
        }
        private void rdThinkCrust_CheckedChanged(object sender, EventArgs e)
        {
           
            UpdateCrust();
        }

        // Where To Eat
        void UpdateWhereToEat()
        {

            if (rdTakeAway.Checked)
                lbWhereToEat.Text = "Take Away";

            else if (rdEatIn.Checked)
                lbWhereToEat.Text = "Eat In";

        }
        private void rdEatIn_CheckedChanged(object sender, EventArgs e)
        {

            UpdateWhereToEat();

        }
        private void rdTakeAway_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        // Quantity
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            UpdateTotalPrice();
            lbQuantity.Text = nudQuantity.Value.ToString();

        }

       // Payment methods
        void UpdatePaymentmethods()
        {
            
            if(rdCash.Checked)
            {

                lbPayMethod.Text = "Cash";
                return;

            }
            if (rdVisa.Checked)
            {

                lbPayMethod.Text = "Visa";
                return;

            }


        }
        private void rdCash_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePaymentmethods();
        }
        private void rdVisa_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePaymentmethods();
        }

        // Order Buttons
        private void btOrder_Click(object sender, EventArgs e)
        {

            string ReceiptInfo = "PizzaSize: " + lbPizzaSize.Text + "\nCrust: " + lbCrust.Text +
                                 "\nToppings: " + lbToppings.Text + "\nQuantiity: " +lbQuantity.Text
                                 + "\nCoupon: " + lbCoupon.Text + "\nPay Method: " + 
                                 lbPayMethod.Text + "\nPrice: " + lbPrice.Text +
                                 "\nOrder Time: " + DateTime.Now.ToString("d-MM-yyyy HH:mm");

            btOrder.Enabled = false;

            MessageBox.Show(ReceiptInfo,"Have a Nice Meal",MessageBoxButtons.OK);
           
        }
        private void btNewOrder_Click(object sender, EventArgs e)
        {

            // Pizza Size
            rdSmall.Checked = false;
            rdMeduim.Checked = false;
            rdLarge.Checked = false;

            // Crust
            rdThinCrust.Checked = false;
            rdThinkCrust.Checked = false;

            // Payment
            rdCash.Checked = false;
            rdVisa.Checked = false;

            // Toppings
            cbChees.Checked = false;
            cbGreenPapper.Checked = false;
            cbMashroom.Checked = false;
            cbOlives.Checked = false;
            cbOnuin.Checked = false;
            cbTomato.Checked = false;

            // WhereToEat
            rdEatIn.Checked = false;
            rdTakeAway.Checked = false;

            // Labels
            lbCrust.Text = string.Empty;
            lbPayMethod.Text = string.Empty;
            lbPizzaSize.Text = string.Empty;
            lbQuantity.Text = string.Empty;
            lbToppings.Text = string.Empty;
            lbWhereToEat.Text = string.Empty;
            lbCoupon.Text = "0";

            //Miscellaneous
            nudQuantity.Value = 1;
            mtbCoupon.Text = string.Empty;
            btOrder.Enabled = true;

            // Price
            PriceInfo.CrustPrice = 0;
            PriceInfo.PizzaPrice = 0;
            PriceInfo.ToppingsPrice = 0;
            PriceInfo.Coupon = 0;
            lbPrice.Text = "0";

        }

        // coupon
        void UpdateCopuon()
        {

            if (mtbCoupon.Text == "Coupon05")
            {
                PriceInfo.Coupon = 5;
                lbCoupon.Text = "5";

            }
            else if (mtbCoupon.Text == "Coupon10")
            {
                PriceInfo.Coupon = 10;
                lbCoupon.Text = "10";
            }
            else
            {
                PriceInfo.Coupon = 0;
                lbCoupon.Text = "0";
            }

            UpdateTotalPrice();

        }
        private void mtbCoupon_Validating(object sender, CancelEventArgs e)
        {

            if(string.IsNullOrEmpty(mtbCoupon.Text))
            {

                CouponError.Clear();
             
                UpdateCopuon();
                return;

            }    
            if (mtbCoupon.Text != "Coupon05" && mtbCoupon.Text != "Coupon10")
            {
              
                CouponError.SetError(mtbCoupon,"The Coupon Code is Wrong");
                UpdateCopuon();
                return;

            }
            else
            {
                CouponError.Clear();
                UpdateCopuon();

            }

        }

        //Miscellaneous
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = "time: " + DateTime.Now.ToString("HH:mm");
        }
       
    }
}
