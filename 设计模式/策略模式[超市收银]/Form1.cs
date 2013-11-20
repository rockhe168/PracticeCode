using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 策略模式_超市收银_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cbxType.SelectedIndex = 0;
        }

        //总价格
        private double _totalPrice = 0d;
        private void btnOk_Click(object sender, EventArgs e)
        {
            //当前产品总价格
            double money = double.Parse(this.txtPrice.Text)*int.Parse(this.txtNumber.Text);

            //获取计算策略的抽象
            var cashContext = new CashContext(this.cbxType.SelectedItem.ToString());

            //获取策略计算的结果
            var realMoney = cashContext.GetResult(money);


            _totalPrice += realMoney;


            this.lsbInfomation.Items.Add(string.Format("单价：{0} 数量：{1} {2} 合计：{3}", this.txtPrice.Text, this.txtNumber.Text, cbxType.SelectedItem, realMoney.ToString(CultureInfo.InvariantCulture)));


            this.lblTotalPrice.Text = _totalPrice.ToString(CultureInfo.InvariantCulture);

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtPrice.Text = "0.00";
            this.txtNumber.Text = "1";
            this.cbxType.SelectedIndex = 0;
        }
    }
}
