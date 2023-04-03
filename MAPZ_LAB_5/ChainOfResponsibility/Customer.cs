using System;
using System.Collections.Generic;
using System.Text;

namespace MAPZ_LAB_5.ChainOfResponsibility
{
    class Customer
    {
        public bool SimplePurchase { get; set; }
        public bool PurchaseAndMaintance { get; set; }
        public bool PurchaseWithDiscount { get; set; }
        public Farmer Farmer { get; set; }
        public Customer(bool sp, bool pm, bool pwd, Farmer farmer)
        {
            this.SimplePurchase = sp;
            this.PurchaseAndMaintance = pm;
            this.PurchaseWithDiscount = pwd;
            this.Farmer = farmer;
        }
    }
}
