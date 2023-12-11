using BethanyPieShop.InventoryManagement.Domain.Contracts;
using BethanyPieShop.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BethanyPieShop.InventoryManagement.Domain.ProductManagement
{
    public class FreshProduct : Product, ISaveable
    {
        public DateTime ExpiryDateTime { get; set; }
        public string? StrorageInstruction { get; set; }    
        public FreshProduct(int id, string name, string? description, Price price, 
            UnitType unitType, int maxAmountInStock) : 
            base(id, name, description, price, unitType, maxAmountInStock)
        {
        }

        public override void IncreaseStock()
        {
            AmountInStock++;
        }

        public override string DisplayDetailsFull()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{Id} {Name}\n{Description}\n{Price}\n{AmountInStock} item(s) in stock");

            if (IsBelowStockTreshold)
            {
                sb.Append($"\n !!STOCK LOW!!");
            }

            sb.AppendLine("Storage instructions: " + StrorageInstruction);
            sb.AppendLine("Expiray Date: " + ExpiryDateTime.ToShortDateString);
            return sb.ToString();
        }

        public string CoverToStringForSaving()
        {
            return $"{Id};{Name};{Description};{maxItemsInStock};{Price.ItemPrice};{(int)
                Price.Currency};{(int)UnitType};2;";
        }

        public override object Clone()
        {
            return new FreshProduct(0, this.Name, this.Description, new Price()
            { ItemPrice = this.Price.ItemPrice, Currency = this.Price.Currency },
            this.UnitType,this.maxItemsInStock);
        }
    }
}
