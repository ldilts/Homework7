using DataAccess.SouthwindTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Class1
    {
        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update)]
        public static void UpdateProduct(long original_ProductId, string productName, decimal unitPrice, bool discontinued)
        {
            ProductsTableAdapter productsTableAdapter = new
            DataAccess.SouthwindTableAdapters.ProductsTableAdapter();
            productsTableAdapter.Update(productName, unitPrice, discontinued, original_ProductId);
        }
    }
}
