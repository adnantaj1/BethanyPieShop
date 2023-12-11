using BethanyPieShop.InventoryManagement.Domain.Contracts;
using BethanyPieShop.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShop.InventoryManagement.Domain.ProductManagement
{
    public class BoxedProduct : Product, ISaveable 
    {
        private int amountPerBox;
        public int AmountPerBox
        {
            get
            {
                return amountPerBox;
            }
            set
            {
                amountPerBox = value;
            }
        }
        public BoxedProduct(int id, string name, string? description, Price price,
            int maxAmountInStock, int amountPerBox) : base(id, name, description, price,
                UnitType.PerBox, maxAmountInStock)
        {
            AmountPerBox = amountPerBox;
        }

        public override string DisplayDetailsFull()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Boxed Product \n");
            sb.Append($"{Id} {Name}\n{Description}\n{Price}\n{AmountInStock} item(s) in stock");

            if (IsBelowStockTreshold)
            {
                sb.Append($"\n !!STOCK LOW!!");
            }
            return sb.ToString();
        }

        public override void UseProduct(int items)
        {
            int smallestMutiple = 0;
            int batchSize;
            while(true)
            {
                smallestMutiple++;
                if (smallestMutiple * AmountPerBox > items) 
                {
                    batchSize = smallestMutiple * AmountPerBox;
                    break;
                }
            }
            base.UseProduct(batchSize);
        }

        public override void IncreaseStock()
        {
            IncreaseStock(1);
        }

        public override void IncreaseStock(int amount)
        {
            int newStock = AmountInStock + amount *AmountPerBox;

            if (newStock <= maxItemsInStock)
            {
                AmountInStock += amount *AmountPerBox;
            }
            else
            {
                AmountInStock = maxItemsInStock;//we only store the possible items, overstock isn't stored
                Log($"{CreateSimpleProductRepresentation} stock overflow. {newStock - AmountInStock} item(s) ordere that couldn't be stored.");
            }

            if (AmountInStock > StockTreshold)
            {
                IsBelowStockTreshold = false;
            }
        }

        public string CoverToStringForSaving()
        {
            return $"{Id};{Name};{Description};{maxItemsInStock};{Price.ItemPrice};{(int)
                Price.Currency};{(int)UnitType};1;{AmountPerBox};";
        }

        public override object Clone()
        {
            return new BoxedProduct(0,this.Name, this.Description,new Price()
            { ItemPrice = this.Price.ItemPrice, Currency = this.Price.Currency },
            this.maxItemsInStock, this.AmountPerBox);
        }
    }
}
