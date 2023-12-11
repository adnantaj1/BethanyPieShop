using BethanyPieShop.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShop.InventoryManagement.Domain.ProductManagement
{
    public class FreshBoxedProduct : BoxedProduct
    {
        public FreshBoxedProduct(int id, string name, string? description, Price price, 
            int maxAmountInStock, int amountPerBox) : 
            base(id, name, description, price, maxAmountInStock, amountPerBox)
        {
        }

        public void useFreshBoxedProduct( int items)
        {
            
        }
    }
}
