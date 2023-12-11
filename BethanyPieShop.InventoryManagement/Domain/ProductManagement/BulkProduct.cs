﻿using BethanyPieShop.InventoryManagement.Domain.Contracts;
using BethanyPieShop.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShop.InventoryManagement.Domain.ProductManagement
{
    public class BulkProduct : Product, ISaveable
    {
        public BulkProduct(int id, string name, string? description, Price price, 
           int maxAmountInStock) : base(id, name, description, price, 
           UnitType.PerKg, maxAmountInStock)
        {
        }

        public override void IncreaseStock()
        {
            AmountInStock++;
        }

        public string CoverToStringForSaving()
        {
            return $"{Id};{Name};{Description};{maxItemsInStock};{Price.ItemPrice};{(int)
                Price.Currency};{(int)UnitType};3;";
        }

        public override object Clone()
        {
            return new BulkProduct(0, this.Name, this.Description, new Price()
            { ItemPrice = this.Price.ItemPrice, Currency = this.Price.Currency },
            this.maxItemsInStock);
        }
    }
}
