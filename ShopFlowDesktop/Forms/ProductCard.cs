using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopFlowDesktop.Forms
{
    public partial class ProductCard : UserControl
    {
        public int ProductId { get; set; }
        public ProductCard()
        {
            InitializeComponent();
        }

        public void SetProduct(string name, decimal price, Image image)
        {
            lblName.Text = name;
            lblPrice.Text = $"₺{price}";
            picProduct.Image = image;
        }
    }
}
